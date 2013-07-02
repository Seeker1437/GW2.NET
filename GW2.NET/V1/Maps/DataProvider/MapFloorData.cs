﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapFloorData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MapFloorData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;
using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.Maps.Models;

namespace GW2DotNET.V1.Maps.DataProvider
{
    /// <summary>The map floor data.</summary>
    public partial class MapFloorData
    {
        /// <summary>The manager.</summary>
        private readonly ApiManager manager;

        /// <summary>The map floors.</summary>
        private IList<MapFloor> mapFloors;

        /// <summary>
        /// Sync object for thread safety. You MUST lock this
        /// object before touching the private continentsCache object.
        /// </summary>
        private readonly object mapFloorsSyncObject = new object();

        /// <summary>Initializes a new instance of the <see cref="MapFloorData"/> class.</summary>
        /// <param name="manager">The manager.</param>
        public MapFloorData(ApiManager manager)
        {
            this.manager = manager;
        }

        /// <summary>Gets a map floor by it's continent and floor id.</summary>
        /// <param name="continentId">The continent id.</param>
        /// <param name="floor">The floor.</param>
        /// <returns>The <see cref="MapFloor"/>.</returns>
        public MapFloor this[int continentId, int floor]
        {
            get
            {
                lock (mapFloorsSyncObject)
                {
                    if (this.mapFloors == null)
                    {
                        this.mapFloors = new List<MapFloor>();
                    }

                    var args = new List<KeyValuePair<string, object>>
                        {
                            new KeyValuePair<string, object>("continent_id", continentId),
                            new KeyValuePair<string, object>("floor", floor),
                            new KeyValuePair<string, object>("lang", this.manager.Language)
                        };

                    var floorToReturn = ApiCall.GetContent<MapFloor>("map_floor.json", args, ApiCall.Categories.World);

                    this.mapFloors.Add(floorToReturn);

                    return floorToReturn;
                }
            }
        }

        /// <summary>
        /// Gets a map floor asynchronously.
        /// </summary>
        /// <param name="continentId"></param>
        /// <param name="floor"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<MapFloor> GetMapFloorAsync(int continentId, int floor, CancellationToken cancellationToken)
        {
            Func<MapFloor> methodCall = () => this[continentId, floor];

            return Task.Factory.StartNew(methodCall, cancellationToken);
        }
    }
}
