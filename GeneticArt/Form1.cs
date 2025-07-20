using System;

namespace GeneticArt
{
    public partial class Form1 : Form
    {
        private GeneticArtTrainer GeneticArtTrainer;
        private Random Random;
        private int MaxTriangles;
        private int PopulationSize;

        private bool ContinueTransform;
        private bool CurrentlyInTraining;

        public Form1()
        {
            InitializeComponent();

            Random = new Random(5);
            MaxTriangles = 100;
            PopulationSize = 100;

            GeneticArtTrainer = new GeneticArtTrainer((Bitmap)InputImage.Image, MaxTriangles, PopulationSize);

            ContinueTransform = false;
            CurrentlyInTraining = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void TransformButton_Click(object sender, EventArgs e)
        {
            ContinueTransform = true;
            TrainingTimer.Start();
        }

        private void InputImage_Click(object sender, EventArgs e)
        {
            using OpenFileDialog fileDirectory = new OpenFileDialog();
            var file = fileDirectory.ShowDialog();

            if (file == DialogResult.OK || file == DialogResult.Yes)
            {
                InputImage.Image = new Bitmap(fileDirectory.FileName);
            }

            Bitmap normalizedInputImage = (Bitmap)InputImage.Image.Clone();
            normalizedInputImage.SetResolution(100, 100);

            GeneticArtTrainer = new GeneticArtTrainer((Bitmap)InputImage.Image, MaxTriangles, PopulationSize);
        }

        private void TrainingTimer_Tick(object sender, EventArgs e)
        {
            if (ContinueTransform && !CurrentlyInTraining)
            {
                CurrentlyInTraining = true;
                GeneticArtTrainer.Train(Random);

                OutputImage.Image = GeneticArtTrainer.GetBestImage();
                CurrentlyInTraining = false;
            }
        }

        private void StopTrainingButton_Click(object sender, EventArgs e)
        {
            ContinueTransform = false;
            TrainingTimer.Stop();
        }
    }
}
