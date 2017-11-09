using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Hydra.Win.ExtensionScript.IO
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class FileWriterScript
    {
        private List<StreamWriter> _Connections = null;

        public FileWriterScript()
        {
            _Connections = new List<StreamWriter>();    
        }

        public int Open(string filePath)
        {
            StreamWriter writer = new StreamWriter(filePath);
            _Connections.Add(writer);
            return (_Connections.Count - 1);
        }

        public void Write(int connectionId, string value)
        {
            _Connections[connectionId].Write(value);
        }

        public void WriteLine(int connectionId, string value)
        {
            _Connections[connectionId].WriteLine(value);
        }

        public void Flush(int connectionId)
        {
            _Connections[connectionId].Flush();
        }

        public void Close(int connectionId)
        {
            _Connections[connectionId].Close();
            _Connections[connectionId].Dispose();
            _Connections[connectionId] = null;
        }
    }
}
