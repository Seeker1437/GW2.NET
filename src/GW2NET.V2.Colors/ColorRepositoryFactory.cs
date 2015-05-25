﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ColorRepositoryFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Colors
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;

    using GW2NET.Colors;
    using GW2NET.Common;

    public sealed class ColorRepositoryFactory
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ColorRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ColorRepositoryFactory(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="language">The two-letter language code.</param>
        /// <returns>A repository.</returns>
        public IColorRepository this[string language]
        {
            get
            {
                Contract.Requires(language != null);
                Contract.Requires(language.Length == 2);
                Contract.Ensures(Contract.Result<IColorRepository>() != null);
                return this.ForCulture(new CultureInfo(language));
            }
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public IColorRepository this[CultureInfo culture]
        {
            get
            {
                Contract.Requires(culture != null);
                Contract.Ensures(Contract.Result<IColorRepository>() != null);
                return this.ForCulture(culture);
            }
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public IColorRepository ForDefaultCulture()
        {
            Contract.Ensures(Contract.Result<IColorRepository>() != null);
            return new ColorRepository(this.serviceClient);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public IColorRepository ForCulture(CultureInfo culture)
        {
            Contract.Ensures(Contract.Result<IColorRepository>() != null);
            IColorRepository repository = new ColorRepository(this.serviceClient);
            repository.Culture = culture;
            return repository;
        }

        /// <summary>Creates an instance for the current system language.</summary>
        /// <returns>A repository.</returns>
        public IColorRepository ForCurrentCulture()
        {
            Contract.Ensures(Contract.Result<IColorRepository>() != null);
            return this.ForCulture(CultureInfo.CurrentCulture);
        }

        /// <summary>Creates an instance for the current UI language.</summary>
        /// <param name="continentId">The continent identifier.</param>
        /// <returns>A repository.</returns>
        public IColorRepository ForCurrentUICulture(int continentId)
        {
            Contract.Ensures(Contract.Result<IColorRepository>() != null);
            return this.ForCulture(CultureInfo.CurrentUICulture);
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
        }
    }
}
