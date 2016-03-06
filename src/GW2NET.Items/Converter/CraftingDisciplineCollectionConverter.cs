// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingDisciplineCollectionConverter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="CraftingDisciplines" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Items.Converter
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Recipes;

    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="CraftingDisciplines"/>.</summary>
    public sealed class CraftingDisciplineCollectionConverter : IConverter<ICollection<string>, CraftingDisciplines>
    {
        private readonly IConverter<string, CraftingDisciplines> craftingDisciplineConverter;

        /// <summary>Initializes a new instance of the <see cref="CraftingDisciplineCollectionConverter"/> class.</summary>
        /// <param name="craftingDisciplineConverter">The converter for <see cref="CraftingDisciplines"/></param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="craftingDisciplineConverter"/> is a null reference.</exception>
        public CraftingDisciplineCollectionConverter(IConverter<string, CraftingDisciplines> craftingDisciplineConverter)
        {
            if (craftingDisciplineConverter == null)
            {
                throw new ArgumentNullException(nameof(craftingDisciplineConverter));
            }

            this.craftingDisciplineConverter = craftingDisciplineConverter;
        }

        /// <inheritdoc />
        public CraftingDisciplines Convert(ICollection<string> value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            CraftingDisciplines result = default(CraftingDisciplines);
            foreach (var s in value)
            {
                result |= this.craftingDisciplineConverter.Convert(s, state);
            }

            return result;
        }
    }
}