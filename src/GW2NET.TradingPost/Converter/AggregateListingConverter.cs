﻿// <copyright file="AggregateListingConverter.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.TradingPost.Converter
{
    using System;

    using GW2NET.Commerce;
    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.TradingPost.ApiModels;

    /// <summary>Converts objects of type <see cref="AggregateListingDataModel"/> to objects of type <see cref="AggregateListing"/>.</summary>
    public sealed class AggregateListingConverter : IConverter<AggregateListingDataModel, AggregateListing>
    {
        private readonly IConverter<AggregateOfferDataModel, AggregateOffer> aggregateOfferConverter;

        /// <summary>Initializes a new instance of the <see cref="AggregateListingConverter"/> class.</summary>
        /// <param name="aggregateOfferConverter">The converter for <see cref="AggregateOffer"/>.</param>
        public AggregateListingConverter(IConverter<AggregateOfferDataModel, AggregateOffer> aggregateOfferConverter)
        {
            if (aggregateOfferConverter == null)
            {
                throw new ArgumentNullException(nameof(aggregateOfferConverter));
            }

            this.aggregateOfferConverter = aggregateOfferConverter;
        }

        /// <inheritdoc />
        public AggregateListing Convert(AggregateListingDataModel value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            ApiMetadata response = state as ApiMetadata;
            if (response == null)
            {
                throw new ArgumentException("Could not cast to ApiMetadata", nameof(state));
            }

            AggregateListing aggregateListing = new AggregateListing
            {
                ItemId = value.Id,
                Timestamp = response.RequestDate,
                Whitelisted = value.Whitelisted
            };
            if (value.BuyOffers != null)
            {
                aggregateListing.BuyOffers = this.aggregateOfferConverter.Convert(value.BuyOffers, value);
            }

            if (value.SellOffers != null)
            {
                aggregateListing.SellOffers = this.aggregateOfferConverter.Convert(value.SellOffers, value);
            }

            return aggregateListing;
        }
    }
}