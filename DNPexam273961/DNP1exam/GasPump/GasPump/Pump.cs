using System;
using System.ComponentModel.DataAnnotations;

namespace GasPump
{
    public class Pump
    {
        public double initialPumpSize = 1100;
        public decimal pumpCapacity = 1100;
        public decimal price = 9.82M;

        public double CostOfFullTank(decimal size)
        {
            return (double) (size * price);
        }

        public double FillTank(decimal liters)
        {
            if (pumpCapacity - liters < 0)
            {
                throw new Exception("Cannot complete action, pump does only contain " + pumpCapacity + " liters.");
            }
            pumpCapacity -= liters;


            return (double) (liters * price);
        }

        public DateTime FillPump()
        {
            pumpCapacity = (decimal) initialPumpSize;
            return DateTime.Now;
        }

    }
}
