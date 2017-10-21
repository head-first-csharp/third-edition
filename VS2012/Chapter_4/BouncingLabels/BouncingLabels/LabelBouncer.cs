using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncingLabels
{
    using System.Windows.Forms;

    class LabelBouncer
    {
        public Label MyLabel;

        public bool GoingForward = true;

        public void Move()
        {
            if (MyLabel != null)
            {
                if (GoingForward == true)
                {
                    MyLabel.Left += 5;
                    if (MyLabel.Left >= MyLabel.Parent.Width - MyLabel.Width)
                    {
                        GoingForward = false;
                    }
                }
                else
                {
                    MyLabel.Left -= 5;
                    if (MyLabel.Left <= 0)
                    {
                        GoingForward = true;
                    }
                }
            }
        }
    }
}
