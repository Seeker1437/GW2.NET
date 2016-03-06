﻿// <copyright file="GatheringToolSkinConverterFactory.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Factories.V2
{
    using System.Diagnostics;
    using Common;

    using GW2NET.Items.ApiModels;
    using GW2NET.Items.Converter;

    using Skins;

    public class GatheringToolSkinConverterFactory : ITypeConverterFactory<SkinDataModel, GatheringToolSkin>
    {
        public IConverter<SkinDataModel, GatheringToolSkin> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "Foraging":
                    return new ForagingToolSkinConverter();
                case "Logging":
                    return new LoggingToolSkinConverter();
                case "Mining":
                    return new MiningToolSkinConverter();
                default:
                    Debug.Assert(false, "Unknown type discriminator: " + discriminator);
                    return new UnknownGatheringToolSkinConverter();
            }
        }
    }
}
