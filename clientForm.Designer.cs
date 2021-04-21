
namespace whisperChat
{
    partial class clientForm
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
            this.messageBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.outPutBoxClient = new System.Windows.Forms.ListBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(88, 362);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(239, 22);
            this.messageBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "whisperChat-Client";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 367);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Message:";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(333, 362);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "SEND";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.OnMessageSendClick);
            // 
            // outPutBoxClient
            // 
            this.outPutBoxClient.FormattingEnabled = true;
            this.outPutBoxClient.ItemHeight = 16;
            this.outPutBoxClient.Location = new System.Drawing.Point(88, 29);
            this.outPutBoxClient.Name = "outPutBoxClient";
            this.outPutBoxClient.Size = new System.Drawing.Size(239, 324);
            this.outPutBoxClient.TabIndex = 4;
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(16, 410);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(23, 17);
            this.userLabel.TabIndex = 5;
            this.userLabel.Text = "---";
            // 
            // clientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 456);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.outPutBoxClient);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.messageBox);
            this.Name = "clientForm";
            this.Text = "clientForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ListBox outPutBoxClient;
        private System.Windows.Forms.Label userLabel;
    }
}