using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDFReportGenerator;
using PdfSharp.Pdf;
namespace Sample {
    class Program {
        static void Main(string[] args) {
            ReportProperties rp = new ReportProperties();
            rp.table.AddColumns(new ColumnAttribute("Title", 20), new ColumnAttribute("Item", 90));
            rp.table.AddData(new string[2] { "1", "2" }, new string[2] { "Test Data For Long Cell That Its OverFlown Letters Should Be Hidden 593958 341", "2123" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" },
                new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" }, new string[2] { "1", "2" });

            ReportProperties.Orientation = MigraDoc.DocumentObjectModel.Orientation.Landscape;

            PdfReport pdf = new PdfReport(rp);


        }
    }
}
