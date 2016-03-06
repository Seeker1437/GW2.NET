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
	using GW2NET.Items;

    public sealed partial class CombatAttributeConverter : IConverter<AttributeDataModel, CombatAttribute>
	{
	    private readonly ITypeConverterFactory<AttributeDataModel, CombatAttribute> converterFactory;

		public CombatAttributeConverter(ITypeConverterFactory<AttributeDataModel, CombatAttribute> converterFactory)
		{
		    if (converterFactory == null)
    		{
    		    throw new ArgumentNullException("converterFactory");
    		}

		    this.converterFactory = converterFactory;
		}

		 /// <inheritdoc />
        public CombatAttribute Convert(AttributeDataModel value, object state)
		{
		    if (value == null)
    		{
    		    throw new ArgumentNullException("value");
    		}

			string discriminator = value.Attribute;
			var converter = this.converterFactory.Create(discriminator);
			var entity = converter.Convert(value, value);
			this.Merge(entity, value, state);
			return entity;
		}

		// Implement this method in a buddy class to set properties that are specific to 'CombatAttribute' (if any)
    	partial void Merge(CombatAttribute entity, AttributeDataModel dto, object state);

		/*
		// Use this template
		public partial class CombatAttributeConverter
		{
		    partial void Merge(CombatAttribute entity, AttributeDataModel dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
	}

#region ExpertiseModifier
    /// <summary>Converts objects of type <see cref="AttributeDataModel"/> to objects of type <see cref="ExpertiseModifier"/>.</summary>
    public sealed partial class ExpertiseModifierConverter : IConverter<AttributeDataModel, CombatAttribute>
    {
	    /// <inheritdoc />
        public CombatAttribute Convert(AttributeDataModel value, object state)
        {
    		var entity = new ExpertiseModifier();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'ExpertiseModifier' (if any)
    	partial void Merge(ExpertiseModifier entity, AttributeDataModel dto, object state);

		/*
		// Use this template
		public partial class ExpertiseModifierConverter
		{
		    partial void Merge(ExpertiseModifier entity, AttributeDataModel dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region ConditionDamageModifier
    /// <summary>Converts objects of type <see cref="AttributeDataModel"/> to objects of type <see cref="ConditionDamageModifier"/>.</summary>
    public sealed partial class ConditionDamageModifierConverter : IConverter<AttributeDataModel, CombatAttribute>
    {
	    /// <inheritdoc />
        public CombatAttribute Convert(AttributeDataModel value, object state)
        {
    		var entity = new ConditionDamageModifier();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'ConditionDamageModifier' (if any)
    	partial void Merge(ConditionDamageModifier entity, AttributeDataModel dto, object state);

		/*
		// Use this template
		public partial class ConditionDamageModifierConverter
		{
		    partial void Merge(ConditionDamageModifier entity, AttributeDataModel dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region FerocityModifier
    /// <summary>Converts objects of type <see cref="AttributeDataModel"/> to objects of type <see cref="FerocityModifier"/>.</summary>
    public sealed partial class FerocityModifierConverter : IConverter<AttributeDataModel, CombatAttribute>
    {
	    /// <inheritdoc />
        public CombatAttribute Convert(AttributeDataModel value, object state)
        {
    		var entity = new FerocityModifier();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'FerocityModifier' (if any)
    	partial void Merge(FerocityModifier entity, AttributeDataModel dto, object state);

		/*
		// Use this template
		public partial class FerocityModifierConverter
		{
		    partial void Merge(FerocityModifier entity, AttributeDataModel dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region HealingModifier
    /// <summary>Converts objects of type <see cref="AttributeDataModel"/> to objects of type <see cref="HealingModifier"/>.</summary>
    public sealed partial class HealingModifierConverter : IConverter<AttributeDataModel, CombatAttribute>
    {
	    /// <inheritdoc />
        public CombatAttribute Convert(AttributeDataModel value, object state)
        {
    		var entity = new HealingModifier();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'HealingModifier' (if any)
    	partial void Merge(HealingModifier entity, AttributeDataModel dto, object state);

		/*
		// Use this template
		public partial class HealingModifierConverter
		{
		    partial void Merge(HealingModifier entity, AttributeDataModel dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region PowerModifier
    /// <summary>Converts objects of type <see cref="AttributeDataModel"/> to objects of type <see cref="PowerModifier"/>.</summary>
    public sealed partial class PowerModifierConverter : IConverter<AttributeDataModel, CombatAttribute>
    {
	    /// <inheritdoc />
        public CombatAttribute Convert(AttributeDataModel value, object state)
        {
    		var entity = new PowerModifier();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'PowerModifier' (if any)
    	partial void Merge(PowerModifier entity, AttributeDataModel dto, object state);

		/*
		// Use this template
		public partial class PowerModifierConverter
		{
		    partial void Merge(PowerModifier entity, AttributeDataModel dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region PrecisionModifier
    /// <summary>Converts objects of type <see cref="AttributeDataModel"/> to objects of type <see cref="PrecisionModifier"/>.</summary>
    public sealed partial class PrecisionModifierConverter : IConverter<AttributeDataModel, CombatAttribute>
    {
	    /// <inheritdoc />
        public CombatAttribute Convert(AttributeDataModel value, object state)
        {
    		var entity = new PrecisionModifier();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'PrecisionModifier' (if any)
    	partial void Merge(PrecisionModifier entity, AttributeDataModel dto, object state);

		/*
		// Use this template
		public partial class PrecisionModifierConverter
		{
		    partial void Merge(PrecisionModifier entity, AttributeDataModel dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region ConcentrationModifier
    /// <summary>Converts objects of type <see cref="AttributeDataModel"/> to objects of type <see cref="ConcentrationModifier"/>.</summary>
    public sealed partial class ConcentrationModifierConverter : IConverter<AttributeDataModel, CombatAttribute>
    {
	    /// <inheritdoc />
        public CombatAttribute Convert(AttributeDataModel value, object state)
        {
    		var entity = new ConcentrationModifier();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'ConcentrationModifier' (if any)
    	partial void Merge(ConcentrationModifier entity, AttributeDataModel dto, object state);

		/*
		// Use this template
		public partial class ConcentrationModifierConverter
		{
		    partial void Merge(ConcentrationModifier entity, AttributeDataModel dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region ToughnessModifier
    /// <summary>Converts objects of type <see cref="AttributeDataModel"/> to objects of type <see cref="ToughnessModifier"/>.</summary>
    public sealed partial class ToughnessModifierConverter : IConverter<AttributeDataModel, CombatAttribute>
    {
	    /// <inheritdoc />
        public CombatAttribute Convert(AttributeDataModel value, object state)
        {
    		var entity = new ToughnessModifier();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'ToughnessModifier' (if any)
    	partial void Merge(ToughnessModifier entity, AttributeDataModel dto, object state);

		/*
		// Use this template
		public partial class ToughnessModifierConverter
		{
		    partial void Merge(ToughnessModifier entity, AttributeDataModel dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region UnknownModifier
    /// <summary>Converts objects of type <see cref="AttributeDataModel"/> to objects of type <see cref="UnknownModifier"/>.</summary>
    public sealed partial class UnknownModifierConverter : IConverter<AttributeDataModel, CombatAttribute>
    {
	    /// <inheritdoc />
        public CombatAttribute Convert(AttributeDataModel value, object state)
        {
    		var entity = new UnknownModifier();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'UnknownModifier' (if any)
    	partial void Merge(UnknownModifier entity, AttributeDataModel dto, object state);

		/*
		// Use this template
		public partial class UnknownModifierConverter
		{
		    partial void Merge(UnknownModifier entity, AttributeDataModel dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region VitalityModifier
    /// <summary>Converts objects of type <see cref="AttributeDataModel"/> to objects of type <see cref="VitalityModifier"/>.</summary>
    public sealed partial class VitalityModifierConverter : IConverter<AttributeDataModel, CombatAttribute>
    {
	    /// <inheritdoc />
        public CombatAttribute Convert(AttributeDataModel value, object state)
        {
    		var entity = new VitalityModifier();
            this.Merge(entity, value, state);
    		return entity;
        }

    	// Implement this method in a buddy class to set properties that are specific to 'VitalityModifier' (if any)
    	partial void Merge(VitalityModifier entity, AttributeDataModel dto, object state);

		/*
		// Use this template
		public partial class VitalityModifierConverter
		{
		    partial void Merge(VitalityModifier entity, AttributeDataModel dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

}
