using System.Linq;
using System.Windows.Forms;
using System.ServiceProcess;

namespace Semaphore
{
    public partial class SelectServiceWindow : Form
    {
        private MainForm parentForm;

        public SelectServiceWindow(MainForm parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();
            dataGridViewServices.SetColumnHeaders();
            ServiceController.GetServices().ToList().ForEach(service => dataGridViewServices.Rows.Add(service.ServiceName, service.Status, service.DisplayName));
        }

        private void Cancel(object sender, System.EventArgs e)
        {
            Close();
        }

        private void Save(object sender, System.EventArgs e)
        {
           if (dataGridViewServices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a service.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var selectedServiceName = dataGridViewServices.SelectedRows[0].Cells[0].Value.ToString();
            var selectedServiceDefaultDisplayName = dataGridViewServices.SelectedRows[0].Cells[2].Value.ToString();
            var exists = parentForm.configuration.Data.Services.FirstOrDefault(x => x.Name == selectedServiceName);
            if (exists != null)
            {
                MessageBox.Show("Service already exists in your configuration.\nPlease select another service.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            parentForm.configuration.Data.Services.Add(new Models.ServiceModel { Name = selectedServiceName, DisplayName = selectedServiceDefaultDisplayName });
            parentForm.configuration.Save();
            parentForm.UpdateDataGrid();
            Close();
        }
    }
}
