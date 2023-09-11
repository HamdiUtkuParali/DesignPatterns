﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgorithm algorithm;

            Console.WriteLine("Men");
            algorithm = new MensScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(8,new TimeSpan(0,2,34)));

            Console.WriteLine("Women");
            algorithm = new WomensScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(8, new TimeSpan(0, 2, 34)));

            Console.WriteLine("Children");
            algorithm = new ChildrensScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(8, new TimeSpan(0, 2, 34)));

            Console.ReadLine();

        }

    }

    abstract class ScoringAlgorithm
    {
        public int GenerateScore(int hits, TimeSpan time)
        {
            int score = CalculateBaseScore(hits);
            int reduction = CalculateReduction(time);
            return CalculateOverallScore(score, reduction);
        }

        public abstract int CalculateOverallScore(int score, int reduction);

        public abstract int CalculateReduction(TimeSpan time);
        
        public abstract int CalculateBaseScore(int hits);
        
    }

    class MensScoringAlgorithm : ScoringAlgorithm
    {

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }

        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

    }

    class WomensScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }

        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

    }

    class ChildrensScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 2;
        }

        public override int CalculateBaseScore(int hits)
        {
            return hits * 80;
        }

    }

}
