﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilesResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.Files
{
    /// <summary>
    /// Represents a response that is the result of a <see cref="FilesRequest"/>.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/files"/> for more information.
    /// </remarks>
    [JsonConverter(typeof(FilesResponseConverter))]
    public class FilesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilesResponse"/> class.
        /// </summary>
        public FilesResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilesResponse"/> class using the specified collection of files.
        /// </summary>
        /// <param name="files">The collection of files.</param>
        public FilesResponse(Assets files)
        {
            this.Files = files;
        }

        /// <summary>
        /// Gets the collection of files.
        /// </summary>
        public Assets Files { get; private set; }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <returns>Returns a JSON <see cref="String"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}