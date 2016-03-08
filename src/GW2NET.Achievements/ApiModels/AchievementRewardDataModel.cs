﻿// <copyright file="AchievementRewardDataModel.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Achievements.ApiModels
{
    public class AchievementRewardDataModel
    {
        public string Type { get; set; }

        public int Id { get; set; }

        public int Count { get; set; }

        public string Region { get; set; }
    }
}