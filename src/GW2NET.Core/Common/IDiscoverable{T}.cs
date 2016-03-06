﻿// <copyright file="IDiscoverable{T}.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Common
{
    /// <summary>Provides the interface to query objects from the Guild Wars 2 api.</summary>
    /// <typeparam name="T">The type of key used to identify items in the cache.</typeparam>
    public interface IDiscoverable<T> : IDiscoverable<T, T>
    {
    }
}
