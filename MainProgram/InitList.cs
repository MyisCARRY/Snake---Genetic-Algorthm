using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGA
{
    public class InitList
    {
        public int Id;
        public int HiddenLayers;
        public int HiddenNodes;
        public double MutationRate;
        public int Size;
        public double TopPopulation;
        public int MovesAtStart;
        public int MovesForFood;

        public string Name;
        public int BestScore;
        
        public bool Validate()
        {
            if (HiddenLayers < 0)
                return false;
            if (HiddenNodes <= 0)
                return false;
            if (MutationRate <= 0 || MutationRate > 1)
                return false;
            if (TopPopulation > 1 || TopPopulation <= 0)
                return false;
            if (Size < 0)
                return false;
            if (MovesAtStart < 0)
                return false;
            if (MovesForFood < 0)
                return false;
            if (Name == "" || Name == null)
                return false;
            return true;
        }

        public override string ToString()
        {
            return $"\"{Name}\", HL: {HiddenLayers}, HN: {HiddenNodes}, MutRate: {MutationRate*100}%, Population size: {Size}, Top population: {TopPopulation*100}% ";
        }
    }
}
