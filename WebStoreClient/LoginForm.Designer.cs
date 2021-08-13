
namespace WebStoreClient
{
    partial class LoginForm
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
            this.hostNameLbl = new System.Windows.Forms.Label();
            this.accountNoLbl = new System.Windows.Forms.Label();
            this.hostNametxtbox = new System.Windows.Forms.TextBox();
            this.accountNotxtbox = new System.Windows.Forms.TextBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hostNameLbl
            // 
            this.hostNameLbl.AutoSize = true;
            this.hostNameLbl.Location = new System.Drawing.Point(40, 26);
            this.hostNameLbl.Name = "hostNameLbl";
            this.hostNameLbl.Size = new System.Drawing.Size(78, 17);
            this.hostNameLbl.TabIndex = 0;
            this.hostNameLbl.Text = "Host Name";
            // 
            // accountNoLbl
            // 
            this.accountNoLbl.AutoSize = true;
            this.accountNoLbl.Location = new System.Drawing.Point(40, 69);
            this.accountNoLbl.Name = "accountNoLbl";
            this.accountNoLbl.Size = new System.Drawing.Size(81, 17);
            this.accountNoLbl.TabIndex = 1;
            this.accountNoLbl.Text = "Account No";
            // 
            // hostNametxtbox
            // 
            this.hostNametxtbox.Location = new System.Drawing.Point(145, 26);
            this.hostNametxtbox.Name = "hostNametxtbox";
            this.hostNametxtbox.Size = new System.Drawing.Size(180, 22);
            this.hostNametxtbox.TabIndex = 2;
            this.hostNametxtbox.Text = "localhost";
            // 
            // accountNotxtbox
            // 
            this.accountNotxtbox.Location = new System.Drawing.Point(145, 69);
            this.accountNotxtbox.Name = "accountNotxtbox";
            this.accountNotxtbox.Size = new System.Drawing.Size(180, 22);
            this.accountNotxtbox.TabIndex = 3;
            this.accountNotxtbox.TextChanged += new System.EventHandler(this.accountNotxtbox_TextChanged);
            // 
            // connectBtn
            // 
            this.connectBtn.AutoSize = true;
            this.connectBtn.Enabled = false;
            this.connectBtn.Location = new System.Drawing.Point(250, 110);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(75, 27);
            this.connectBtn.TabIndex = 4;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.connectBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 149);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.accountNotxtbox);
            this.Controls.Add(this.hostNametxtbox);
            this.Controls.Add(this.accountNoLbl);
            this.Controls.Add(this.hostNameLbl);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label hostNameLbl;
        private System.Windows.Forms.Label accountNoLbl;
        private System.Windows.Forms.TextBox hostNametxtbox;
        private System.Windows.Forms.TextBox accountNotxtbox;
        private System.Windows.Forms.Button connectBtn;
    }
}