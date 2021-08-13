
namespace WebStoreClient
{
    partial class WebStoreForm
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
            this.orderListPanel = new System.Windows.Forms.Panel();
            this.productcomboBox = new System.Windows.Forms.ComboBox();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.purchaseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // orderListPanel
            // 
            this.orderListPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.orderListPanel.Location = new System.Drawing.Point(40, 26);
            this.orderListPanel.Name = "orderListPanel";
            this.orderListPanel.Size = new System.Drawing.Size(307, 376);
            this.orderListPanel.TabIndex = 0;
            // 
            // productcomboBox
            // 
            this.productcomboBox.FormattingEnabled = true;
            this.productcomboBox.Location = new System.Drawing.Point(374, 26);
            this.productcomboBox.Name = "productcomboBox";
            this.productcomboBox.Size = new System.Drawing.Size(250, 24);
            this.productcomboBox.TabIndex = 1;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(374, 378);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(100, 23);
            this.refreshBtn.TabIndex = 2;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // purchaseBtn
            // 
            this.purchaseBtn.Location = new System.Drawing.Point(516, 378);
            this.purchaseBtn.Name = "purchaseBtn";
            this.purchaseBtn.Size = new System.Drawing.Size(100, 23);
            this.purchaseBtn.TabIndex = 3;
            this.purchaseBtn.Text = "Purchase";
            this.purchaseBtn.UseVisualStyleBackColor = true;
            this.purchaseBtn.Click += new System.EventHandler(this.purchaseBtn_Click);
            // 
            // WebStoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 443);
            this.Controls.Add(this.purchaseBtn);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.productcomboBox);
            this.Controls.Add(this.orderListPanel);
            this.Name = "WebStoreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebStore";
            this.Load += new System.EventHandler(this.WebStoreForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel orderListPanel;
        private System.Windows.Forms.ComboBox productcomboBox;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button purchaseBtn;
    }
}

