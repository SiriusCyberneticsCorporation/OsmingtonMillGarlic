using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace OsmingtonMillGarlic.Controls
{
	public class NumericDataGridViewCell : DataGridViewTextBoxCell
	{
		public NumericDataGridViewCell()
			: base()
		{
		}

		public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
		{
			// Set the value of the editing control to the current cell value.
			base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
			NumericEditingControl iNumericEditingControl = DataGridView.EditingControl as NumericEditingControl;

			// Pass the Allow Negative setting down to the numeric control.
			if (OwningColumn is NumericDataGridViewColumn)
			{
				iNumericEditingControl.AllowNegative = ((NumericDataGridViewColumn)OwningColumn).AllowNegative;
				iNumericEditingControl.AllowDecimal = ((NumericDataGridViewColumn)OwningColumn).AllowDecimal;
			}

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
				iNumericEditingControl.Text = val.ToString();
			}
		}

		public override Type EditType
		{
			// Return the type of the editing control that CalendarCell uses.
			get { return typeof(NumericEditingControl); }
		}

		public override Type ValueType
		{
			// Return the type of the value that CalendarCell contains.
			get 
			{ 
				NumericEditingControl iNumericEditingControl = DataGridView.EditingControl as NumericEditingControl;
				if (iNumericEditingControl != null && iNumericEditingControl.AllowDecimal)
				{
					return typeof(Decimal);
				}
				else
				{
					return typeof(int);
				}
			}
		}

		public override object DefaultNewRowValue
		{
			// Use 0 as the default value.
			get { return 0; }
		}
	}
}
