using System;
using System.Diagnostics;
using System.Threading.Tasks;
using FFMpegConvertor.Interfaces;

namespace FFMpegConvertor
{
    public class Converter : IConverter
    {
        private const string FFMPEG = "ffmpeg.exe";

        private readonly ICommandArgumentsProducer _commandArgumentsProducer;

        public Converter(ICommandArgumentsProducer producer)
        {
            _commandArgumentsProducer = producer;
        }

        public void Convert()
        {
            try
            {
                RunFFMpegProcess(_commandArgumentsProducer.Create());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public Task ConvertAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    RunFFMpegProcess(_commandArgumentsProducer.Create());
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            });
        }

        private static void RunFFMpegProcess(string arguments)
        {
            var startupProcessInfo = new ProcessStartInfo(FFMPEG);
            startupProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startupProcessInfo.Arguments = arguments;
            Process.Start(startupProcessInfo);
        }
    }
}
