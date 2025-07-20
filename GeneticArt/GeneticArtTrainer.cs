using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticArt
{
    public class GeneticArtTrainer
    {
        TriangleArt[] Population;
        double BestError;

        public GeneticArtTrainer(Bitmap originalImage, int maxTriangles, int populationSize)
        {
            Population = new TriangleArt[populationSize];
            for (int i = 0; i < populationSize; i++)
            {
                Population[i] = new TriangleArt(maxTriangles, originalImage);
            }
            BestError = double.MaxValue;
        }

        public double Train(Random random)
        {
            BestError = Population[0].GetError();
            int bestIndex = 0;

            for (int i = 1; i < Population.Length; i++)
            {
                Population[0].CopyTo(Population[i]);
                Population[i].Mutate(random);

                double currentError = Population[i].GetError();
                if (BestError > currentError)
                {
                    BestError = currentError;
                    bestIndex = i;
                }
            }

            Population[bestIndex].CopyTo(Population[0]);
            return BestError;
        }

        public Bitmap GetBestImage()
        {
            return Population[0].DrawImage();
        }
    }
}
