﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingRecipeUnlocker.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a crafting recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Consumables.ConsumableTypes.UnlockTypes
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a crafting recipe.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class CraftingRecipeUnlocker : Unlocker
    {
        /// <summary>Initializes a new instance of the <see cref="CraftingRecipeUnlocker" /> class.</summary>
        public CraftingRecipeUnlocker()
            : base(UnlockType.CraftingRecipe)
        {
        }

        /// <summary>Gets or sets the crafting recipe's ID.</summary>
        [DataMember(Name = "recipe_id", Order = 10000)]
        public virtual int RecipeId { get; set; }
    }
}