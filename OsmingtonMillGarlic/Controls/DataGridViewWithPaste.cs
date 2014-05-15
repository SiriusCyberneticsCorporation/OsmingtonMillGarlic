using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace OsmingtonMillGarlic.Controls
{
	/// <summary>
	/// The standard DataGridView control does not support paste functionality. This control
	/// provides a Copy and Paste context menu as well as supporting a trap for Ctrl+V which
	/// will try to paste whatever is in the clipboard.
	/// NOTE: Ctrl+C is already supported functionality for DataGridView controls.
	/// </summary>
	public class DataGridViewWithPaste : DataGridView
	{
		private ContextMenuStrip m_copyPasteMenu = null;

		public DataGridViewWithPaste()
		{
			base.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
		}

		[Description("For DataGridViewWithPaste the EditMode is fixed as DataGridViewEditMode.EditOnKeystrokeOrF2")]
		public new DataGridViewEditMode EditMode { get { return DataGridViewEditMode.EditOnKeystrokeOrF2; } }

		/// <summary>
		/// This method creates the context menu for the copy and paste functionality.
		/// </summary>
		private void CreateCopyPasteMenu()
		{
			if (m_copyPasteMenu == null)
			{
				ToolStripMenuItem copyItem = new ToolStripMenuItem("Copy (Ctrl+C)", null, OnCopyClick);
				ToolStripMenuItem pasteItem = new ToolStripMenuItem("Paste (Ctrl+V)", null, OnPasteClick);

				m_copyPasteMenu = new ContextMenuStrip();
				m_copyPasteMenu.ShowCheckMargin = false;
				m_copyPasteMenu.ShowImageMargin = false;
				m_copyPasteMenu.Items.Add(copyItem);
				if (!this.ReadOnly)
				{
					m_copyPasteMenu.Items.Add(pasteItem);
				}
			}
		}

		/// <summary>
		/// This event is trapped to force the opening of ComboBoxes and Calendar Controls
		/// when the user first clicks on them.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnCellClick(DataGridViewCellEventArgs e)
		{
			base.OnCellClick(e);

			if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
			{
				// If the column is a Combo Box column then set the DroppedDown flag.
				if (this.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewComboBoxColumn))
				{
					this.CurrentCell = this[e.ColumnIndex, e.RowIndex];
					this.BeginEdit(false);
					ComboBox comboBoxControl = this.EditingControl as ComboBox;
					if (comboBoxControl != null)
					{
						comboBoxControl.DroppedDown = true;
					}
				}
				// If the column is a Calendar column then send the "down" message as there is no DroppedDown equivalent.
				else if (this.Columns[e.ColumnIndex].GetType() == typeof(CalendarColumn))
				{
					this.CurrentCell = this[e.ColumnIndex, e.RowIndex];
					this.BeginEdit(false);
					CalendarEditingControl calendarControl = this.EditingControl as CalendarEditingControl;
					if (calendarControl != null)
					{
						SendKeys.Send("%{DOWN}");
					}
				}
			}
		}

		protected override void OnCellContentClick(DataGridViewCellEventArgs e)
		{
			base.OnCellContentClick(e);
			
			SendKeys.Send("{F2}");
		}

		/// <summary>
		/// If the user right clicks a cell in the DataGridView then the selected cell is set as the 
		/// current cell and the copy/paste context menu is displayed.
		/// </summary>
		/// <param name="e">Mouse click event parameter.</param>
		protected override void OnCellMouseClick(DataGridViewCellMouseEventArgs e)
		{
			base.OnCellMouseClick(e);

			if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				// Convert the mouse position to a position relative to the DataGridView.
				System.Drawing.Point clickPosition = this.PointToClient(MousePosition);

				// From the DataGridView get the associated cell that was selected.
				HitTestInfo iHitTestInfo = this.HitTest(clickPosition.X, clickPosition.Y);
				if (iHitTestInfo != null)
				{
					// If the HitTest returns a valid DataGridView cell then show the context menu.
					if (iHitTestInfo.ColumnIndex >= 0 && iHitTestInfo.ColumnIndex <= this.ColumnCount &&
						iHitTestInfo.RowIndex >= 0 && iHitTestInfo.RowIndex <= this.RowCount)
					{
						// Set the current cell to the position clicked.
						this.CurrentCell = this[iHitTestInfo.ColumnIndex, iHitTestInfo.RowIndex];
						
						// Ensure that the context menu exists.
						CreateCopyPasteMenu();

						// Show the context menu in the position clicked.
						m_copyPasteMenu.Show(this, clickPosition);
					}
				}
			}
		}

		/// <summary>
		/// The method traps the Ctrl+V key combination and performs the OnPasteClick menu item event.
		/// All other key presses are handled normally.
		/// </summary>
		/// <param name="e">Key press parameters.</param>
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.V)
			{
				OnPasteClick(this, new EventArgs());
			}
			else
			{
				base.OnKeyDown(e);
			}
		}

		// If the context menu Copy item is selected then the current selection is pushed to the clipboard.
		private void OnCopyClick(object sender, EventArgs e)
		{
			// Copy to clipboard
			DataObject dataObj = this.GetClipboardContent();
			if (dataObj != null)
			{
				Clipboard.SetDataObject(dataObj);
			}
		}

		// If the context menu Paste item is selected then attempt to paste the clipboard content into the DataGridView.
		private void OnPasteClick(object sender, EventArgs e)
		{
			try
			{
				int startRow = this.CurrentCell.RowIndex;
				int startColumn = this.CurrentCell.ColumnIndex;

				// If multiple cells are highlighted as the destination then find the 
				// first row and column and use them as the start point.
				if (this.SelectedCells.Count > 1)
				{
					foreach (DataGridViewCell cell in this.SelectedCells)
					{
						if (cell.RowIndex < startRow)
						{
							startRow = cell.RowIndex;
						}
						if (cell.ColumnIndex < startColumn)
						{
							startColumn = cell.ColumnIndex;
						}
					}
				}
				int gridRow = startRow;

				// Rows in the clipboard are delineated by carriage return AND line feed. This first
				// line strips out the carriage return so the text may be split on line feed alone.
				string clipboardText = Clipboard.GetText().Replace("\r","");
				string[] lines = clipboardText.Split('\n');	// Copied rows are separated by '\n'.

				foreach (string line in lines)
				{
					if (gridRow < this.RowCount && line.Length > 0)
					{
						int pasteColumn = 0;
						string[] pasteValues = line.Split('\t');	// Copied columns are separated by '\t'.

						// Because some of the DataGridView columns may be hidden, 
						// only visible columns are pasted into.
						for (int gridColumn = startColumn; gridColumn < this.ColumnCount; ++gridColumn)
						{
							// If we run out of column data then this loop is completed.
							if (pasteColumn >= pasteValues.Length)
							{
								break;
							}

							DataGridViewCell gridCell = this[gridColumn, gridRow];	// Get the cell to paste into.

							// Ignore hidden cells.
							if(!gridCell.Visible)
							{
								continue;
							}
							else 
							{
								// Do not paste into read only cells.
								if(!gridCell.ReadOnly)
								{
									// No point pasting over identical values.
									if (gridCell.Value.ToString() != pasteValues[pasteColumn])
									{
										if (pasteValues[pasteColumn].Length == 0)
										{
											gridCell.Value = DBNull.Value;
										}
										else
										{
											// Ensure that the string from the clipboard is converted to the cells data type.
											gridCell.Value = Convert.ChangeType(pasteValues[pasteColumn], gridCell.ValueType);
										}
									}
								}
								pasteColumn++;
							}
						}
						gridRow++;
					}
					else
					{ 
						break; 
					}
				}
			}
			catch (FormatException)
			{
				MessageBox.Show("The data you pasted is in the wrong format for the cell");
			}			
		}

		/// <summary>
		/// For numeric columns there is a validation issue that occurs when the user sets a numeric
		/// cell value to blank (i.e. deletes the content). Validation of such a cell throws a FormatException
		/// and does not allow the user out of the cell until the 'problem' is fixed.
		/// The handling of this event traps blank numeric values and sets the cell value to NULL. 
		/// This solves the FormatException issue and make the value correct for saving to the database.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnCellParsing(DataGridViewCellParsingEventArgs e)
		{
			if(this.Columns[e.ColumnIndex].GetType() == typeof(NumericDataGridViewColumn) &&
				e.Value.ToString().Length == 0)
			{
				e.Value = DBNull.Value;
				e.ParsingApplied = true;
			}
		}
	}
}
