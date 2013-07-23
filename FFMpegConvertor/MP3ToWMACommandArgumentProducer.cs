namespace FFMpegConvertor
{
    public class MP3ToWMACommandArgumentProducer : AbstractCommandArgumentsProducer
    {
        private readonly string _bitrate;

        /// <summary>
        /// .ctor for MP3ToWMACommandArgumentProducer
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="bitrate">Bitrate would be 128k, 256k...</param>

        public MP3ToWMACommandArgumentProducer(string filename, string bitrate = null) : base(filename)
        {
            _bitrate = bitrate;
        }

        protected override string OutputExtension
        {
            get
            {
                return "wma";
            }
        }

        public override string GetOutputFileOptions()
        {
            if (string.IsNullOrEmpty(_bitrate))
            {
                return "";
            }
            return "-b:a " + _bitrate + " ";
        }
    }
}
