using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OsmingtonMillGarlic.Controls
{
	public partial class NumericTextBox : TextBox
	{
		public delegate void NumberEnteredHandler(NumericTextBox source);

		[Description("This event is triggered when the user presses Enter or Return when a number has been typed into the field.")]
		public event NumberEnteredHandler NumberEntered;
		
		private bool m_allowDecimal = false;
		private bool m_allowNegative = false;

		public NumericTextBox()
		{
			InitializeComponent();
		}

		public void TriggerNumberEntered()
		{
			if (NumberEntered != null)
			{
				NumberEntered(this);
			}
		}

		/// <summary>
		/// Key presses on the numeric text box are restricted to numeric values only.
		/// The pressing of Enter or Return (when a number has been entered) causes
		/// the NumberEntered event to be triggered.
		/// </summary>
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			System.Globalization.NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
			string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
			string negativeSign = numberFormatInfo.NegativeSign;

			string keyInput = e.KeyChar.ToString();

			// If the character types is a digit then accept it.
			if (Char.IsDigit(e.KeyChar))
			{
				e.Handled = false;
			}
			else if ((m_allowDecimal && keyInput.Equals(decimalSeparator)) || (m_allowNegative && keyInput.Equals(negativeSign)))
			{
				// If the character is a negative sign or a decimal place then only accept it
				// if there is not already one in the string.
				if (this.Text.Contains(keyInput))
				{
					e.Handled = true;
				}
				else
				{
					e.Handled = false;
				}
			}
			// Any attempt to edit the text is also acceptable.
			else if (e.KeyChar == (char)Keys.Back)
			{
				e.Handled = false;
			}
			// Pressing enter/return indicates completion so fire the NumberEntered event.
			else if ((e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Return))
			{
				TriggerNumberEntered();
				e.Handled = true;
			}
			// All other key strokes are rejected when then control key is not pressed (this allows shortcuts to work).
			else if(!Char.IsControl(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		/// <summary>
		/// The pressing of 'Tab' is not trapped by the OnKeyPress event. 
		/// It is necessary to trap 'Tab' in the OnPreviewKeyDown event as this appears to get
		/// all key presses before they are processed.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode.Equals(Keys.Tab))
			{
				TriggerNumberEntered();
			}
		}		

		[Description("By default the NumericTextBox accepts only integer values. Changing this setting to 'True' will allow decimal values to be entered."),
		Category("Behavior"),
		DefaultValue(false),
		Browsable(true)]
		public bool AllowDecimal
		{
			get { return m_allowDecimal; }
			set { m_allowDecimal = value; }
		}

		[Description("By default the NumericTextBox accepts only positive values. Changing this setting to 'True' will allow negative values to be entered."),
		Category("Behavior"),
		DefaultValue(false),
		Browsable(true)]
		public bool AllowNegative
		{
			get { return m_allowNegative; }
			set { m_allowNegative = value; }
		}

		[Browsable(false)]
		public bool IsEmpty { get { return this.Text.Length == 0; } }

		[Browsable(false)]
		public int IntValue
		{
			get
			{
				int result = 0;

				if (!int.TryParse(this.Text,
								 NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint,
								 CultureInfo.CurrentCulture,
								 out result))
				{
					Decimal temp;
					if (Decimal.TryParse(this.Text,
								 NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint,
								 CultureInfo.CurrentCulture,
								 out temp))
					{
						result = (int)temp;
					}
				}
				return result;
			}
		}

		[Browsable(false)]
		public decimal DecimalValue
		{
			get
			{
				Decimal result = 0;

				Decimal.TryParse(this.Text, 
								 NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint,
								 CultureInfo.CurrentCulture,
								 out result);
				
				return result;
			}
		}

	}
}
