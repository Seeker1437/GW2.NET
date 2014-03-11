﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemRecipeTests.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ItemRecipeTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using GW2DotNET.V1;
using GW2DotNET.V1.Items.Models;
using GW2DotNET.V1.Items.Models.Items;

using NUnit.Framework;

namespace GW2DotNET_Tests
{
    /// <summary>
    /// The item recipe tests.
    /// </summary>
    [TestFixture]
    public class ItemRecipeTests
    {
        /// <summary>
        /// The item manager.
        /// </summary>
        private IDataManager dataManager;

        /// <summary>
        /// Runs before each test run.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.dataManager = new DataManager(GW2DotNET.V1.Infrastructure.Language.En);
        }

        /// <summary>
        /// Gets a recipe by id.
        /// </summary>
        [Test]
        public void GetRecipe()
        {
            Trace.WriteLine("Getting a single recipe from the server.");
            Trace.WriteLine(string.Empty);

            Trace.WriteLine("Starting stopwatch");
            Stopwatch stopwatch = Stopwatch.StartNew();

            Recipe recipe = this.dataManager.RecipeData.GetRecipeDetail(805);

            Trace.WriteLine("Stopping stopwatch");
            stopwatch.Stop();

            Assert.IsNotNull(recipe.OutputItemId);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Recipe Details: {0} (Crafts: {1})", recipe.Id, recipe.OutputItemId));
        }

        /// <summary>
        /// Gets a recipe by id asynchronously.
        /// </summary>
        [Test]
        public async void GetRecipeAsync()
        {
            Trace.WriteLine("Getting a single recipe from the server asynchronously.");
            Trace.WriteLine(string.Empty);

            Trace.WriteLine("Starting stopwatch");
            var stopwatch = Stopwatch.StartNew();

            Task<Recipe> task = this.dataManager.RecipeData.GetRecipeDetailAsync(805);
            task.Wait();

            Recipe recipe = await task;

            Trace.WriteLine("Stopping stopwatch");
            stopwatch.Stop();

            Assert.Greater(recipe.OutputItemId, 0);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Recipe Details: {0} (Crafts: {1})", recipe.Id, recipe.OutputItemId));
        }

        /// <summary>
        /// Gets all recipes from the server.
        /// !!WARNING!! This method will run about 15 minutes.
        /// Run at your own risk.
        /// </summary>
        [Test]
        public void GetRecipes()
        {
            Trace.WriteLine("Geting all recipes from the server.");
            Trace.WriteLine(string.Empty);

            Trace.WriteLine("Starting stopwatch");
            Stopwatch stopwatch = Stopwatch.StartNew();

            List<int> recipes = this.dataManager.RecipeData.GetRecipeIdList().ToList();

            Trace.WriteLine("Stopping stopwatch");
            stopwatch.Stop();

            Assert.IsNotEmpty(recipes);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total number of recipes: {0}", recipes.Count));
        }

        /// <summary>
        /// Gets all recipes from the server asynchronously.
        /// !!WARNING!! This method will run about 15 minutes.
        /// Run at your own risk.
        /// </summary>
        [Test]
        public async void GetRecipesAsync()
        {
            Trace.WriteLine("Geting all recipes from the server asynchronously.");
            Trace.WriteLine(string.Empty);

            Trace.WriteLine("Starting stopwatch");
            Stopwatch stopwatch = Stopwatch.StartNew();

            Task<IEnumerable<int>> task = this.dataManager.RecipeData.GetRecipeIdListAsync();
            task.Wait();

            List<int> recipes = (await task).ToList();

            Trace.WriteLine("Stopping stopwatch");
            stopwatch.Stop();

            Assert.IsNotEmpty(recipes);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total number of recipes: {0}", recipes.Count));
        }

        /// <summary>
        /// Gets all items from the server.
        /// !!!WARNING!!!: Running this method will take a long time.
        /// If you are running this test make sure to run it in a separate NUnit session.
        /// </summary> 
        [Test]
        public void GetItems()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            List<int> items = this.dataManager.ItemData.GetItemIdList().ToList();

            stopwatch.Stop();

            Assert.IsNotEmpty(items);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Recipe Details: {0}", items.Count));
        }

        /// <summary>
        /// Gets all items from the server asynchronously.
        /// !!!WARNING!!!: Running this method will take a long time.
        /// If you are running this test make sure to run it in a separate NUnit session.
        /// </summary> 
        [Test]
        public async void GetItemsAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            var task = this.dataManager.ItemData.GetItemDetailListAsync();
            task.Wait();

            var items = (await task).ToList();

            stopwatch.Stop();

            Assert.IsNotEmpty(items);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Recipe Details: {0}", items.Count));
        }

        /// <summary>
        /// Gets a single item from the server.
        /// </summary>
        [Test]
        public void GetItem()
        {
            var stopwatch = Stopwatch.StartNew();

            var item = this.dataManager.ItemData.GetItemDetail(23481);

            stopwatch.Stop();

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Recipe Details: {0}", item.Id));
        }

        /// <summary>
        /// Gets a single item from the server asynchronously.
        /// </summary>
        [Test]
        public async void GetItemAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            Task<Item> task = this.dataManager.ItemData.GetItemDetailAsync(23481);
            task.Wait();

            var item = await task;

            stopwatch.Stop();

            Assert.IsNotNullOrEmpty(item.Name);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Recipe Details: {0}", item.Id));
        }
    }
}