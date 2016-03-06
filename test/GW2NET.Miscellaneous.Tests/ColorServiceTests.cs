﻿// <copyright file="Foo.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Miscellaneous
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;

    public class ColorServiceTests
    {
        [Fact]
        public async void DiscoverTest()
        {
            HttpClient client = new HttpClient(new HttpClientHandler(), false)
            {
                BaseAddress = new Uri("https://api.guildwars2.com/")
            };

            JsonSerializerFactory jsonSerializerFactory = new JsonSerializerFactory();
            GzipInflator gzipInflator = new GzipInflator();

            HttpResponseConverter responseConverter = new HttpResponseConverter(jsonSerializerFactory, jsonSerializerFactory, gzipInflator);

            IConverter<int, int> idConverter = new ConverterAdapter<int>();
            ColorPaletteConverter colorConverter = new ColorPaletteConverter(new ColorConverter(), new ColorModelConverter(new ColorConverter()));

            ColorRepository repository = new ColorRepository(client, responseConverter, new MemoryCache<int, ColorPalette>(), idConverter, colorConverter);

            IEnumerable<int> ids = await repository.DiscoverAsync();

            Assert.NotEmpty(ids);
        }

        [Fact]
        public async void ElementTest()
        {
            HttpClient client = new HttpClient(new HttpClientHandler(), false)
            {
                BaseAddress = new Uri("https://api.guildwars2.com/")
            };

            JsonSerializerFactory jsonSerializerFactory = new JsonSerializerFactory();
            GzipInflator gzipInflator = new GzipInflator();

            IResponseConverter responseConverter = new HttpResponseConverter(jsonSerializerFactory, jsonSerializerFactory, gzipInflator);

            IConverter<int, int> idConverter = new ConverterAdapter<int>();
            ColorPaletteConverter colorConverter = new ColorPaletteConverter(new ColorConverter(), new ColorModelConverter(new ColorConverter()));

            ColorRepository repository = new ColorRepository(client, responseConverter, new MemoryCache<int, ColorPalette>(), idConverter, colorConverter);

            ColorPalette color = await repository.GetAsync(10, CancellationToken.None);

            Assert.NotNull(color);
            Assert.Equal(color.ColorId, 10);
        }

        [Fact]
        public async void SetTest()
        {
            HttpClient client = new HttpClient(new HttpClientHandler(), false)
            {
                BaseAddress = new Uri("https://api.guildwars2.com/")
            };

            JsonSerializerFactory jsonSerializerFactory = new JsonSerializerFactory();
            GzipInflator gzipInflator = new GzipInflator();

            IResponseConverter responseConverter = new HttpResponseConverter(jsonSerializerFactory, jsonSerializerFactory, gzipInflator);

            IConverter<int, int> idConverter = new ConverterAdapter<int>();
            ColorPaletteConverter colorConverter = new ColorPaletteConverter(new ColorConverter(), new ColorModelConverter(new ColorConverter()));

            ColorRepository repository = new ColorRepository(client, responseConverter, new MemoryCache<int, ColorPalette>(), idConverter, colorConverter);

            IEnumerable<int> ids = (await repository.DiscoverAsync()).Take(400);
            List<ColorPalette> color = (await repository.GetAsync(ids, CancellationToken.None)).ToList();

            Assert.NotNull(color);
            Assert.True(color.Count == 400);
        }
    }
}