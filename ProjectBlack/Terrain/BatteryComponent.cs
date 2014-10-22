using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack.Terrain
{
    public class BatteryComponent : Component
    {
        public float MaxCharge;
        public float CurrentCharge;
        public float DischargeRate;
        public float ChargeRate;

        /// <summary>
        /// Drains the battery
        /// </summary>
        /// <param name="draw">The power draw</param>
        /// <returns>Actual power drained from the battery</returns>
        public float Drain(float draw)
        {
            if (draw < 0) return 0;
            draw = draw > DischargeRate ? DischargeRate : draw;
            draw = CurrentCharge < draw ? CurrentCharge : draw;
            CurrentCharge -= draw;
            return draw;
        }

        /// <summary>
        /// Charges up the battery
        /// </summary>
        /// <param name="charge">Charge amount</param>
        /// <returns>Actual power used</returns>
        public float Charge(float charge) 
        {
            if (charge < 0) return 0;
            charge = charge > ChargeRate ? ChargeRate : charge;
            charge = (CurrentCharge + charge) > MaxCharge ? MaxCharge - CurrentCharge : charge;
            CurrentCharge += charge;
            return charge;
        }
    }
}
