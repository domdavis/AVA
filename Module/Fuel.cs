using System.Collections.Generic;

namespace AVA.Module
{
    class Fuel : 
        IMonitor<AVA.EDDI.ShipRefuelledEvent>,
        IMonitor<AVA.EDDI.JumpedEvent>
    {
        private decimal bingo;

        public void Handle(AVA.EDDI.ShipRefuelledEvent e)
        {
            decimal reported = AVA.EDDI.Variables.Status.Fuel;
            if (e.Source == AVA.EDDI.ShipRefuelledEvent.Scoop) { reported = e.Total; }
            if (reported > 0) { bingo = reported/2; }
        }

        public void Handle(AVA.EDDI.JumpedEvent e)
        {
            if (bingo == 0) { return; }
            if (e.FuelRemaining < bingo)
            {
                Audio.PlaySounds(new List<ISound> {Audio.Say("Bingo fuel.")});
            }
        }
    }
}
