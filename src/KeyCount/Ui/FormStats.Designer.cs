namespace KeyCount.Ui
{
    partial class FormStats
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStats));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panelKeyList = new System.Windows.Forms.Panel();
            this.buttonKeyListExport = new System.Windows.Forms.Button();
            this.buttonKeyListImport = new System.Windows.Forms.Button();
            this.labelHeaderKeyCount = new System.Windows.Forms.Label();
            this.labelHeaderKeyList = new System.Windows.Forms.Label();
            this.dataGridViewKeyCount = new System.Windows.Forms.DataGridView();
            this.columnKeyCountDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnKeyCountCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceKeyCount = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewKeyList = new System.Windows.Forms.DataGridView();
            this.columnKeyListKeyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnKeyListKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnKeyListCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceKeyList = new System.Windows.Forms.BindingSource(this.components);
            this.panelKeyCount = new System.Windows.Forms.Panel();
            this.buttonKeyCountExport = new System.Windows.Forms.Button();
            this.buttonKeyCountImport = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.panelKeyList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKeyCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceKeyCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKeyList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceKeyList)).BeginInit();
            this.panelKeyCount.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.panelKeyList, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.labelHeaderKeyCount, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelHeaderKeyList, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.dataGridViewKeyCount, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.dataGridViewKeyList, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.panelKeyCount, 0, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // panelKeyList
            // 
            this.panelKeyList.Controls.Add(this.buttonKeyListExport);
            this.panelKeyList.Controls.Add(this.buttonKeyListImport);
            this.panelKeyList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKeyList.Location = new System.Drawing.Point(400, 421);
            this.panelKeyList.Margin = new System.Windows.Forms.Padding(0);
            this.panelKeyList.Name = "panelKeyList";
            this.panelKeyList.Size = new System.Drawing.Size(400, 29);
            this.panelKeyList.TabIndex = 7;
            // 
            // buttonKeyListExport
            // 
            this.buttonKeyListExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonKeyListExport.Location = new System.Drawing.Point(320, 3);
            this.buttonKeyListExport.Name = "buttonKeyListExport";
            this.buttonKeyListExport.Size = new System.Drawing.Size(75, 23);
            this.buttonKeyListExport.TabIndex = 5;
            this.buttonKeyListExport.Text = "Export";
            this.buttonKeyListExport.UseVisualStyleBackColor = true;
            this.buttonKeyListExport.Click += new System.EventHandler(this.ButtonExport_Click);
            // 
            // buttonKeyListImport
            // 
            this.buttonKeyListImport.Location = new System.Drawing.Point(5, 3);
            this.buttonKeyListImport.Name = "buttonKeyListImport";
            this.buttonKeyListImport.Size = new System.Drawing.Size(75, 23);
            this.buttonKeyListImport.TabIndex = 4;
            this.buttonKeyListImport.Text = "Import";
            this.buttonKeyListImport.UseVisualStyleBackColor = true;
            this.buttonKeyListImport.Click += new System.EventHandler(this.ButtonImport_Click);
            // 
            // labelHeaderKeyCount
            // 
            this.labelHeaderKeyCount.AutoSize = true;
            this.labelHeaderKeyCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHeaderKeyCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelHeaderKeyCount.Location = new System.Drawing.Point(3, 3);
            this.labelHeaderKeyCount.Margin = new System.Windows.Forms.Padding(3);
            this.labelHeaderKeyCount.Name = "labelHeaderKeyCount";
            this.labelHeaderKeyCount.Size = new System.Drawing.Size(394, 15);
            this.labelHeaderKeyCount.TabIndex = 0;
            this.labelHeaderKeyCount.Text = "Counts";
            // 
            // labelHeaderKeyList
            // 
            this.labelHeaderKeyList.AutoSize = true;
            this.labelHeaderKeyList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHeaderKeyList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelHeaderKeyList.Location = new System.Drawing.Point(403, 3);
            this.labelHeaderKeyList.Margin = new System.Windows.Forms.Padding(3);
            this.labelHeaderKeyList.Name = "labelHeaderKeyList";
            this.labelHeaderKeyList.Size = new System.Drawing.Size(394, 15);
            this.labelHeaderKeyList.TabIndex = 1;
            this.labelHeaderKeyList.Text = "Key list";
            // 
            // dataGridViewKeyCount
            // 
            this.dataGridViewKeyCount.AllowUserToAddRows = false;
            this.dataGridViewKeyCount.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewKeyCount.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewKeyCount.AutoGenerateColumns = false;
            this.dataGridViewKeyCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKeyCount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnKeyCountDay,
            this.columnKeyCountCount});
            this.dataGridViewKeyCount.DataSource = this.sourceKeyCount;
            this.dataGridViewKeyCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewKeyCount.Location = new System.Drawing.Point(5, 26);
            this.dataGridViewKeyCount.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridViewKeyCount.Name = "dataGridViewKeyCount";
            this.dataGridViewKeyCount.ReadOnly = true;
            this.dataGridViewKeyCount.RowTemplate.Height = 25;
            this.dataGridViewKeyCount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewKeyCount.Size = new System.Drawing.Size(390, 390);
            this.dataGridViewKeyCount.TabIndex = 2;
            // 
            // columnKeyCountDay
            // 
            this.columnKeyCountDay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnKeyCountDay.DataPropertyName = "Day";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.columnKeyCountDay.DefaultCellStyle = dataGridViewCellStyle2;
            this.columnKeyCountDay.HeaderText = "Day";
            this.columnKeyCountDay.Name = "columnKeyCountDay";
            this.columnKeyCountDay.ReadOnly = true;
            // 
            // columnKeyCountCount
            // 
            this.columnKeyCountCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnKeyCountCount.DataPropertyName = "Count";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.columnKeyCountCount.DefaultCellStyle = dataGridViewCellStyle3;
            this.columnKeyCountCount.HeaderText = "Count";
            this.columnKeyCountCount.Name = "columnKeyCountCount";
            this.columnKeyCountCount.ReadOnly = true;
            // 
            // sourceKeyCount
            // 
            this.sourceKeyCount.DataSource = typeof(KeyCount.DataObjects.DayKeyCount);
            // 
            // dataGridViewKeyList
            // 
            this.dataGridViewKeyList.AllowUserToAddRows = false;
            this.dataGridViewKeyList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewKeyList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewKeyList.AutoGenerateColumns = false;
            this.dataGridViewKeyList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKeyList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnKeyListKeyCode,
            this.columnKeyListKey,
            this.columnKeyListCount});
            this.dataGridViewKeyList.DataSource = this.sourceKeyList;
            this.dataGridViewKeyList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewKeyList.Location = new System.Drawing.Point(405, 26);
            this.dataGridViewKeyList.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridViewKeyList.Name = "dataGridViewKeyList";
            this.dataGridViewKeyList.ReadOnly = true;
            this.dataGridViewKeyList.RowTemplate.Height = 25;
            this.dataGridViewKeyList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewKeyList.Size = new System.Drawing.Size(390, 390);
            this.dataGridViewKeyList.TabIndex = 3;
            // 
            // columnKeyListKeyCode
            // 
            this.columnKeyListKeyCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnKeyListKeyCode.DataPropertyName = "KeyCode";
            this.columnKeyListKeyCode.HeaderText = "KeyCode";
            this.columnKeyListKeyCode.Name = "columnKeyListKeyCode";
            this.columnKeyListKeyCode.ReadOnly = true;
            // 
            // columnKeyListKey
            // 
            this.columnKeyListKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnKeyListKey.DataPropertyName = "Key";
            this.columnKeyListKey.HeaderText = "Key";
            this.columnKeyListKey.Name = "columnKeyListKey";
            this.columnKeyListKey.ReadOnly = true;
            // 
            // columnKeyListCount
            // 
            this.columnKeyListCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnKeyListCount.DataPropertyName = "Count";
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.columnKeyListCount.DefaultCellStyle = dataGridViewCellStyle5;
            this.columnKeyListCount.HeaderText = "Count";
            this.columnKeyListCount.Name = "columnKeyListCount";
            this.columnKeyListCount.ReadOnly = true;
            // 
            // sourceKeyList
            // 
            this.sourceKeyList.DataSource = typeof(KeyCount.DataObjects.KeyListEntry);
            // 
            // panelKeyCount
            // 
            this.panelKeyCount.Controls.Add(this.buttonKeyCountExport);
            this.panelKeyCount.Controls.Add(this.buttonKeyCountImport);
            this.panelKeyCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKeyCount.Location = new System.Drawing.Point(0, 421);
            this.panelKeyCount.Margin = new System.Windows.Forms.Padding(0);
            this.panelKeyCount.Name = "panelKeyCount";
            this.panelKeyCount.Size = new System.Drawing.Size(400, 29);
            this.panelKeyCount.TabIndex = 6;
            // 
            // buttonKeyCountExport
            // 
            this.buttonKeyCountExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonKeyCountExport.Location = new System.Drawing.Point(320, 3);
            this.buttonKeyCountExport.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.buttonKeyCountExport.Name = "buttonKeyCountExport";
            this.buttonKeyCountExport.Size = new System.Drawing.Size(75, 23);
            this.buttonKeyCountExport.TabIndex = 5;
            this.buttonKeyCountExport.Text = "Export";
            this.buttonKeyCountExport.UseVisualStyleBackColor = true;
            this.buttonKeyCountExport.Click += new System.EventHandler(this.ButtonExport_Click);
            // 
            // buttonKeyCountImport
            // 
            this.buttonKeyCountImport.Location = new System.Drawing.Point(5, 3);
            this.buttonKeyCountImport.Name = "buttonKeyCountImport";
            this.buttonKeyCountImport.Size = new System.Drawing.Size(75, 23);
            this.buttonKeyCountImport.TabIndex = 4;
            this.buttonKeyCountImport.Text = "Import";
            this.buttonKeyCountImport.UseVisualStyleBackColor = true;
            this.buttonKeyCountImport.Click += new System.EventHandler(this.ButtonImport_Click);
            // 
            // FormStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormStats";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "KeyCount - Statistics";
            this.Load += new System.EventHandler(this.FormStats_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.panelKeyList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKeyCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceKeyCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKeyList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceKeyList)).EndInit();
            this.panelKeyCount.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel panelKeyList;
        private System.Windows.Forms.Button buttonKeyListExport;
        private System.Windows.Forms.Button buttonKeyListImport;
        private System.Windows.Forms.Label labelHeaderKeyCount;
        private System.Windows.Forms.Label labelHeaderKeyList;
        private System.Windows.Forms.DataGridView dataGridViewKeyCount;
        private System.Windows.Forms.DataGridView dataGridViewKeyList;
        private System.Windows.Forms.Panel panelKeyCount;
        private System.Windows.Forms.Button buttonKeyCountExport;
        private System.Windows.Forms.Button buttonKeyCountImport;
        private System.Windows.Forms.BindingSource sourceKeyCount;
        private System.Windows.Forms.BindingSource sourceKeyList;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnKeyCountDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnKeyCountCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnKeyListKeyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnKeyListKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnKeyListCount;
    }
}