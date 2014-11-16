﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForTrinket.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDataContract" /> to objects of type <see cref="Trinket" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items.Converters
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Items.Common;
    using GW2NET.Items.Trinkets;
    using GW2NET.V2.Items.Json;

    /// <summary>Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="Trinket"/>.</summary>
    internal sealed class ConverterForTrinket : IConverter<DetailsDataContract, Trinket>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<InfixUpgradeDataContract, InfixUpgrade> converterForInfixUpgrade;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<InfusionSlotDataContract>, ICollection<InfusionSlot>> converterForInfusionSlotCollection;

        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<DetailsDataContract, Trinket>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForTrinket"/> class.</summary>
        public ConverterForTrinket()
            : this(GetKnownTypeConverters(), new ConverterForCollection<InfusionSlotDataContract, InfusionSlot>(new ConverterForInfusionSlot()), new ConverterForInfixUpgrade())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForTrinket"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        /// <param name="converterForInfusionSlotCollection">The converter for <see cref="ICollection{InfusionSlot}"/>.</param>
        /// <param name="converterForInfixUpgrade">The converter for <see cref="InfixUpgrade"/>.</param>
        public ConverterForTrinket(IDictionary<string, IConverter<DetailsDataContract, Trinket>> typeConverters, IConverter<ICollection<InfusionSlotDataContract>, ICollection<InfusionSlot>> converterForInfusionSlotCollection, IConverter<InfixUpgradeDataContract, InfixUpgrade> converterForInfixUpgrade)
        {
            Contract.Requires(converterForInfusionSlotCollection != null);
            Contract.Requires(converterForInfixUpgrade != null);
            this.converterForInfusionSlotCollection = converterForInfusionSlotCollection;
            this.converterForInfixUpgrade = converterForInfixUpgrade;
            this.typeConverters = typeConverters;
        }

        /// <summary>Converts the given object of type <see cref="DetailsDataContract"/> to an object of type <see cref="Trinket"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Trinket Convert(DetailsDataContract value)
        {
            Contract.Assume(value != null);
            Trinket trinket;
            IConverter<DetailsDataContract, Trinket> converter;
            if (this.typeConverters.TryGetValue(value.Type, out converter))
            {
                trinket = converter.Convert(value);
            }
            else
            {
                trinket = new UnknownTrinket();
            }

            var infusionSlotDataContracts = value.InfusionSlots;
            if (infusionSlotDataContracts != null)
            {
                trinket.InfusionSlots = this.converterForInfusionSlotCollection.Convert(infusionSlotDataContracts);
            }

            var infixUpgradeDataContract = value.InfixUpgrade;
            if (infixUpgradeDataContract != null)
            {
                trinket.InfixUpgrade = this.converterForInfixUpgrade.Convert(infixUpgradeDataContract);
            }

            trinket.SuffixItemId = value.SuffixItemId;

            int secondarySuffixItemId;
            if (int.TryParse(value.SecondarySuffixItemId, out secondarySuffixItemId))
            {
                trinket.SecondarySuffixItemId = secondarySuffixItemId;
            }

            return trinket;
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<DetailsDataContract, Trinket>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<DetailsDataContract, Trinket>>
            {
                { "Amulet", new ConverterForAmulet() }, 
                { "Accessory", new ConverterForAccessory() }, 
                { "Ring", new ConverterForRing() }, 
            };
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.typeConverters != null);
            Contract.Invariant(this.converterForInfusionSlotCollection != null);
            Contract.Invariant(this.converterForInfixUpgrade != null);
        }
    }
}