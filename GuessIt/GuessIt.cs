using Python.Runtime;

namespace GuessIt
{
    public class GuessIt
    {
        private readonly dynamic _matchesDict;

        public GuessIt(string rawFileName)
        {
            using (Py.GIL())
            {
                dynamic guessItModule = Py.Import("guessit");

                var guessItFunc = guessItModule.guessit;

                _matchesDict = guessItFunc(rawFileName);
            }
        }

        public string Title => GetMatch("title");

        public int? Season => GetMatch("season");

        public int? Episode => GetMatch("episode");

        public string EpisodeTitle => GetMatch("episode_title");

        public string Format => GetMatch("format");

        public string VideoCodec => GetMatch("video_codec");

        public string ReleaseGroup => GetMatch("release_group");

        public string Container => GetMatch("container");

        public string Mimetype => GetMatch("mimetype");

        public string Type => GetMatch("type");

        private dynamic GetMatch(string key)
        {
            dynamic value;

            try
            {
                value = _matchesDict[key];
            }
            catch (PythonException)
            {
                return null;
            }

            if (!PyInt.IsIntType(value)) return value;

            int result = value;

            return result;
        }
    }
}