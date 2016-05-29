namespace ImageAnalysis
{
    partial class ImageAnalysisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageAnalysisForm));
            this.PreviousButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.FlagButton = new System.Windows.Forms.Button();
            this.SendButton = new System.Windows.Forms.Button();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.CheckBoxFalse = new System.Windows.Forms.CheckBox();
            this.CheckBoxTrue = new System.Windows.Forms.CheckBox();
            this.LevelLabel = new System.Windows.Forms.Label();
            this.LevelTextBox = new System.Windows.Forms.TextBox();
            this.InformationTextBox = new System.Windows.Forms.TextBox();
            this.InformationLabel = new System.Windows.Forms.Label();
            this.ReceivedImageBox = new System.Windows.Forms.PictureBox();
            this.PercentageTextBox = new System.Windows.Forms.TextBox();
            this.PercentageofGreen = new System.Windows.Forms.Label();
            this.EmailCheckBox = new System.Windows.Forms.CheckBox();
            this.SMSCheckBox = new System.Windows.Forms.CheckBox();
            this.UnFlagButton = new System.Windows.Forms.Button();
            this.CompareButton = new System.Windows.Forms.Button();
            this.RefrenceImageBox = new System.Windows.Forms.PictureBox();
            this.ReferenceImageLabel = new System.Windows.Forms.Label();
            this.InternetTextBox = new System.Windows.Forms.TextBox();
            this.InternetLabel = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ChangeRefButton = new System.Windows.Forms.Button();
            this.openImageFile = new System.Windows.Forms.OpenFileDialog();
            this.DecodeButton = new System.Windows.Forms.Button();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.AutoProcess = new System.Windows.Forms.Button();
            this.ImageReceivedLabel = new System.Windows.Forms.Label();
            this.ComparisonProgressBar = new System.Windows.Forms.ProgressBar();
            this.ComparisonProgressLabel = new System.Windows.Forms.Label();
            this.SquaresCheckbox = new System.Windows.Forms.CheckBox();
            this.GreenCheckbox = new System.Windows.Forms.CheckBox();
            this.AutoProcessProgressBar = new System.Windows.Forms.ProgressBar();
            this.AutoProcessLabel = new System.Windows.Forms.Label();
            this.LevelCheckBox = new System.Windows.Forms.CheckBox();
            this.LevelProgressBar = new System.Windows.Forms.ProgressBar();
            this.LevelProgressLabel = new System.Windows.Forms.Label();
            this.ResultingImageBox = new System.Windows.Forms.PictureBox();
            this.AnalysedImageLabel = new System.Windows.Forms.Label();
            this.ImageNumberLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefrenceImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultingImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PreviousButton
            // 
            this.PreviousButton.Location = new System.Drawing.Point(175, 489);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(82, 32);
            this.PreviousButton.TabIndex = 0;
            this.PreviousButton.Text = "Previous";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(745, 489);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(82, 32);
            this.NextButton.TabIndex = 1;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // FlagButton
            // 
            this.FlagButton.Location = new System.Drawing.Point(176, 618);
            this.FlagButton.Name = "FlagButton";
            this.FlagButton.Size = new System.Drawing.Size(82, 32);
            this.FlagButton.TabIndex = 2;
            this.FlagButton.Text = "Flag";
            this.FlagButton.UseVisualStyleBackColor = true;
            this.FlagButton.Click += new System.EventHandler(this.FlagButton_Click);
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(745, 618);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(82, 32);
            this.SendButton.TabIndex = 3;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButtton_Click);
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Location = new System.Drawing.Point(176, 532);
            this.MessageTextBox.Multiline = true;
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(651, 80);
            this.MessageTextBox.TabIndex = 4;
            // 
            // CheckBoxFalse
            // 
            this.CheckBoxFalse.AutoSize = true;
            this.CheckBoxFalse.Location = new System.Drawing.Point(17, 41);
            this.CheckBoxFalse.Name = "CheckBoxFalse";
            this.CheckBoxFalse.Size = new System.Drawing.Size(69, 17);
            this.CheckBoxFalse.TabIndex = 6;
            this.CheckBoxFalse.Text = "Negative";
            this.CheckBoxFalse.UseVisualStyleBackColor = true;
            // 
            // CheckBoxTrue
            // 
            this.CheckBoxTrue.AutoSize = true;
            this.CheckBoxTrue.Location = new System.Drawing.Point(17, 64);
            this.CheckBoxTrue.Name = "CheckBoxTrue";
            this.CheckBoxTrue.Size = new System.Drawing.Size(63, 17);
            this.CheckBoxTrue.TabIndex = 7;
            this.CheckBoxTrue.Text = "Positive";
            this.CheckBoxTrue.UseVisualStyleBackColor = true;
            // 
            // LevelLabel
            // 
            this.LevelLabel.AutoSize = true;
            this.LevelLabel.Location = new System.Drawing.Point(12, 99);
            this.LevelLabel.Name = "LevelLabel";
            this.LevelLabel.Size = new System.Drawing.Size(91, 13);
            this.LevelLabel.TabIndex = 8;
            this.LevelLabel.Text = "Protein Level (g/l)";
            // 
            // LevelTextBox
            // 
            this.LevelTextBox.Location = new System.Drawing.Point(11, 115);
            this.LevelTextBox.Multiline = true;
            this.LevelTextBox.Name = "LevelTextBox";
            this.LevelTextBox.Size = new System.Drawing.Size(153, 20);
            this.LevelTextBox.TabIndex = 9;
            // 
            // InformationTextBox
            // 
            this.InformationTextBox.Location = new System.Drawing.Point(846, 41);
            this.InformationTextBox.Multiline = true;
            this.InformationTextBox.Name = "InformationTextBox";
            this.InformationTextBox.Size = new System.Drawing.Size(263, 173);
            this.InformationTextBox.TabIndex = 10;
            // 
            // InformationLabel
            // 
            this.InformationLabel.AutoSize = true;
            this.InformationLabel.Location = new System.Drawing.Point(925, 25);
            this.InformationLabel.Name = "InformationLabel";
            this.InformationLabel.Size = new System.Drawing.Size(96, 13);
            this.InformationLabel.TabIndex = 11;
            this.InformationLabel.Text = "Sender Information";
            // 
            // ReceivedImageBox
            // 
            this.ReceivedImageBox.Location = new System.Drawing.Point(175, 38);
            this.ReceivedImageBox.Name = "ReceivedImageBox";
            this.ReceivedImageBox.Size = new System.Drawing.Size(652, 445);
            this.ReceivedImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ReceivedImageBox.TabIndex = 12;
            this.ReceivedImageBox.TabStop = false;
            // 
            // PercentageTextBox
            // 
            this.PercentageTextBox.Location = new System.Drawing.Point(11, 160);
            this.PercentageTextBox.Name = "PercentageTextBox";
            this.PercentageTextBox.Size = new System.Drawing.Size(153, 20);
            this.PercentageTextBox.TabIndex = 14;
            // 
            // PercentageofGreen
            // 
            this.PercentageofGreen.AutoSize = true;
            this.PercentageofGreen.Location = new System.Drawing.Point(12, 144);
            this.PercentageofGreen.Name = "PercentageofGreen";
            this.PercentageofGreen.Size = new System.Drawing.Size(106, 13);
            this.PercentageofGreen.TabIndex = 15;
            this.PercentageofGreen.Text = "Percentage of Green";
            // 
            // EmailCheckBox
            // 
            this.EmailCheckBox.AutoSize = true;
            this.EmailCheckBox.Location = new System.Drawing.Point(849, 549);
            this.EmailCheckBox.Name = "EmailCheckBox";
            this.EmailCheckBox.Size = new System.Drawing.Size(51, 17);
            this.EmailCheckBox.TabIndex = 16;
            this.EmailCheckBox.Text = "Email";
            this.EmailCheckBox.UseVisualStyleBackColor = true;
            // 
            // SMSCheckBox
            // 
            this.SMSCheckBox.AutoSize = true;
            this.SMSCheckBox.Location = new System.Drawing.Point(849, 572);
            this.SMSCheckBox.Name = "SMSCheckBox";
            this.SMSCheckBox.Size = new System.Drawing.Size(49, 17);
            this.SMSCheckBox.TabIndex = 17;
            this.SMSCheckBox.Text = "SMS";
            this.SMSCheckBox.UseVisualStyleBackColor = true;
            // 
            // UnFlagButton
            // 
            this.UnFlagButton.Location = new System.Drawing.Point(264, 618);
            this.UnFlagButton.Name = "UnFlagButton";
            this.UnFlagButton.Size = new System.Drawing.Size(82, 32);
            this.UnFlagButton.TabIndex = 18;
            this.UnFlagButton.Text = "Un-Flag";
            this.UnFlagButton.UseVisualStyleBackColor = true;
            this.UnFlagButton.Click += new System.EventHandler(this.UnFlagButton_Click);
            // 
            // CompareButton
            // 
            this.CompareButton.Location = new System.Drawing.Point(352, 618);
            this.CompareButton.Name = "CompareButton";
            this.CompareButton.Size = new System.Drawing.Size(82, 32);
            this.CompareButton.TabIndex = 19;
            this.CompareButton.Text = "Calculate";
            this.CompareButton.UseVisualStyleBackColor = true;
            this.CompareButton.Click += new System.EventHandler(this.CompareButton_Click);
            // 
            // RefrenceImageBox
            // 
            this.RefrenceImageBox.Location = new System.Drawing.Point(916, 520);
            this.RefrenceImageBox.Name = "RefrenceImageBox";
            this.RefrenceImageBox.Size = new System.Drawing.Size(171, 122);
            this.RefrenceImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RefrenceImageBox.TabIndex = 20;
            this.RefrenceImageBox.TabStop = false;
            // 
            // ReferenceImageLabel
            // 
            this.ReferenceImageLabel.AutoSize = true;
            this.ReferenceImageLabel.Location = new System.Drawing.Point(953, 504);
            this.ReferenceImageLabel.Name = "ReferenceImageLabel";
            this.ReferenceImageLabel.Size = new System.Drawing.Size(89, 13);
            this.ReferenceImageLabel.TabIndex = 21;
            this.ReferenceImageLabel.Text = "Reference Image";
            // 
            // InternetTextBox
            // 
            this.InternetTextBox.Location = new System.Drawing.Point(11, 208);
            this.InternetTextBox.Name = "InternetTextBox";
            this.InternetTextBox.Size = new System.Drawing.Size(153, 20);
            this.InternetTextBox.TabIndex = 22;
            // 
            // InternetLabel
            // 
            this.InternetLabel.AutoSize = true;
            this.InternetLabel.Location = new System.Drawing.Point(12, 192);
            this.InternetLabel.Name = "InternetLabel";
            this.InternetLabel.Size = new System.Drawing.Size(100, 13);
            this.InternetLabel.TabIndex = 23;
            this.InternetLabel.Text = "Internet Connection";
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(657, 618);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(82, 32);
            this.ClearButton.TabIndex = 24;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ChangeRefButton
            // 
            this.ChangeRefButton.Location = new System.Drawing.Point(970, 651);
            this.ChangeRefButton.Name = "ChangeRefButton";
            this.ChangeRefButton.Size = new System.Drawing.Size(82, 32);
            this.ChangeRefButton.TabIndex = 25;
            this.ChangeRefButton.Text = "Change Ref";
            this.ChangeRefButton.UseVisualStyleBackColor = true;
            this.ChangeRefButton.Click += new System.EventHandler(this.ChangeRefButton_Click);
            // 
            // DecodeButton
            // 
            this.DecodeButton.Location = new System.Drawing.Point(440, 618);
            this.DecodeButton.Name = "DecodeButton";
            this.DecodeButton.Size = new System.Drawing.Size(82, 32);
            this.DecodeButton.TabIndex = 26;
            this.DecodeButton.Text = "Decode";
            this.DecodeButton.UseVisualStyleBackColor = true;
            this.DecodeButton.Click += new System.EventHandler(this.DecodeButton_Click);
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Location = new System.Drawing.Point(445, 513);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(71, 13);
            this.MessageLabel.TabIndex = 27;
            this.MessageLabel.Text = "Message Box";
            // 
            // AutoProcess
            // 
            this.AutoProcess.Location = new System.Drawing.Point(528, 618);
            this.AutoProcess.Name = "AutoProcess";
            this.AutoProcess.Size = new System.Drawing.Size(82, 32);
            this.AutoProcess.TabIndex = 28;
            this.AutoProcess.Text = "Auto Process";
            this.AutoProcess.UseVisualStyleBackColor = true;
            this.AutoProcess.Click += new System.EventHandler(this.AutoProcess_Click);
            // 
            // ImageReceivedLabel
            // 
            this.ImageReceivedLabel.AutoSize = true;
            this.ImageReceivedLabel.Location = new System.Drawing.Point(437, 22);
            this.ImageReceivedLabel.Name = "ImageReceivedLabel";
            this.ImageReceivedLabel.Size = new System.Drawing.Size(85, 13);
            this.ImageReceivedLabel.TabIndex = 29;
            this.ImageReceivedLabel.Text = "Image Received";
            // 
            // ComparisonProgressBar
            // 
            this.ComparisonProgressBar.Location = new System.Drawing.Point(13, 400);
            this.ComparisonProgressBar.Name = "ComparisonProgressBar";
            this.ComparisonProgressBar.Size = new System.Drawing.Size(113, 23);
            this.ComparisonProgressBar.TabIndex = 30;
            // 
            // ComparisonProgressLabel
            // 
            this.ComparisonProgressLabel.AutoSize = true;
            this.ComparisonProgressLabel.Location = new System.Drawing.Point(13, 384);
            this.ComparisonProgressLabel.Name = "ComparisonProgressLabel";
            this.ComparisonProgressLabel.Size = new System.Drawing.Size(106, 13);
            this.ComparisonProgressLabel.TabIndex = 31;
            this.ComparisonProgressLabel.Text = "Comparison Progress";
            // 
            // SquaresCheckbox
            // 
            this.SquaresCheckbox.AutoSize = true;
            this.SquaresCheckbox.Location = new System.Drawing.Point(10, 302);
            this.SquaresCheckbox.Name = "SquaresCheckbox";
            this.SquaresCheckbox.Size = new System.Drawing.Size(138, 17);
            this.SquaresCheckbox.TabIndex = 32;
            this.SquaresCheckbox.Text = "Compare using Squares";
            this.SquaresCheckbox.UseVisualStyleBackColor = true;
            this.SquaresCheckbox.CheckedChanged += new System.EventHandler(this.SquaresCheckbox_CheckedChanged);
            // 
            // GreenCheckbox
            // 
            this.GreenCheckbox.AutoSize = true;
            this.GreenCheckbox.Location = new System.Drawing.Point(10, 279);
            this.GreenCheckbox.Name = "GreenCheckbox";
            this.GreenCheckbox.Size = new System.Drawing.Size(153, 17);
            this.GreenCheckbox.TabIndex = 33;
            this.GreenCheckbox.Text = "Compare using Green Area";
            this.GreenCheckbox.UseVisualStyleBackColor = true;
            this.GreenCheckbox.CheckedChanged += new System.EventHandler(this.GreenCheckbox_CheckedChanged);
            // 
            // AutoProcessProgressBar
            // 
            this.AutoProcessProgressBar.Location = new System.Drawing.Point(12, 448);
            this.AutoProcessProgressBar.Name = "AutoProcessProgressBar";
            this.AutoProcessProgressBar.Size = new System.Drawing.Size(114, 23);
            this.AutoProcessProgressBar.TabIndex = 34;
            // 
            // AutoProcessLabel
            // 
            this.AutoProcessLabel.AutoSize = true;
            this.AutoProcessLabel.Location = new System.Drawing.Point(13, 432);
            this.AutoProcessLabel.Name = "AutoProcessLabel";
            this.AutoProcessLabel.Size = new System.Drawing.Size(114, 13);
            this.AutoProcessLabel.TabIndex = 35;
            this.AutoProcessLabel.Text = "Auto Process Progress";
            // 
            // LevelCheckBox
            // 
            this.LevelCheckBox.AutoSize = true;
            this.LevelCheckBox.Location = new System.Drawing.Point(10, 256);
            this.LevelCheckBox.Name = "LevelCheckBox";
            this.LevelCheckBox.Size = new System.Drawing.Size(164, 17);
            this.LevelCheckBox.TabIndex = 36;
            this.LevelCheckBox.Text = "Calculate Protein Colour level";
            this.LevelCheckBox.UseVisualStyleBackColor = true;
            // 
            // LevelProgressBar
            // 
            this.LevelProgressBar.Location = new System.Drawing.Point(13, 353);
            this.LevelProgressBar.Name = "LevelProgressBar";
            this.LevelProgressBar.Size = new System.Drawing.Size(113, 23);
            this.LevelProgressBar.TabIndex = 37;
            // 
            // LevelProgressLabel
            // 
            this.LevelProgressLabel.AutoSize = true;
            this.LevelProgressLabel.Location = new System.Drawing.Point(14, 337);
            this.LevelProgressLabel.Name = "LevelProgressLabel";
            this.LevelProgressLabel.Size = new System.Drawing.Size(113, 13);
            this.LevelProgressLabel.TabIndex = 38;
            this.LevelProgressLabel.Text = "Protein Level Progress";
            // 
            // ResultingImageBox
            // 
            this.ResultingImageBox.Image = ((System.Drawing.Image)(resources.GetObject("ResultingImageBox.Image")));
            this.ResultingImageBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("ResultingImageBox.InitialImage")));
            this.ResultingImageBox.Location = new System.Drawing.Point(846, 273);
            this.ResultingImageBox.Name = "ResultingImageBox";
            this.ResultingImageBox.Size = new System.Drawing.Size(260, 172);
            this.ResultingImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ResultingImageBox.TabIndex = 39;
            this.ResultingImageBox.TabStop = false;
            // 
            // AnalysedImageLabel
            // 
            this.AnalysedImageLabel.AutoSize = true;
            this.AnalysedImageLabel.Location = new System.Drawing.Point(925, 256);
            this.AnalysedImageLabel.Name = "AnalysedImageLabel";
            this.AnalysedImageLabel.Size = new System.Drawing.Size(85, 13);
            this.AnalysedImageLabel.TabIndex = 40;
            this.AnalysedImageLabel.Text = "Analysed Image ";
            // 
            // ImageNumberLabel
            // 
            this.ImageNumberLabel.AutoSize = true;
            this.ImageNumberLabel.Location = new System.Drawing.Point(437, 486);
            this.ImageNumberLabel.Name = "ImageNumberLabel";
            this.ImageNumberLabel.Size = new System.Drawing.Size(0, 13);
            this.ImageNumberLabel.TabIndex = 41;
            // 
            // ImageAnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 703);
            this.Controls.Add(this.ImageNumberLabel);
            this.Controls.Add(this.AnalysedImageLabel);
            this.Controls.Add(this.ResultingImageBox);
            this.Controls.Add(this.LevelProgressLabel);
            this.Controls.Add(this.LevelProgressBar);
            this.Controls.Add(this.LevelCheckBox);
            this.Controls.Add(this.AutoProcessLabel);
            this.Controls.Add(this.AutoProcessProgressBar);
            this.Controls.Add(this.GreenCheckbox);
            this.Controls.Add(this.SquaresCheckbox);
            this.Controls.Add(this.ComparisonProgressLabel);
            this.Controls.Add(this.ComparisonProgressBar);
            this.Controls.Add(this.ImageReceivedLabel);
            this.Controls.Add(this.AutoProcess);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.DecodeButton);
            this.Controls.Add(this.ChangeRefButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.InternetLabel);
            this.Controls.Add(this.InternetTextBox);
            this.Controls.Add(this.ReferenceImageLabel);
            this.Controls.Add(this.RefrenceImageBox);
            this.Controls.Add(this.CompareButton);
            this.Controls.Add(this.UnFlagButton);
            this.Controls.Add(this.SMSCheckBox);
            this.Controls.Add(this.EmailCheckBox);
            this.Controls.Add(this.PercentageofGreen);
            this.Controls.Add(this.PercentageTextBox);
            this.Controls.Add(this.ReceivedImageBox);
            this.Controls.Add(this.InformationLabel);
            this.Controls.Add(this.InformationTextBox);
            this.Controls.Add(this.LevelTextBox);
            this.Controls.Add(this.LevelLabel);
            this.Controls.Add(this.CheckBoxTrue);
            this.Controls.Add(this.CheckBoxFalse);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.FlagButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PreviousButton);
            this.Name = "ImageAnalysisForm";
            this.Text = "ImageAnalysis";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefrenceImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultingImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button FlagButton;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.CheckBox CheckBoxFalse;
        private System.Windows.Forms.CheckBox CheckBoxTrue;
        private System.Windows.Forms.Label LevelLabel;
        private System.Windows.Forms.TextBox LevelTextBox;
        private System.Windows.Forms.TextBox InformationTextBox;
        private System.Windows.Forms.Label InformationLabel;
        private System.Windows.Forms.PictureBox ReceivedImageBox;
        private System.Windows.Forms.TextBox PercentageTextBox;
        private System.Windows.Forms.Label PercentageofGreen;
        private System.Windows.Forms.CheckBox EmailCheckBox;
        private System.Windows.Forms.CheckBox SMSCheckBox;
        private System.Windows.Forms.Button UnFlagButton;
        private System.Windows.Forms.Button CompareButton;
        private System.Windows.Forms.PictureBox RefrenceImageBox;
        private System.Windows.Forms.Label ReferenceImageLabel;
        private System.Windows.Forms.TextBox InternetTextBox;
        private System.Windows.Forms.Label InternetLabel;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button ChangeRefButton;
        private System.Windows.Forms.OpenFileDialog openImageFile;
        private System.Windows.Forms.Button DecodeButton;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Button AutoProcess;
        private System.Windows.Forms.Label ImageReceivedLabel;
        private System.Windows.Forms.ProgressBar ComparisonProgressBar;
        private System.Windows.Forms.Label ComparisonProgressLabel;
        private System.Windows.Forms.CheckBox SquaresCheckbox;
        private System.Windows.Forms.CheckBox GreenCheckbox;
        private System.Windows.Forms.ProgressBar AutoProcessProgressBar;
        private System.Windows.Forms.Label AutoProcessLabel;
        private System.Windows.Forms.CheckBox LevelCheckBox;
        private System.Windows.Forms.ProgressBar LevelProgressBar;
        private System.Windows.Forms.Label LevelProgressLabel;
        private System.Windows.Forms.PictureBox ResultingImageBox;
        private System.Windows.Forms.Label AnalysedImageLabel;
        private System.Windows.Forms.Label ImageNumberLabel;
    }
}

