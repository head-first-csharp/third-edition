using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetMission
{
    class Mars : PlanetMission
    {
        public Mars()
        {
            MilesToPlanet = 75000000;
            RocketFuelPerMile = 100000;
            RocketSpeedMPH = 25000;
        }
    }
}
