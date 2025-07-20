using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticArt
{
    public class TriangleArt
    {
        private int MaxTriangles;
        private List<Triangle> Triangles;
        Bitmap OriginalImage;

        public TriangleArt(int maxTriangles, Bitmap originalImage)
        {
            MaxTriangles = maxTriangles;
            OriginalImage = originalImage;

            Triangles = new List<Triangle>();
        }

        public void Mutate(Random random)
        {
            double selectedChance = random.NextDouble();

            if (selectedChance < TriangleArtConstants.AddTriangleChance)
            {
                Triangle newTriangle = Triangle.RandomTriangle(random);
                Triangles.Add(newTriangle);

                if (Triangles.Count > MaxTriangles)
                {
                    Triangles.RemoveAt(0);
                }
            }
            else if (selectedChance < TriangleArtConstants.AddTriangleChance + TriangleArtConstants.MutateTriangleChance)
            {
                if (Triangles.Count > 0)
                {
                    Triangles[random.Next(0, Triangles.Count)].Mutate(random);
                }
            }
            else
            {
                int removalIndex = random.Next(0, Triangles.Count);

                if (Triangles.Count > 0)
                {
                    Triangles.RemoveAt(removalIndex);
                }
            }
        }

        public Bitmap DrawImage()
        {
            Bitmap image = new Bitmap(100, 100);
            using Graphics gfx = Graphics.FromImage(image);

            foreach (Triangle triangle in Triangles)
            {
                gfx.FillPolygon(new SolidBrush(triangle.Color), triangle.Points);
            }

            return image;
        }

        public void CopyTo(TriangleArt other)
        {
            other.Triangles.Clear();
            foreach (Triangle trianlge in Triangles)
            {
                other.Triangles.Add(trianlge.Copy());
            }
        }

        public double GetError()
        {
            using Bitmap currentImage = DrawImage();
            double errorSum = 0;

            for (int x = 0; x < currentImage.Width; x++)
            {
                for (int y = 0; y < currentImage.Height; y++)
                {
                    var currentPixel = currentImage.GetPixel(x, y);
                    var originalPixel = OriginalImage.GetPixel(x, y);

                    errorSum += Math.Pow(
                                (currentPixel.A - originalPixel.A) +
                                (currentPixel.R - originalPixel.R) +
                                (currentPixel.G - originalPixel.G) +
                                (currentPixel.B - originalPixel.B),
                                2);
                }
            }

            return errorSum / (currentImage.Width * currentImage.Height);
        }
    }
}
