using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfBaseballSimulator
{
    class Ball
    {
        public event EventHandler BallInPlay;
        public void OnBallInPlay(BallEventArgs e)
        {
            EventHandler ballInPlay = BallInPlay;
            if (ballInPlay != null)
                ballInPlay(this, e);
        }
    }

}
