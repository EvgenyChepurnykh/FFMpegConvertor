using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFMpegConvertor;

namespace TestFFMpegConvertor
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathToMP3 = "C:\\Mp3\\BigGun.mp3";
            var newPath = "C:\\Output\\";
            var commandArgumentsProducer = new MP3ToWMACommandArgumentProducer(pathToMP3, newPath, "256k");
            var converter = new Converter(commandArgumentsProducer);
            converter.Convert();
        }
    }
}
