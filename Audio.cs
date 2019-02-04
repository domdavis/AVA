using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Threading;
using System.Media;
using System.Text.RegularExpressions;

namespace AVA
{
    class PlayAudioEvent : Dispatchable<PlayAudioEvent>
    {
        public List<ISound> Sounds;

        public PlayAudioEvent(List<ISound> sounds) {
            Sounds = sounds;
            Dispatch(this);
        }
    }

    class QueueAudioEvent : Dispatchable<QueueAudioEvent>
    {
        public List<ISound> Sounds;

        public QueueAudioEvent(List<ISound> sounds)
        {
            Sounds = sounds;
            Dispatch(this);
        }
    }

    interface ISound {
        void Play();
    }

    class Silence : ISound
    {
        private readonly int delay;
        public Silence(int delay) { this.delay = delay; }
        public void Play() { Thread.Sleep(delay); }
    }

    class Effect : ISound
    {
        public static readonly Effect OK = new Effect(new SoundPlayer(VASoundResource.Properties.Resources.abinkle));
        public static readonly Effect Cancel = new Effect(new SoundPlayer(VASoundResource.Properties.Resources.glugluglug));
        public static readonly Effect Error = new Effect(new SoundPlayer(VASoundResource.Properties.Resources.echo));
        public static readonly Effect Start = new Effect(new SoundPlayer(VASoundResource.Properties.Resources.lalalaloot));
        public static readonly Effect Done = new Effect(new SoundPlayer(VASoundResource.Properties.Resources.thweem));
        public static readonly Effect Abort = new Effect(new SoundPlayer(VASoundResource.Properties.Resources.pwoon));
        public static readonly Effect Interrupt = new Effect(new SoundPlayer(VASoundResource.Properties.Resources.bedebeep));
        public static readonly Effect PowerOn = new Effect(new SoundPlayer(VASoundResource.Properties.Resources.grrrrrr), false);
        public static readonly Effect Initalised = new Effect(new SoundPlayer(VASoundResource.Properties.Resources.onetwothreefive), false);

        private readonly bool sync;
        private readonly SoundPlayer sound;
        public Effect(SoundPlayer sound, bool sync = true)
        {
            this.sound = sound;
            this.sync = sync;
        }

        public void Play()
        {
            if (sync) { sound.PlaySync(); } else { sound.Play(); }
        }
    }

    class Phrase : ISound
    {
        public static Dictionary<string, string> replacements = Properties.StandardReplacements;
        private readonly string prose;

        public Phrase(string prose) {
            foreach (KeyValuePair<string, string> entry in replacements)
            {
                prose = Regex.Replace(prose, entry.Key, entry.Value);
            }
            this.prose = prose;
        }

        public void Play() { EDDI.Proxy.Speak(prose); }
    }

    class Audio : 
        IMonitor<InitPluginEvent>, 
        IMonitor<PlayAudioEvent>, 
        IMonitor<QueueAudioEvent>, 
        IMonitor<StopCommandEvent>, 
        IMonitor<ExitPluginEvent>
    {
        private bool stopped;
        private BlockingCollection<ISound> queue = new BlockingCollection<ISound>();

        public Audio()
        {
            Dispatcher<InitPluginEvent>.Instance.Add(this);
            Dispatcher<PlayAudioEvent>.Instance.Add(this);
            Dispatcher<QueueAudioEvent>.Instance.Add(this);
            Dispatcher<StopCommandEvent>.Instance.Add(this);
            Dispatcher<ExitPluginEvent>.Instance.Add(this);
        }

        public void Handle(InitPluginEvent _) { Listen(); }
        public void Handle(PlayAudioEvent e) { Play(e.Sounds); }
        public void Handle(QueueAudioEvent e) { Queue(e.Sounds); }
        public void Handle(StopCommandEvent _) { Interrupt(); }
        public void Handle(ExitPluginEvent _) { Done(); }

        private void Listen()
        {
            if (stopped) return;
            Task.Run(() => { while (!stopped) { queue.Take().Play(); } });
        }

        private void Queue(List<ISound> sounds)
        {
            foreach (ISound sound in sounds) queue.Add(sound);
        }

        private void Play(List<ISound> sounds)
        {
            if (Interrupt()) sounds.Insert(0, Effect.Interrupt);
            Queue(sounds);
        }

        private bool Interrupt()
        {
            bool pending = queue.Count > 1;
            while (queue.TryTake(out _)) { }
            return pending || EDDI.Proxy.Shutup();
        }

        private void Done()
        {
            stopped = true;
            queue.CompleteAdding();
            
            Interrupt();
        }

        public static PlayAudioEvent PlaySounds(List<ISound> sounds) { return new PlayAudioEvent(sounds); }
        public static QueueAudioEvent QueueSounds(List<ISound> sounds) { return new QueueAudioEvent(sounds); }

        public static Phrase Say(string phrase) { return new Phrase(phrase); }
        public static Silence Pause(int delay) { return new Silence(delay); }
    }
}
