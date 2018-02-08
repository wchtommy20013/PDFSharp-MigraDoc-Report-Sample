using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFReportGenerator {
    public class ColumnAttribute {
        public string Header = "";
        public double WidthPercentage = 0;

        public ColumnAttribute(string header, double width_percentage) {
            this.Header = header;
            this.WidthPercentage = width_percentage;
        }
    }
}
