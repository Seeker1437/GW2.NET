﻿// <copyright file="CollectionConverter.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Common.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>Converts objects of type <see cref="ICollection{T}"/> to objects of type <see cref="ICollection{T}"/>.</summary>
    /// <typeparam name="TInput">The type of the input.</typeparam>
    /// <typeparam name="TOutput">The type of the output.</typeparam>
    public sealed class CollectionConverter<TInput, TOutput> : IConverter<IEnumerable<TInput>, IEnumerable<TOutput>>
    {
        private readonly IConverter<TInput, TOutput> collectionItemConverter;

        /// <summary>Initializes a new instance of the <see cref="CollectionConverter{TInput,TOutput}"/> class.</summary>
        /// <param name="collectionItemConverter">The converter for <typeparamref name="TOutput"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collectionItemConverter"/> is null.</exception>
        public CollectionConverter(IConverter<TInput, TOutput> collectionItemConverter)
        {
            if (collectionItemConverter == null)
            {
                throw new ArgumentNullException(nameof(collectionItemConverter));
            }

            this.collectionItemConverter = collectionItemConverter;
        }

        /// <inheritdoc />
        public IEnumerable<TOutput> Convert(IEnumerable<TInput> value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            List<TOutput> values = new List<TOutput>();
            values.AddRange(value.Select(item => this.collectionItemConverter.Convert(item, value)));
            return values;
        }
    }
}