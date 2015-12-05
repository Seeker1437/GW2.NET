﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GW2NET.V2.Items.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;
	using ItemDTO = GW2NET.V2.Items.Json.ItemDTO;

    public sealed partial class UpgradeComponentConverter : IConverter<ItemDTO, UpgradeComponent>
	{
	    private readonly ITypeConverterFactory<ItemDTO, UpgradeComponent> converterFactory;

		private UpgradeComponentConverter(ITypeConverterFactory<ItemDTO, UpgradeComponent> converterFactory)
		{
		    if (converterFactory == null)
    		{
    		    throw new ArgumentNullException("converterFactory");
    		}

		    this.converterFactory = converterFactory;
		}

		 /// <inheritdoc />
        UpgradeComponent IConverter<ItemDTO, UpgradeComponent>.Convert(ItemDTO value, object state)
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

		// Implement this method in a buddy class to set properties that are specific to 'UpgradeComponent' (if any)
    	partial void Merge(UpgradeComponent entity, ItemDTO dto, object state);

		/*
		// Use this template
		public partial class UpgradeComponentConverter
		{
		    partial void Merge(UpgradeComponent entity, ItemDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
	}

#region DefaultUpgradeComponent
    /// <summary>Converts objects of type <see cref="ItemDTO"/> to objects of type <see cref="DefaultUpgradeComponent"/>.</summary>
    public sealed partial class DefaultUpgradeComponentConverter : IConverter<ItemDTO, UpgradeComponent>
    {
	    /// <inheritdoc />
        public UpgradeComponent Convert(ItemDTO value, object state)
        {
    		var entity = new DefaultUpgradeComponent();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'DefaultUpgradeComponent' (if any)
    	partial void Merge(DefaultUpgradeComponent entity, ItemDTO dto, object state);

		/*
		// Use this template
		public partial class DefaultUpgradeComponentConverter
		{
		    partial void Merge(DefaultUpgradeComponent entity, ItemDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region Gem
    /// <summary>Converts objects of type <see cref="ItemDTO"/> to objects of type <see cref="Gem"/>.</summary>
    public sealed partial class GemConverter : IConverter<ItemDTO, UpgradeComponent>
    {
	    /// <inheritdoc />
        public UpgradeComponent Convert(ItemDTO value, object state)
        {
    		var entity = new Gem();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'Gem' (if any)
    	partial void Merge(Gem entity, ItemDTO dto, object state);

		/*
		// Use this template
		public partial class GemConverter
		{
		    partial void Merge(Gem entity, ItemDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region Rune
    /// <summary>Converts objects of type <see cref="ItemDTO"/> to objects of type <see cref="Rune"/>.</summary>
    public sealed partial class RuneConverter : IConverter<ItemDTO, UpgradeComponent>
    {
	    /// <inheritdoc />
        public UpgradeComponent Convert(ItemDTO value, object state)
        {
    		var entity = new Rune();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'Rune' (if any)
    	partial void Merge(Rune entity, ItemDTO dto, object state);

		/*
		// Use this template
		public partial class RuneConverter
		{
		    partial void Merge(Rune entity, ItemDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region Sigil
    /// <summary>Converts objects of type <see cref="ItemDTO"/> to objects of type <see cref="Sigil"/>.</summary>
    public sealed partial class SigilConverter : IConverter<ItemDTO, UpgradeComponent>
    {
	    /// <inheritdoc />
        public UpgradeComponent Convert(ItemDTO value, object state)
        {
    		var entity = new Sigil();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'Sigil' (if any)
    	partial void Merge(Sigil entity, ItemDTO dto, object state);

		/*
		// Use this template
		public partial class SigilConverter
		{
		    partial void Merge(Sigil entity, ItemDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region UnknownUpgradeComponent
    /// <summary>Converts objects of type <see cref="ItemDTO"/> to objects of type <see cref="UnknownUpgradeComponent"/>.</summary>
    public sealed partial class UnknownUpgradeComponentConverter : IConverter<ItemDTO, UpgradeComponent>
    {
	    /// <inheritdoc />
        public UpgradeComponent Convert(ItemDTO value, object state)
        {
    		var entity = new UnknownUpgradeComponent();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'UnknownUpgradeComponent' (if any)
    	partial void Merge(UnknownUpgradeComponent entity, ItemDTO dto, object state);

		/*
		// Use this template
		public partial class UnknownUpgradeComponentConverter
		{
		    partial void Merge(UnknownUpgradeComponent entity, ItemDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

}
