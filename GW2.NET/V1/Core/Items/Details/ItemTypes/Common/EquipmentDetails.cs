﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EquipmentDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a piece of combat equipment.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Common
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Core.Common;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a piece of combat equipment.</summary>
    public abstract class EquipmentDetails : JsonObject
    {
        /// <summary>Gets or sets the item's infix upgrade.</summary>
        [DataMember(Name = "infix_upgrade", Order = 101)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public InfixUpgrade InfixUpgrade { get; set; }

        /// <summary>Gets or sets the item's infusion slots.</summary>
        [DataMember(Name = "infusion_slots", Order = 100)]
        public InfusionSlotCollection InfusionSlots { get; set; }

        /// <summary>Gets or sets the item's suffix item's ID.</summary>
        [DataMember(Name = "suffix_item_id", Order = 102)]
        public int? SuffixItemId { get; set; }
    }
}