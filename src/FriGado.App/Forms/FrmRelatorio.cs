using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FriGado.App.Forms
{
    public partial class FrmRelatorio : Form
    {
        DataTable dataTable;
        public FrmRelatorio(DataTable dataTable)
        {
            InitializeComponent();
            this.dataTable = dataTable;
        }

        private void FrmRelatorio_Load(object sender, EventArgs e)
        {
            var reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dataTable);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
