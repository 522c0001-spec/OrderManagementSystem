namespace GUI_PresentationLayer
{
    partial class MainForm
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
            this.btnItems = new System.Windows.Forms.Button();
            this.btnAgents = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnItems
            // 
            this.btnItems.Location = new System.Drawing.Point(467, 243);
            this.btnItems.Name = "btnItems";
            this.btnItems.Size = new System.Drawing.Size(220, 55);
            this.btnItems.TabIndex = 0;
            this.btnItems.Text = "Manage Items";
            this.btnItems.UseVisualStyleBackColor = true;
            this.btnItems.Click += new System.EventHandler(this.btnItems_Click);
            // 
            // btnAgents
            // 
            this.btnAgents.Location = new System.Drawing.Point(467, 159);
            this.btnAgents.Name = "btnAgents";
            this.btnAgents.Size = new System.Drawing.Size(220, 54);
            this.btnAgents.TabIndex = 1;
            this.btnAgents.Text = "Manage Agents";
            this.btnAgents.UseVisualStyleBackColor = true;
            this.btnAgents.Click += new System.EventHandler(this.btnAgents_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.Location = new System.Drawing.Point(467, 78);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(220, 51);
            this.btnOrders.TabIndex = 2;
            this.btnOrders.Text = "Manage Orders";
            this.btnOrders.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 626);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.btnAgents);
            this.Controls.Add(this.btnItems);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnItems;
        private System.Windows.Forms.Button btnAgents;
        private System.Windows.Forms.Button btnOrders;
    }
}