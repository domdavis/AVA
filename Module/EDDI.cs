using System.Collections.Generic;

namespace AVA.Module
{
    class EDDI : 
        IMonitor<InitPluginEvent>,
        IMonitor<AVA.EDDI.InitialisedEvent>,
        IMonitor<AVA.EDDI.UnhandledEvent>
    {
        public EDDI()
        {
            Dispatcher<InitPluginEvent>.Instance.Add(this);
            Dispatcher<AVA.EDDI.InitialisedEvent>.Instance.Add(this);
        }

        public void Handle(InitPluginEvent _)
        {
            new PlayAudioEvent(new List<ISound> { Effect.Initalised });
        }

        public void Handle(AVA.EDDI.InitialisedEvent e)
        {
            Audio.PlaySounds(new List<ISound>
            {
                Effect.Start,
                Audio.Say("Connection to EDDI established."),
                Audio.Say($"{Properties.SpokenName} online.")
            });
        }

        public void Handle(AVA.EDDI.UnhandledEvent e)
        {
            VA.Log.Debug($"Unhadled EDDI event: {e.Name}");
        }
    }
}
