using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using PdfFileWriter;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

using GenCode128;
using System.Collections.Generic;

namespace BarcodeGen
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class BarcodeGen : System.Windows.Forms.Form
	{
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox txtInput;
      private System.Windows.Forms.Button cmdMakeBarcode;
      private System.Windows.Forms.PictureBox pictBarcode;
      private System.Windows.Forms.TextBox txtWeight;
      private System.Windows.Forms.Label label2;
      private System.Drawing.Printing.PrintDocument printDocument1;
      private System.Windows.Forms.Button cmdPrint;
      private System.Windows.Forms.TextBox scaleTxtBox;
      private Label label3;
      private System.Windows.Forms.TextBox HeightScaleTxtBox;
      private Label label4;
      private Button btnMakePdf;
      
      PdfDocument Document;
      PdfPage Page;
      PdfContents Contents;

      private PdfTilingPattern WaterMark;
      private PdfFont ArialNormal;
      private PdfFont ArialBold;
      private PdfFont ArialItalic;
      private PdfFont ArialBoldItalic;
      private PdfFont TimesNormal;
      private PdfFont CourierNormal;
      private PdfFont CourierBold;
      private PdfFont Comic;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BarcodeGen()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.cmdMakeBarcode = new System.Windows.Forms.Button();
            this.pictBarcode = new System.Windows.Forms.PictureBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.scaleTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.HeightScaleTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMakePdf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictBarcode)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text to encode";
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(115, 9);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(415, 22);
            this.txtInput.TabIndex = 1;
            this.txtInput.Text = "12345678";
            // 
            // cmdMakeBarcode
            // 
            this.cmdMakeBarcode.Location = new System.Drawing.Point(230, 42);
            this.cmdMakeBarcode.Name = "cmdMakeBarcode";
            this.cmdMakeBarcode.Size = new System.Drawing.Size(111, 26);
            this.cmdMakeBarcode.TabIndex = 2;
            this.cmdMakeBarcode.Text = "Make barcode";
            this.cmdMakeBarcode.Click += new System.EventHandler(this.cmdMakeBarcode_Click);
            // 
            // pictBarcode
            // 
            this.pictBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictBarcode.Location = new System.Drawing.Point(10, 187);
            this.pictBarcode.Name = "pictBarcode";
            this.pictBarcode.Size = new System.Drawing.Size(525, 105);
            this.pictBarcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictBarcode.TabIndex = 3;
            this.pictBarcode.TabStop = false;
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(115, 42);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(53, 22);
            this.txtWeight.TabIndex = 5;
            this.txtWeight.Text = "1";
            this.txtWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Bar weight";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPrint.Location = new System.Drawing.Point(444, 301);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(90, 27);
            this.cmdPrint.TabIndex = 6;
            this.cmdPrint.Text = "Print";
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // scaleTxtBox
            // 
            this.scaleTxtBox.Location = new System.Drawing.Point(115, 76);
            this.scaleTxtBox.Name = "scaleTxtBox";
            this.scaleTxtBox.Size = new System.Drawing.Size(53, 22);
            this.scaleTxtBox.TabIndex = 8;
            this.scaleTxtBox.Text = "25";
            this.scaleTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Width Scale";
            // 
            // HeightScaleTxtBox
            // 
            this.HeightScaleTxtBox.Location = new System.Drawing.Point(115, 108);
            this.HeightScaleTxtBox.Name = "HeightScaleTxtBox";
            this.HeightScaleTxtBox.Size = new System.Drawing.Size(53, 22);
            this.HeightScaleTxtBox.TabIndex = 10;
            this.HeightScaleTxtBox.Text = "20";
            this.HeightScaleTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Height Scale";
            // 
            // btnMakePdf
            // 
            this.btnMakePdf.Location = new System.Drawing.Point(230, 81);
            this.btnMakePdf.Name = "btnMakePdf";
            this.btnMakePdf.Size = new System.Drawing.Size(111, 26);
            this.btnMakePdf.TabIndex = 11;
            this.btnMakePdf.Text = "Make PDF";
            this.btnMakePdf.Click += new System.EventHandler(this.btnMakePdf_Click);
            // 
            // BarcodeGen
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(540, 336);
            this.Controls.Add(this.btnMakePdf);
            this.Controls.Add(this.HeightScaleTxtBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.scaleTxtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictBarcode);
            this.Controls.Add(this.cmdMakeBarcode);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BarcodeGen";
            this.Text = "BarcodeGen";
            ((System.ComponentModel.ISupportInitialize)(this.pictBarcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

      }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new BarcodeGen());
		}

      private void cmdMakeBarcode_Click(object sender, System.EventArgs e)
      {
         Code128Rendering.wScale = Convert.ToDouble(scaleTxtBox.Text);
         Code128Rendering.hScale = Convert.ToDouble(HeightScaleTxtBox.Text);
         try
         {
            Image myimg = Code128Rendering.MakeBarcodeImage(txtInput.Text, double.Parse(txtWeight.Text), true);
            pictBarcode.Image = myimg;
         }
         catch (Exception ex)
         {
            MessageBox.Show(this, ex.Message, this.Text);
         }
      }

      private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
      {
         using (Graphics g = e.Graphics)
         {
            using (Font fnt = new Font("Arial", 16))
            {
               string caption = string.Format("Code128 barcode weight={0}", txtWeight.Text);
               g.DrawString(caption, fnt, System.Drawing.Brushes.Black, 50, 50);
               caption = string.Format("message='{0}'", txtInput.Text);
               g.DrawString(caption, fnt, System.Drawing.Brushes.Black, 50, 75);
               g.DrawImage(pictBarcode.Image, 50, 110);
            }
         }
      }

      private void cmdPrint_Click(object sender, System.EventArgs e)
      {
         printDocument1.Print();
      }

      private void btnMakePdf_Click(object sender, EventArgs e)
      {
          string Filename = "myFile.pdf";

          //if (File.Exists(Filename))
          //{
          //    File.Delete(Filename);
          //}

          Document = new PdfDocument(PaperType.Letter, false, UnitOfMeasure.Inch, Filename);
          Document.Debug = false;
          DefineFontResources();
          DefineTilingPatternResource();
          Page = new PdfPage(Document);
          Contents = new PdfContents(Page);

            IPartDataAdapter adapter = new ExamplePartDataAdapter();
            List<Part> parts = adapter.GetPartsData();

            try
            {
                int index = 0;
                for (double j = 0.5; j < 10.5; j += 0.5)
                {
                    for (double i = 0.375; i < 8.375; i += 2)
                    {
                        Part part = parts[index++];
                        DrawBox(i, j);
                        DrawBarcode(i, j, "" + part.GetId());
                        DrawNumber(i, j, "" + part.GetId());
                        DrawTextBox(i, j, part.GetName());
                        DrawTextBox(i, j - 0.1, part.GetName());
                    }
                }
            }
            catch (ArgumentOutOfRangeException error) { }
          Document.CreateFile();

          // start default PDF reader and display the file
          Process Proc = new Process();
          Proc.StartInfo = new ProcessStartInfo(Filename);
          Proc.Start();

          return;
      }

      ////////////////////////////////////////////////////////////////////
      // Define Font Resources
      ////////////////////////////////////////////////////////////////////

      private void DefineFontResources()
      {
          // Define font resources
          // Arguments: PdfDocument class, font family name, font style, embed flag
          // Font style (must be: Regular, Bold, Italic or Bold | Italic) All other styles are invalid.
          // Embed font. If true, the font file will be embedded in the PDF file.
          // If false, the font will not be embedded
          String FontName1 = "Arial";
          String FontName2 = "Times New Roman";
          String FontName3 = "Courier New";

          ArialNormal = new PdfFont(Document, FontName1, FontStyle.Regular, true);
          ArialBold = new PdfFont(Document, FontName1, FontStyle.Bold, true);
          ArialItalic = new PdfFont(Document, FontName1, FontStyle.Italic, true);
          ArialBoldItalic = new PdfFont(Document, FontName1, FontStyle.Bold | FontStyle.Italic, true);
          TimesNormal = new PdfFont(Document, FontName2, FontStyle.Regular, true);
          CourierNormal = new PdfFont(Document, FontName3, FontStyle.Regular, true);
          CourierBold = new PdfFont(Document, FontName3, FontStyle.Bold, true);
          Comic = new PdfFont(Document, "Comic Sans MS", FontStyle.Bold, true);

          // substitute one character for another
          // this program supports characters 32 to 126 and 160 to 255
          // if a font has a character outside these ranges that is required by the application,
          // you can replace an unused character with this character
          // Note: space (32) and non breaking space (160) cannot be replaced
          ArialNormal.CharSubstitution(9679, 9679, 161);		// euro
          ArialNormal.CharSubstitution(1488, 1514, 162);		// hebrew
          ArialNormal.CharSubstitution(1040, 1045, 189);		// russian
          ArialNormal.CharSubstitution(945, 950, 195);		// greek
          return;
      }

      ////////////////////////////////////////////////////////////////////
      // Define Tiling Pattern Resource
      ////////////////////////////////////////////////////////////////////

      private void DefineTilingPatternResource()
      {
          // create empty tiling pattern
          WaterMark = new PdfTilingPattern(Document);

          // the pattern will be PdfFileWriter laied out in brick pattern
          String Mark = "PdfFileWriter";

          // text width and height for Arial bold size 18 points
          Double FontSize = 18.0;
          Double TextWidth = ArialBold.TextWidth(FontSize, Mark);
          Double TextHeight = ArialBold.LineSpacing(FontSize);

          // text base line
          Double BaseLine = ArialBold.DescentPlusLeading(FontSize);

          // the overall pattern box (we add text height value as left and right text margin)
          Double BoxWidth = TextWidth + 2 * TextHeight;
          Double BoxHeight = 4 * TextHeight;
          WaterMark.SetTileBox(BoxWidth, BoxHeight);

          // save graphics state
          WaterMark.SaveGraphicsState();

          // fill the pattern box with background light blue color
          WaterMark.SetColorNonStroking(Color.FromArgb(230, 244, 255));
          WaterMark.DrawRectangle(0, 0, BoxWidth, BoxHeight, PaintOp.Fill);

          // set fill color for water mark text to white
          WaterMark.SetColorNonStroking(Color.White);

          // draw PdfFileWriter at the bottom center of the box
          WaterMark.DrawText(ArialBold, FontSize, BoxWidth / 2, BaseLine, TextJustify.Center, Mark);

          // adjust base line upward by half height
          BaseLine += BoxHeight / 2;

          // draw the right half of PdfFileWriter shifted left by half width
          WaterMark.DrawText(ArialBold, FontSize, 0.0, BaseLine, TextJustify.Center, Mark);

          // draw the left half of PdfFileWriter shifted right by half width
          WaterMark.DrawText(ArialBold, FontSize, BoxWidth, BaseLine, TextJustify.Center, Mark);

          // restore graphics state
          WaterMark.RestoreGraphicsState();
          return;
      }


      ////////////////////////////////////////////////////////////////////
      // Draw Barcode
      ////////////////////////////////////////////////////////////////////

      private void DrawBarcode(double i, double j, string value)
      {          
          double xBuffer = 0.8;
          double yBuffer = 0.05;
          double barWidth = 0.013;
          double barHeight = 0.195;

          Contents.SaveGraphicsState();
          Barcode128 Barcode1 = new Barcode128(value);
          Contents.DrawBarcode(i + xBuffer, j + yBuffer, barWidth, barHeight, Barcode1, ArialNormal, 0);          
          Contents.RestoreGraphicsState();
          return;
      }

      /*******************************************************************
       ** Draw box
       ********************************************************************/

      private void DrawBox(double i, double j)
      {
          double width = 1.75;
          double height = 0.5;

          Contents.SaveGraphicsState();
          Contents.SetLineWidth(0.01);
          Contents.SetColorStroking(Color.Black);
          Contents.SetColorNonStroking(Color.White);
          Contents.DrawRectangle(i, j, width, height, PaintOp.CloseFillStroke);
          Contents.RestoreGraphicsState();
          return;
      }

      ////////////////////////////////////////////////////////////////////
      // Draw example of a text box
      ////////////////////////////////////////////////////////////////////

      private void DrawTextBox(double i, double j, string text)
      {
          Contents.SaveGraphicsState();
          const Double Width = 1.75;
          const Double Height = 0.25;
          const Double FontSize = 8.0;

          PdfFileWriter.TextBox Box = new PdfFileWriter.TextBox(Width);
          Box.AddText(CourierBold, FontSize, text);
          Double PosY = Height + 0.21885 + j;
          Contents.DrawText(0.03125+i, ref PosY, 0.0, 0, 0.015, 0.05, TextBoxJustify.FitToWidth, Box);
          Contents.RestoreGraphicsState();
          return;
      }

      private void DrawNumber(double i, double j, string text)
      {
          Contents.SaveGraphicsState();
          const Double Width = 1.75;
          const Double Height = 0.20;
          const Double FontSize = 8.0;

          PdfFileWriter.TextBox Box = new PdfFileWriter.TextBox(Width);
          Box.AddText(CourierBold, FontSize, text);
          Double PosY = Height + j;
          Contents.DrawText(0.28125 + i, ref PosY, 0.0, 0, 0.015, 0.05, TextBoxJustify.FitToWidth, Box);
          Contents.RestoreGraphicsState();
          return;
      }

	}
}
