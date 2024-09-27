using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImoveisPrecoDesktopApp.Services
{
    public static class SvcExportarArquivos
    {
        public static DataGridView dataGridView { get; set; }

        public static void ExportarArquivoCsvExcel(DataGridView dgv)
        {
            dataGridView = dgv;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv|Excel files (*.xlsx)|*.xlsx";
                sfd.Title = "Salvar como";
                sfd.DefaultExt = "csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = sfd.FileName;
                    if (filePath.EndsWith(".csv"))
                    {
                        ExportToCsv(filePath);
                    }
                    else if (filePath.EndsWith(".xlsx"))
                    {
                        ExportToExcel(filePath);
                    }
                }
            }
        }

        private static void ExportToCsv(string filePath)
        {
            StringBuilder sb = new StringBuilder();

            // Cabeçalhos
            string[] columnNames = GetColumnNames();
            sb.AppendLine(string.Join(",", columnNames));

            // Dados visíveis
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.Visible || row.IsNewRow) continue;
                string[] cells = Array.ConvertAll(row.Cells.Cast<DataGridViewCell>().ToArray(), c => c.Value?.ToString());
                sb.AppendLine(string.Join(",", cells));
            }

            File.WriteAllText(filePath, sb.ToString());
        }

        private static void ExportToExcel(string filePath)
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Dados exportados");

                // Cabeçalhos
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = dataGridView.Columns[i].HeaderText;
                }

                // Dados visíveis
                int rowIndex = 2;
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (!row.Visible || row.IsNewRow) continue;
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        worksheet.Cells[rowIndex, j + 1].Value = row.Cells[j].Value;
                    }
                    rowIndex++;
                }

                package.SaveAs(new FileInfo(filePath));
            }
        }

        private static string[] GetColumnNames()
        {
            return Array.ConvertAll(dataGridView.Columns.Cast<DataGridViewColumn>().ToArray(), c => c.HeaderText);
        }
    }
}
