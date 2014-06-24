﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Gloves.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about arm protection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Armors.ArmorTypes
{
    using GW2DotNET.Common;

    /// <summary>Represents detailed information about arm protection.</summary>
    [TypeDiscriminator(Value = "Gloves", BaseType = typeof(Armor))]
    public class Gloves : Armor
    {
    }
}