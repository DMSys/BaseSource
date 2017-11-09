using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hydra.Win.ExtensionScript
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class ConsoleScript
    {
        public void Log(string message)
        {
            ConsoleEventArgs arg = new ConsoleEventArgs()
            {
                Message = message
            };
            OnConsoleLog(arg);
        }

        public void Info(string message)
        {
            ConsoleEventArgs arg = new ConsoleEventArgs()
            {
                Message = message
            };
            OnConsoleInfo(arg);
        }

        public void Warn(string message)
        {
            ConsoleEventArgs arg = new ConsoleEventArgs()
            {
                Message = message
            };
            OnConsoleWarn(arg);
        }

        public void Debug(string message)
        {
            ConsoleEventArgs arg = new ConsoleEventArgs()
            {
                Message = message
            };
            OnConsoleDebug(arg);
        }

        public void Error(string message)
        {
            ConsoleEventArgs arg = new ConsoleEventArgs()
            {
                Message = message
            };
            OnConsoleError(arg);
        }

        #region Events

        public event ConsoleEventHandler ConsoleLog;
        protected virtual void OnConsoleLog(ConsoleEventArgs e)
        {
            if (ConsoleLog != null)
            { ConsoleLog(this, e); }
        }

        public event ConsoleEventHandler ConsoleInfo;
        protected virtual void OnConsoleInfo(ConsoleEventArgs e)
        {
            if (ConsoleInfo != null)
            { ConsoleInfo(this, e); }
        }

        public event ConsoleEventHandler ConsoleWarn;
        protected virtual void OnConsoleWarn(ConsoleEventArgs e)
        {
            if (ConsoleWarn != null)
            { ConsoleWarn(this, e); }
        }

        public event ConsoleEventHandler ConsoleDebug;
        protected virtual void OnConsoleDebug(ConsoleEventArgs e)
        {
            if (ConsoleDebug != null)
            { ConsoleDebug(this, e); }
        }

        public event ConsoleEventHandler ConsoleError;
        protected virtual void OnConsoleError(ConsoleEventArgs e)
        {
            if (ConsoleError != null)
            { ConsoleError(this, e); }
        }

        #endregion Events
    }

    public delegate void ConsoleEventHandler(object sender, ConsoleEventArgs e);
    
    public class ConsoleEventArgs
    {
        public string Message { get; set; }
    }
}
