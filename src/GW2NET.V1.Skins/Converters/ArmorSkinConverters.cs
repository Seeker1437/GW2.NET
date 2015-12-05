﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GW2NET.V1.Skins.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Skins;
	using SkinDTO = GW2NET.V1.Skins.Json.SkinDTO;

    public sealed partial class ArmorSkinConverter : IConverter<SkinDTO, ArmorSkin>
	{
	    private readonly ITypeConverterFactory<SkinDTO, ArmorSkin> converterFactory;

		private ArmorSkinConverter(ITypeConverterFactory<SkinDTO, ArmorSkin> converterFactory)
		{
		    if (converterFactory == null)
    		{
    		    throw new ArgumentNullException("converterFactory");
    		}

		    this.converterFactory = converterFactory;
		}

		 /// <inheritdoc />
        ArmorSkin IConverter<SkinDTO, ArmorSkin>.Convert(SkinDTO value, object state)
		{
		    if (value == null)
    		{
    		    throw new ArgumentNullException("value");
    		}

			string discriminator = value.Armor == null ? null : value.Armor.Type;
			var converter = this.converterFactory.Create(discriminator);
			var entity = converter.Convert(value, value);
			this.Merge(entity, value, state);
			return entity;
		}

		// Implement this method in a buddy class to set properties that are specific to 'ArmorSkin' (if any)
    	partial void Merge(ArmorSkin entity, SkinDTO dto, object state);

		/*
		// Use this template
		public partial class ArmorSkinConverter
		{
		    partial void Merge(ArmorSkin entity, SkinDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
	}

#region BootsSkin
    /// <summary>Converts objects of type <see cref="SkinDTO"/> to objects of type <see cref="BootsSkin"/>.</summary>
    public sealed partial class BootsSkinConverter : IConverter<SkinDTO, ArmorSkin>
    {
	    /// <inheritdoc />
        public ArmorSkin Convert(SkinDTO value, object state)
        {
    		var entity = new BootsSkin();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'BootsSkin' (if any)
    	partial void Merge(BootsSkin entity, SkinDTO dto, object state);

		/*
		// Use this template
		public partial class BootsSkinConverter
		{
		    partial void Merge(BootsSkin entity, SkinDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region CoatSkin
    /// <summary>Converts objects of type <see cref="SkinDTO"/> to objects of type <see cref="CoatSkin"/>.</summary>
    public sealed partial class CoatSkinConverter : IConverter<SkinDTO, ArmorSkin>
    {
	    /// <inheritdoc />
        public ArmorSkin Convert(SkinDTO value, object state)
        {
    		var entity = new CoatSkin();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'CoatSkin' (if any)
    	partial void Merge(CoatSkin entity, SkinDTO dto, object state);

		/*
		// Use this template
		public partial class CoatSkinConverter
		{
		    partial void Merge(CoatSkin entity, SkinDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region GlovesSkin
    /// <summary>Converts objects of type <see cref="SkinDTO"/> to objects of type <see cref="GlovesSkin"/>.</summary>
    public sealed partial class GlovesSkinConverter : IConverter<SkinDTO, ArmorSkin>
    {
	    /// <inheritdoc />
        public ArmorSkin Convert(SkinDTO value, object state)
        {
    		var entity = new GlovesSkin();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'GlovesSkin' (if any)
    	partial void Merge(GlovesSkin entity, SkinDTO dto, object state);

		/*
		// Use this template
		public partial class GlovesSkinConverter
		{
		    partial void Merge(GlovesSkin entity, SkinDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region HelmAquaticSkin
    /// <summary>Converts objects of type <see cref="SkinDTO"/> to objects of type <see cref="HelmAquaticSkin"/>.</summary>
    public sealed partial class HelmAquaticSkinConverter : IConverter<SkinDTO, ArmorSkin>
    {
	    /// <inheritdoc />
        public ArmorSkin Convert(SkinDTO value, object state)
        {
    		var entity = new HelmAquaticSkin();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'HelmAquaticSkin' (if any)
    	partial void Merge(HelmAquaticSkin entity, SkinDTO dto, object state);

		/*
		// Use this template
		public partial class HelmAquaticSkinConverter
		{
		    partial void Merge(HelmAquaticSkin entity, SkinDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region HelmSkin
    /// <summary>Converts objects of type <see cref="SkinDTO"/> to objects of type <see cref="HelmSkin"/>.</summary>
    public sealed partial class HelmSkinConverter : IConverter<SkinDTO, ArmorSkin>
    {
	    /// <inheritdoc />
        public ArmorSkin Convert(SkinDTO value, object state)
        {
    		var entity = new HelmSkin();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'HelmSkin' (if any)
    	partial void Merge(HelmSkin entity, SkinDTO dto, object state);

		/*
		// Use this template
		public partial class HelmSkinConverter
		{
		    partial void Merge(HelmSkin entity, SkinDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region LeggingsSkin
    /// <summary>Converts objects of type <see cref="SkinDTO"/> to objects of type <see cref="LeggingsSkin"/>.</summary>
    public sealed partial class LeggingsSkinConverter : IConverter<SkinDTO, ArmorSkin>
    {
	    /// <inheritdoc />
        public ArmorSkin Convert(SkinDTO value, object state)
        {
    		var entity = new LeggingsSkin();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'LeggingsSkin' (if any)
    	partial void Merge(LeggingsSkin entity, SkinDTO dto, object state);

		/*
		// Use this template
		public partial class LeggingsSkinConverter
		{
		    partial void Merge(LeggingsSkin entity, SkinDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region ShouldersSkin
    /// <summary>Converts objects of type <see cref="SkinDTO"/> to objects of type <see cref="ShouldersSkin"/>.</summary>
    public sealed partial class ShouldersSkinConverter : IConverter<SkinDTO, ArmorSkin>
    {
	    /// <inheritdoc />
        public ArmorSkin Convert(SkinDTO value, object state)
        {
    		var entity = new ShouldersSkin();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'ShouldersSkin' (if any)
    	partial void Merge(ShouldersSkin entity, SkinDTO dto, object state);

		/*
		// Use this template
		public partial class ShouldersSkinConverter
		{
		    partial void Merge(ShouldersSkin entity, SkinDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region UnknownArmorSkin
    /// <summary>Converts objects of type <see cref="SkinDTO"/> to objects of type <see cref="UnknownArmorSkin"/>.</summary>
    public sealed partial class UnknownArmorSkinConverter : IConverter<SkinDTO, ArmorSkin>
    {
	    /// <inheritdoc />
        public ArmorSkin Convert(SkinDTO value, object state)
        {
    		var entity = new UnknownArmorSkin();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'UnknownArmorSkin' (if any)
    	partial void Merge(UnknownArmorSkin entity, SkinDTO dto, object state);

		/*
		// Use this template
		public partial class UnknownArmorSkinConverter
		{
		    partial void Merge(UnknownArmorSkin entity, SkinDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

}
