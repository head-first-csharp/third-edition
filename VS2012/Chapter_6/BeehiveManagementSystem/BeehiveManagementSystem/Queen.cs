using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class Queen : Bee
    {
        public Queen(Worker[] workers, double weightMg)
            : base(weightMg)
        {
            this.workers = workers;
        }

        private Worker[] workers;
        private int shiftNumber = 0;

        public bool AssignWork(string job, int numberOfShifts)
        {
            for (int i = 0; i < workers.Length; i++)
                if (workers[i].DoThisJob(job, numberOfShifts))
                    return true;
            return false;
        }

        public string WorkTheNextShift()
        {
            double honeyConsumed = HoneyConsumptionRate();

            shiftNumber++;
            string report = "Report for shift #" + shiftNumber + "\r\n";
            for (int i = 0; i < workers.Length; i++)
            {
                honeyConsumed += workers[i].HoneyConsumptionRate();

                if (workers[i].DidYouFinish())
                    report += "Worker #" + (i + 1) + " finished the job\r\n";
                if (String.IsNullOrEmpty(workers[i].CurrentJob))
                    report += "Worker #" + (i + 1) + " is not working\r\n";
                else
                    if (workers[i].ShiftsLeft > 0)
                        report += "Worker #" + (i + 1) + " is doing ‘" + workers[i].CurrentJob
                            + "’ for " + workers[i].ShiftsLeft + " more shifts\r\n";
                    else
                        report += "Worker #" + (i + 1) + " will be done with ‘"
                            + workers[i].CurrentJob + "’ after this shift\r\n";
            }

            report += "Total honey consumed for the shift: " + honeyConsumed + " units\r\n";

            return report;
        }
    }
}
