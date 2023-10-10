namespace Semaphore
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.buttonOpenConfig = new System.Windows.Forms.Button();
            this.buttonSelectServices = new System.Windows.Forms.Button();
            this.buttonRestoreConfig = new System.Windows.Forms.Button();
            this.buttonReloadConfig = new System.Windows.Forms.Button();
            this.dataGridViewMonitingService = new System.Windows.Forms.DataGridView();
            this.buttonDeleteService = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonRefreshService = new System.Windows.Forms.Button();
            this.buttonHide = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMonitingService)).BeginInit();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Visible = true;
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnTrayClick);
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnTrayDoubleClick);
            // 
            // buttonOpenConfig
            // 
            this.buttonOpenConfig.Location = new System.Drawing.Point(12, 12);
            this.buttonOpenConfig.Name = "buttonOpenConfig";
            this.buttonOpenConfig.Size = new System.Drawing.Size(185, 30);
            this.buttonOpenConfig.TabIndex = 1;
            this.buttonOpenConfig.Text = "Open Config";
            this.buttonOpenConfig.UseVisualStyleBackColor = true;
            this.buttonOpenConfig.Click += new System.EventHandler(this.OpenConfig);
            // 
            // buttonSelectServices
            // 
            this.buttonSelectServices.Location = new System.Drawing.Point(12, 519);
            this.buttonSelectServices.Name = "buttonSelectServices";
            this.buttonSelectServices.Size = new System.Drawing.Size(185, 30);
            this.buttonSelectServices.TabIndex = 4;
            this.buttonSelectServices.Text = "Select Service";
            this.buttonSelectServices.UseVisualStyleBackColor = true;
            this.buttonSelectServices.Click += new System.EventHandler(this.SelectService);
            // 
            // buttonRestoreConfig
            // 
            this.buttonRestoreConfig.Location = new System.Drawing.Point(203, 12);
            this.buttonRestoreConfig.Name = "buttonRestoreConfig";
            this.buttonRestoreConfig.Size = new System.Drawing.Size(185, 30);
            this.buttonRestoreConfig.TabIndex = 2;
            this.buttonRestoreConfig.Text = "Restore Config";
            this.buttonRestoreConfig.UseVisualStyleBackColor = true;
            this.buttonRestoreConfig.Click += new System.EventHandler(this.RestoreConfig);
            // 
            // buttonReloadConfig
            // 
            this.buttonReloadConfig.Location = new System.Drawing.Point(394, 12);
            this.buttonReloadConfig.Name = "buttonReloadConfig";
            this.buttonReloadConfig.Size = new System.Drawing.Size(185, 30);
            this.buttonReloadConfig.TabIndex = 3;
            this.buttonReloadConfig.Text = "Reload Config";
            this.buttonReloadConfig.UseVisualStyleBackColor = true;
            this.buttonReloadConfig.Click += new System.EventHandler(this.ReloadConfig);
            // 
            // dataGridViewMonitingService
            // 
            this.dataGridViewMonitingService.AllowUserToAddRows = false;
            this.dataGridViewMonitingService.AllowUserToDeleteRows = false;
            this.dataGridViewMonitingService.AllowUserToResizeRows = false;
            this.dataGridViewMonitingService.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewMonitingService.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMonitingService.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewMonitingService.ColumnHeadersHeight = 30;
            this.dataGridViewMonitingService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewMonitingService.EnableHeadersVisualStyles = false;
            this.dataGridViewMonitingService.Location = new System.Drawing.Point(12, 48);
            this.dataGridViewMonitingService.MultiSelect = false;
            this.dataGridViewMonitingService.Name = "dataGridViewMonitingService";
            this.dataGridViewMonitingService.ReadOnly = true;
            this.dataGridViewMonitingService.RowHeadersVisible = false;
            this.dataGridViewMonitingService.RowHeadersWidth = 4;
            this.dataGridViewMonitingService.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewMonitingService.RowTemplate.Height = 25;
            this.dataGridViewMonitingService.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMonitingService.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMonitingService.Size = new System.Drawing.Size(760, 465);
            this.dataGridViewMonitingService.TabIndex = 5;
            // 
            // buttonDeleteService
            // 
            this.buttonDeleteService.Location = new System.Drawing.Point(203, 519);
            this.buttonDeleteService.Name = "buttonDeleteService";
            this.buttonDeleteService.Size = new System.Drawing.Size(185, 30);
            this.buttonDeleteService.TabIndex = 6;
            this.buttonDeleteService.Text = "Delete Service";
            this.buttonDeleteService.UseVisualStyleBackColor = true;
            this.buttonDeleteService.Click += new System.EventHandler(this.DeleteService);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(587, 12);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(185, 30);
            this.buttonExit.TabIndex = 7;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.Exit);
            // 
            // buttonRefreshService
            // 
            this.buttonRefreshService.Location = new System.Drawing.Point(394, 519);
            this.buttonRefreshService.Name = "buttonRefreshService";
            this.buttonRefreshService.Size = new System.Drawing.Size(185, 30);
            this.buttonRefreshService.TabIndex = 8;
            this.buttonRefreshService.Text = "Refresh Service";
            this.buttonRefreshService.UseVisualStyleBackColor = true;
            this.buttonRefreshService.Click += new System.EventHandler(this.RefreshService);
            // 
            // buttonHide
            // 
            this.buttonHide.Location = new System.Drawing.Point(587, 519);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(185, 30);
            this.buttonHide.TabIndex = 9;
            this.buttonHide.Text = "Hide Widnow";
            this.buttonHide.UseVisualStyleBackColor = true;
            this.buttonHide.Click += new System.EventHandler(this.HideWindow);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.buttonHide);
            this.Controls.Add(this.buttonRefreshService);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonDeleteService);
            this.Controls.Add(this.dataGridViewMonitingService);
            this.Controls.Add(this.buttonReloadConfig);
            this.Controls.Add(this.buttonRestoreConfig);
            this.Controls.Add(this.buttonSelectServices);
            this.Controls.Add(this.buttonOpenConfig);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Semaphore";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMonitingService)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Button buttonOpenConfig;
        private System.Windows.Forms.Button buttonSelectServices;
        private System.Windows.Forms.Button buttonRestoreConfig;
        private System.Windows.Forms.Button buttonReloadConfig;
        private System.Windows.Forms.DataGridView dataGridViewMonitingService;
        private System.Windows.Forms.Button buttonDeleteService;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonRefreshService;
        private System.Windows.Forms.Button buttonHide;
    }
}

