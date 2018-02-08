using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using MigraDoc;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.DocumentObjectModel.Shapes;
using PdfSharp.Pdf;
using MigraDoc.Rendering;
using PdfSharp.Drawing;

namespace PDFReportGenerator {
    public class PdfReport {
        ReportProperties prop;
        Document document = new Document();
        Section current_section;
        Table table; 

        public PdfReport(ReportProperties prop) {
            this.prop = prop;
            document.Info = prop.document_info;
            document.UseCmykColor = prop.UseCmykColor;
            document.DefaultPageSetup.Orientation = ReportProperties.Orientation;

            current_section = document.AddSection();

            _CreateLeadingInformation();
            _CreateTable();

            _FillRowsContent();
            _Render();
        }

        private void _CreateLeadingInformation() {
            Paragraph paragraph = current_section.Headers.Primary.AddParagraph();
            paragraph.AddText("HelloWorld");
            paragraph.Format.Font.Size = 9;
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            // Create the text frame for the address

            Paragraph dateFrame = current_section.AddParagraph();
            dateFrame.Format.Alignment = ParagraphAlignment.Right;
            // Put sender in address frame
            dateFrame.AddText("Information: Hello World \r\n 123\r\nDate: 2017/11/11");
            dateFrame.Format.Font.Name = "Times New Roman";
            dateFrame.Format.Font.Size = 10;
        }

        #region Table
        private void _CreateTable() {
            //TextFrame tableFrame = current_section.AddTextFrame();
            //tableFrame.Left = ShapePosition.Left;
            //tableFrame.RelativeVertical = RelativeVertical.Paragraph;
            //tableFrame.RelativeHorizontal = RelativeHorizontal.Margin;
            //this.table = tableFrame.AddTable();
            current_section.AddParagraph();
            current_section.AddParagraph();
            current_section.AddParagraph();
            current_section.AddParagraph();

            this.table = current_section.AddTable();
            this.table.Style = "Table";
            this.table.Borders = prop.table.borders.Clone();
            this.table.Rows.LeftIndent = 0;
            this.table.Format.Font.Size = new Unit(9, UnitType.Point);
            _CreateTableColumn();
            _CreateTableHeaderRow();
        }

        private void _CreateTableColumn() {
            double total_width_percentage = prop.table.columns.Sum(x => x.WidthPercentage);

            foreach (var col_attr in prop.table.columns) {
                double width = ReportProperties.GetMaxTableWidth() * (col_attr.WidthPercentage / total_width_percentage);
                Column column = this.table.AddColumn(width.ToString("0.00") + "cm");
            }
        }

        private void _CreateTableHeaderRow() {
            Row row = table.AddRow();
            row.Format.Font.Bold = true;
            row.KeepWith = 1;
            for (int i = 0; i < prop.table.columns.Count; i++) {
                row.Cells[i].AddParagraph(prop.table.columns[i].Header);
            }
        }

        private void _FillRowsContent() {
            int count = 0;
            foreach (var data in prop.table.datum) {
                Row row = table.AddRow();

                if (prop.table.BreakAt > 0 && count > 0 && count % prop.table.BreakAt == 0) {
                    current_section = document.AddSection();
                    _CreateLeadingInformation();
                    _CreateTable();
                }

                for (int i = 0; i < data.Length; i++) {
                    _AddTextToCellWithOverFlow(data[i], row.Cells[i], this.table.Format.Font.Size);
                }
                count++;
            }
        }
        #endregion


        private void _Render() {
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(prop.UseUnicode, prop.Embedding);
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            const string filename = "HelloWorld.pdf";
            pdfRenderer.PdfDocument.Save(filename);
            Process.Start(filename);
        }



        private Paragraph _AddTextToCellWithOverFlow(string instring, Cell cell, Unit fontsize) {
            if(instring.Length < 3) return cell.AddParagraph(instring);
            PdfDocument pdfd = new PdfDocument();
            PdfPage pg = pdfd.AddPage();
            XGraphics oGFX = XGraphics.FromPdfPage(pg);
            Unit maxWidth = cell.Column.Width - (cell.Column.LeftPadding + cell.Column.RightPadding);
            Paragraph par;
            XFont font = new XFont("Times New Roman", fontsize);
            if (oGFX.MeasureString(instring, font).Width < maxWidth.Value) {
                par = cell.AddParagraph(instring);
            } else {
                int stringlength = instring.Length;
                for (int i = 0; i < 3; i++) {
                    if (oGFX.MeasureString(instring.Substring(0, stringlength) + '\u2026', font).Width > maxWidth.Value)
                        stringlength -= (int)Math.Ceiling(instring.Length * Math.Pow(0.5f, i));
                    else
                        if (i < 2)
                        stringlength += (int)Math.Ceiling(instring.Length * Math.Pow(0.5f, i));
                }
                par = cell.AddParagraph(instring.Substring(0, stringlength) + '\u2026');
            }
            par.Format.Font.Size = fontsize;
            return par;
        }


    }
}
