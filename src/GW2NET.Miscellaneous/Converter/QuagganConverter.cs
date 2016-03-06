﻿// <copyright file="QuagganConverter.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Miscellaneous.Converter
{
    using System;

    using GW2NET.Common;
    using GW2NET.Miscellaneous.ApiModels;
    using GW2NET.Quaggans;

    /// <summary>Converts objects of type <see cref="QuagganDataContract"/> to objects of type <see cref="Quaggan"/>.</summary>
    public sealed class QuagganConverter : IConverter<QuagganDataContract, Quaggan>
    {
        /// <inheritdoc />
        public Quaggan Convert(QuagganDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return new Quaggan
            {
                Id = value.Id,
                Url = new Uri(value.Url, UriKind.Absolute)
            };
        }
    }
}