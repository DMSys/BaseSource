using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Hydra.Win.ExtensionScript.IO
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class FileReaderScript
    {
        private List<StreamReader> _Connections = null;

        public FileReaderScript()
        {
            _Connections = new List<StreamReader>();    
        }

        /*
        public string Open(string path, Encoding encoding)
        {
            //_SReader = new StreamReader(path, encoding);
            //_SReader.EndOfStream
            return "test 123";
        }
        */
        public int Open(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            _Connections.Add(reader);
            return (_Connections.Count - 1);
        }
        
        public string ReadLine(int connectionId)
        {
            return _Connections[connectionId].ReadLine();
        }
        public bool EndOfFile(int connectionId)
        {
            return _Connections[connectionId].EndOfStream;
        }

        public void Close(int connectionId)
        {
            _Connections[connectionId].Close();
            _Connections[connectionId].Dispose();
            _Connections[connectionId] = null;
        }
    }
}
