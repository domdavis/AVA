using System.Collections.Generic;

namespace AVA.Module
{
    class Session : 
        IMonitor<AVA.EDDI.CommanderContinuedEvent>, 
        IMonitor<AVA.EDDI.LocationEvent>, 
        IMonitor<AVA.EDDI.ShipLoadoutEvent>,
        IMonitor<AVA.EDDI.ShipRebootedEvent>,
        IMonitor<AVA.EDDI.ShutdownEvent>
    {
        private bool loaded;

        private string cmdr;
        private string shipname;

        public Session()
        {
            Dispatcher<AVA.EDDI.CommanderContinuedEvent>.Instance.Add(this);
            Dispatcher<AVA.EDDI.LocationEvent>.Instance.Add(this);
            Dispatcher<AVA.EDDI.ShipLoadoutEvent>.Instance.Add(this);
            Dispatcher<AVA.EDDI.ShipRebootedEvent>.Instance.Add(this);
            Dispatcher<AVA.EDDI.ShutdownEvent>.Instance.Add(this);
        }

        public void Handle(AVA.EDDI.CommanderContinuedEvent e)
        {
            Dispatcher<AVA.EDDI.CommanderContinuedEvent>.Instance.Remove(this);
            cmdr = e.Commander;

            Audio.PlaySounds(new List<ISound>
            {
                Effect.PowerOn,
                Audio.Pause(250),
                Audio.Say("System startup initiated."),
                Audio.Pause(500),
                Audio.Say($"Powering up your {e.Ship}")
            });
        }

        public void Handle(AVA.EDDI.LocationEvent e)
        {
            if (loaded) return;
            loaded = true;
            Audio.PlaySounds(new List<ISound> { Audio.Say($"Welcome back, Commander {cmdr}") });
        }

        public void Handle(AVA.EDDI.ShipLoadoutEvent e)
        {
            if (shipname == e.ShipName) return;
            shipname = e.ShipName;

            List<ISound> sounds = new List<ISound> { Audio.Pause(2000), Effect.Start };

            if (!loaded) sounds.Add(Audio.Say($"Welcome back, Commander {cmdr}"));
            loaded = true;

            sounds.Add(Audio.Say($"{e.ShipName} online."));
            Audio.QueueSounds(sounds);
        }

        public void Handle(AVA.EDDI.ShipRebootedEvent _)
        {
            Audio.PlaySounds(new List<ISound> {
                Audio.Say("Ship reboot complete"),
                Audio.Say($"{Properties.SpokenName}, online"),
            });
        }

        public void Handle(AVA.EDDI.ShutdownEvent _)
        {
            loaded = false;
            Audio.PlaySounds(new List<ISound> {
                Audio.Say($"{Properties.SpokenName}, shutting down"),
                Effect.Done
            });
        }
    }
}
