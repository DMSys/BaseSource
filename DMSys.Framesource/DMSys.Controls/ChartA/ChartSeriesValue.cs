#region References
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
#endregion

namespace DMSys.Controls.ChartA
{
	/// <summary>
	/// Represents a value from the time series of the chart control.
	/// </summary>
	[TypeConverter(typeof(ChartSeriesValue.ChartSeriesValueTypeConverter))]
	public class ChartSeriesValue
	{
		#region Fields
        private int value_index = 0;
        private decimal value_x = Decimal.Zero;
		private decimal value_y = Decimal.Zero;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of class ChartSeriesValue.
		/// </summary>
        public ChartSeriesValue(int value_index)
        {
            this.value_index = value_index;
        }

		/// <summary>
		/// Initializes a new instance of class ChartSeriesValue.
		/// </summary>
        /// <param name="date">A Decimal object representing the date for the given value.</param>
		/// <param name="value">A Decimal value represening the value to be drawn on the chart.</param>
        public ChartSeriesValue( int value_index, decimal value_x, decimal value_y)
		{
            this.value_index = value_index;
            this.value_x = value_x;
            this.value_y = value_y;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets/sets the date for the given value.
		/// </summary>
		[Description("Gets/sets the date for the given value.")]
        public decimal ValueX
		{
			get
			{
				return this.value_x;
			}
			set
			{
				this.value_x = value;
			}
		}

		/// <summary>
		/// Gets/sets the value to be drawn on the chart.
		/// </summary>
		[Description("Gets/sets the value to be drawn on the chart.")]
		public decimal ValueY
		{
			get
			{
				return this.value_y;
			}
			set
			{
				this.value_y = value;
			}
		}

        public int ValueIndex
		{
			get
			{
                return this.value_index;
			}
		}
        
		#endregion

		#region Methods
		/// <summary>
		/// Returns a string that represents the current object.  
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
            return this.value_y.ToString() + " / " + this.value_x.ToString();
		}
		#endregion

		#region ChartSeriesValueTypeConverter
		/// <summary>
		/// ChartSeriesValue Type Converter class.
		/// </summary>
		internal class ChartSeriesValueTypeConverter : TypeConverter 
		{
			/// <summary>
			/// Method used to define if object can be converted to specific type.
			/// </summary>
			public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
			{
				// check if InstanceDescriptor (used by IDE to serialize the values)
				if (destType == typeof(InstanceDescriptor))
				{
					// override to convert to InstanceDescriptor
					return true;
				}

				// call base class for other types
				return base.CanConvertTo(context, destType);
			}

			/// <summary>
			/// Method used to do the conversion.
			/// </summary>
			public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType) 
			{
				// check if InstanceDescriptor (used by IDE to serialize the values)
				if (destType == typeof(InstanceDescriptor)) 
				{
					ChartSeriesValue seriesValue = (ChartSeriesValue)value;
					// use the default constructor
                    return new InstanceDescriptor(typeof(ChartSeriesValue).GetConstructor(new Type[] { typeof(Decimal), typeof(Decimal) }),
																						new object[] {seriesValue.ValueX, seriesValue.ValueY},
																						false);
				}

				// call base class for other types
				return base.ConvertTo(context, culture, value, destType);
			}
		}
		#endregion
	}
}
