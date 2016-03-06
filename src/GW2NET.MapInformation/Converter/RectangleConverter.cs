// <copyright file="RectangleConverter.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.MapInformation.Converter
{
    using System;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;

    /// <summary>Converts objects of type <see cref="T:double[][]"/> to objects of type <see cref="Rectangle"/>.</summary>
    public sealed class RectangleConverter : IConverter<double[][], Rectangle>
    {
        private readonly IConverter<double[], Vector2D> vectorConverter;

        /// <summary>Initializes a new instance of the <see cref="RectangleConverter"/> class.</summary>
        /// <param name="vectorConverter">The vector converter.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="vectorConverter"/> is a null reference.</exception>
        public RectangleConverter(IConverter<double[], Vector2D> vectorConverter)
        {
            if (vectorConverter == null)
            {
                throw new ArgumentNullException(nameof(vectorConverter));
            }

            this.vectorConverter = vectorConverter;
        }

        /// <inheritdoc />
        public Rectangle Convert(double[][] value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value.Length != 2)
            {
                throw new ArgumentException("The array must contain exactly two elements.", nameof(value));
            }

            Vector2D vectorNorthWest = default(Vector2D);
            double[] coordiantes = value[0];
            if (coordiantes != null && coordiantes.Length == 2)
            {
                vectorNorthWest = this.vectorConverter.Convert(coordiantes, state);
            }

            Vector2D vectorSouthEast = default(Vector2D);
            coordiantes = value[1];
            if (coordiantes != null && coordiantes.Length == 2)
            {
                vectorSouthEast = this.vectorConverter.Convert(coordiantes, state);
            }

            return new Rectangle(vectorNorthWest, vectorSouthEast);
        }
    }
}