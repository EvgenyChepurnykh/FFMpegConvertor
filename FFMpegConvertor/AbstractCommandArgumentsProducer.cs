using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFMpegConvertor.Interfaces;

namespace FFMpegConvertor
{
    public abstract class AbstractCommandArgumentsProducer : ICommandArgumentsProducer
    {
        private readonly string _fileName;
        private readonly string _pathToOutputFolder;

        protected abstract string OutputExtension { get; }

        protected AbstractCommandArgumentsProducer(string filename, string pathToOutputFolder)
        {
            _fileName = filename;
            _pathToOutputFolder = pathToOutputFolder;
        }

        public string Create()
        {
            return " -i " + _fileName + " " + GetOutputFileOptions()+ " " + GetOutputFileName();
        }

        private string GetFileNameWithoutExtension()
        {
            var indexOfDot = _fileName.LastIndexOf('.');
            var filenameWithoutExtensionIndex = indexOfDot != -1 ? indexOfDot : _fileName.Length - 1;
            var indexOfFolder = _fileName.LastIndexOf('\\');
            var shortFileName = indexOfFolder == -1 ? _fileName.Substring(0, filenameWithoutExtensionIndex) 
                                                : _fileName.Substring(indexOfFolder + 1, filenameWithoutExtensionIndex - indexOfFolder - 1);
            if (!string.IsNullOrEmpty(_pathToOutputFolder))
            {
                return _pathToOutputFolder + shortFileName;
            }
            return _fileName.Substring(0, filenameWithoutExtensionIndex);
        }

        private string GetOutputFileName()
        {
            return GetFileNameWithoutExtension()+'.'+ OutputExtension;
        }

        public abstract string GetOutputFileOptions();
    }
}
