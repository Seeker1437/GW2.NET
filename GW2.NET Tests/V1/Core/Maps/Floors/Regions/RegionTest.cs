﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegionTest.cs" company="">
//   
// </copyright>
// <summary>
//   The region test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Maps.Floors.Regions
{
    using System.Drawing;

    using GW2DotNET.V1.Core.Maps.Floors.Regions.Subregions;
    using GW2DotNET.V1.MapsFloors.Types.Regions.Subregions;

    using Newtonsoft.Json;

    using NUnit.Framework;

    using Region = GW2DotNET.V1.MapsFloors.Types.Regions.Region;

    /// <summary>The region test.</summary>
    [TestFixture]
    public class RegionTest
    {
        /// <summary>The region.</summary>
        private Region region;

        /// <summary>The initialize.</summary>
        [SetUp]
        public void Initialize()
        {
            const string input = "{\"name\":\"\",\"label_coord\":[],\"maps\":{}}";
            this.region = JsonConvert.DeserializeObject<Region>(input);
        }

        /// <summary>The region_ extension data is empty.</summary>
        [Test]
        [Category("map_floor.json")]
        [Category("ExtensionData")]
        public void Region_ExtensionDataIsEmpty()
        {
            Assert.IsEmpty(this.region.ExtensionData);
        }

        /// <summary>The region_ label coordinates reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void Region_LabelCoordinatesReflectsInput()
        {
            PointF expected = default(PointF);
            PointF actual = this.region.LabelCoordinates;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The region_ maps reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void Region_MapsReflectsInput()
        {
            var expected = new SubregionCollection();
            SubregionCollection actual = this.region.Maps;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>The region_ name reflects input.</summary>
        [Test]
        [Category("map_floor.json")]
        public void Region_NameReflectsInput()
        {
            string expected = string.Empty;
            string actual = this.region.Name;

            Assert.AreEqual(expected, actual);
        }
    }
}