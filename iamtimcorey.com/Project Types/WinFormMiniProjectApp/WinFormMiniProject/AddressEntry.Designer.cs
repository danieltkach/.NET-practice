namespace WinFormMiniProject
{
    partial class AddressEntry
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
            this.cityText = new System.Windows.Forms.TextBox();
            this.cityLabel = new System.Windows.Forms.Label();
            this.streetAddressText = new System.Windows.Forms.TextBox();
            this.streetAddressLabel = new System.Windows.Forms.Label();
            this.zipcodeText = new System.Windows.Forms.TextBox();
            this.zipcodeLabel = new System.Windows.Forms.Label();
            this.stateText = new System.Windows.Forms.TextBox();
            this.stateLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cityText
            // 
            this.cityText.Location = new System.Drawing.Point(142, 108);
            this.cityText.Margin = new System.Windows.Forms.Padding(2);
            this.cityText.Name = "cityText";
            this.cityText.Size = new System.Drawing.Size(324, 27);
            this.cityText.TabIndex = 6;
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(100, 111);
            this.cityLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(38, 20);
            this.cityLabel.TabIndex = 3;
            this.cityLabel.Text = "City";
            // 
            // streetAddressText
            // 
            this.streetAddressText.Location = new System.Drawing.Point(142, 61);
            this.streetAddressText.Margin = new System.Windows.Forms.Padding(2);
            this.streetAddressText.Name = "streetAddressText";
            this.streetAddressText.Size = new System.Drawing.Size(324, 27);
            this.streetAddressText.TabIndex = 5;
            // 
            // streetAddressLabel
            // 
            this.streetAddressLabel.AutoSize = true;
            this.streetAddressLabel.Location = new System.Drawing.Point(84, 64);
            this.streetAddressLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.streetAddressLabel.Name = "streetAddressLabel";
            this.streetAddressLabel.Size = new System.Drawing.Size(54, 20);
            this.streetAddressLabel.TabIndex = 4;
            this.streetAddressLabel.Text = "Street";
            // 
            // zipcodeText
            // 
            this.zipcodeText.Location = new System.Drawing.Point(142, 202);
            this.zipcodeText.Margin = new System.Windows.Forms.Padding(2);
            this.zipcodeText.Name = "zipcodeText";
            this.zipcodeText.Size = new System.Drawing.Size(324, 27);
            this.zipcodeText.TabIndex = 10;
            // 
            // zipcodeLabel
            // 
            this.zipcodeLabel.AutoSize = true;
            this.zipcodeLabel.Location = new System.Drawing.Point(71, 205);
            this.zipcodeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.zipcodeLabel.Name = "zipcodeLabel";
            this.zipcodeLabel.Size = new System.Drawing.Size(67, 20);
            this.zipcodeLabel.TabIndex = 7;
            this.zipcodeLabel.Text = "Zipcode";
            // 
            // stateText
            // 
            this.stateText.Location = new System.Drawing.Point(142, 155);
            this.stateText.Margin = new System.Windows.Forms.Padding(2);
            this.stateText.Name = "stateText";
            this.stateText.Size = new System.Drawing.Size(324, 27);
            this.stateText.TabIndex = 9;
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(90, 158);
            this.stateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(48, 20);
            this.stateLabel.TabIndex = 8;
            this.stateLabel.Text = "State";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(166, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 29);
            this.label1.TabIndex = 11;
            this.label1.Text = "Address Entry";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(207, 300);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(123, 38);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // AddressEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 350);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zipcodeText);
            this.Controls.Add(this.zipcodeLabel);
            this.Controls.Add(this.stateText);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.cityText);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.streetAddressText);
            this.Controls.Add(this.streetAddressLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "AddressEntry";
            this.Text = "AddressEntry";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cityText;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.TextBox streetAddressText;
        private System.Windows.Forms.Label streetAddressLabel;
        private System.Windows.Forms.TextBox zipcodeText;
        private System.Windows.Forms.Label zipcodeLabel;
        private System.Windows.Forms.TextBox stateText;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
    }
}