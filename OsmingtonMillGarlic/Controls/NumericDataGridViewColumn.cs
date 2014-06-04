using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OsmingtonMillGarlic.Controls
{
	public class NumericDataGridViewColumn : DataGridViewColumn
	{
		[Description("By default the NumericDataGridViewColumn accepts only positive values. Changing this setting to 'True' will allow negative values to be entered."),
		Category("Behavior"),
		Browsable(true)]
		public bool AllowNegative { get; set; }

		[Description("By default the NumericDataGridViewColumn accepts integer values. Changing this setting to 'True' will allow decimal values to be entered."),
		Category("Behavior"),
		Browsable(true)]
		public bool AllowDecimal { get; set; }

		public NumericDataGridViewColumn()
			: base(new NumericDataGridViewCell())
		{
		}

		public override DataGridViewCell CellTemplate
		{
			get { return base.CellTemplate; }
			set
			{
				// Ensure that the cell used for the template is a CalendarCell.
				if (value != null && !value.GetType().IsAssignableFrom(typeof(NumericDataGridViewCell)))
				{
					throw new InvalidCastException("Must be a CurrencyCell");
				}
				base.CellTemplate = value;
			}
		}
	}
}
