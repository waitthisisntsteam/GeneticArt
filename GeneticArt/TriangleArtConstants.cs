using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticArt
{
    public class TriangleArtConstants
    {
        //Chances
        public static double MutateColorChance = .3;
        public static double MutatePointChance = .7;

        public static double AddTriangleChance = .4;
        public static double MutateTriangleChance = .2;
        public static double RemoveTriangleChance = .4;

        //Art
        public static float XCoefficient = 300;
        public static float YCoefficient = 300;

        public static int TriangleCount = 300;
        public static int MinimumOpacity = 25;
    }
}
