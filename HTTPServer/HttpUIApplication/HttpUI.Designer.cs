namespace HttpUIApplication
{
    partial class HttpUI
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
            this.StartButton = new System.Windows.Forms.Button();
            this.PathText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StopButton = new System.Windows.Forms.Button();
            this.PortText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ServerStatus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ClientAddress = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(12, 407);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(90, 31);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start Server";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // PathText
            // 
            this.PathText.Location = new System.Drawing.Point(107, 23);
            this.PathText.Name = "PathText";
            this.PathText.Size = new System.Drawing.Size(587, 20);
            this.PathText.TabIndex = 1;
            this.PathText.TextChanged += new System.EventHandler(this.Path_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Path directory:";
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(610, 407);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(84, 31);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "Stop Server";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // PortText
            // 
            this.PortText.Location = new System.Drawing.Point(107, 72);
            this.PortText.Name = "PortText";
            this.PortText.Size = new System.Drawing.Size(88, 20);
            this.PortText.TabIndex = 4;
            this.PortText.TextChanged += new System.EventHandler(this.Port_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port number:";
            // 
            // ServerStatus
            // 
            this.ServerStatus.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ServerStatus.Location = new System.Drawing.Point(107, 141);
            this.ServerStatus.Name = "ServerStatus";
            this.ServerStatus.ReadOnly = true;
            this.ServerStatus.Size = new System.Drawing.Size(397, 20);
            this.ServerStatus.TabIndex = 6;
            this.ServerStatus.TextChanged += new System.EventHandler(this.ServerStatus_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Server status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Client IP:";
            // 
            // ClientAddress
            // 
            this.ClientAddress.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientAddress.Location = new System.Drawing.Point(107, 194);
            this.ClientAddress.Name = "ClientAddress";
            this.ClientAddress.ReadOnly = true;
            this.ClientAddress.Size = new System.Drawing.Size(503, 190);
            this.ClientAddress.TabIndex = 10;
            this.ClientAddress.Text = "";
            this.ClientAddress.TextChanged += new System.EventHandler(this.ClientAddress_TextChanged);
            // 
            // HttpUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 450);
            this.Controls.Add(this.ClientAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ServerStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PortText);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PathText);
            this.Controls.Add(this.StartButton);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Name = "HttpUI";
            this.Text = "HttpServer";
            this.Load += new System.EventHandler(this.HttpUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox PathText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.TextBox PortText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ServerStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox ClientAddress;
    }
}

