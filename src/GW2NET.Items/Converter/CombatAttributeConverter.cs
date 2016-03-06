﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CombatAttributeConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="AttributeDTO" /> to objects of type <see cref="CombatAttribute" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Items.Converter
{
    using GW2NET.Items.ApiModels;

    public partial class CombatAttributeConverter
    {
        partial void Merge(CombatAttribute entity, AttributeDataModel dataModel, object state)
        {
            entity.Modifier = dataModel.Modifier;
        }
    }
}