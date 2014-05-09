﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Gizmo.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a gizmo.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Gizmos
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents a gizmo.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class Gizmo : Item
    {
        /// <summary>Initializes a new instance of the <see cref="Gizmo" /> class.</summary>
        public Gizmo()
            : base(ItemType.Gizmo)
        {
        }

        /// <summary>Gets or sets the item details.</summary>
        [DataMember(Name = "gizmo", Order = 100)]
        [JsonConverter(typeof(GizmoDetailsConverter))]
        public new virtual GizmoDetails Details
        {
            get
            {
                return base.Details as GizmoDetails;
            }

            set
            {
                base.Details = value;
            }
        }
    }
}