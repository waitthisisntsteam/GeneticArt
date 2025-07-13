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
                Triangles[random.Next(0, Triangles.Count)].Mutate(random);
            }
            else
            {   
                Triangles.RemoveAt(random.Next(0, Triangles.Count));
            }
        }

        public Bitmap DrawImage()
        {
            Bitmap image = new Bitmap(0, 1);
            Graphics gfx = Graphics.FromImage(image);

            foreach (Triangle triangle in Triangles)
            {
                gfx.FillPolygon(new SolidBrush(triangle.Color), triangle.Points);
            }

            return image;
        }

        public void CopyTo(TriangleArt other)
        {

        }

        public double GetError()
        {

        }
    }
}
