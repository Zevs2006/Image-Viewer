namespace Image_Viewer
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pictureBox = new PictureBox();
            buttonPrevious = new Button();
            buttonNext = new Button();
            buttonLoadFolder = new Button();
            numericUpDownZoom = new NumericUpDown();
            labelZoom = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownZoom).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(12, 12);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(760, 400);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 5;
            pictureBox.TabStop = false;
            // 
            // buttonPrevious
            // 
            buttonPrevious.Location = new Point(12, 430);
            buttonPrevious.Name = "buttonPrevious";
            buttonPrevious.Size = new Size(75, 23);
            buttonPrevious.TabIndex = 4;
            buttonPrevious.Text = "Назад";
            buttonPrevious.Click += buttonPrevious_Click;
            // 
            // buttonNext
            // 
            buttonNext.Location = new Point(697, 430);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(75, 23);
            buttonNext.TabIndex = 3;
            buttonNext.Text = "Вперед";
            buttonNext.Click += buttonNext_Click;
            // 
            // buttonLoadFolder
            // 
            buttonLoadFolder.Location = new Point(110, 430);
            buttonLoadFolder.Name = "buttonLoadFolder";
            buttonLoadFolder.Size = new Size(150, 23);
            buttonLoadFolder.TabIndex = 2;
            buttonLoadFolder.Text = "Загрузить папку";
            buttonLoadFolder.Click += buttonLoadFolder_Click;
            // 
            // numericUpDownZoom
            // 
            numericUpDownZoom.Location = new Point(290, 430);
            numericUpDownZoom.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownZoom.Name = "numericUpDownZoom";
            numericUpDownZoom.Size = new Size(120, 23);
            numericUpDownZoom.TabIndex = 1;
            numericUpDownZoom.Value = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDownZoom.ValueChanged += numericUpDownZoom_ValueChanged;
            // 
            // labelZoom
            // 
            labelZoom.Location = new Point(380, 430);
            labelZoom.Name = "labelZoom";
            labelZoom.Size = new Size(100, 23);
            labelZoom.TabIndex = 0;
            labelZoom.Text = "Увеличение (%)";
            // 
            // Form1
            // 
            ClientSize = new Size(784, 496);
            Controls.Add(labelZoom);
            Controls.Add(numericUpDownZoom);
            Controls.Add(buttonLoadFolder);
            Controls.Add(buttonNext);
            Controls.Add(buttonPrevious);
            Controls.Add(pictureBox);
            Name = "Form1";
            Text = "Просмотрщик изображений";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownZoom).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonLoadFolder;
        private System.Windows.Forms.NumericUpDown numericUpDownZoom;
        private System.Windows.Forms.Label labelZoom;
    }
}
