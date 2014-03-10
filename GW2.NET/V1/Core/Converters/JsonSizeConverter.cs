﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonSizeConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts a <see cref="Size" /> to and from its <see cref="System.String" /> representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.Converters
{
    using System;
    using System.Drawing;

    using GW2DotNET.Extensions;
    using GW2DotNET.Utilities;

    using Newtonsoft.Json;

    /// <summary>
    ///     Converts a <see cref="Size" /> to and from its <see cref="System.String" /> representation.
    /// </summary>
    public class JsonSizeConverter : JsonConverter
    {
        /// <summary>Determines whether this instance can convert the specified object type.</summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(Size?).IsAssignableFrom(objectType);
        }

        /// <summary>Reads the JSON representation of the object.</summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return objectType.CreateDefault();
            }

            var values = serializer.Deserialize<int[]>(reader);

            try
            {
                Preconditions.EnsureInRange(values.Length, 0, 2);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                throw new JsonSerializationException("The input specifies more than two dimensions.", exception);
            }

            switch (values.Length)
            {
                case 0:
                    return default(Size);
                case 1:
                    return new Size(values[0], values[0]);
                default:
                    return new Size(values[0], values[1]);
            }
        }

        /// <summary>Writes the JSON representation of the object.</summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var size = (Size)value;

            writer.WriteStartArray();
            {
                writer.WriteValue(size.Width);

                writer.WriteValue(size.Height);
            }

            writer.WriteEndArray();
        }
    }
}