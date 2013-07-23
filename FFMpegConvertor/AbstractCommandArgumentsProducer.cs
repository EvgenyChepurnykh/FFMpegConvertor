using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFMpegConvertor.Interfaces;

namespace FFMpegConvertor
{
    public abstract class AbstractCommandArgumentsProducer : ICommandArgumentsProducer
    {
        protected readonly string FileName;

        protected abstract string OutputExtension { get; }

        protected AbstractCommandArgumentsProducer(string filename)
        {
            FileName = filename;
        }

        public string Create()
        {
            return " -i " + FileName + " " + GetOutputFileOptions()+ " " + GetOutputFileName();
        }

        protected string GetFileNameWithoutExtension()
        {
            var indexOfDot = FileName.LastIndexOf('.');
            var filenameWithoutExtensionIndex = indexOfDot != -1 ? indexOfDot : FileName.Length - 1;
            return FileName.Substring(0, filenameWithoutExtensionIndex);
        }

        private string GetOutputFileName()
        {
            return GetFileNameWithoutExtension()+'.'+ OutputExtension;
        }

        public abstract string GetOutputFileOptions();
    }
}
