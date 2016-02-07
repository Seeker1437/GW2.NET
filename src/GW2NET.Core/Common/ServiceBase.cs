namespace GW2NET.Common
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;

    using GW2NET.Caching;
    using GW2NET.Common.Converters;

    /// <summary>Contains methods and properties for repositories.</summary>
    /// <typeparam name="T">The type of objects used in the service.</typeparam>
    public abstract class ServiceBase<T>
    {
        /// <summary>Initializes a new instance of the <see cref="ServiceBase{T}"/> class.</summary>
        /// <param name="client">The <see cref="HttpClient"/> to make connections with the GW2 api.</param>
        /// <param name="responseConverter">The <see cref="ConverterExtensions"/> converting an <see cref="HttpResponseMessage"/> for further processing.</param>
        /// <param name="cache">The cache used to store objects.</param>
        protected ServiceBase(HttpClient client, HttpResponseConverter responseConverter, ICache<T> cache)
        {
            this.Client = client;
            this.ResponseConverter = responseConverter;
            this.Cache = cache;
        }

        /// <summary>Gets or sets the http client.</summary>
        public HttpClient Client { get; }

        /// <summary>Gets or sets the response converter.</summary>
        public HttpResponseConverter ResponseConverter { get; }

        /// <summary>Gets ot sets the cache used to retrieve not yet obsolete objects.</summary>
        public ICache<T> Cache { get; }

        protected IEnumerable<int> CalculatePageSizes(int queryCount)
        {
            if (queryCount <= 200)
            {
                return new List<int> { queryCount };
            }

            return new List<int> { 200 }.Concat(this.CalculatePageSizes(queryCount - 200));
        }
    }
}