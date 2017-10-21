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
            SetMissionInfo(75000000, 100000, 25000);
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
