﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfusionSlotFlagCollectionConverter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="InfusionSlotFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Items.Converter
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items.Common;

    /// <summary>
    ///     Converts objects of type <see cref="T:ICollection{string}" /> to objects of type
    ///     <see cref="InfusionSlotFlags" />.
    /// </summary>
    public sealed class InfusionSlotFlagCollectionConverter : IConverter<ICollection<string>, InfusionSlotFlags>
    {
        private readonly IConverter<string, InfusionSlotFlags> infusionSlotFlagConverter;

        /// <summary>Initializes a new instance of the <see cref="InfusionSlotFlagCollectionConverter" /> class.</summary>
        /// <param name="infusionSlotFlagConverter">The converter for <see cref="InfusionSlotFlags" />.</param>
        public InfusionSlotFlagCollectionConverter(IConverter<string, InfusionSlotFlags> infusionSlotFlagConverter)
        {
            if (infusionSlotFlagConverter == null)
            {
                throw new ArgumentNullException(nameof(infusionSlotFlagConverter));
            }

            this.infusionSlotFlagConverter = infusionSlotFlagConverter;
        }

        /// <summary>
        ///     Converts the given object of type <see cref="T:ICollection{string}" /> to an object of type
        ///     <see cref="InfusionSlotFlags" />.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public InfusionSlotFlags Convert(ICollection<string> value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var result = default(InfusionSlotFlags);
            foreach (var s in value)
            {
                result |= this.infusionSlotFlagConverter.Convert(s, state);
            }

            return result;
        }
    }
}