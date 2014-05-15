using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace OsmingtonMillGarlic.Controls
{
	public class CalendarCell : DataGridViewTextBoxCell
	{
		public CalendarCell() : base()
		{
		}

		public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
		{
			// Set the value of the editing control to the current cell value.
			base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
			CalendarEditingControl iCalendarEditingControl = DataGridView.EditingControl as CalendarEditingControl;

			object val = null;
			try
			{
				val = this.Value;
			}
			catch /*(Exception ex)*/
			{
				// Argument of of range (value doesn't exists in collection)
				return;
			}

			if (val != System.DBNull.Value)
			{
				iCalendarEditingControl.Value = (DateTime)val;
			}
		}

		public override Type EditType
		{
			// Return the type of the editing control that CalendarCell uses.
			get { return typeof(CalendarEditingControl); }
		}

		public override Type ValueType
		{
			// Return the type of the value that CalendarCell contains.
			get { return typeof(DateTime); }
		}

		public override object DefaultNewRowValue
		{
			// Use the current date and time as the default value.
			get { return DateTime.Now; }
		}
	}
}