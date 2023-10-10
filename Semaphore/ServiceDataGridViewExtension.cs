using System.Windows.Forms;

namespace Semaphore
{
    internal static class ServiceDataGridViewExtension
    {
        public static void SetColumnHeaders(this DataGridView dataGridView)
        {
            dataGridView.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) {
                SortMode = DataGridViewColumnSortMode.Automatic,
                HeaderText = "Service Name",
                Width = 150 });
            dataGridView.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) {
                SortMode = DataGridViewColumnSortMode.Automatic,
                HeaderText = "State",
                Width = 90 });
            dataGridView.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) {
                SortMode = DataGridViewColumnSortMode.Automatic,
                HeaderText = "Display Name",
                Width = dataGridView.Width - 150 - 90 - 10 });
        }
    }
}
