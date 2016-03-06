﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfusionSlotConverter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <summary>
//   Converts objects of type <see cref="InfusionSlotDTO" /> to objects of type <see cref="InfusionSlot" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Items.Converter
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items.ApiModels;
    using GW2NET.Items.Common;

    /// <summary>Converts objects of type <see cref="InfusionSlotDataModel" /> to objects of type <see cref="InfusionSlot" />.</summary>
    public sealed class InfusionSlotConverter : IConverter<InfusionSlotDataModel, InfusionSlot>
    {
        private readonly IConverter<ICollection<string>, InfusionSlotFlags> infusionSlotFlagCollectionConverter;

        /// <summary>Initializes a new instance of the <see cref="InfusionSlotConverter" /> class.</summary>
        /// <param name="infusionSlotFlagCollectionConverter">The converter for <see cref="InfusionSlotFlags" />.</param>
        public InfusionSlotConverter(
            IConverter<ICollection<string>, InfusionSlotFlags> infusionSlotFlagCollectionConverter)
        {
            if (infusionSlotFlagCollectionConverter == null)
            {
                throw new ArgumentNullException(nameof(infusionSlotFlagCollectionConverter));
            }

            this.infusionSlotFlagCollectionConverter = infusionSlotFlagCollectionConverter;
        }

        /// <summary>
        ///     Converts the given object of type <see cref="InfusionSlotDataModel" /> to an object of type
        ///     <see cref="InfusionSlot" />.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public InfusionSlot Convert(InfusionSlotDataModel value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var infusionSlot = new InfusionSlot { ItemId = value.ItemId };
            var flags = value.Flags;
            if (flags != null)
            {
                infusionSlot.Flags = this.infusionSlotFlagCollectionConverter.Convert(flags, state);
            }

            return infusionSlot;
        }
    }
}