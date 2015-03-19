﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForContainerKey.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="GizmoDataContract" /> to objects of type <see cref="ContainerKey" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.Items;
using GW2NET.V1.Items.Json;

namespace GW2NET.V1.Items.Converters
{
    /// <summary>Converts objects of type <see cref="GizmoDataContract"/> to objects of type <see cref="ContainerKey"/>.</summary>
    internal sealed class ConverterForContainerKey : IConverter<GizmoDataContract, ContainerKey>
    {
        /// <summary>Converts the given object of type <see cref="GizmoDataContract"/> to an object of type <see cref="ContainerKey"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public ContainerKey Convert(GizmoDataContract value)
        {
            Contract.Assume(value != null);
            return new ContainerKey();
        }
    }
}