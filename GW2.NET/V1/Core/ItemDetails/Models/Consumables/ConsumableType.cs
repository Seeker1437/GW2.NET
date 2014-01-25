﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsumableType.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Consumables
{
    /// <summary>
    /// Enumerates the possible consumable types.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ConsumableType
    {
        /// <summary>
        /// The 'Unknown' consumable type.
        /// </summary>
        [EnumMember(Value = "Unknown")]
        Unknown = 0,

        /// <summary>
        /// The 'Appearance Change' consumable type.
        /// </summary>
        [EnumMember(Value = "AppearanceChange")]
        AppearanceChange = 1 << 0,

        /// <summary>
        /// The 'Booze' consumable type.
        /// </summary>
        [EnumMember(Value = "Booze")]
        Booze = 1 << 1,

        /// <summary>
        /// The 'Contract NPC' consumable type.
        /// </summary>
        [EnumMember(Value = "ContractNpc")]
        ContractNPC = 1 << 2,

        /// <summary>
        /// The 'Food' consumable type.
        /// </summary>
        [EnumMember(Value = "Food")]
        Food = 1 << 3,

        /// <summary>
        /// The 'Generic' consumable type.
        /// </summary>
        [EnumMember(Value = "Generic")]
        Generic = 1 << 4,

        /// <summary>
        /// The 'Halloween' consumable type.
        /// </summary>
        [EnumMember(Value = "Halloween")]
        Halloween = 1 << 5,

        /// <summary>
        /// The 'Immediate' consumable type.
        /// </summary>
        [EnumMember(Value = "Immediate")]
        Immediate = 1 << 6,

        /// <summary>
        /// The 'Transmutation' consumable type.
        /// </summary>
        [EnumMember(Value = "Transmutation")]
        Transmutation = 1 << 7,

        /// <summary>
        /// The 'Unlock' consumable type.
        /// </summary>
        [EnumMember(Value = "Unlock")]
        Unlock = 1 << 8,

        /// <summary>
        /// The 'Utility' consumable type.
        /// </summary>
        [EnumMember(Value = "Utility")]
        Utility = 1 << 9
    }
}