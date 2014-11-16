﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForTool.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDataContract" /> to objects of type <see cref="Tool" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items.Converters
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Items.Tools;
    using GW2NET.V2.Items.Json;

    /// <summary>Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="Tool"/>.</summary>
    internal sealed class ConverterForTool : IConverter<DetailsDataContract, Tool>
    {
        /// <summary>Infrastructure. Holds a reference to type converters.</summary>
        private readonly IDictionary<string, IConverter<DetailsDataContract, Tool>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForTool"/> class.</summary>
        internal ConverterForTool()
            : this(GetKnownTypeConverters())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForTool"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        internal ConverterForTool(IDictionary<string, IConverter<DetailsDataContract, Tool>> typeConverters)
        {
            Contract.Requires(typeConverters != null);
            this.typeConverters = typeConverters;
        }

        /// <summary>Converts the given object of type <see cref="DetailsDataContract"/> to an object of type <see cref="Tool"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Tool Convert(DetailsDataContract value)
        {
            Contract.Assume(value != null);
            IConverter<DetailsDataContract, Tool> converterForTool;
            if (this.typeConverters.TryGetValue(value.Type, out converterForTool))
            {
                return converterForTool.Convert(value);
            }

            return new UnknownTool();
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static Dictionary<string, IConverter<DetailsDataContract, Tool>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<DetailsDataContract, Tool>>
            {
                { "Salvage", new ConverterForSalvageTool() }
            };
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.typeConverters != null);
        }
    }
}