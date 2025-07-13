using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticArt
{
    public class Triangle
    {
        public Color Color;
        public PointF[] Points;

        public Triangle(PointF point0, PointF point1, PointF point2, Color color)
        {
            Points = [point0, point1, point2];
            Color = color;
        }

        //public void Normalize(float xCoefficient, float yCoefficient)
        //{
        //    Points[0].X /= xCoefficient;
        //    Points[0].Y /= yCoefficient;
        //    Points[1].X /= xCoefficient;
        //    Points[1].Y /= yCoefficient;
        //    Points[2].X /= xCoefficient;
        //    Points[2].Y /= yCoefficient;
        //}
        //public void Unnormalize(float xCoefficient, float yCoefficient)
        //{
        //    Points[0].X *= xCoefficient;
        //    Points[0].Y *= yCoefficient;
        //    Points[1].X *= xCoefficient;
        //    Points[1].Y *= yCoefficient;
        //    Points[2].X *= xCoefficient;
        //    Points[2].Y *= yCoefficient;
        //}
        private int ConstrainColor(int number, int mutation, int min = 0, int max = 255)
        {
            int result = number + mutation;
            if (result < min) return min;
            if (result > max) return max;
            return result;
        }
        private float ConstrainPoints(float number, float mutation, int positive, float min = 0, float max = 1)
        {
            if (positive == 0) mutation *= -1;

            float result = number + mutation;
            if (result < min) return min;
            if (result > max) return max;
            return result;
        }

        public void DrawTriangle(Graphics graphics, float xCoefficient, float yCoefficient)
        {
            graphics.FillPolygon(new SolidBrush(Color), Points);
        }

        public void Mutate(Random random)
        {
            double selectedChance = random.NextDouble();

            if (selectedChance < TriangleArtConstants.MutateColorChance)
            {
                int mutateeIndex = random.Next(0, 4);
                int mutateAmount = random.Next(-255, 256);

                switch (mutateeIndex)
                {
                    case 0:
                        Color = Color.FromArgb(ConstrainColor(Color.A, mutateAmount), Color.R, Color.G, Color.B);
                        break;
                    case 1:
                        Color = Color.FromArgb(Color.A, ConstrainColor(Color.R, mutateAmount), Color.G, Color.B);
                        break;
                    case 2:
                        Color = Color.FromArgb(Color.A, Color.R, ConstrainColor(Color.G, mutateAmount), Color.B);
                        break;
                    case 3:
                        Color = Color.FromArgb(Color.A, Color.R, Color.G, ConstrainColor(Color.B, mutateAmount));
                        break;
                }
            }
            else
            {
                int mutateePointIndex = random.Next(0, 4);
                PointF mutateePoint = Points[mutateePointIndex];

                int mutateeIndex = random.Next(0, 2);
                float mutateAmount = (float)random.NextDouble();
                int mutateDirection = random.Next(0, 2);

                switch (mutateeIndex)
                {
                    case 0:
                        mutateePoint.X = ConstrainPoints(mutateePoint.X, mutateAmount, mutateDirection);
                        break;
                    case 1:
                        mutateePoint.Y = ConstrainPoints(mutateePoint.Y, mutateAmount, mutateDirection);  
                        break;
                }
                Points[mutateePointIndex] = mutateePoint;
            }
        }

        public Triangle Copy()
        {
            PointF pointF1 = new PointF(Points[0].X, Points[0].Y);
            PointF pointF2 = new PointF(Points[1].X, Points[1].Y);
            PointF pointF3 = new PointF(Points[2].X, Points[2].Y);

            return new Triangle(pointF1, pointF2, pointF3, Color);
        }

        public static Triangle RandomTriangle(Random random)
        {
            return new Triangle(new PointF(random.Next(0, 1), random.Next(0, 1)), 
                                new PointF(random.Next(0, 1), random.Next(0, 1)),
                                new PointF(random.Next(0, 1), random.Next(0, 1)), 
                                Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256),random.Next(TriangleArtConstants.MinimumOpacity, 256)));
        }
    }
}
