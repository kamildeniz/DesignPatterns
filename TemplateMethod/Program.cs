﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgrithm algrithm;
            Console.WriteLine("Mans");
            algrithm=new MenScoringAlgorithm();
            Console.WriteLine(algrithm.GenerateScore(8,new TimeSpan(0,2,34)));

   
            Console.WriteLine("Womans");
            algrithm = new WomansScoringAlgorithm();
            Console.WriteLine(algrithm.GenerateScore(8, new TimeSpan(0, 2, 34)));

            
            Console.WriteLine("Children");
            algrithm = new ChildrenScoringAlgorithm();
            Console.WriteLine(algrithm.GenerateScore(8, new TimeSpan(0, 2, 34)));
            Console.ReadLine();
        }
    }
    abstract class ScoringAlgrithm
    {
        public int GenerateScore(int hit, TimeSpan time)
        {
            int score = CalculateBaseScore(hit);
            int reduction = CalculateReduction(time);
            return CalculateOverallScore(score,reduction);
        }

        public abstract int CalculateOverallScore(int score, int reduction);
        public abstract int CalculateReduction(TimeSpan time);
        public abstract int CalculateBaseScore(int hit);

    }
    class MenScoringAlgorithm : ScoringAlgrithm
    {
        public override int CalculateBaseScore(int hit)
        {
            return hit * 100;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;   
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }
    }
    class WomansScoringAlgorithm : ScoringAlgrithm
    {
        public override int CalculateBaseScore(int hit)
        {
            return hit * 100;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 4;
        }
    }
    class ChildrenScoringAlgorithm : ScoringAlgrithm
    {
        public override int CalculateBaseScore(int hit)
        {
            return hit * 80;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }
    }
}

