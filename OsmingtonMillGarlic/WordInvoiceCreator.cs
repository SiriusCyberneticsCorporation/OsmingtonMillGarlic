using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Core;

namespace OsmingtonMillGarlic
{

	public enum eInvoiceType
	{
		JeanetteAndRichard = 2,
		OsmingtonMillGarlic = 1,
	}

	public class WordInvoiceCreator
	{
		#region Necessary definitions and enumerations

		public static object MISSING = System.Reflection.Missing.Value;
		public static object ENDOFDOC = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

		public enum eInvoiceTextStyle
		{
			[Description("Header Table Text")]
			HeaderTableText,
			[Description("Invoice Normal")]
			Normal,
			[Description("Invoice Table Text")]
			TableText,
			[Description("Bank Text")]
			BankText,
		}

		public enum eBoldness
		{
			NotBold = 0,
			Bold = 1,
		}

		public enum eItalicisation
		{
			NotItalic = 0,
			Italic = 1
		}

		public enum ePageBreakBefore
		{
			On = -1,
			Off = 0
		}

		public enum eKeepWithNext
		{
			Keep = -1,
			DontKeep = 0
		}

		public enum ePageOrientation
		{
			Portrait = Word.WdOrientation.wdOrientPortrait,
			LandScape = Word.WdOrientation.wdOrientLandscape
		}

		public enum eParagraphAlignment
		{
			Left = Word.WdParagraphAlignment.wdAlignParagraphLeft,
			Center = Word.WdParagraphAlignment.wdAlignParagraphCenter,
			Right = Word.WdParagraphAlignment.wdAlignParagraphRight,
			Justify = Word.WdParagraphAlignment.wdAlignParagraphJustify,
			Distribute = Word.WdParagraphAlignment.wdAlignParagraphDistribute,
			JustifyMed = Word.WdParagraphAlignment.wdAlignParagraphJustifyMed,
			JustifyHi = Word.WdParagraphAlignment.wdAlignParagraphJustifyHi,
			JustifyLow = Word.WdParagraphAlignment.wdAlignParagraphJustifyLow,
			ThaiJustify = Word.WdParagraphAlignment.wdAlignParagraphThaiJustify,
		}

		public enum eCellVerticalAlignment
		{
			Top = Word.WdCellVerticalAlignment.wdCellAlignVerticalTop,
			Center = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter,
			Bottom = Word.WdCellVerticalAlignment.wdCellAlignVerticalBottom,
		}

		public enum eUnderline
		{
			None = Word.WdUnderline.wdUnderlineNone,
			Single = Word.WdUnderline.wdUnderlineSingle,
			Words = Word.WdUnderline.wdUnderlineWords,
			Double = Word.WdUnderline.wdUnderlineDouble,
			Dotted = Word.WdUnderline.wdUnderlineDotted,
			Thick = Word.WdUnderline.wdUnderlineThick,
			Dash = Word.WdUnderline.wdUnderlineDash,
			DotDash = Word.WdUnderline.wdUnderlineDotDash,
			DotDotDash = Word.WdUnderline.wdUnderlineDotDotDash,
			Wavy = Word.WdUnderline.wdUnderlineWavy,
			DottedHeavy = Word.WdUnderline.wdUnderlineDottedHeavy,
			DashHeavy = Word.WdUnderline.wdUnderlineDashHeavy,
			DotDashHeavy = Word.WdUnderline.wdUnderlineDotDashHeavy,
			DotDotDashHeavy = Word.WdUnderline.wdUnderlineDotDotDashHeavy,
			WavyHeavy = Word.WdUnderline.wdUnderlineWavyHeavy,
			DashLong = Word.WdUnderline.wdUnderlineDashLong,
			WavyDouble = Word.WdUnderline.wdUnderlineWavyDouble,
			DashLongHeavy = Word.WdUnderline.wdUnderlineDashLongHeavy,
		}

		public enum eBorderType
		{
			DiagonalUp = Word.WdBorderType.wdBorderDiagonalUp,
			DiagonalDown = Word.WdBorderType.wdBorderDiagonalDown,
			Vertical = Word.WdBorderType.wdBorderVertical,
			Horizontal = Word.WdBorderType.wdBorderHorizontal,
			Right = Word.WdBorderType.wdBorderRight,
			Bottom = Word.WdBorderType.wdBorderBottom,
			Left = Word.WdBorderType.wdBorderLeft,
			Top = Word.WdBorderType.wdBorderTop,
		}

		public enum eLineStyle
		{
			None = Word.WdLineStyle.wdLineStyleNone,
			Single = Word.WdLineStyle.wdLineStyleSingle,
			Dot = Word.WdLineStyle.wdLineStyleDot,
			DashSmallGap = Word.WdLineStyle.wdLineStyleDashSmallGap,
			DashLargeGap = Word.WdLineStyle.wdLineStyleDashLargeGap,
			DashDot = Word.WdLineStyle.wdLineStyleDashDot,
			DashDotDot = Word.WdLineStyle.wdLineStyleDashDotDot,
			Double = Word.WdLineStyle.wdLineStyleDouble,
			Triple = Word.WdLineStyle.wdLineStyleTriple,
			ThinThickSmallGap = Word.WdLineStyle.wdLineStyleThinThickSmallGap,
			ThickThinSmallGap = Word.WdLineStyle.wdLineStyleThickThinSmallGap,
			ThinThickThinSmallGap = Word.WdLineStyle.wdLineStyleThinThickThinSmallGap,
			ThinThickMedGap = Word.WdLineStyle.wdLineStyleThinThickMedGap,
			ThickThinMedGap = Word.WdLineStyle.wdLineStyleThickThinMedGap,
			ThinThickThinMedGap = Word.WdLineStyle.wdLineStyleThinThickThinMedGap,
			ThinThickLargeGap = Word.WdLineStyle.wdLineStyleThinThickLargeGap,
			ThickThinLargeGap = Word.WdLineStyle.wdLineStyleThickThinLargeGap,
			ThinThickThinLargeGap = Word.WdLineStyle.wdLineStyleThinThickThinLargeGap,
			SingleWavy = Word.WdLineStyle.wdLineStyleSingleWavy,
			DoubleWavy = Word.WdLineStyle.wdLineStyleDoubleWavy,
			DashDotStroked = Word.WdLineStyle.wdLineStyleDashDotStroked,
			Emboss3D = Word.WdLineStyle.wdLineStyleEmboss3D,
			Engrave3D = Word.WdLineStyle.wdLineStyleEngrave3D,
			Outset = Word.WdLineStyle.wdLineStyleOutset,
			Inset = Word.WdLineStyle.wdLineStyleInset,
		}
		
		#endregion Necessary definitions and enumerations

		#region Member variables

		private Word.Application m_wordApplication = null;
		private Word.Document m_currentDocument = null;
		private Word.Paragraph m_currentParagraph = null;
		private Word.Table m_currentTable = null;
		private Word.ListTemplate m_headingTemplate = null;

		#endregion Member variables
	

		/// <summary>
		/// This methods returns the text value associated with an enumeration item.
		/// If the enumeration item has a "Description" then the "Description" will
		/// be used in place of the ToString representation of the item.
		/// </summary>
		/// <param name="eValue">The enumeration item to evaluate.</param>
		/// <returns>Text that represents the enumeration value.</returns>
		private string GetEnumDescription(Enum eValue)
		{
			Type enumType = eValue.GetType();
			FieldInfo field = enumType.GetField(eValue.ToString());
			object[] attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
			return attributes.Length == 0 ? eValue.ToString() : ((DescriptionAttribute)attributes[0]).Description;
		}

		public WordInvoiceCreator()
		{
			m_wordApplication = new Word.Application();
		}

		public void ShowWord()
		{
			// Make word visible to show the results.
			m_wordApplication.Visible = true;
			m_wordApplication.Activate();
		}

		public void CreateInvoice()
		{
			object template = MISSING;

			// Hide Word while creating the document to speed things up.
			m_wordApplication.Visible = false;

			// Create a new Document, by calling the Add function in the Documents collection
			m_currentDocument = m_wordApplication.Documents.Add(ref template, ref MISSING, ref MISSING, ref MISSING);
			m_currentDocument.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
			m_currentDocument.PageSetup.TopMargin = m_wordApplication.CentimetersToPoints(1.2f);
			m_currentDocument.PageSetup.LeftMargin = m_wordApplication.CentimetersToPoints(2.0f);
			m_currentDocument.PageSetup.RightMargin = m_wordApplication.CentimetersToPoints(2.0f);
			m_currentDocument.PageSetup.BottomMargin = m_wordApplication.CentimetersToPoints(1.2f);
			m_currentDocument.PageSetup.HeaderDistance = m_wordApplication.CentimetersToPoints(1.0f);
			m_currentDocument.PageSetup.FooterDistance = m_wordApplication.CentimetersToPoints(0.72f);

			UpdateDocumentStyles();
		}

		private void UpdateDocumentStyles()
		{
			// Add a special Report styles so that it does not clash with existing styles.
			m_currentDocument.Styles.Add("Header Table Text", Word.WdStyleType.wdStyleTypeParagraph);
			m_currentDocument.Styles.Add("Invoice Normal", Word.WdStyleType.wdStyleTypeParagraph);
			m_currentDocument.Styles.Add("Invoice Table Text", Word.WdStyleType.wdStyleTypeParagraph);
			m_currentDocument.Styles.Add("Bank Text", Word.WdStyleType.wdStyleTypeParagraph);

			m_currentDocument.Styles["Header Table Text"].Font.Name = "Arial";
			m_currentDocument.Styles["Header Table Text"].Font.Size = 12;
			m_currentDocument.Styles["Header Table Text"].Font.Color = Word.WdColor.wdColorBlack;
			m_currentDocument.Styles["Header Table Text"].Font.Bold = (int)eBoldness.Bold;
			m_currentDocument.Styles["Header Table Text"].ParagraphFormat.SpaceBeforeAuto = 0;
			m_currentDocument.Styles["Header Table Text"].ParagraphFormat.SpaceBefore = 0;
			m_currentDocument.Styles["Header Table Text"].ParagraphFormat.SpaceAfterAuto = 0;
			m_currentDocument.Styles["Header Table Text"].ParagraphFormat.SpaceAfter = 0;

			m_currentDocument.Styles["Invoice Normal"].Font.Name = "Arial";
			m_currentDocument.Styles["Invoice Normal"].Font.Size = 11;
			m_currentDocument.Styles["Invoice Normal"].Font.Color = Word.WdColor.wdColorBlack;
			m_currentDocument.Styles["Invoice Normal"].ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
			m_currentDocument.Styles["Invoice Normal"].ParagraphFormat.SpaceBeforeAuto = 0;
			m_currentDocument.Styles["Invoice Normal"].ParagraphFormat.SpaceBefore = 0;
			m_currentDocument.Styles["Invoice Normal"].ParagraphFormat.SpaceAfterAuto = 0;
			m_currentDocument.Styles["Invoice Normal"].ParagraphFormat.SpaceAfter = 0;

			m_currentDocument.Styles["Invoice Table Text"].Font.Name = "Arial";
			m_currentDocument.Styles["Invoice Table Text"].Font.Size = 11;
			m_currentDocument.Styles["Invoice Table Text"].Font.Color = Word.WdColor.wdColorBlack;
			m_currentDocument.Styles["Invoice Table Text"].ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
			m_currentDocument.Styles["Invoice Table Text"].ParagraphFormat.SpaceBeforeAuto = 0;
			m_currentDocument.Styles["Invoice Table Text"].ParagraphFormat.SpaceBefore = 0.5f;
			m_currentDocument.Styles["Invoice Table Text"].ParagraphFormat.SpaceAfterAuto = 0;
			m_currentDocument.Styles["Invoice Table Text"].ParagraphFormat.SpaceAfter = 0;
			m_currentDocument.Styles["Invoice Table Text"].ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpaceSingle;
			m_currentDocument.Styles["Invoice Table Text"].ParagraphFormat.LeftIndent = 0;

			m_currentDocument.Styles["Bank Text"].Font.Name = "Arial";
			m_currentDocument.Styles["Bank Text"].Font.Size = 10;
			m_currentDocument.Styles["Bank Text"].Font.Color = Word.WdColor.wdColorBlack;
			m_currentDocument.Styles["Bank Text"].ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
			m_currentDocument.Styles["Bank Text"].ParagraphFormat.SpaceBeforeAuto = 0;
			m_currentDocument.Styles["Bank Text"].ParagraphFormat.SpaceBefore = 0;
			m_currentDocument.Styles["Bank Text"].ParagraphFormat.SpaceAfterAuto = 0;
			m_currentDocument.Styles["Bank Text"].ParagraphFormat.SpaceAfter = 0;
			m_currentDocument.Styles["Bank Text"].ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpaceSingle;
			m_currentDocument.Styles["Bank Text"].ParagraphFormat.LeftIndent = 0;

			m_currentDocument.UpdateStyles();
		}

		public void FillInHeader(eInvoiceType invoiceType, DateTime invoiceDate, int invoiceNumber)
		{
			// Set the focus to the page header.
			m_currentDocument.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageHeader;
			// Align everything central.
			m_currentDocument.ActiveWindow.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
			// Get the current Range instance.
			Word.Range currentRange = m_currentDocument.ActiveWindow.Selection.Range;

			if (invoiceType == eInvoiceType.JeanetteAndRichard)
			{
				// Insert first Header Line.
				m_currentParagraph = currentRange.Paragraphs.Add(ref MISSING);
				// Set the font size to 38 so that the Word Art fits into the space.
				m_currentParagraph.Range.Font.Size = 30;
				m_currentParagraph.Range.ParagraphFormat.SpaceBeforeAuto = 0;
				m_currentParagraph.Range.ParagraphFormat.SpaceBefore = 0;
				m_currentParagraph.Range.ParagraphFormat.SpaceAfterAuto = 0;
				m_currentParagraph.Range.ParagraphFormat.SpaceAfter = 0;

				// Add the Word Art
				Word.Shape headerArt = m_wordApplication.Selection.HeaderFooter.Shapes.AddTextEffect(MsoPresetTextEffect.msoTextEffect8,
										   "Jeanette & Richard Smith",
										   "Bodoni MT Black",
										   36,
										   MsoTriState.msoFalse,
										   MsoTriState.msoFalse,
										   m_wordApplication.CentimetersToPoints(5.81f), 0);
				headerArt.Height = m_wordApplication.CentimetersToPoints(1.18f);
				headerArt.Width = m_wordApplication.CentimetersToPoints(13.91f);

				// Add a new paragraph for the table.
				m_currentParagraph = currentRange.Paragraphs.Add(ref MISSING);
				// Add in a table of 1 row and 4 columns.
				m_currentTable = currentRange.Tables.Add(m_currentParagraph.Range, 1, 4, ref MISSING, ref MISSING);
				m_currentTable.Range.set_Style(m_currentDocument.Styles[GetEnumDescription(eInvoiceTextStyle.HeaderTableText)]);

				// Set up cell padding for the entire table.
				m_currentTable.LeftPadding = m_wordApplication.CentimetersToPoints(0.1f);
				m_currentTable.RightPadding = m_wordApplication.CentimetersToPoints(0.1f);
				m_currentTable.TopPadding = m_wordApplication.CentimetersToPoints(0.05f);
				m_currentTable.BottomPadding = m_wordApplication.CentimetersToPoints(0.05f);

				m_currentTable.Columns[1].Width = m_wordApplication.CentimetersToPoints(8.0f);
				m_currentTable.Columns[2].Width = m_wordApplication.CentimetersToPoints(9.8f);
				m_currentTable.Columns[3].Width = m_wordApplication.CentimetersToPoints(6.2f);
				m_currentTable.Columns[4].Width = m_wordApplication.CentimetersToPoints(1.7f);

				m_currentTable.Cell(1, 1).Range.Text = invoiceDate.ToLongDateString();

				m_currentTable.Cell(1, 2).Range.Text = "TAX INVOICE";
				m_currentTable.Cell(1, 2).Range.Font.Name = "Cooper Black";
				m_currentTable.Cell(1, 2).Range.Font.Size = 18;
				m_currentTable.Cell(1, 2).Range.Font.Bold = (int)eBoldness.NotBold;
				m_currentTable.Cell(1, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

				m_currentTable.Cell(1, 3).Range.Text = "INVOICE NUMBER:";
				m_currentTable.Cell(1, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;

				m_currentTable.Cell(1, 4).Range.Text = invoiceNumber.ToString("00000");
			}
			else
			{
				// Add a new paragraph for the table.
				m_currentParagraph = currentRange.Paragraphs.Add(ref MISSING);
				// Add in a table of 1 row and 4 columns.
				m_currentTable = currentRange.Tables.Add(m_currentParagraph.Range, 2, 4, ref MISSING, ref MISSING);
				m_currentTable.Range.set_Style(m_currentDocument.Styles[GetEnumDescription(eInvoiceTextStyle.HeaderTableText)]);

				// Set up cell padding for the entire table.
				m_currentTable.LeftPadding = m_wordApplication.CentimetersToPoints(0.1f);
				m_currentTable.RightPadding = m_wordApplication.CentimetersToPoints(0.1f);
				m_currentTable.TopPadding = m_wordApplication.CentimetersToPoints(0.05f);
				m_currentTable.BottomPadding = m_wordApplication.CentimetersToPoints(0.05f);

				m_currentTable.Columns[1].Width = m_wordApplication.CentimetersToPoints(8.0f);
				m_currentTable.Columns[2].Width = m_wordApplication.CentimetersToPoints(9.8f);
				m_currentTable.Columns[3].Width = m_wordApplication.CentimetersToPoints(6.2f);
				m_currentTable.Columns[4].Width = m_wordApplication.CentimetersToPoints(1.7f);

				m_currentTable.Rows[1].Height = m_wordApplication.CentimetersToPoints(1.0f);
				m_currentTable.Rows[2].Height = m_wordApplication.CentimetersToPoints(1.0f);

				MergeCells(1, 3, 1, 4);
				MergeCells(1, 1, 2, 1);
				MergeCells(1, 2, 2, 2);

				SetCellAlignment(1, 3, eParagraphAlignment.Right, eCellVerticalAlignment.Center);
				m_currentTable.Cell(1, 3).Range.Text = invoiceDate.ToLongDateString();

				m_currentTable.Cell(1, 2).Range.Text = "TAX INVOICE";
				m_currentTable.Cell(1, 2).Range.Font.Name = "Cooper Black";
				m_currentTable.Cell(1, 2).Range.Font.Size = 24;
				m_currentTable.Cell(1, 2).Range.Font.Bold = (int)eBoldness.NotBold;
				m_currentTable.Cell(1, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

				m_currentTable.Cell(2, 3).Range.Text = "INVOICE NUMBER:";
				m_currentTable.Cell(2, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;

				m_currentTable.Cell(2, 4).Range.Text = invoiceNumber.ToString("00000");


				string path = System.Windows.Forms.Application.ExecutablePath;

				path = path.Substring(0, path.LastIndexOf("\\") + 1);
				
				Word.Shape headerArt = m_wordApplication.Selection.HeaderFooter.Shapes.AddPicture(path + "OMG Logo Transparent.png",
																									Type.Missing,
																									Type.Missing,
																									m_wordApplication.CentimetersToPoints(0.75f),
																									0,
																									m_wordApplication.CentimetersToPoints(5.0f),
																									m_wordApplication.CentimetersToPoints(3.7f),
																									m_currentTable.Cell(1,1).Range);
			}			

			m_currentParagraph.Range.Font.Size = 2;

			// Setting focus back to document
			m_currentDocument.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument;
		}

		public void FillInFooter(eInvoiceType invoiceType)
		{
			object CurrentPage = Word.WdFieldType.wdFieldPage;
			object TotalPages = Word.WdFieldType.wdFieldNumPages;

			// Setting the focus on the page footer
			m_currentDocument.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageFooter;

			// Inserting the page numbers centrally aligned in the page footer
			m_currentDocument.ActiveWindow.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

			Word.Range currentRange = m_currentDocument.ActiveWindow.Selection.Range;
			m_currentTable = currentRange.Tables.Add(currentRange, 3, 7, ref MISSING, ref MISSING);
			m_currentTable.Range.set_Style(m_currentDocument.Styles[GetEnumDescription(eInvoiceTextStyle.TableText)]);
			m_currentTable.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;
			m_currentTable.Rows.WrapAroundText = -1;

			m_currentTable.Columns[1].Width = m_wordApplication.CentimetersToPoints(1.5f);
			m_currentTable.Columns[2].Width = m_wordApplication.CentimetersToPoints(0.4f);
			m_currentTable.Columns[3].Width = m_wordApplication.CentimetersToPoints(9.0f);
			m_currentTable.Columns[4].Width = m_wordApplication.CentimetersToPoints(4.1f);
			m_currentTable.Columns[5].Width = m_wordApplication.CentimetersToPoints(6.5f);
			m_currentTable.Columns[6].Width = m_wordApplication.CentimetersToPoints(0.4f);
			m_currentTable.Columns[7].Width = m_wordApplication.CentimetersToPoints(3.8f);

			SetRowBorder(1, eBorderType.Top, eLineStyle.Single);

			MergeCells(1, 1, 1, 3);
			MergeCells(2, 1, 2, 3);

			SetCellText(1, 1, "PO Box 1814");
			SetCellText(2, 1, "Margaret River WA 6285");
			SetCellText(3, 1, "email");
			SetCellText(3, 2, ":");
			switch(invoiceType)
			{
				case eInvoiceType.JeanetteAndRichard:
					SetCellText(3, 3, "rajsmith@iinet.net.au");
					break;
				case eInvoiceType.OsmingtonMillGarlic:
					SetCellText(3, 3, "OsmingtonMill@bigpond.com");
					break;
			}

			//SetCellText(1, 2, "Page");
			//SetCellText(2, 2, "1");	// TODO

			SetCellAlignment(1, 3, eParagraphAlignment.Right);
			SetCellText(1, 3, "Phone");
			SetCellText(1, 4, ":");
			SetCellText(1, 5, "(08) 9757 4545");

			if (invoiceType == eInvoiceType.OsmingtonMillGarlic)
			{
				SetCellAlignment(2, 3, eParagraphAlignment.Right);
				SetCellText(2, 3, "ABN");
				SetCellText(2, 4, ":");
				SetCellText(2, 5, "443 554 460 527");
			}

			// Setting focus back to document
			m_currentDocument.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument;
		}

		private void SetCurrentParagraphToMiniText()
		{
			m_currentParagraph.Range.Font.Size = 4;
			m_currentParagraph.Range.ParagraphFormat.SpaceBeforeAuto = 0;
			m_currentParagraph.Range.ParagraphFormat.SpaceBefore = 0;
			m_currentParagraph.Range.ParagraphFormat.SpaceAfterAuto = 0;
			m_currentParagraph.Range.ParagraphFormat.SpaceAfter = 0;
		}

		public void AddRecipientInformation(eInvoiceType invoiceType, string invoiceTo, string referenceText)
		{
			object endRange = GetLastRangeInDocument();
			m_currentParagraph = m_currentDocument.Content.Paragraphs.Add(ref endRange);
			m_currentTable = m_currentDocument.Tables.Add(m_currentParagraph.Range, 1, 4, ref MISSING, ref MISSING);
			m_currentTable.Range.set_Style(m_currentDocument.Styles[GetEnumDescription(eInvoiceTextStyle.Normal)]);

			// Set up cell padding for the entire table.
			m_currentTable.LeftPadding = m_wordApplication.CentimetersToPoints(0.1f);
			m_currentTable.RightPadding = m_wordApplication.CentimetersToPoints(0.1f);
			m_currentTable.TopPadding = m_wordApplication.CentimetersToPoints(0.05f);
			m_currentTable.BottomPadding = m_wordApplication.CentimetersToPoints(0.05f);

			m_currentTable.Rows[1].Height = m_wordApplication.CentimetersToPoints(1.5f);

			switch (invoiceType)
			{
				case eInvoiceType.JeanetteAndRichard:
					m_currentTable.Columns[1].Width = m_wordApplication.CentimetersToPoints(1.96f);
					m_currentTable.Columns[2].Width = m_wordApplication.CentimetersToPoints(11.64f);
					m_currentTable.Columns[3].Width = m_wordApplication.CentimetersToPoints(5.5f);
					m_currentTable.Columns[4].Width = m_wordApplication.CentimetersToPoints(6.6f);
					break;
				case eInvoiceType.OsmingtonMillGarlic:
					m_currentTable.Columns[1].Width = m_wordApplication.CentimetersToPoints(8.1f);
					m_currentTable.Columns[2].Width = m_wordApplication.CentimetersToPoints(7.25f);
					m_currentTable.Columns[3].Width = m_wordApplication.CentimetersToPoints(3.74f);
					m_currentTable.Columns[4].Width = m_wordApplication.CentimetersToPoints(6.6f);
					break;
			}

			SetCellText(1, 1, "To:");
			SetCellAlignment(1, 1, eParagraphAlignment.Right, eCellVerticalAlignment.Top);
			SetCellText(1, 2, invoiceTo);
			SetCellText(1, 3, "Reference:");
			SetCellAlignment(1, 3, eParagraphAlignment.Right, eCellVerticalAlignment.Top);
			SetCellText(1, 4, referenceText);

			SetCurrentParagraphToMiniText();
			InsertParagraphAfter();
		}					

		public void AddInvoiceBody()
		{
			object endRange = GetLastRangeInDocument();
			m_currentParagraph = m_currentDocument.Content.Paragraphs.Add(ref endRange);
			m_currentTable = m_currentDocument.Tables.Add(m_currentParagraph.Range, 20, 5, ref MISSING, ref MISSING);
			m_currentTable.Range.set_Style(m_currentDocument.Styles[GetEnumDescription(eInvoiceTextStyle.TableText)]);

			// Set up cell padding for the entire table.
			m_currentTable.LeftPadding = m_wordApplication.CentimetersToPoints(0.1f);
			m_currentTable.RightPadding = m_wordApplication.CentimetersToPoints(0.1f);
			m_currentTable.TopPadding = m_wordApplication.CentimetersToPoints(0.05f);
			m_currentTable.BottomPadding = m_wordApplication.CentimetersToPoints(0.05f);
			
			m_currentTable.Columns[1].Width = m_wordApplication.CentimetersToPoints(4.0f);
			m_currentTable.Columns[2].Width = m_wordApplication.CentimetersToPoints(2.0f);
			m_currentTable.Columns[3].Width = m_wordApplication.CentimetersToPoints(1.5f);
			m_currentTable.Columns[4].Width = m_wordApplication.CentimetersToPoints(15.03f);
			m_currentTable.Columns[5].Width = m_wordApplication.CentimetersToPoints(3.22f);

			MergeCells(1, 1, 1, 4);
			SetRowBorder(1, eBorderType.Bottom, eLineStyle.Single);
			SetRowBorder(1, eBorderType.Top, eLineStyle.Single);
			SetRowBorder(1, eBorderType.Left, eLineStyle.Single);
			SetRowBorder(1, eBorderType.Right, eLineStyle.Single);
			SetCellBorder(1, 1, eBorderType.Right, eLineStyle.Single);
			SetCellText(1, 1, "Description");
			SetCellBoldness(1, 1, eBoldness.Bold);
			SetCellText(1, 2, "Amount");
			SetCellAlignment(1, 2, eParagraphAlignment.Center);
			SetCellBoldness(1, 2, eBoldness.Bold);

			// Merge the first 4 columns together for the description.
			for(int row = 2; row < 18; row += 2)
			{
				MergeCells(row, 1, row, 4);
				SetCellBorder(row, 1, eBorderType.Left, eLineStyle.Single);
				SetCellBorder(row, 1, eBorderType.Right, eLineStyle.Single);
				SetCellBorder(row, 2, eBorderType.Right, eLineStyle.Single);
			}
			// Set the item rows to grey.
			for (int row = 3; row < 19; row += 2)
			{
				SetCellAlignment(row, 1, eParagraphAlignment.Right);
				SetCellAlignment(row, 5, eParagraphAlignment.Right);
				SetCellBorder(row, 1, eBorderType.Left, eLineStyle.Single);
				SetCellBorder(row, 4, eBorderType.Right, eLineStyle.Single);
				SetCellBorder(row, 5, eBorderType.Right, eLineStyle.Single);
				m_currentTable.Rows[row].Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
			}

			MergeCells(18, 1, 18, 3);
			MergeCells(19, 1, 19, 3);
			MergeCells(20, 1, 20, 3);

			SetRowBorder(17, eBorderType.Bottom, eLineStyle.Single);
			SetCellText(18, 2, "Sub Total");
			SetCellAlignment(18, 2, eParagraphAlignment.Right);
			SetCellAlignment(18, 3, eParagraphAlignment.Right);
			SetCellBorder(18, 3, eBorderType.Left, eLineStyle.Single);
			SetCellBorder(18, 3, eBorderType.Right, eLineStyle.Single);
			SetCellBorder(18, 3, eBorderType.Top, eLineStyle.Single);
			SetCellBorder(18, 3, eBorderType.Bottom, eLineStyle.Single);
			SetCellText(19, 2, "GST");
			SetCellAlignment(19, 2, eParagraphAlignment.Right);
			SetCellAlignment(19, 3, eParagraphAlignment.Right);
			SetCellBorder(19, 3, eBorderType.Left, eLineStyle.Single);
			SetCellBorder(19, 3, eBorderType.Right, eLineStyle.Single);
			SetCellBorder(19, 3, eBorderType.Top, eLineStyle.Single);
			SetCellBorder(19, 3, eBorderType.Bottom, eLineStyle.Single);
			SetCellText(20, 2, "Total including GST");
			SetCellAlignment(20, 2, eParagraphAlignment.Right);
			SetCellAlignment(20, 3, eParagraphAlignment.Right);
			SetCellBoldness(20, 2, eBoldness.Bold);
			SetCellBorder(20, 3, eBorderType.Left, eLineStyle.Single);
			SetCellBorder(20, 3, eBorderType.Right, eLineStyle.Single);
			SetCellBorder(20, 3, eBorderType.Top, eLineStyle.Single);
			SetCellBorder(20, 3, eBorderType.Bottom, eLineStyle.Single);
		}

		public void AddBankDetails()
		{
			InsertParagraphAfter();
			SetCurrentParagraphToMiniText();

			object endRange = GetLastRangeInDocument();
			m_currentParagraph = m_currentDocument.Content.Paragraphs.Add(ref endRange);
			m_currentTable = m_currentDocument.Tables.Add(m_currentParagraph.Range, 3, 3, ref MISSING, ref MISSING);
			m_currentTable.Range.set_Style(m_currentDocument.Styles[GetEnumDescription(eInvoiceTextStyle.BankText)]);
			m_currentTable.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;

			// Set up cell padding for the entire table.
			m_currentTable.LeftPadding = m_wordApplication.CentimetersToPoints(0.1f);
			m_currentTable.RightPadding = m_wordApplication.CentimetersToPoints(0.1f);
			m_currentTable.TopPadding = m_wordApplication.CentimetersToPoints(0.05f);
			m_currentTable.BottomPadding = m_wordApplication.CentimetersToPoints(0.05f);

			m_currentTable.Columns[1].Width = m_wordApplication.CentimetersToPoints(5.75f);
			m_currentTable.Columns[2].Width = m_wordApplication.CentimetersToPoints(3.5f);
			m_currentTable.Columns[3].Width = m_wordApplication.CentimetersToPoints(5.75f);

			SetCellText(1, 1, "Banking details for direct credit.");
			SetCellText(1, 2, "Account Name:");
			SetCellAlignment(1, 2, eParagraphAlignment.Right);
			SetCellText(2, 2, "BSB Number:");
			SetCellAlignment(2, 2, eParagraphAlignment.Right);
			SetCellText(3, 2, "Account Number:");
			SetCellAlignment(2, 2, eParagraphAlignment.Right);
			SetCellText(1, 3, "RAJ & JH Smith");
			SetCellText(2, 3, "016-520");
			SetCellText(3, 3, "5669-02804");
		}

		public void SetPageGutter(float cm)
		{
			m_currentDocument.PageSetup.Gutter = m_wordApplication.CentimetersToPoints(cm);
		}

		public void GoToStartOfDocument()
		{
			object what = Word.WdGoToItem.wdGoToLine;
			object which = Word.WdGoToDirection.wdGoToFirst;

			m_currentDocument.ActiveWindow.Selection.GoTo(ref what, ref which, ref MISSING, ref MISSING);
		}

		private Word.Range GetLastRangeInDocument()
		{
			return m_currentDocument.Bookmarks.get_Item(ref ENDOFDOC).Range;
		}

		public void InsertParagraphAfter()
		{
			m_currentParagraph.Range.InsertParagraphAfter();
		}

		public void SetPageBreakBefore(ePageBreakBefore beforeOnOff)
		{
			m_currentParagraph.PageBreakBefore = (int)beforeOnOff;
		}

		public void ApplyBulletDefault()
		{
			m_currentParagraph.Range.ListFormat.ApplyBulletDefault();
		}

		public void TurnOffBulletPoints()
		{
			m_currentParagraph.Range.ListFormat.RemoveNumbers(Word.WdNumberType.wdNumberParagraph);
		}

		public void AppendStyledText(string theText, eInvoiceTextStyle textStyle)
		{
			object endRange = m_currentDocument.Bookmarks.get_Item(ref ENDOFDOC).Range;
			m_currentParagraph = m_currentDocument.Content.Paragraphs.Add(ref endRange);

			string[] linesOfText = theText.Split(new string[] { "\r\n" }, StringSplitOptions.None);

			for (int lineNumber = 0; lineNumber < linesOfText.Length; lineNumber++)
			{
				m_currentParagraph.Range.Text = linesOfText[lineNumber];
				m_currentParagraph.set_Style(m_currentDocument.Styles[GetEnumDescription(textStyle)]);
				if (lineNumber < linesOfText.Length - 1)
				{
					m_currentParagraph.Range.InsertParagraphAfter();
				}
			}
		}

		public void AppendStyledText(string theText, eInvoiceTextStyle textStyle, bool restartNumbering)
		{
			object endRange = m_currentDocument.Bookmarks.get_Item(ref ENDOFDOC).Range;
			m_currentParagraph = m_currentDocument.Content.Paragraphs.Add(ref endRange);

			string[] linesOfText = theText.Split(new string[] { "\r\n" }, StringSplitOptions.None);

			for (int lineNumber = 0; lineNumber < linesOfText.Length; lineNumber++)
			{
				m_currentParagraph.Range.Text = linesOfText[lineNumber];
				m_currentParagraph.set_Style(m_currentDocument.Styles[GetEnumDescription(textStyle)]);
				m_currentParagraph.Range.ListFormat.ApplyListTemplate(m_headingTemplate,
																	  !restartNumbering,
																	  Word.WdListApplyTo.wdListApplyToThisPointForward,
																	  Word.WdDefaultListBehavior.wdWord10ListBehavior);
				if (lineNumber < linesOfText.Length - 1)
				{
					m_currentParagraph.Range.InsertParagraphAfter();
				}
			}
		}

		public void AppendStyledText(string theText, eInvoiceTextStyle textStyle, eParagraphAlignment alignment = eParagraphAlignment.Left,
										eBoldness bold = eBoldness.NotBold,
										eItalicisation italic = eItalicisation.NotItalic,
										eUnderline underlined = eUnderline.None,
										bool insertParagraphBefore = false)
		{
			object endRange = m_currentDocument.Bookmarks.get_Item(ref ENDOFDOC).Range;
			m_currentParagraph = m_currentDocument.Content.Paragraphs.Add(ref endRange);

			if (insertParagraphBefore)
			{
				m_currentParagraph.Range.InsertParagraphBefore();
			}
			string[] linesOfText = theText.Split(new string[] { "\r\n" }, StringSplitOptions.None);

			for (int lineNumber = 0; lineNumber < linesOfText.Length; lineNumber++)
			{
				m_currentParagraph.Range.Text = linesOfText[lineNumber];
				m_currentParagraph.Range.set_Style(m_currentDocument.Styles[GetEnumDescription(textStyle)]);
				m_currentParagraph.Range.Font.Bold = (int)bold;
				m_currentParagraph.Range.Font.Italic = (int)italic;
				m_currentParagraph.Range.Font.Underline = (Word.WdUnderline)underlined;
				m_currentParagraph.Range.ParagraphFormat.Alignment = (Word.WdParagraphAlignment)alignment;
				if (lineNumber < linesOfText.Length - 1)
				{
					m_currentParagraph.Range.InsertParagraphAfter();
				}
			}
		}

		public void AppendText(string theText, eParagraphAlignment alignment = eParagraphAlignment.Left,
								eBoldness bold = eBoldness.NotBold,
								eItalicisation italic = eItalicisation.NotItalic,
								eUnderline underlined = eUnderline.None,
								bool insertParagraphBefore = false)
		{
			object endRange = m_currentDocument.Bookmarks.get_Item(ref ENDOFDOC).Range;
			m_currentParagraph = m_currentDocument.Content.Paragraphs.Add(ref endRange);

			m_currentParagraph.Range.Font.Name = "Arial";
			m_currentParagraph.Range.Font.Size = 11;
			m_currentParagraph.Range.Font.Color = Word.WdColor.wdColorBlack;

			if (insertParagraphBefore)
			{
				m_currentParagraph.Range.InsertParagraphBefore();
			}
			m_currentParagraph.Range.Text = theText;
			m_currentParagraph.Range.Font.Bold = (int)bold;
			m_currentParagraph.Range.Font.Italic = (int)italic;
			m_currentParagraph.Range.Font.Underline = (Word.WdUnderline)underlined;
			m_currentParagraph.Range.ParagraphFormat.Alignment = (Word.WdParagraphAlignment)alignment;
		}

		public void AddHeaderText(List<string> linesOfText)
		{
			bool first = true;
			object missing = System.Reflection.Missing.Value;

			// Setting the focus on the page header
			m_currentDocument.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageHeader;

			// Inserting the page numbers centrally aligned in the page header
			m_currentDocument.ActiveWindow.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

			Word.Range currentRange = m_currentDocument.ActiveWindow.Selection.Range;

			// Insert first Header Line.
			m_currentParagraph = currentRange.Paragraphs.Add(ref missing);

			foreach (string line in linesOfText)
			{
				if (!first)
				{
					m_currentParagraph.Range.InsertParagraphAfter();
				}
				first = false;

				m_currentParagraph.Range.Font.Name = "Arial";
				m_currentParagraph.Range.Font.Size = 11;
				m_currentParagraph.Range.Font.Color = Word.WdColor.wdColorBlack;
				m_currentParagraph.Range.Font.Bold = (int)eBoldness.Bold;
				m_currentParagraph.Range.Text = line;
				m_currentParagraph.SpaceBeforeAuto = 0;
				m_currentParagraph.SpaceAfterAuto = 0;
				m_currentParagraph.SpaceBefore = 3;
				m_currentParagraph.SpaceAfter = 3;
			}
			// Force the last line to have a larger space after to provide a gap between header and body text.
			m_currentParagraph.SpaceAfter = 6;

			// Setting focus back to document
			m_currentDocument.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument;
		}

		public void AddSectionBreakAndBlankHeader()
		{
			Word.Range endRange = m_currentDocument.Bookmarks.get_Item(ref ENDOFDOC).Range;
			object sectionBreak = Word.WdSectionStart.wdSectionNewPage;

			endRange.InsertBreak(ref sectionBreak);

			// Move to after the section break.
			m_currentDocument.Bookmarks.get_Item(ref ENDOFDOC).Range.Select();

			// Get the last header in the document.
			int lastHeader = m_currentDocument.Sections.Count;
			Word.HeaderFooter currentHeader = m_currentDocument.Sections[lastHeader].Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary];

			// Unlink from the previous header.
			currentHeader.LinkToPrevious = false;

			// Delete the content of the Header.
			object deletePara = Word.WdUnits.wdWord;
			object numberOfWords = currentHeader.Range.Words.Count;
			currentHeader.Range.Delete(ref deletePara, ref numberOfWords);
		}

		public void AddStandardReportTable(int rows, int columns, List<float> columnWidths, float leftIndent = 0)
		{
			Word.Range currentRange = GetLastRangeInDocument();

			m_currentTable = m_currentDocument.Tables.Add(currentRange, rows, columns, ref MISSING, ref MISSING);
			m_currentTable.Range.set_Style(m_currentDocument.Styles[GetEnumDescription(eInvoiceTextStyle.TableText)]);

			// Set up cell padding for the entire table.
			m_currentTable.LeftPadding = m_wordApplication.CentimetersToPoints(0.1f);
			m_currentTable.RightPadding = m_wordApplication.CentimetersToPoints(0.1f);
			m_currentTable.TopPadding = m_wordApplication.CentimetersToPoints(0.05f);
			m_currentTable.BottomPadding = m_wordApplication.CentimetersToPoints(0.05f);

			if (leftIndent > 0)
			{
				m_currentTable.Rows.SetLeftIndent(m_wordApplication.CentimetersToPoints(leftIndent), Word.WdRulerStyle.wdAdjustNone);
			}
			else
			{
				m_currentTable.Rows.LeftIndent = m_wordApplication.CentimetersToPoints(0);
			}

			for (int index = 0; index < Math.Min(columns, columnWidths.Count); index++)
			{
				m_currentTable.Columns[index + 1].Width = m_wordApplication.CentimetersToPoints(columnWidths[index]);
			}
		}

		public void AddStandardReportFooter(string leftText, string rightText, bool includePageNumbers = true)
		{
			object CurrentPage = Word.WdFieldType.wdFieldPage;
			object TotalPages = Word.WdFieldType.wdFieldNumPages;

			// Setting the focus on the page footer
			m_currentDocument.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageFooter;

			// Inserting the page numbers centrally aligned in the page footer
			m_currentDocument.ActiveWindow.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

			Word.Range currentRange = m_currentDocument.ActiveWindow.Selection.Range;
			Word.Table newTable = currentRange.Tables.Add(currentRange, 1, 3, ref MISSING, ref MISSING);
			//			newTable.Range.set_Style(m_currentDocument.Styles[GMSHelper.GetEnumDescription(ReportTextStyle.TableText)]);
			newTable.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;
			newTable.Rows.WrapAroundText = -1;

			if (m_currentDocument.PageSetup.Orientation == Word.WdOrientation.wdOrientPortrait)
			{
				newTable.Columns[1].Width = m_wordApplication.CentimetersToPoints(6.79f);
				newTable.Columns[2].Width = m_wordApplication.CentimetersToPoints(3.79f);
				newTable.Columns[3].Width = m_wordApplication.CentimetersToPoints(6.79f);
			}
			else
			{
				newTable.Columns[1].Width = m_wordApplication.CentimetersToPoints(11.35f);
				newTable.Columns[2].Width = m_wordApplication.CentimetersToPoints(3.8f);
				newTable.Columns[3].Width = m_wordApplication.CentimetersToPoints(11.35f);
			}

			newTable.Rows[1].Range.Font.Bold = (int)eBoldness.NotBold;
			newTable.Rows[1].Range.Font.Name = "Arial";
			newTable.Rows[1].Range.Font.Size = 11;
			newTable.Rows[1].Range.Font.Color = Word.WdColor.wdColorBlack;
			newTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
			newTable.Rows[1].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

			if (leftText.Length > 0)
			{
				newTable.Cell(1, 1).Range.Text = leftText;
				newTable.Cell(1, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
			}

			if (rightText.Length > 0)
			{
				newTable.Cell(1, 3).Range.Text = rightText;
				newTable.Cell(1, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
			}
			newTable.Cell(1, 2).Select();

			if (includePageNumbers)
			{
				m_currentDocument.ActiveWindow.Selection.TypeText("Page ");
				m_currentDocument.ActiveWindow.Selection.Fields.Add(m_currentDocument.ActiveWindow.Selection.Range, ref CurrentPage, ref MISSING, ref MISSING);
				m_currentDocument.ActiveWindow.Selection.TypeText(" of ");
				m_currentDocument.ActiveWindow.Selection.Fields.Add(m_currentDocument.ActiveWindow.Selection.Range, ref TotalPages, ref MISSING, ref MISSING);
			}

			// Setting focus back to document
			m_currentDocument.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument;
		}

		public void EnableTableBorders()
		{
			m_currentTable.Borders.Enable = 1;
		}

		/// <summary>
		/// This method duplicates the last row of the specified table.
		/// </summary>
		/// <param name="iTable">The table to which the row is to be added.</param>
		/// <returns>Returns the row number of the second to last row i.e. the row
		/// that should receive the next set of data.</returns>
		public int DuplicateLastTableRow()
		{
			int lastRowNumber = m_currentTable.Rows.Count;

			m_currentTable.Rows.Add(m_currentTable.Rows[lastRowNumber]);
			// The borders of last row are turn off just in case the previous row had borders assigned.
			m_currentTable.Rows[lastRowNumber + 1].Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleNone;

			return lastRowNumber;
		}

		public void SetRowSpaceBefore(int rowNumber, float points)
		{
			m_currentTable.Rows[rowNumber].Range.ParagraphFormat.SpaceBefore = points;
		}

		public void SetRowSpaceAfter(int rowNumber, float points)
		{
			m_currentTable.Rows[rowNumber].Range.ParagraphFormat.SpaceAfter = points;
		}

		public void SetRowBold(int rowNumber, eBoldness bold)
		{
			m_currentTable.Rows[rowNumber].Range.Font.Bold = (int)bold;
		}

		public void SetRowFontName(int rowNumber, string fontName)
		{
			m_currentTable.Rows[rowNumber].Range.Font.Name = fontName;
		}

		public void SetRowFontSize(int rowNumber, float fontSize)
		{
			m_currentTable.Rows[rowNumber].Range.Font.Size = fontSize;
		}

		public void SetRowAlignment(int rowNumber, eParagraphAlignment horizontal, eCellVerticalAlignment vertical = eCellVerticalAlignment.Center)
		{
			m_currentTable.Rows[rowNumber].Range.ParagraphFormat.Alignment = (Word.WdParagraphAlignment)horizontal;
			m_currentTable.Rows[rowNumber].Cells.VerticalAlignment = (Word.WdCellVerticalAlignment)vertical;
		}

		public void SetRowAsHeader(int rowNumber)
		{
			m_currentTable.Rows[rowNumber].HeadingFormat = -1;
		}

		public void SetRowToBreakAcrossPages(int rowNumber)
		{
			m_currentTable.Rows[rowNumber].AllowBreakAcrossPages = 0;
		}

		public void SetRowKeepWithNext(int rowNumber, eKeepWithNext keep)
		{
			m_currentTable.Rows[rowNumber].Range.ParagraphFormat.KeepWithNext = (int)keep;
		}

		public void SetCellBorder(int row, int column, eBorderType border, eLineStyle style)
		{
			m_currentTable.Cell(row, column).Borders[(Word.WdBorderType)border].Color = Word.WdColor.wdColorBlack;
			m_currentTable.Cell(row, column).Borders[(Word.WdBorderType)border].LineStyle = (Word.WdLineStyle)style;
		}

		public void SetRowBorder(int rowNumber, eBorderType border, eLineStyle style)
		{
			m_currentTable.Rows[rowNumber].Borders[(Word.WdBorderType)border].Color = Word.WdColor.wdColorBlack;
			m_currentTable.Rows[rowNumber].Borders[(Word.WdBorderType)border].LineStyle = (Word.WdLineStyle)style;
		}

		public void SetRowTextUnderline(int rowNumber, eUnderline style)
		{
			m_currentTable.Rows[rowNumber].Range.Font.Underline = (Word.WdUnderline)style;
		}

		public void SetCellText(int row, int column, string text)
		{
			m_currentTable.Cell(row, column).Range.Text = text;
		}

		public void FillBlankableCell(int row, int column, int value, string format)
		{
			if (value != 0)
			{
				m_currentTable.Cell(row, column).Range.Text = value.ToString(format);
			}
		}

		public void FillBlankableCell(int row, int column, decimal value, string format)
		{
			if (value != 0)
			{
				m_currentTable.Cell(row, column).Range.Text = value.ToString(format);
			}
		}

		public void SetCellAlignment(int row, int column, eParagraphAlignment alignment, eCellVerticalAlignment vertical = eCellVerticalAlignment.Center)
		{
			m_currentTable.Cell(row, column).Range.ParagraphFormat.Alignment = (Word.WdParagraphAlignment)alignment;
			m_currentTable.Cell(row, column).VerticalAlignment = (Word.WdCellVerticalAlignment)vertical;
		}

		public void SetCellBoldness(int row, int column, eBoldness bold)
		{
			m_currentTable.Cell(row, column).Range.Font.Bold = (int)bold;
		}

		public void SetCellItalics(int row, int column, eItalicisation italics)
		{
			m_currentTable.Cell(row, column).Range.Font.Italic = (int)italics;
		}

		public void SetCellTextUnderline(int row, int column, eUnderline style)
		{
			m_currentTable.Cell(row, column).Range.Font.Underline = (Word.WdUnderline)style;
		}

		public void MergeCells(int startRow, int startColumn, int endRow, int endColumn)
		{
			m_currentTable.Cell(startRow, startColumn).Merge(m_currentTable.Cell(endRow, endColumn));
		}

		public int CurrentTableRowCount()
		{
			return m_currentTable.Rows.Count;
		}

		public int CurrentTableColumnCount()
		{
			return m_currentTable.Columns.Count;
		}

	}
}
