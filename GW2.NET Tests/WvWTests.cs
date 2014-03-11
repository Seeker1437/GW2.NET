﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WvWTests.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the WvWTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;
using System.Threading.Tasks;

using GW2DotNET.V1;

using NUnit.Framework;

namespace GW2DotNET_Tests
{
    /// <summary>
    /// The wvw tests.
    /// </summary>
    [TestFixture]
    public class WvWTests
    {
        /// <summary>
        /// The wvw manager.
        /// </summary>
        private IDataManager manager;

        /// <summary>
        /// Runs before each test run
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.manager = new DataManager(GW2DotNET.V1.Infrastructure.Language.En);
        }

        /// <summary>
        /// Gets all matches from the api.
        /// </summary>
        [Test]
        public void GetMatchList()
        {
            var stopwatch = Stopwatch.StartNew();

            var matchList = this.manager.WvWData.GetMatchList();

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total Number of Matches: {0}", matchList.Count));
        }

        /// <summary>The get match list async.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        [Test]
        public async Task GetMatchListAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            var matchList = await this.manager.WvWData.GetMatchListAsync();

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total Number of Matches: {0}", matchList.Count));
        }

        /// <summary>
        /// Gets a single match from the api.
        /// </summary>
        [Test]
        public void GetSingleMatch()
        {
            var stopwatch = Stopwatch.StartNew();

            var singleMatch = this.manager.WvWData.GetSingleMatch("1-1");

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Match Id: {0}", singleMatch.MatchId));
        }

        /// <summary>Gets a single match from the api asynchronously.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        [Test]
        public async Task GetSingleMatchAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            var singleMatch = await this.manager.WvWData.GetSingleMatchAsync("1-1");

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Match Id: {0}", singleMatch.MatchId));
        }
    }
}