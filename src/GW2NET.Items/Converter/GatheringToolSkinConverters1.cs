﻿//---------------------------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
// <copyright file="SkinDataContract.cs" company="GW2.NET Coding Team">
//     This product is licensed under the GNU General Public License version 2 (GPLv2).
//     See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
//---------------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Items.Converter
{
    using System;

    using GW2NET.Common;
	using GW2NET.Items.ApiModels;
	using GW2NET.Skins;

    public sealed partial class GatheringToolSkinConverter : IConverter<SkinDataModel, GatheringToolSkin>
	{
	    private readonly ITypeConverterFactory<SkinDataModel, GatheringToolSkin> converterFactory;

		public GatheringToolSkinConverter(ITypeConverterFactory<SkinDataModel, GatheringToolSkin> converterFactory)
		{
		    if (converterFactory == null)
    		{
    		    throw new ArgumentNullException("converterFactory");
    		}

		    this.converterFactory = converterFactory;
		}

		 /// <inheritdoc />
        public GatheringToolSkin Convert(SkinDataModel value, object state)
		{
		    if (value == null)
    		{
    		    throw new ArgumentNullException("value");
    		}

			string discriminator = value.Details.Type;
			var converter = this.converterFactory.Create(discriminator);
			var entity = converter.Convert(value, value);
			this.Merge(entity, value, state);
			return entity;
		}

		// Implement this method in a buddy class to set properties that are specific to 'GatheringToolSkin' (if any)
    	partial void Merge(GatheringToolSkin entity, SkinDataModel dto, object state);

		/*
		// Use this template
		public partial class GatheringToolSkinConverter
		{
		    partial void Merge(GatheringToolSkin entity, SkinDataModel dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
	}

#region ForagingToolSkin
    /// <summary>Converts objects of type <see cref="SkinDataModel"/> to objects of type <see cref="ForagingToolSkin"/>.</summary>
    public sealed partial class ForagingToolSkinConverter : IConverter<SkinDataModel, GatheringToolSkin>
    {
	    /// <inheritdoc />
        public GatheringToolSkin Convert(SkinDataModel value, object state)
        {
    		var entity = new ForagingToolSkin();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'ForagingToolSkin' (if any)
    	partial void Merge(ForagingToolSkin entity, SkinDataModel dto, object state);

		/*
		// Use this template
		public partial class ForagingToolSkinConverter
		{
		    partial void Merge(ForagingToolSkin entity, SkinDataModel dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region LoggingToolSkin
    /// <summary>Converts objects of type <see cref="SkinDataModel"/> to objects of type <see cref="LoggingToolSkin"/>.</summary>
    public sealed partial class LoggingToolSkinConverter : IConverter<SkinDataModel, GatheringToolSkin>
    {
	    /// <inheritdoc />
        public GatheringToolSkin Convert(SkinDataModel value, object state)
        {
    		var entity = new LoggingToolSkin();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'LoggingToolSkin' (if any)
    	partial void Merge(LoggingToolSkin entity, SkinDataModel dto, object state);

		/*
		// Use this template
		public partial class LoggingToolSkinConverter
		{
		    partial void Merge(LoggingToolSkin entity, SkinDataModel dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region MiningToolSkin
    /// <summary>Converts objects of type <see cref="SkinDataModel"/> to objects of type <see cref="MiningToolSkin"/>.</summary>
    public sealed partial class MiningToolSkinConverter : IConverter<SkinDataModel, GatheringToolSkin>
    {
	    /// <inheritdoc />
        public GatheringToolSkin Convert(SkinDataModel value, object state)
        {
    		var entity = new MiningToolSkin();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'MiningToolSkin' (if any)
    	partial void Merge(MiningToolSkin entity, SkinDataModel dto, object state);

		/*
		// Use this template
		public partial class MiningToolSkinConverter
		{
		    partial void Merge(MiningToolSkin entity, SkinDataModel dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region UnknownGatheringToolSkin
    /// <summary>Converts objects of type <see cref="SkinDataModel"/> to objects of type <see cref="UnknownGatheringToolSkin"/>.</summary>
    public sealed partial class UnknownGatheringToolSkinConverter : IConverter<SkinDataModel, GatheringToolSkin>
    {
	    /// <inheritdoc />
        public GatheringToolSkin Convert(SkinDataModel value, object state)
        {
    		var entity = new UnknownGatheringToolSkin();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'UnknownGatheringToolSkin' (if any)
    	partial void Merge(UnknownGatheringToolSkin entity, SkinDataModel dto, object state);

		/*
		// Use this template
		public partial class UnknownGatheringToolSkinConverter
		{
		    partial void Merge(UnknownGatheringToolSkin entity, SkinDataModel dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

}
