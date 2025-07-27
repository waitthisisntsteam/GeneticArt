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
        public static double MutateColorChance = .5;
        public static double MutatePointChance = .5;

        public static double AddTriangleChance = .2;
        public static double MutateTriangleChance = .6;
        public static double RemoveTriangleChance = .2;

        //Art
        public static int MinimumOpacity = 25;

        public static int MaximumTriangles = 40;
        public static int PopulationSize = 50;
    }
}
