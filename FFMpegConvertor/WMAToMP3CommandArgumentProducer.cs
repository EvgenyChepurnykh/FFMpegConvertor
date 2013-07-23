using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpegConvertor
{
    public class WMAToMP3CommandArgumentProducer : AbstractCommandArgumentsProducer
    {
        private readonly string _bitrate;

        /// <summary>
        /// .ctor for WMAToMP3CommandArgumentProducer
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="bitrate">Bitrate would be 128k, 256k...</param>
        public WMAToMP3CommandArgumentProducer(string filename, string bitrate = null) : base(filename)
        {
            _bitrate = bitrate;
        }

        protected override string OutputExtension
        {
            get { return "mp3"; }
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
