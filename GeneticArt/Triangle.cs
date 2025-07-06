using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticArt
{
    public class Triangle
    {
        Color Color;
        PointF[] Points;

        public Triangle(PointF point0, PointF point1, PointF point2, Color color)
        {
            Points = [point0, point1, point2];
            Color = color;
        }

        public void Normalize(float xCoefficient, float yCoefficient)
        {
            Points[0].X /= xCoefficient;
            Points[0].Y /= yCoefficient;
            Points[1].X /= xCoefficient;
            Points[1].Y /= yCoefficient;
            Points[2].X /= xCoefficient;
            Points[2].Y /= yCoefficient;
        }
        public void Unnormalize(float xCoefficient, float yCoefficient)
        {
            Points[0].X *= xCoefficient;
            Points[0].Y *= yCoefficient;
            Points[1].X *= xCoefficient;
            Points[1].Y *= yCoefficient;
            Points[2].X *= xCoefficient;
            Points[2].Y *= yCoefficient;
        }
        private int ConstrainColor(int number, int mutation, int min = 0, int max = 255)
        {
            int result = number + mutation;
            if (result < min) return min;
            if (result > max) return max;
            return result;
        }
        private float ConstrainImage(float number, float mutation, float min = 0, float max = 100)
        {
            float result = number + mutation;
            if (result < min) return min;
            if (result > max) return max;
            return result;
        }

        public void DrawTriangle(Graphics graphics, float xCoefficient, float yCoefficient)
        {
            Unnormalize(xCoefficient, yCoefficient);
            graphics.FillPolygon(new SolidBrush(Color), Points);
        }

        public void Mutate(Random random, float xCoefficient, float yCoefficient)
        {
            if (true) // use a weighed random to mutate color
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
            else if (true) // use a weigehed random to mutate point
            {
                Unnormalize(xCoefficient, yCoefficient);

                int mutateePointIndex = random.Next(0, 4);
                PointF mutateePoint = Points[mutateePointIndex];

                int mutateeIndex = random.Next(0, 2);
                int mutateAmount = random.Next(-300, 300);

                switch (mutateeIndex)
                {
                    case 0:
                        mutateePoint.X = ConstrainImage(mutateePoint.X, mutateAmount);
                        break;
                    case 1:
                        mutateePoint.Y = ConstrainImage(mutateePoint.Y, mutateAmount);  
                        break;
                }
                Points[mutateePointIndex] = mutateePoint;

                Normalize(xCoefficient, yCoefficient);
            }
        }

        public void Copy()
        {

        }

        public static Triangle RandomTriangle(Random random)
        {

        }
    }
}
