﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForGenericConsumable.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDataContract" /> to objects of type <see cref="GenericConsumable" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items.Converters
{
    using System;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Items.Consumables;
    using GW2NET.V2.Items.Json;

    /// <summary>Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="GenericConsumable"/>.</summary>
    internal sealed class ConverterForGenericConsumable : IConverter<DetailsDataContract, GenericConsumable>
    {
        /// <summary>Converts the given object of type <see cref="DetailsDataContract"/> to an object of type <see cref="GenericConsumable"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public GenericConsumable Convert(DetailsDataContract value)
        {
            Contract.Assume(value != null);
            var genericConsumable = new GenericConsumable();

            // Set the duration
            var duration = value.Duration;
            if (duration.HasValue)
            {
                genericConsumable.Duration = TimeSpan.FromMilliseconds(duration.Value);
            }

            // Set the effect description
            genericConsumable.Effect = value.Description;

            return genericConsumable;
        }
    }
}