
namespace IOTdbFrontend
{
    partial class Form1
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
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxType = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.editBoxID = new System.Windows.Forms.TextBox();
            this.editBoxIP = new System.Windows.Forms.TextBox();
            this.editBoxType = new System.Windows.Forms.TextBox();
            this.editBoxCategory = new System.Windows.Forms.TextBox();
            this.editBoxValue = new System.Windows.Forms.TextBox();
            this.editBoxUnit = new System.Windows.Forms.TextBox();
            this.Send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(12, 90);
            this.textBoxID.Multiline = true;
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.ReadOnly = true;
            this.textBoxID.Size = new System.Drawing.Size(176, 348);
            this.textBoxID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Device-ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "IP-Address";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(194, 90);
            this.textBoxIP.Multiline = true;
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.ReadOnly = true;
            this.textBoxIP.Size = new System.Drawing.Size(176, 348);
            this.textBoxIP.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(373, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Time stamp";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(376, 90);
            this.textBoxTime.Multiline = true;
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(137, 348);
            this.textBoxTime.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(513, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Device-Type";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBoxType
            // 
            this.textBoxType.Location = new System.Drawing.Point(519, 90);
            this.textBoxType.Multiline = true;
            this.textBoxType.Name = "textBoxType";
            this.textBoxType.ReadOnly = true;
            this.textBoxType.Size = new System.Drawing.Size(75, 348);
            this.textBoxType.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(577, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Device-Category";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.Location = new System.Drawing.Point(600, 90);
            this.textBoxCategory.Multiline = true;
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.ReadOnly = true;
            this.textBoxCategory.Size = new System.Drawing.Size(66, 348);
            this.textBoxCategory.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(690, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Value";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(672, 90);
            this.textBoxValue.Multiline = true;
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.ReadOnly = true;
            this.textBoxValue.Size = new System.Drawing.Size(55, 348);
            this.textBoxValue.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(733, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // editBoxID
            // 
            this.editBoxID.Location = new System.Drawing.Point(12, 51);
            this.editBoxID.Name = "editBoxID";
            this.editBoxID.Size = new System.Drawing.Size(176, 20);
            this.editBoxID.TabIndex = 13;
            // 
            // editBoxIP
            // 
            this.editBoxIP.Location = new System.Drawing.Point(194, 51);
            this.editBoxIP.Name = "editBoxIP";
            this.editBoxIP.Size = new System.Drawing.Size(176, 20);
            this.editBoxIP.TabIndex = 14;
            // 
            // editBoxType
            // 
            this.editBoxType.Location = new System.Drawing.Point(516, 51);
            this.editBoxType.Name = "editBoxType";
            this.editBoxType.Size = new System.Drawing.Size(78, 20);
            this.editBoxType.TabIndex = 16;
            // 
            // editBoxCategory
            // 
            this.editBoxCategory.Location = new System.Drawing.Point(600, 51);
            this.editBoxCategory.Name = "editBoxCategory";
            this.editBoxCategory.Size = new System.Drawing.Size(66, 20);
            this.editBoxCategory.TabIndex = 17;
            // 
            // editBoxValue
            // 
            this.editBoxValue.Location = new System.Drawing.Point(672, 51);
            this.editBoxValue.Name = "editBoxValue";
            this.editBoxValue.Size = new System.Drawing.Size(55, 20);
            this.editBoxValue.TabIndex = 18;
            // 
            // editBoxUnit
            // 
            this.editBoxUnit.Location = new System.Drawing.Point(733, 51);
            this.editBoxUnit.Name = "editBoxUnit";
            this.editBoxUnit.Size = new System.Drawing.Size(55, 20);
            this.editBoxUnit.TabIndex = 19;
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(733, 90);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(55, 23);
            this.Send.TabIndex = 20;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.editBoxUnit);
            this.Controls.Add(this.editBoxValue);
            this.Controls.Add(this.editBoxCategory);
            this.Controls.Add(this.editBoxType);
            this.Controls.Add(this.editBoxIP);
            this.Controls.Add(this.editBoxID);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxCategory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxID);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxCategory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox editBoxID;
        private System.Windows.Forms.TextBox editBoxIP;
        private System.Windows.Forms.TextBox editBoxType;
        private System.Windows.Forms.TextBox editBoxCategory;
        private System.Windows.Forms.TextBox editBoxValue;
        private System.Windows.Forms.TextBox editBoxUnit;
        private System.Windows.Forms.Button Send;
    }
}

