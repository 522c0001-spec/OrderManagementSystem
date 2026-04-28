namespace GUI_PresentationLayer
{
    partial class FilterForm
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
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.btnBestItems = new System.Windows.Forms.Button();
            this.cbAgents = new System.Windows.Forms.ComboBox();
            this.btnCustomerPurchases = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReports
            // 
            this.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReports.Location = new System.Drawing.Point(417, 35);
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.RowHeadersWidth = 51;
            this.dgvReports.RowTemplate.Height = 24;
            this.dgvReports.Size = new System.Drawing.Size(895, 475);
            this.dgvReports.TabIndex = 0;
            // 
            // btnBestItems
            // 
            this.btnBestItems.Location = new System.Drawing.Point(64, 68);
            this.btnBestItems.Name = "btnBestItems";
            this.btnBestItems.Size = new System.Drawing.Size(175, 33);
            this.btnBestItems.TabIndex = 1;
            this.btnBestItems.Text = "Show Best Items";
            this.btnBestItems.UseVisualStyleBackColor = true;
            this.btnBestItems.Click += new System.EventHandler(this.btnBestItems_Click);
            // 
            // cbAgents
            // 
            this.cbAgents.FormattingEnabled = true;
            this.cbAgents.Location = new System.Drawing.Point(257, 170);
            this.cbAgents.Name = "cbAgents";
            this.cbAgents.Size = new System.Drawing.Size(127, 24);
            this.cbAgents.TabIndex = 2;
            this.cbAgents.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnCustomerPurchases
            // 
            this.btnCustomerPurchases.Location = new System.Drawing.Point(64, 165);
            this.btnCustomerPurchases.Name = "btnCustomerPurchases";
            this.btnCustomerPurchases.Size = new System.Drawing.Size(175, 33);
            this.btnCustomerPurchases.TabIndex = 3;
            this.btnCustomerPurchases.Text = "Filter by Customer";
            this.btnCustomerPurchases.UseVisualStyleBackColor = true;
            this.btnCustomerPurchases.Click += new System.EventHandler(this.btnCustomerPurchases_Click);
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 598);
            this.Controls.Add(this.btnCustomerPurchases);
            this.Controls.Add(this.cbAgents);
            this.Controls.Add(this.btnBestItems);
            this.Controls.Add(this.dgvReports);
            this.Name = "FilterForm";
            this.Text = "FilterForm";
            this.Load += new System.EventHandler(this.FilterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.Button btnBestItems;
        private System.Windows.Forms.ComboBox cbAgents;
        private System.Windows.Forms.Button btnCustomerPurchases;
    }
}