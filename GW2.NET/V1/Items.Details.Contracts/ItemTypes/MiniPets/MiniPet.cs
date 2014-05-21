﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MiniPet.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a mini pet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.MiniPets
{
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents a mini pet.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class MiniPet : Item
    {
        /// <summary>Initializes a new instance of the <see cref="MiniPet" /> class.</summary>
        public MiniPet()
            : base(ItemType.MiniPet, "minipet")
        {
        }
    }
}