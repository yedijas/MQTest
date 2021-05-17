
namespace MQTest
{
    partial class MQTest
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbQManager = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbChannel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btPut = new System.Windows.Forms.Button();
            this.btGet = new System.Windows.Forms.Button();
            this.tbMessage = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbQName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbTransportType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(99, 13);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(401, 20);
            this.tbServer.TabIndex = 1;
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(99, 39);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(401, 20);
            this.tbPort.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // tbQManager
            // 
            this.tbQManager.Location = new System.Drawing.Point(99, 65);
            this.tbQManager.Name = "tbQManager";
            this.tbQManager.Size = new System.Drawing.Size(401, 20);
            this.tbQManager.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Q Manager";
            // 
            // tbChannel
            // 
            this.tbChannel.Location = new System.Drawing.Point(99, 91);
            this.tbChannel.Name = "tbChannel";
            this.tbChannel.Size = new System.Drawing.Size(401, 20);
            this.tbChannel.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Channel";
            // 
            // btPut
            // 
            this.btPut.Location = new System.Drawing.Point(506, 11);
            this.btPut.Name = "btPut";
            this.btPut.Size = new System.Drawing.Size(164, 23);
            this.btPut.TabIndex = 8;
            this.btPut.Text = "Put";
            this.btPut.UseVisualStyleBackColor = true;
            this.btPut.Click += new System.EventHandler(this.btPut_Click);
            // 
            // btGet
            // 
            this.btGet.Location = new System.Drawing.Point(506, 37);
            this.btGet.Name = "btGet";
            this.btGet.Size = new System.Drawing.Size(164, 23);
            this.btGet.TabIndex = 9;
            this.btGet.Text = "Get";
            this.btGet.UseVisualStyleBackColor = true;
            this.btGet.Click += new System.EventHandler(this.btGet_Click);
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(12, 198);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(653, 264);
            this.tbMessage.TabIndex = 10;
            this.tbMessage.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Message";
            // 
            // tbQName
            // 
            this.tbQName.Location = new System.Drawing.Point(99, 117);
            this.tbQName.Name = "tbQName";
            this.tbQName.Size = new System.Drawing.Size(401, 20);
            this.tbQName.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Q Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Transport Type";
            // 
            // cbTransportType
            // 
            this.cbTransportType.FormattingEnabled = true;
            this.cbTransportType.Items.AddRange(new object[] {
            "connect as Server",
            "connect as non-XA client",
            "connect as XA client",
            "connect as non-XA managed client"});
            this.cbTransportType.Location = new System.Drawing.Point(99, 143);
            this.cbTransportType.Name = "cbTransportType";
            this.cbTransportType.Size = new System.Drawing.Size(401, 21);
            this.cbTransportType.TabIndex = 15;
            // 
            // MQTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 505);
            this.Controls.Add(this.cbTransportType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbQName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.btGet);
            this.Controls.Add(this.btPut);
            this.Controls.Add(this.tbChannel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbQManager);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbServer);
            this.Controls.Add(this.label1);
            this.Name = "MQTest";
            this.Text = "MQ Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbQManager;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbChannel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btPut;
        private System.Windows.Forms.Button btGet;
        private System.Windows.Forms.RichTextBox tbMessage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbQName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbTransportType;
    }
}

