using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyber.UnitTest
{
    public class Simulation
    {
        public Dictionary<string, int> SimuFeatures { get; private set; }
        public int[] SimuDice10 { get; private set; }
        public int[] SimuDice20 { get; private set; }

        public Simulation(bool rnd = false)
        {
            if (!rnd)
            {
                SimuFeatures = new Dictionary<string, int>()
                {
                    {"BT", 3},
                    {"CON", 10},
                    {"EMP", 6},
                    {"MVT", 8},
                    {"SF", 3},
                    {"TECH", 2},
                    {"INT", 3},
                    {"REF", 9},
                    {"CH", 7},
                };
            }
            else
            {
                SimuFeatures = new Dictionary<string, int>()
                {
                    {"BT", GetFeatureRdn()},
                    {"CON", GetFeatureRdn()},
                    {"EMP", GetFeatureRdn()},
                    {"MVT", GetFeatureRdn()},
                    {"SF", GetFeatureRdn()},
                    {"TECH", GetFeatureRdn()},
                    {"INT", GetFeatureRdn()},
                    {"REF", GetFeatureRdn()},
                    {"CH", GetFeatureRdn()},
                };
            }
        }

        private int GetFeatureRdn()
        {
            Random rnd = new Random();
            return rnd.Next(2, 10);
        }

    }
}
