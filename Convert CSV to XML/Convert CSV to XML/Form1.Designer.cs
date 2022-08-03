namespace Convert_CSV_to_XML
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.filePath = new System.Windows.Forms.Label();
            this.btBrowse = new System.Windows.Forms.Button();
            this.btUpload = new System.Windows.Forms.Button();
            this.csvPath = new System.Windows.Forms.TextBox();
            this.csvGridView = new System.Windows.Forms.DataGridView();
            this.exportXML = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.csvGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // filePath
            // 
            this.filePath.AutoSize = true;
            this.filePath.Location = new System.Drawing.Point(27, 60);
            this.filePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(55, 15);
            this.filePath.TabIndex = 0;
            this.filePath.Text = "File path:";
            // 
            // btBrowse
            // 
            this.btBrowse.Location = new System.Drawing.Point(499, 58);
            this.btBrowse.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(118, 27);
            this.btBrowse.TabIndex = 1;
            this.btBrowse.Text = "Browse";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // btUpload
            // 
            this.btUpload.Location = new System.Drawing.Point(89, 88);
            this.btUpload.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btUpload.Name = "btUpload";
            this.btUpload.Size = new System.Drawing.Size(118, 27);
            this.btUpload.TabIndex = 2;
            this.btUpload.Text = "Upload CSV";
            this.btUpload.UseVisualStyleBackColor = true;
            this.btUpload.Click += new System.EventHandler(this.BtnUpload_Click);
            // 
            // csvPath
            // 
            this.csvPath.Location = new System.Drawing.Point(89, 58);
            this.csvPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.csvPath.Name = "csvPath";
            this.csvPath.Size = new System.Drawing.Size(402, 23);
            this.csvPath.TabIndex = 3;
            // 
            // csvGridView
            // 
            this.csvGridView.AllowUserToAddRows = false;
            this.csvGridView.AllowUserToDeleteRows = false;
            this.csvGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.csvGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.csvGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.csvGridView.Location = new System.Drawing.Point(12, 121);
            this.csvGridView.Name = "csvGridView";
            this.csvGridView.ReadOnly = true;
            this.csvGridView.Size = new System.Drawing.Size(999, 500);
            this.csvGridView.TabIndex = 4;
            // 
            // exportXML
            // 
            this.exportXML.Location = new System.Drawing.Point(215, 88);
            this.exportXML.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.exportXML.Name = "exportXML";
            this.exportXML.Size = new System.Drawing.Size(118, 27);
            this.exportXML.TabIndex = 5;
            this.exportXML.Text = "Export to XML";
            this.exportXML.UseVisualStyleBackColor = true;
            this.exportXML.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(380, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(8, 8);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 121);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(999, 500);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 643);
            this.Controls.Add(this.csvGridView);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.exportXML);
            this.Controls.Add(this.csvPath);
            this.Controls.Add(this.btUpload);
            this.Controls.Add(this.btBrowse);
            this.Controls.Add(this.filePath);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Convert CSV to XML";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.csvGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label filePath;
        private Button btBrowse;
        private Button btUpload;
        private TextBox csvPath;
        private DataGridView csvGridView;
        private Button exportXML;
        private Button button1;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}