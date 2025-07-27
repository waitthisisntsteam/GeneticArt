namespace GeneticArt
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            InputImage = new PictureBox();
            OutputImage = new PictureBox();
            InputLabel = new Label();
            OutputLabel = new Label();
            TransformButton = new Button();
            Arrow = new Label();
            TrainingTimer = new System.Windows.Forms.Timer(components);
            StopTrainingButton = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)InputImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OutputImage).BeginInit();
            SuspendLayout();
            // 
            // InputImage
            // 
            InputImage.BorderStyle = BorderStyle.FixedSingle;
            InputImage.Location = new Point(12, 60);
            InputImage.Name = "InputImage";
            InputImage.Size = new Size(300, 300);
            InputImage.SizeMode = PictureBoxSizeMode.StretchImage;
            InputImage.TabIndex = 0;
            InputImage.TabStop = false;
            InputImage.Click += InputImage_Click;
            // 
            // OutputImage
            // 
            OutputImage.BorderStyle = BorderStyle.FixedSingle;
            OutputImage.Location = new Point(488, 60);
            OutputImage.Name = "OutputImage";
            OutputImage.Size = new Size(300, 300);
            OutputImage.SizeMode = PictureBoxSizeMode.StretchImage;
            OutputImage.TabIndex = 1;
            OutputImage.TabStop = false;
            // 
            // InputLabel
            // 
            InputLabel.AutoSize = true;
            InputLabel.Font = new Font("Segoe UI Variable Display Semib", 26F, FontStyle.Bold, GraphicsUnit.Point, 0);
            InputLabel.Location = new Point(48, 10);
            InputLabel.Name = "InputLabel";
            InputLabel.Size = new Size(211, 47);
            InputLabel.TabIndex = 2;
            InputLabel.Text = "Input Image";
            // 
            // OutputLabel
            // 
            OutputLabel.AutoSize = true;
            OutputLabel.Font = new Font("Segoe UI Variable Display Semib", 26F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OutputLabel.Location = new Point(526, 10);
            OutputLabel.Name = "OutputLabel";
            OutputLabel.Size = new Size(240, 47);
            OutputLabel.TabIndex = 3;
            OutputLabel.Text = "Output Image";
            // 
            // TransformButton
            // 
            TransformButton.Font = new Font("Segoe UI Variable Display Semib", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TransformButton.Location = new Point(318, 348);
            TransformButton.Name = "TransformButton";
            TransformButton.Size = new Size(164, 90);
            TransformButton.TabIndex = 4;
            TransformButton.Text = "Transform";
            TransformButton.UseVisualStyleBackColor = true;
            TransformButton.Click += TransformButton_Click;
            // 
            // Arrow
            // 
            Arrow.AutoSize = true;
            Arrow.Font = new Font("Segoe UI", 74.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Arrow.Location = new Point(318, 137);
            Arrow.Name = "Arrow";
            Arrow.Size = new Size(165, 131);
            Arrow.TabIndex = 5;
            Arrow.Text = "->";
            // 
            // TrainingTimer
            // 
            TrainingTimer.Interval = 10;
            TrainingTimer.Tick += TrainingTimer_Tick;
            // 
            // StopTrainingButton
            // 
            StopTrainingButton.Location = new Point(535, 388);
            StopTrainingButton.Name = "StopTrainingButton";
            StopTrainingButton.Size = new Size(75, 23);
            StopTrainingButton.TabIndex = 6;
            StopTrainingButton.Text = "Stop";
            StopTrainingButton.UseVisualStyleBackColor = true;
            StopTrainingButton.Click += StopTrainingButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(373, 112);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 7;
            label1.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(StopTrainingButton);
            Controls.Add(Arrow);
            Controls.Add(TransformButton);
            Controls.Add(OutputLabel);
            Controls.Add(InputLabel);
            Controls.Add(OutputImage);
            Controls.Add(InputImage);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)InputImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)OutputImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox InputImage;
        private PictureBox OutputImage;
        private Label InputLabel;
        private Label OutputLabel;
        private Button TransformButton;
        private Label Arrow;
        private System.Windows.Forms.Timer TrainingTimer;
        private Button StopTrainingButton;
        private Label label1;
    }
}
