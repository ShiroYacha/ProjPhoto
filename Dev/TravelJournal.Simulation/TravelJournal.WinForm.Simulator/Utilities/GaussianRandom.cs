using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelJournal.WinForm.Simulator
{
    public class GaussianRandom
    {
        private bool _available;
        private double _nextGauss;
        private Random _rng;

        public GaussianRandom()
        {
            _rng = new Random();
        }

        public double Random()
        {
            if (_available)
            {
                _available = false;
                return _nextGauss;
            }

            double u1 = _rng.NextDouble();
            double u2 = _rng.NextDouble();
            double temp1 = Math.Sqrt(-2.0 * Math.Log(u1));
            double temp2 = 2.0 * Math.PI * u2;

            _nextGauss = temp1 * Math.Sin(temp2);
            _available = true;
            return temp1 * Math.Cos(temp2);
        }

        public double Random(double mu, double sigma)
        {
            return mu + sigma * Random();
        }

        public double Random(double sigma)
        {
            return sigma * Random();
        }
    }
}
