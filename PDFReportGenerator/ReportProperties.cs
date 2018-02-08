using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using MigraDoc.DocumentObjectModel;
namespace PDFReportGenerator {
    public class ReportProperties {
        public static Orientation Orientation = Orientation.Portrait;

        public bool UseCmykColor = true;
        public bool UseUnicode = true;
        public PdfFontEmbedding Embedding = PdfFontEmbedding.Always;

        public DocumentInfo document_info = new DocumentInfo();
        public TableProperties table = new TableProperties();
        public ReportProperties() {

        }

        public static double GetMaxTableWidth() {
            return ReportProperties.Orientation == Orientation.Portrait ? 16.2d : 24.5d;
        }

    }
}
