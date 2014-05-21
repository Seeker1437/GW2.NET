﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Shoulders.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about shoulder protection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Armors.ArmorTypes
{
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about shoulder protection.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class Shoulders : Armor
    {
        /// <summary>Initializes a new instance of the <see cref="Shoulders" /> class</summary>
        public Shoulders()
            : base(ArmorType.Shoulders)
        {
        }
    }
}