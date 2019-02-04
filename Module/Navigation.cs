using System.Collections.Generic;
using System.Linq;

namespace AVA.Module
{
    class Navigation : IMonitor<AVA.EDDI.FSDEngagedEvent>
    {
        public Navigation()
        {
            Dispatcher<AVA.EDDI.FSDEngagedEvent>.Instance.Add(this);
        }

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

        bool Scoopable(string stellarclass)
        {
            return new[] { "M", "K", "G", "F", "A", "B", "O" }.Contains(stellarclass);
        }
    }
}