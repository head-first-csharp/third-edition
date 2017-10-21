using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetMission
{
    class Venus : PlanetMission
    {
        public Venus()
        {
            SetMissionInfo(40000000, 100000, 25000);
        }
        public override void SetMissionInfo(int milesToPlanet, int rocketFuelPerMile,
         long rocketSpeedMPH)
        {
            this.MilesToPlanet = milesToPlanet;
            this.RocketFuelPerMile = rocketFuelPerMile;
            this.RocketSpeedMPH = rocketSpeedMPH;
        }
    }
}
