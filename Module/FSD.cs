using System.Collections.Generic;
using System.Linq;

namespace AVA.Module
{
    class FSD :
        IMonitor<AVA.EDDI.EnteredNormalSpaceEvent>,
        IMonitor<AVA.EDDI.EnteredSupercruiseEvent>,
        IMonitor<AVA.EDDI.FSDEngagedEvent>,
        IMonitor<AVA.EDDI.JumpedEvent>,
        IMonitor<AVA.EDDI.ShipFSDEvent>
    {
        public FSD()
        {
            Dispatcher<AVA.EDDI.FSDEngagedEvent>.Instance.Add(this);
        }

        public void Handle(AVA.EDDI.EnteredNormalSpaceEvent e) { VA.Log.Debug($"Supercruise: {e.BodyType}: {e.Body}"); }
        public void Handle(AVA.EDDI.EnteredSupercruiseEvent _) { }
        public void Handle(AVA.EDDI.FSDEngagedEvent e)
        {
            if (e.Target != AVA.EDDI.FSDEngagedEvent.Hyperspace) { return; }
            List<ISound> sounds = new List<ISound>
            {
                Audio.Pause(5500),
                Audio.Say($"En route to {e.System}, class: {e.StellarClass}")
            };

            if (!Scoopable(e.StellarClass))
            {
                sounds.Add(Audio.Pause(200));
                sounds.Add(Audio.Say("Warning, primary star cannot be used for fuel."));
            }

            Audio.PlaySounds(sounds);
        }

        public void Handle(AVA.EDDI.JumpedEvent e)
        {
            VA.Log.Debug($"Jumped to {e.System} ({e.X}, {e.Y}, {e.Z}). Used {e.FuelUsed}, remaining {e.FuelRemaining}");
        }

        public void Handle(AVA.EDDI.ShipFSDEvent _) { }

        bool Scoopable(string stellarclass)
        {
            return new[] { "M", "K", "G", "F", "A", "B", "O" }.Contains(stellarclass);
        }
    }
}