using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballSimulator
{
    using System.Collections.ObjectModel;
    class Fan
    {
        public ObservableCollection<string> FanSays = new ObservableCollection<string>();
        private int pitchNumber = 0;
        public Fan(Ball ball)
        {
            ball.BallInPlay += new EventHandler(ball_BallInPlay);
        }
        void ball_BallInPlay(object sender, EventArgs e)
        {
            pitchNumber++;
            if (e is BallEventArgs)
            {
                BallEventArgs ballEventArgs = e as BallEventArgs;
                if (ballEventArgs.Distance > 400 && ballEventArgs.Trajectory > 30)
                    FanSays.Add("Pitch #" + pitchNumber
                                 + ": Home run! I'm going for the ball!");
                else
                    FanSays.Add("Pitch #" + pitchNumber + ": Woo-hoo! Yeah!");
            }
        }
    }
}
