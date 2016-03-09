﻿// <copyright file="InfixUpgrade.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Items.Common
{
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>Represents an item's infixed combat upgrades.</summary>
    public class InfixUpgrade
    {
        private static readonly CombatAttribute[] EmptyCombatAttributes = new CombatAttribute[0];

        private IEnumerable<CombatAttribute> attributes = EmptyCombatAttributes;

        /// <summary>Gets or sets the combat attribute modifiers.</summary>
        public virtual IEnumerable<CombatAttribute> Attributes
        {
            get
            {
                Debug.Assert(this.attributes != null, "this.attributes != null");
                return this.attributes;
            }

            set
            {
                this.attributes = value ?? EmptyCombatAttributes;
            }
        }

        /// <summary>Gets or sets the buff. This is used for Boon Duration, Condition Duration, or additional attribute bonuses for ascended trinkets or back items.</summary>
        public virtual CombatBuff Buff { get; set; }
    }
}