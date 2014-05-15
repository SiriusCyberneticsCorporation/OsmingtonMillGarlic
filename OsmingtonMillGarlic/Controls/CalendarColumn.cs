using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace OsmingtonMillGarlic.Controls
{
	public class CalendarColumn : DataGridViewColumn
	{
		public const string STANDARD_DATE_FORMAT = "dd-MMM-yyyy";
		public const string STANDARD_DATE_TIME_FORMAT = "dd-MMM-yyyy HH:mm";

		public CalendarColumn()
			: base(new CalendarCell())
		{
			
		}

		[Description("Format string for the date."),
		Category("Appearance"),
		DefaultValue(STANDARD_DATE_FORMAT),
		Browsable(true)]
		public string Format
		{
			get { return this.DefaultCellStyle.Format; }
			set { this.DefaultCellStyle.Format = value; }
		}

		public override DataGridViewCell CellTemplate
		{
			get { return base.CellTemplate; }
			set
			{
				// Ensure that the cell used for the template is a CalendarCell.
				if (value != null && !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
				{
					throw new InvalidCastException("Must be a CalendarCell");
				}
				base.CellTemplate = value;
			}
		}
	}
}