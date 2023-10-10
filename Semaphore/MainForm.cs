using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.ServiceProcess;
using System;

namespace Semaphore
{
    public partial class MainForm : Form
    {
        internal Configuration configuration;
        static readonly System.Drawing.Font contextMenuTitleFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        static readonly System.Drawing.Font contextMenuErrorFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
        static readonly System.Drawing.Font contextMenuItemFont = new System.Drawing.Font("Segoe UI", 8F);

        public MainForm()
        {
            InitializeComponent();
            configuration = new Configuration(out var message);
            if (message != null) MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            trayIcon.ContextMenuStrip = new ContextMenuStrip();
            dataGridViewMonitingService.SetColumnHeaders();
        }

        private void OnLoad(object sender, System.EventArgs e)
        {
            UpdateDataGrid();
            UpdateTrayContextMenu();
            BeginInvoke(new MethodInvoker(delegate
            {
                Hide();
                trayIcon.Visible = true;                
                Opacity = 100;
            }));
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void Exit(object sender, System.EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void HideWindow(object sender, System.EventArgs e)
        {
            Hide();
        }

        private void OnTrayDoubleClick(object sender, MouseEventArgs e)
        {
            UpdateTrayContextMenu();
            UpdateDataGrid();
            Visible = !Visible;
        }

        private void OnTrayClick(object sender, MouseEventArgs e)
        {
            UpdateTrayContextMenu();
        }

        private void UpdateTrayContextMenu()
        {
            var hasNotFound = false;
            var isEmpty = true;
            trayIcon.ContextMenuStrip.Items.Clear();
            trayIcon.ContextMenuStrip.Items.Add(new ToolStripLabel("Semaphore") { Font = contextMenuTitleFont });
            trayIcon.ContextMenuStrip.Items.Add("Open Main Window", null, OnTrayOpenMainWindow);
            trayIcon.ContextMenuStrip.Items.Add("Configuration", null, OpenConfig);
            trayIcon.ContextMenuStrip.Items.Add("Reload Configuration", null, ReloadConfig);
            trayIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            var availableServicesList = ServiceController.GetServices().ToList();
            configuration.Data.Services.ForEach(queryService =>
            {
                var service = availableServicesList.FirstOrDefault(svc => svc.ServiceName == queryService.Name);
                if (service == null)
                {
                    hasNotFound = true;
                    return;
                }
                var stateImage = Properties.Resources.IconAttension;
                if (service.Status == ServiceControllerStatus.Running) stateImage = Properties.Resources.IconActive;
                if (service.Status == ServiceControllerStatus.Stopped) stateImage = Properties.Resources.IconStop;
                var item = new ToolStripMenuItem(queryService.DisplayName, stateImage);
                item.DropDownItems.Add(new ToolStripLabel(queryService.Name) { Font = contextMenuTitleFont });
                item.DropDownItems.Add(new ToolStripMenuItem(service.Status.ToString(), null, (s, e) =>
                {
                    Process.Start("services.msc");
                }) { Font = contextMenuErrorFont });
                item.DropDownItems.Add("Start", null, (s, e) =>
                {
                    try { service.Start(); UpdateTrayContextMenu(); }
                    catch (Exception ex) { ShowExceptionError(new Exception("Fail to start service", ex)); }
                });
                item.DropDownItems.Add("Stop", null, (s, e) =>
                {
                    try { service.Stop(); UpdateTrayContextMenu(); }
                    catch (Exception ex) { ShowExceptionError(new Exception("Fail to stop service", ex)); }
                });
                item.DropDownItems.Add("Restart", null, (s, e) =>
                {
                    try { service.Stop(); service.WaitForStatus(ServiceControllerStatus.Stopped); service.Start(); UpdateTrayContextMenu(); }
                    catch (Exception ex) { ShowExceptionError(new Exception("Fail to restart service", ex)); }
                });
                trayIcon.ContextMenuStrip.Items.Add(item);
                isEmpty = false;
            });
            if (isEmpty) trayIcon.ContextMenuStrip.Items.Add(new ToolStripLabel("No service to monitor") { Font = contextMenuErrorFont });
            trayIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            if (hasNotFound) trayIcon.ContextMenuStrip.Items.Add(new ToolStripLabel("Some services not found") { Font = contextMenuErrorFont });
            trayIcon.ContextMenuStrip.Items.Add("Exit", null, OnTrayExit);
        }

        private void ShowExceptionError(Exception exception)
        {
            var message = string.Empty;
            var title = exception.Message;
            while (exception != null)
            {
                message += $"{exception.Message}\n\n";
                exception = exception.InnerException;
            }
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OnTrayOpenMainWindow(object sender, EventArgs e)
        {
            Show();
        }

        private void OnTrayExit(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void OpenConfig(object sender, System.EventArgs e)
        {
            Process.Start(Configuration.ConfigurationFolder);
        }

        private void ReloadConfig(object sender, System.EventArgs e)
        {
            configuration = new Configuration(out string message);
            if (message != null) MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            UpdateDataGrid();
            UpdateTrayContextMenu();
        }

        private void RestoreConfig(object sender, System.EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure to restore configuration? You will lose all current configuration.", "Restore Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (confirm == DialogResult.Cancel) return;

            var oldExist = configuration.Restore(out var backupFileName);
            if (oldExist)
            {
                MessageBox.Show($"Reestore successfully!\n\nOld configuration file has been backup to {backupFileName}", "Restore Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Reestore successfully", "Restore Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ReloadConfig(null, null);
        }

        private void SelectService(object sender, System.EventArgs e)
        {
            var selectServiceWindow = new SelectServiceWindow(this);
            selectServiceWindow.ShowDialog();
        }

        internal void UpdateDataGrid()
        {
            dataGridViewMonitingService.Rows.Clear();
            var availableServicesList = ServiceController.GetServices().ToList();
            configuration.Data.Services.ForEach(queryService =>
            {
                var queryServiceResult = availableServicesList.FirstOrDefault(service => service.ServiceName == queryService.Name);
                var state = queryServiceResult == null ? "Not Found" : queryServiceResult.Status.ToString();
                dataGridViewMonitingService.Rows.Add(queryService.Name, state, queryService.DisplayName);
            });
        }

        private void DeleteService(object sender, System.EventArgs e)
        {
            var selected = dataGridViewMonitingService.SelectedRows;
            if (selected.Count == 0)
            {
                MessageBox.Show("Please select a service.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var confirm = MessageBox.Show("Are you sure to delete selected services?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (confirm == DialogResult.Cancel) return;

            foreach (DataGridViewRow row in selected)
            {
                var serviceName = row.Cells[0].Value.ToString();
                var service = configuration.Data.Services.FirstOrDefault(x => x.Name == serviceName);
                if (service != null)
                {
                    configuration.Data.Services.Remove(service);
                }
            }
            configuration.Save();
            UpdateDataGrid();
        }

        private void RefreshService(object sender, System.EventArgs e)
        {
            UpdateDataGrid();
        }
    }
}
