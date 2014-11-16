﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForLoggingTool.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDataContract" /> to objects of type <see cref="LoggingTool" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items.Converters
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Items.GatheringTools;
    using GW2NET.V2.Items.Json;

    /// <summary>Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="LoggingTool"/>.</summary>
    internal sealed class ConverterForLoggingTool : IConverter<DetailsDataContract, LoggingTool>
    {
        /// <summary>Converts the given object of type <see cref="DetailsDataContract"/> to an object of type <see cref="LoggingTool"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public LoggingTool Convert(DetailsDataContract value)
        {
            Contract.Assume(value != null);
            return new LoggingTool();
        }
    }
}