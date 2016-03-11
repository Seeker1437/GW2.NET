﻿// <copyright file="PartialCollection{T}.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Common
{
    using System.Collections.ObjectModel;

    /// <summary>Represents the slice of a bigger collection.</summary>
    /// <typeparam name="T">The type of the collection</typeparam>
    public class PartialCollection<T> : Collection<T>, IPartialCollection<T>
    {
        public int TotalCount { get; set; }
    }
}
