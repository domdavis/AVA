using EddiSpeechService;

namespace AVA.EDDI
{
    class Proxy
    {
        public static void Speak(string phrase, int echo = 100, int distortion = 0, int effects = 40, int compression = 0)
        {
            int chorus = (int)(effects * 0.6);
            int reverb = (int)(effects * 0.8);
            SpeechService.Instance.Speak(phrase, null, echo, distortion, chorus, reverb, compression);
        }

        public static bool Shutup()
        {
            bool speaking = SpeechService.eddiSpeaking;
            SpeechService.Instance.ShutUp();
            return speaking;
        }
    }
}
