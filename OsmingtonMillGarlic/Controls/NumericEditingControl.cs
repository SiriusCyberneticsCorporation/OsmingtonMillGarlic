using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OsmingtonMillGarlic.Controls
{
	public class NumericEditingControl : NumericTextBox, IDataGridViewEditingControl
	{
		private int m_rowIndex;
		private bool m_valueChanged = false;
		private string m_format;
		private DataGridView m_dataGridView;

		public NumericEditingControl()
		{
		}

		// Implements the IDataGridViewEditingControl.EditingControlFormattedValue property.
		public object EditingControlFormattedValue
		{
			get { return this.Text; }
			set
			{
				if (value is String)
				{
					this.Text = (string)value;
				}
			}
		}

		// Implements the IDataGridViewEditingControl.GetEditingControlFormattedValue method.
		public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
		{
			return EditingControlFormattedValue;
		}

		// Implements the IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
		public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
		{
			m_format = dataGridViewCellStyle.Format;

			this.Font = dataGridViewCellStyle.Font;
			this.ForeColor = dataGridViewCellStyle.ForeColor;
			this.BackColor = dataGridViewCellStyle.BackColor;
					
			switch (dataGridViewCellStyle.Alignment)
			{
				case DataGridViewContentAlignment.BottomCenter:
				case DataGridViewContentAlignment.MiddleCenter:
				case DataGridViewContentAlignment.TopCenter:
					this.TextAlign = HorizontalAlignment.Center;
					break;
				case DataGridViewContentAlignment.BottomLeft:
				case DataGridViewContentAlignment.MiddleLeft:
				case DataGridViewContentAlignment.TopLeft:
					this.TextAlign = HorizontalAlignment.Left;
					break;
				case DataGridViewContentAlignment.BottomRight:
				case DataGridViewContentAlignment.MiddleRight:
				case DataGridViewContentAlignment.TopRight:
					this.TextAlign = HorizontalAlignment.Right;
					break;
			}
		}

		// Implements the IDataGridViewEditingControl.EditingControlRowIndex property.
		public int EditingControlRowIndex
		{
			get { return m_rowIndex; }
			set { m_rowIndex = value; }
		}

		// Implements the IDataGridViewEditingControl.EditingControlWantsInputKey method.
		public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
		{
			// Let the DateTimePicker handle the keys listed.
			switch (key & Keys.KeyCode)
			{
				case Keys.Left:
				case Keys.Up:
				case Keys.Down:
				case Keys.Right:
				case Keys.Home:
				case Keys.End:
				case Keys.PageDown:
				case Keys.PageUp:
				case Keys.Tab:
					return true;
				default:
					return !dataGridViewWantsInputKey;
			}
		}

		// Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit method.
		public void PrepareEditingControlForEdit(bool selectAll)
		{
			// No preparation needs to be done.
		}

		// Implements the IDataGridViewEditingControl.RepositionEditingControlOnValueChange property.
		public bool RepositionEditingControlOnValueChange
		{
			get { return false; }
		}

		// Implements the IDataGridViewEditingControl.EditingControlDataGridView property.
		public DataGridView EditingControlDataGridView
		{
			get { return m_dataGridView; }
			set { m_dataGridView = value; }
		}

		// Implements the IDataGridViewEditingControl.EditingControlValueChanged property.
		public bool EditingControlValueChanged
		{
			get { return m_valueChanged; }
			set { m_valueChanged = value; }
		}

		// Implements the IDataGridViewEditingControl.EditingPanelCursor property.
		public Cursor EditingPanelCursor
		{
			get { return base.Cursor; }
		}
		
		protected override void OnTextChanged(EventArgs eventargs)
		{
			// Notify the DataGridView that the contents of the cell have changed.
			m_valueChanged = true;
			this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
			base.OnTextChanged(eventargs);
		}
		
	}
}
