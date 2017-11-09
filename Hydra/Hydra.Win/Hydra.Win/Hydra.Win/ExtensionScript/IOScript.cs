using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hydra.Win.ExtensionScript.IO;

namespace Hydra.Win.ExtensionScript
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class IOScript
    {
        private FileReaderScript _FileReader = null;
        public FileReaderScript FileReader
        {
            get
            {
                if (_FileReader == null)
                { _FileReader = new FileReaderScript(); }
                return _FileReader;
            }
        }

        private FileWriterScript _FileWriter = null;
        public FileWriterScript FileWriter
        {
            get
            {
                if (_FileWriter == null)
                { _FileWriter = new FileWriterScript(); }
                return _FileWriter;
            }
        }

        private PathScript _Path = null;
        public PathScript Path
        {
            get
            {
                if (_Path == null)
                { _Path = new PathScript(); }
                return _Path;
            }
        }
    }
}
