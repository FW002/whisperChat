
namespace whisperChat
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.chatOutPutServer = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.newUser = new System.Windows.Forms.Button();
            this.currentlyOnline = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // chatOutPutServer
            // 
            this.chatOutPutServer.FormattingEnabled = true;
            this.chatOutPutServer.ItemHeight = 16;
            this.chatOutPutServer.Location = new System.Drawing.Point(89, 79);
            this.chatOutPutServer.Name = "chatOutPutServer";
            this.chatOutPutServer.Size = new System.Drawing.Size(435, 276);
            this.chatOutPutServer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "whisperChat-Server";
            // 
            // newUser
            // 
            this.newUser.Location = new System.Drawing.Point(89, 381);
            this.newUser.Name = "newUser";
            this.newUser.Size = new System.Drawing.Size(176, 23);
            this.newUser.TabIndex = 2;
            this.newUser.Text = "Simulate new User";
            this.newUser.UseVisualStyleBackColor = true;
            this.newUser.Click += new System.EventHandler(this.OnNewUserClick);
            // 
            // currentlyOnline
            // 
            this.currentlyOnline.FormattingEnabled = true;
            this.currentlyOnline.ItemHeight = 16;
            this.currentlyOnline.Location = new System.Drawing.Point(523, 397);
            this.currentlyOnline.Name = "currentlyOnline";
            this.currentlyOnline.Size = new System.Drawing.Size(123, 84);
            this.currentlyOnline.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 493);
            this.Controls.Add(this.currentlyOnline);
            this.Controls.Add(this.newUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chatOutPutServer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox chatOutPutServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button newUser;
        private System.Windows.Forms.ListBox currentlyOnline;
    }
}

