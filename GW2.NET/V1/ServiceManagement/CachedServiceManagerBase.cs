﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CachedServiceManagerBase.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for service managers that are backed up by a cache.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ServiceManagement
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Core.Builds;
    using GW2DotNET.V1.Core.Common;
    using GW2DotNET.V1.Core.Continents;
    using GW2DotNET.V1.Core.DynamicEvents;
    using GW2DotNET.V1.Core.DynamicEvents.Details;
    using GW2DotNET.V1.Core.DynamicEvents.Names;
    using GW2DotNET.V1.Core.Files;
    using GW2DotNET.V1.Core.Guilds.Details;
    using GW2DotNET.V1.Core.Items.Details;
    using GW2DotNET.V1.Core.Maps;
    using GW2DotNET.V1.Core.Maps.Floors;
    using GW2DotNET.V1.Core.Maps.Names;
    using GW2DotNET.V1.Core.Recipes.Details;
    using GW2DotNET.V1.Core.Worlds.Names;
    using GW2DotNET.V1.Core.WorldVersusWorld.Matches;
    using GW2DotNET.V1.Core.WorldVersusWorld.Matches.Details;
    using GW2DotNET.V1.Core.WorldVersusWorld.Objectives.Names;

    using ColorPalette = GW2DotNET.V1.Core.Colors.ColorPalette;

    /// <summary>Provides the base class for service managers that are backed up by a cache.</summary>
    public abstract class CachedServiceManagerBase : ICachedServiceManager
    {
        /// <summary>Infrastructure. Stores the fallback service manager.</summary>
        private readonly IServiceManager fallbackServiceManager;

        /// <summary>Initializes a new instance of the <see cref="CachedServiceManagerBase"/> class.</summary>
        /// <param name="fallbackServiceManager">The fallback service manager.</param>
        protected CachedServiceManagerBase(IServiceManager fallbackServiceManager)
        {
            Preconditions.EnsureNotNull(paramName: "fallbackServiceManager", value: fallbackServiceManager);

            this.fallbackServiceManager = fallbackServiceManager;
        }

        /// <summary>Gets or sets the preferred language.</summary>
        public virtual CultureInfo PreferredLanguageInfo
        {
            get
            {
                return this.fallbackServiceManager.PreferredLanguageInfo;
            }

            set
            {
                this.fallbackServiceManager.PreferredLanguageInfo = value;
            }
        }

        /// <summary>Gets the fallback service manager.</summary>
        protected IServiceManager FallbackServiceManager
        {
            get
            {
                return this.fallbackServiceManager;
            }
        }

        /// <summary>Gets the current game build.</summary>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public virtual Build GetBuild()
        {
            try
            {
                return this.GetBuild(true);
            }
            catch
            {
                return this.FallbackServiceManager.GetBuild();
            }
        }

        /// <summary>Gets the current game build.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public abstract Build GetBuild(bool allowCache);

        /// <summary>Gets the current build.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public virtual Task<Build> GetBuildAsync(CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetBuildAsync(true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetBuildAsync(cancellationToken);
            }
        }

        /// <summary>Gets the current build.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public abstract Task<Build> GetBuildAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of colors in the game.</summary>
        /// <returns>The collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public virtual IEnumerable<ColorPalette> GetColors()
        {
            try
            {
                return this.GetColors(true);
            }
            catch
            {
                return this.FallbackServiceManager.GetColors();
            }
        }

        /// <summary>Gets the collection of colors in the game.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public abstract IEnumerable<ColorPalette> GetColors(bool allowCache);

        /// <summary>Gets the collection of colors in the game.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public virtual Task<IEnumerable<ColorPalette>> GetColorsAsync(CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetColorsAsync(true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetColorsAsync(cancellationToken);
            }
        }

        /// <summary>Gets the collection of colors in the game.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public abstract Task<IEnumerable<ColorPalette>> GetColorsAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of continents in the game.</summary>
        /// <returns>The collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public virtual IEnumerable<Continent> GetContinents()
        {
            try
            {
                return this.GetContinents(true);
            }
            catch
            {
                return this.FallbackServiceManager.GetContinents();
            }
        }

        /// <summary>Gets the collection of continents in the game.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public abstract IEnumerable<Continent> GetContinents(bool allowCache);

        /// <summary>Gets the collection of continents in the game.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public virtual Task<IEnumerable<Continent>> GetContinentsAsync(CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetContinentsAsync(true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetContinentsAsync(cancellationToken);
            }
        }

        /// <summary>Gets the collection of continents in the game.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public abstract Task<IEnumerable<Continent>> GetContinentsAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <returns>A collection of dynamic events.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public virtual IEnumerable<DynamicEventDetails> GetDynamicEventDetails()
        {
            try
            {
                return this.GetDynamicEventDetails(true);
            }
            catch
            {
                return this.FallbackServiceManager.GetDynamicEventDetails();
            }
        }

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public virtual IEnumerable<DynamicEventDetails> GetDynamicEventDetails(Guid eventId)
        {
            try
            {
                return this.GetDynamicEventDetails(eventId, true);
            }
            catch
            {
                return this.FallbackServiceManager.GetDynamicEventDetails(eventId);
            }
        }

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public abstract IEnumerable<DynamicEventDetails> GetDynamicEventDetails(bool allowCache);

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public abstract IEnumerable<DynamicEventDetails> GetDynamicEventDetails(Guid eventId, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public virtual Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(Guid eventId, CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetDynamicEventDetailsAsync(eventId, true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetDynamicEventDetailsAsync(eventId, cancellationToken);
            }
        }

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public virtual Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetDynamicEventDetailsAsync(true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetDynamicEventDetailsAsync(cancellationToken);
            }
        }

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public abstract Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(
            Guid eventId, 
            bool allowCache, 
            CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their details.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public abstract Task<IEnumerable<DynamicEventDetails>> GetDynamicEventDetailsAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of dynamic events and their localized name.</summary>
        /// <returns>The collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public virtual IEnumerable<DynamicEventName> GetDynamicEventNames()
        {
            try
            {
                return this.GetDynamicEventNames(true);
            }
            catch
            {
                return this.FallbackServiceManager.GetDynamicEventNames();
            }
        }

        /// <summary>Gets the collection of dynamic events and their localized name.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public abstract IEnumerable<DynamicEventName> GetDynamicEventNames(bool allowCache);

        /// <summary>Gets the collection of dynamic events and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public virtual Task<IEnumerable<DynamicEventName>> GetDynamicEventNamesAsync(CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetDynamicEventNamesAsync(true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetDynamicEventNamesAsync(cancellationToken);
            }
        }

        /// <summary>Gets the collection of dynamic events and their localized name.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public abstract Task<IEnumerable<DynamicEventName>> GetDynamicEventNamesAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public virtual IEnumerable<DynamicEvent> GetDynamicEvents()
        {
            try
            {
                return this.GetDynamicEvents(true);
            }
            catch
            {
                return this.FallbackServiceManager.GetDynamicEvents();
            }
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public abstract IEnumerable<DynamicEvent> GetDynamicEvents(bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public virtual Task<IEnumerable<DynamicEvent>> GetDynamicEventsAsync(CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetDynamicEventsAsync(true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetDynamicEventsAsync(cancellationToken);
            }
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public abstract Task<IEnumerable<DynamicEvent>> GetDynamicEventsAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public virtual IEnumerable<DynamicEvent> GetDynamicEventsById(Guid eventId)
        {
            try
            {
                return this.GetDynamicEventsById(eventId, true);
            }
            catch
            {
                return this.FallbackServiceManager.GetDynamicEventsById(eventId);
            }
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public virtual IEnumerable<DynamicEvent> GetDynamicEventsById(Guid eventId, int worldId)
        {
            try
            {
                return this.GetDynamicEventsById(eventId, worldId, true);
            }
            catch
            {
                return this.FallbackServiceManager.GetDynamicEventsById(eventId, worldId);
            }
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public abstract IEnumerable<DynamicEvent> GetDynamicEventsById(Guid eventId, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public abstract IEnumerable<DynamicEvent> GetDynamicEventsById(Guid eventId, int worldId, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public virtual Task<IEnumerable<DynamicEvent>> GetDynamicEventsByIdAsync(Guid eventId, CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetDynamicEventsByIdAsync(eventId, true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetDynamicEventsByIdAsync(eventId, cancellationToken);
            }
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public virtual Task<IEnumerable<DynamicEvent>> GetDynamicEventsByIdAsync(Guid eventId, int worldId, CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetDynamicEventsByIdAsync(eventId, worldId, true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetDynamicEventsByIdAsync(eventId, worldId, cancellationToken);
            }
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public abstract Task<IEnumerable<DynamicEvent>> GetDynamicEventsByIdAsync(Guid eventId, bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public abstract Task<IEnumerable<DynamicEvent>> GetDynamicEventsByIdAsync(
            Guid eventId, 
            int worldId, 
            bool allowCache, 
            CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public virtual IEnumerable<DynamicEvent> GetDynamicEventsByMap(int mapId)
        {
            try
            {
                return this.GetDynamicEventsByMap(mapId, true);
            }
            catch
            {
                return this.FallbackServiceManager.GetDynamicEventsByMap(mapId);
            }
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public virtual IEnumerable<DynamicEvent> GetDynamicEventsByMap(int mapId, int worldId)
        {
            try
            {
                return this.GetDynamicEventsByMap(mapId, worldId, true);
            }
            catch
            {
                return this.FallbackServiceManager.GetDynamicEventsByMap(mapId, worldId);
            }
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public abstract IEnumerable<DynamicEvent> GetDynamicEventsByMap(int mapId, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public abstract IEnumerable<DynamicEvent> GetDynamicEventsByMap(int mapId, int worldId, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public virtual Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId, CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetDynamicEventsByMapAsync(mapId, true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetDynamicEventsByMapAsync(mapId, cancellationToken);
            }
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public virtual Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId, int worldId, CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetDynamicEventsByMapAsync(mapId, worldId, true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetDynamicEventsByMapAsync(mapId, worldId, cancellationToken);
            }
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public abstract Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId, bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public abstract Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(
            int mapId, 
            int worldId, 
            bool allowCache, 
            CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public virtual IEnumerable<DynamicEvent> GetDynamicEventsByWorld(int worldId)
        {
            try
            {
                return this.GetDynamicEventsByWorld(worldId, true);
            }
            catch
            {
                return this.FallbackServiceManager.GetDynamicEventsByWorld(worldId);
            }
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public abstract IEnumerable<DynamicEvent> GetDynamicEventsByWorld(int worldId, bool allowCache);

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public virtual Task<IEnumerable<DynamicEvent>> GetDynamicEventsByWorldAsync(int worldId, CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetDynamicEventsByWorldAsync(worldId, true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetDynamicEventsByWorldAsync(worldId, cancellationToken);
            }
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public abstract Task<IEnumerable<DynamicEvent>> GetDynamicEventsByWorldAsync(int worldId, bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        public virtual IEnumerable<Asset> GetFiles()
        {
            try
            {
                return this.GetFiles(true);
            }
            catch
            {
                return this.FallbackServiceManager.GetFiles();
            }
        }

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        public abstract IEnumerable<Asset> GetFiles(bool allowCache);

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        public virtual Task<IEnumerable<Asset>> GetFilesAsync(CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetFilesAsync(true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetFilesAsync(cancellationToken);
            }
        }

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        public abstract Task<IEnumerable<Asset>> GetFilesAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public virtual Guild GetGuildDetails(Guid guildId)
        {
            try
            {
                return this.GetGuildDetails(guildId, true);
            }
            catch
            {
                return this.FallbackServiceManager.GetGuildDetails(guildId);
            }
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The guild's name.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public virtual Guild GetGuildDetails(string guildName)
        {
            try
            {
                return this.GetGuildDetails(guildName, true);
            }
            catch
            {
                return this.FallbackServiceManager.GetGuildDetails(guildName);
            }
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public abstract Guild GetGuildDetails(Guid guildId, bool allowCache);

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The guild's name.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public abstract Guild GetGuildDetails(string guildName, bool allowCache);

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public virtual Task<Guild> GetGuildDetailsAsync(Guid guildId, CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetGuildDetailsAsync(guildId, true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetGuildDetailsAsync(guildId, cancellationToken);
            }
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The guild's name.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public virtual Task<Guild> GetGuildDetailsAsync(string guildName, CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetGuildDetailsAsync(guildName, true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetGuildDetailsAsync(guildName, cancellationToken);
            }
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public abstract Task<Guild> GetGuildDetailsAsync(Guid guildId, bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The guild's name.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public abstract Task<Guild> GetGuildDetailsAsync(string guildName, bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image Format.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        public virtual Image GetImage(IRenderable file, ImageFormat imageFormat)
        {
            try
            {
                return this.GetImage(file, imageFormat, true);
            }
            catch
            {
                return this.FallbackServiceManager.GetImage(file, imageFormat);
            }
        }

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image Format.</param>
        /// <param name="allowCache">The allow Cache.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        public abstract Image GetImage(IRenderable file, ImageFormat imageFormat, bool allowCache);

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        public virtual Task<Image> GetImageAsync(IRenderable file, ImageFormat imageFormat, CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetImageAsync(file, imageFormat, true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetImageAsync(file, imageFormat, cancellationToken);
            }
        }

        /// <summary>Gets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <param name="allowCache">The allow Cache.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        public abstract Task<Image> GetImageAsync(IRenderable file, ImageFormat imageFormat, bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets an item and its details.</summary>
        /// <param name="itemId">The item's ID.</param>
        /// <returns>An item and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public virtual Item GetItemDetails(int itemId)
        {
            try
            {
                return this.GetItemDetails(itemId, true);
            }
            catch
            {
                return this.FallbackServiceManager.GetItemDetails(itemId);
            }
        }

        /// <summary>Gets an item and its details.</summary>
        /// <param name="itemId">The item's ID.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>An item and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public abstract Item GetItemDetails(int itemId, bool allowCache);

        /// <summary>Gets an item and its details.</summary>
        /// <param name="itemId">The item's ID.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An item and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public virtual Task<Item> GetItemDetailsAsync(int itemId, CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetItemDetailsAsync(itemId, true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetItemDetailsAsync(itemId, cancellationToken);
            }
        }

        /// <summary>Gets an item and its details.</summary>
        /// <param name="itemId">The item's ID.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>An item and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public abstract Task<Item> GetItemDetailsAsync(int itemId, bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of discovered items.</summary>
        /// <returns>The collection of discovered items.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public virtual IEnumerable<int> GetItems()
        {
            try
            {
                return this.GetItems(true);
            }
            catch
            {
                return this.FallbackServiceManager.GetItems();
            }
        }

        /// <summary>Gets the collection of discovered items.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The collection of discovered items.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public abstract IEnumerable<int> GetItems(bool allowCache);

        /// <summary>Gets the collection of discovered items.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of discovered items.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public virtual Task<IEnumerable<int>> GetItemsAsync(CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetItemsAsync(true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetItemsAsync(cancellationToken);
            }
        }

        /// <summary>Gets the collection of discovered items.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of discovered items.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public abstract Task<IEnumerable<int>> GetItemsAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <returns>A map floor and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public virtual Floor GetMapFloor(int continentId, int floor)
        {
            try
            {
                return this.GetMapFloor(continentId, floor, true);
            }
            catch
            {
                return this.FallbackServiceManager.GetMapFloor(continentId, floor);
            }
        }

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A map floor and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public abstract Floor GetMapFloor(int continentId, int floor, bool allowCache);

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public virtual Task<Floor> GetMapFloorAsync(int continentId, int floor, CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetMapFloorAsync(continentId, floor, true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetMapFloorAsync(continentId, floor, cancellationToken);
            }
        }

        /// <summary>Gets a map floor and its details.</summary>
        /// <param name="continentId">The continent.</param>
        /// <param name="floor">The map floor.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public abstract Task<Floor> GetMapFloorAsync(int continentId, int floor, bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of maps and their localized name.</summary>
        /// <returns>The collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public virtual IEnumerable<MapName> GetMapNames()
        {
            try
            {
                return this.GetMapNames(true);
            }
            catch
            {
                return this.FallbackServiceManager.GetMapNames();
            }
        }

        /// <summary>Gets the collection of maps and their localized name.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public abstract IEnumerable<MapName> GetMapNames(bool allowCache);

        /// <summary>Gets the collection of maps and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public virtual Task<IEnumerable<MapName>> GetMapNamesAsync(CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetMapNamesAsync(true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetMapNamesAsync(cancellationToken);
            }
        }

        /// <summary>Gets the collection of maps and their localized name.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public abstract Task<IEnumerable<MapName>> GetMapNamesAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public virtual IEnumerable<Map> GetMaps()
        {
            try
            {
                return this.GetMaps(true);
            }
            catch
            {
                return this.FallbackServiceManager.GetMaps();
            }
        }

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public virtual IEnumerable<Map> GetMaps(int mapId)
        {
            try
            {
                return this.GetMaps(mapId, true);
            }
            catch
            {
                return this.FallbackServiceManager.GetMaps(mapId);
            }
        }

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public abstract IEnumerable<Map> GetMaps(bool allowCache);

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public abstract IEnumerable<Map> GetMaps(int mapId, bool allowCache);

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public virtual Task<IEnumerable<Map>> GetMapsAsync(int mapId, CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetMapsAsync(mapId, true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetMapsAsync(mapId, cancellationToken);
            }
        }

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public virtual Task<IEnumerable<Map>> GetMapsAsync(CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetMapsAsync(true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetMapsAsync(cancellationToken);
            }
        }

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public abstract Task<IEnumerable<Map>> GetMapsAsync(int mapId, bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public abstract Task<IEnumerable<Map>> GetMapsAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public virtual MatchDetails GetMatchDetails(string matchId)
        {
            try
            {
                return this.GetMatchDetails(matchId, true);
            }
            catch
            {
                return this.FallbackServiceManager.GetMatchDetails(matchId);
            }
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public abstract MatchDetails GetMatchDetails(string matchId, bool allowCache);

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public virtual Task<MatchDetails> GetMatchDetailsAsync(string matchId, CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetMatchDetailsAsync(matchId, true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetMatchDetailsAsync(matchId, cancellationToken);
            }
        }

        /// <summary>Gets a World versus World match and its details.</summary>
        /// <param name="matchId">The match.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A World versus World match and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public abstract Task<MatchDetails> GetMatchDetailsAsync(string matchId, bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of currently running World versus World matches.</summary>
        /// <returns>The collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        public virtual IEnumerable<Match> GetMatches()
        {
            try
            {
                return this.GetMatches(true);
            }
            catch
            {
                return this.FallbackServiceManager.GetMatches();
            }
        }

        /// <summary>Gets the collection of currently running World versus World matches.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        public abstract IEnumerable<Match> GetMatches(bool allowCache);

        /// <summary>Gets the collection of currently running World versus World matches.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        public virtual Task<IEnumerable<Match>> GetMatchesAsync(CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetMatchesAsync(true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetMatchesAsync(cancellationToken);
            }
        }

        /// <summary>Gets the collection of currently running World versus World matches.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of currently running World versus World matches.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        public abstract Task<IEnumerable<Match>> GetMatchesAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of World versus World objectives and their localized name.</summary>
        /// <returns>The collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public virtual IEnumerable<ObjectiveName> GetObjectiveNames()
        {
            try
            {
                return this.GetObjectiveNames(true);
            }
            catch
            {
                return this.FallbackServiceManager.GetObjectiveNames();
            }
        }

        /// <summary>Gets the collection of World versus World objectives and their localized name.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public abstract IEnumerable<ObjectiveName> GetObjectiveNames(bool allowCache);

        /// <summary>Gets the collection of World versus World objectives and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public virtual Task<IEnumerable<ObjectiveName>> GetObjectiveNamesAsync(CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetObjectiveNamesAsync(true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetObjectiveNamesAsync(cancellationToken);
            }
        }

        /// <summary>Gets the collection of World versus World objectives and their localized name.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public abstract Task<IEnumerable<ObjectiveName>> GetObjectiveNamesAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipeId">The recipe.</param>
        /// <returns>A recipe and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public virtual Recipe GetRecipeDetails(int recipeId)
        {
            try
            {
                return this.GetRecipeDetails(recipeId, true);
            }
            catch
            {
                return this.FallbackServiceManager.GetRecipeDetails(recipeId);
            }
        }

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipeId">The recipe.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A recipe and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public abstract Recipe GetRecipeDetails(int recipeId, bool allowCache);

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipeId">The recipe.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public virtual Task<Recipe> GetRecipeDetailsAsync(int recipeId, CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetRecipeDetailsAsync(recipeId, true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetRecipeDetailsAsync(recipeId, cancellationToken);
            }
        }

        /// <summary>Gets a recipe and its details.</summary>
        /// <param name="recipeId">The recipe.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public abstract Task<Recipe> GetRecipeDetailsAsync(int recipeId, bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of discovered recipes.</summary>
        /// <returns>The collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public virtual IEnumerable<int> GetRecipes()
        {
            try
            {
                return this.GetRecipes(true);
            }
            catch
            {
                return this.FallbackServiceManager.GetRecipes();
            }
        }

        /// <summary>Gets the collection of discovered recipes.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public abstract IEnumerable<int> GetRecipes(bool allowCache);

        /// <summary>Gets the collection of discovered recipes.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public virtual Task<IEnumerable<int>> GetRecipesAsync(CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetRecipesAsync(true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetRecipesAsync(cancellationToken);
            }
        }

        /// <summary>Gets the collection of discovered recipes.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public abstract Task<IEnumerable<int>> GetRecipesAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of worlds and their localized name.</summary>
        /// <returns>The collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public virtual IEnumerable<WorldName> GetWorldNames()
        {
            try
            {
                return this.GetWorldNames(true);
            }
            catch
            {
                return this.FallbackServiceManager.GetWorldNames();
            }
        }

        /// <summary>Gets the collection of worlds and their localized name.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public abstract IEnumerable<WorldName> GetWorldNames(bool allowCache);

        /// <summary>Gets the collection of worlds and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public virtual Task<IEnumerable<WorldName>> GetWorldNamesAsync(CancellationToken? cancellationToken = null)
        {
            try
            {
                return this.GetWorldNamesAsync(true, cancellationToken);
            }
            catch
            {
                return this.FallbackServiceManager.GetWorldNamesAsync(cancellationToken);
            }
        }

        /// <summary>Gets the collection of worlds and their localized name.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public abstract Task<IEnumerable<WorldName>> GetWorldNamesAsync(bool allowCache, CancellationToken? cancellationToken = null);

        /// <summary>Sets the current game build.</summary>
        /// <param name="build">The build.</param>
        public abstract void SetBuild(Build build);

        /// <summary>Sets the current game build.</summary>
        /// <param name="build">The build.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public abstract Task SetBuildAsync(Build build, CancellationToken? cancellationToken = null);

        /// <summary>Sets the collection of colors in the game.</summary>
        /// <param name="colors">The colors.</param>
        public abstract void SetColors(IEnumerable<ColorPalette> colors);

        /// <summary>Sets the collection of colors in the game.</summary>
        /// <param name="colors">The colors.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public abstract Task SetColorsAsync(IEnumerable<ColorPalette> colors, CancellationToken? cancellationToken = null);

        /// <summary>Sets the collection of continents in the game.</summary>
        /// <param name="continents">The collection of continents.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public abstract void SetContinents(IEnumerable<Continent> continents);

        /// <summary>Sets the collection of continents in the game.</summary>
        /// <param name="continents">The collection of continents.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        public abstract Task SetContinentsAsync(IEnumerable<Continent> continents, CancellationToken? cancellationToken = null);

        /// <summary>Sets a collection of dynamic events and their details.</summary>
        /// <param name="dynamicEventDetails">A collection of dynamic events.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public abstract void SetDynamicEventDetails(IEnumerable<DynamicEventDetails> dynamicEventDetails);

        /// <summary>Sets a collection of dynamic events and their details.</summary>
        /// <param name="dynamicEventDetails">A collection of dynamic events.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        public abstract Task SetDynamicEventDetailsAsync(IEnumerable<DynamicEventDetails> dynamicEventDetails, CancellationToken? cancellationToken = null);

        /// <summary>Sets the collection of dynamic events and their localized name.</summary>
        /// <param name="dynamicEventNames">The collection of dynamic events and their localized name.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public abstract void SetDynamicEventNames(IEnumerable<DynamicEventName> dynamicEventNames);

        /// <summary>Sets the collection of dynamic events and their localized name.</summary>
        /// <param name="dynamicEventNames">The collection of dynamic events and their localized name.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        public abstract Task SetDynamicEventNamesAsync(IEnumerable<DynamicEventName> dynamicEventNames, CancellationToken? cancellationToken = null);

        /// <summary>Sets a collection of dynamic events and their status.</summary>
        /// <param name="dynamicEvents">A collection of dynamic events and their status.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public abstract void SetDynamicEvents(IEnumerable<DynamicEvent> dynamicEvents);

        /// <summary>Sets a collection of dynamic events and their status.</summary>
        /// <param name="dynamicEvents">A collection of dynamic events and their status.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        public abstract Task SetDynamicEventsAsync(IEnumerable<DynamicEvent> dynamicEvents, CancellationToken? cancellationToken = null);

        /// <summary>Sets a collection of commonly requested in-game assets.</summary>
        /// <param name="assets">A collection of commonly requested in-game assets.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        public abstract void SetFiles(IEnumerable<Asset> assets);

        /// <summary>Sets a collection of commonly requested in-game assets.</summary>
        /// <param name="assets">A collection of commonly requested in-game assets.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        public abstract Task SetFilesAsync(IEnumerable<Asset> assets, CancellationToken? cancellationToken = null);

        /// <summary>Sets a guild and its details.</summary>
        /// <param name="guild">A guild and its details.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public abstract void SetGuildDetails(Guild guild);

        /// <summary>Sets a guild and its details.</summary>
        /// <param name="guild">A guild and its details.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        public abstract Task SetGuildDetailsAsync(Guild guild, CancellationToken? cancellationToken = null);

        /// <summary>Sets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="image">The image.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        public abstract Image SetImage(IRenderable file, Image image);

        /// <summary>Sets an image.</summary>
        /// <param name="file">The file.</param>
        /// <param name="image">The image.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:Render_service">wiki</a> for more information.</remarks>
        public abstract Task<Image> SetImageAsync(IRenderable file, Image image, CancellationToken? cancellationToken = null);

        /// <summary>Sets an item and its details.</summary>
        /// <param name="item">An item and its details.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        public abstract void SetItemDetails(Item item);

        /// <summary>Sets an item and its details.</summary>
        /// <param name="item">An item and its details.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        public abstract Task SetItemDetailsAsync(Item item, CancellationToken? cancellationToken = null);

        /// <summary>Sets the collection of discovered items.</summary>
        /// <param name="items">The collection of discovered items.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        public abstract void SetItems(IEnumerable<int> items);

        /// <summary>Sets the collection of discovered items.</summary>
        /// <param name="items">The collection of discovered items.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/items">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        public abstract Task SetItemsAsync(IEnumerable<int> items, CancellationToken? cancellationToken = null);

        /// <summary>Sets a map floor and its details.</summary>
        /// <param name="floor">A map floor and its details.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public abstract void SetMapFloor(Floor floor);

        /// <summary>Sets a map floor and its details.</summary>
        /// <param name="floor">A map floor and its details.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        public abstract Task SetMapFloorAsync(Floor floor, CancellationToken? cancellationToken = null);

        /// <summary>Sets the collection of maps and their localized name.</summary>
        /// <param name="mapNames">The collection of maps and their localized name.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public abstract void SetMapNames(IEnumerable<MapName> mapNames);

        /// <summary>Sets the collection of maps and their localized name.</summary>
        /// <param name="mapNames">The collection of maps and their localized name.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        public abstract Task SetMapNamesAsync(IEnumerable<MapName> mapNames, CancellationToken? cancellationToken = null);

        /// <summary>Sets a collection of maps and their details.</summary>
        /// <param name="maps">A collection of maps and their details.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public abstract void SetMaps(IEnumerable<Map> maps);

        /// <summary>Sets a collection of maps and their details.</summary>
        /// <param name="maps">A collection of maps and their details.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        public abstract Task SetMapsAsync(IEnumerable<Map> maps, CancellationToken? cancellationToken = null);

        /// <summary>Sets a World versus World match and its details.</summary>
        /// <param name="matchDetails">A World versus World match and its details</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        public abstract void SetMatchDetails(MatchDetails matchDetails);

        /// <summary>Sets a World versus World match and its details.</summary>
        /// <param name="matchDetails">A World versus World match and its details</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/match_details">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        public abstract Task SetMatchDetailsAsync(MatchDetails matchDetails, CancellationToken? cancellationToken = null);

        /// <summary>Sets the collection of currently running World versus World matches.</summary>
        /// <param name="matches">The collection of currently running World versus World matches..</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        public abstract void SetMatches(IEnumerable<Match> matches);

        /// <summary>Sets the collection of currently running World versus World matches.</summary>
        /// <param name="matches">The collection of currently running World versus World matches..</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/matches">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        public abstract Task SetMatchesAsync(IEnumerable<Match> matches, CancellationToken? cancellationToken = null);

        /// <summary>Sets the collection of World versus World objectives and their localized name.</summary>
        /// <param name="objectiveNames">The collection of World versus World objectives and their localized name.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public abstract void SetObjectiveNames(IEnumerable<ObjectiveName> objectiveNames);

        /// <summary>Sets the collection of World versus World objectives and their localized name.</summary>
        /// <param name="objectiveNames">The collection of World versus World objectives and their localized name.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        public abstract Task SetObjectiveNamesAsync(IEnumerable<ObjectiveName> objectiveNames, CancellationToken? cancellationToken = null);

        /// <summary>Sets a recipe and its details.</summary>
        /// <param name="recipe">The recipe.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public abstract void SetRecipeDetails(Recipe recipe);

        /// <summary>Sets a recipe and its details.</summary>
        /// <param name="recipe">The recipe.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        public abstract Task SetRecipeDetailsAsync(Recipe recipe, CancellationToken? cancellationToken = null);

        /// <summary>Sets the collection of discovered recipes.</summary>
        /// <param name="recipes">The collection of discovered recipes.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public abstract void SetRecipes(IEnumerable<int> recipes);

        /// <summary>Sets the collection of discovered recipes.</summary>
        /// <param name="recipes">The collection of discovered recipes.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        public abstract Task SetRecipesAsync(IEnumerable<int> recipes, CancellationToken? cancellationToken = null);

        /// <summary>Gets the collection of worlds and their localized name.</summary>
        /// <param name="worldNames">The collection of worlds and their localized name.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public abstract void SetWorldNames(IEnumerable<WorldName> worldNames);

        /// <summary>Gets the collection of worlds and their localized name.</summary>
        /// <param name="worldNames">The collection of worlds and their localized name.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        /// <returns>The <see cref="Task"/>.</returns>
        public abstract Task SetWorldNamesAsync(IEnumerable<WorldName> worldNames, CancellationToken? cancellationToken = null);
    }
}