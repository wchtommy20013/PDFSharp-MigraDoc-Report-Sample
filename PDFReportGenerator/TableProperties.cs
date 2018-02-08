using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc;
namespace PDFReportGenerator {
    public class TableProperties {
        public Borders borders = new Borders();
        public int LeftIndent = 0;

        public int BreakAt = 20;

        public List<ColumnAttribute> columns = new List<ColumnAttribute>();
        public List<string[]> datum = new List<string[]>();
         
        public TableProperties() {
            borders.Color = Color.FromCmyk(0, 0, 0, 100);
            borders.Width = 0.25;
            borders.Left.Width = 0.5;
            borders.Right.Width = 0.5;
        }

        public void SetBreak(int BreakAt) {
            this.BreakAt = BreakAt;
        }

        #region Columns

        public void AddColumns(params ColumnAttribute[] attrs) {
            this.columns.AddRange(attrs);
        }

        public void AddColumns(IList<ColumnAttribute> attrs) {
            this.columns.AddRange(attrs);
        }

        public void AddColumns(IDictionary<string, double> header_width) {
            foreach (var kv in header_width) {
                columns.Add(new ColumnAttribute(kv.Key, kv.Value));
            }
        }

        public void AddColumn(string header, double width_in_percentage) {
            columns.Add(new ColumnAttribute(header, width_in_percentage));
        }
        #endregion

#region Data
        public void AddData(params string[][] data) {
                datum.AddRange(data);
        }

        public void AddData(string[] data) {
            datum.Add(data);
        }

        public void AddData(List<string[]> data) {
            datum.AddRange(data);
        }
#endregion

    }
}
