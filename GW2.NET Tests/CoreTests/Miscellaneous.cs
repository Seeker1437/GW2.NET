﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.Build;
using GW2DotNET.V1.Core.Colors;
using GW2DotNET.V1.Core.Colors.Models;
using GW2DotNET.V1.Core.Files;
using GW2DotNET.V1.Core.Files.Models;

using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests
{
    [TestFixture]
    class Miscellaneous
    {
        [Test]
        public void GetBuildNumber()
        {
            BuildRequest request = new BuildRequest();

            BuildResponse response = request.GetResponse(ApiClient.Create(new Version(1, 0))).DeserializeResponse();

            int build = response.BuildId;

            Assert.IsNotNull(build);

            Trace.WriteLine(string.Format("Build: {0}", build));
        }

        [Test]
        public void GetFiles()
        {
            FilesRequest filesRequest = new FilesRequest();

            FilesResponse filesResponse = filesRequest.GetResponse(ApiClient.Create(new Version(1, 0))).DeserializeResponse();

            Assets assets = filesResponse.Files;

            Assert.IsNotNull(assets);
            Assert.IsNotEmpty(assets);

            Trace.WriteLine(string.Format("Number of Assets: {0}", assets.Count));
        }
    }
}
