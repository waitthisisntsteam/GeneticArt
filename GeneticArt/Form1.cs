using System;

namespace GeneticArt
{
    public partial class Form1 : Form
    {
        Graphics Input;
        Graphics Output;

        public Form1()
        {
            InitializeComponent();
            Input = Graphics.FromImage(InputImage.Image);
            Output = Graphics.FromImage(OutputImage.Image);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

        private void TransformButton_Click(object sender, EventArgs e)
        {

        }

        private void InputImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDirectory = new OpenFileDialog();
            var file = fileDirectory.ShowDialog();

            if (file == DialogResult.OK || file == DialogResult.Yes)
            {
                InputImage.Image = new Bitmap(fileDirectory.FileName);
            }

            Bitmap? normalizedInputImage = InputImage.Image as Bitmap;
            normalizedInputImage.SetResolution(1, 1);

            Input = Graphics.FromImage(normalizedInputImage);
        }
    }
}
