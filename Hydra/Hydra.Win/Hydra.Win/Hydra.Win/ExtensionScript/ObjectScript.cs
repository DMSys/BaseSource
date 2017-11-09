using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hydra.Win.ExtensionScript
{
    /// <summary>
    /// Скрипт разширяване приложенията стартирани в Hydra
    /// </summary>
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class ObjectScript
    {
        private SystemScript _System = null;
        public SystemScript System
        {
            get
            {
                if (_System == null)
                { _System = new SystemScript(); }
                return _System;
            }
        }

        private IOScript _IO = null;
        public IOScript IO
        {
            get
            {
                if (_IO == null)
                { _IO = new IOScript(); }
                return _IO;
            }
        }

        private DataScript _Data = null;
        /// <summary>
        /// Връзка с базата данни
        /// </summary>
        public DataScript Data
        {
            get
            {
                if (_Data == null)
                { _Data = new DataScript(); }
                return _Data;
            }
        }

        private ConsoleScript _Console = null;
        /// <summary>
        /// Принтира съобщения в конзолата
        /// </summary>
        public ConsoleScript Console
        {
            get
            {
                if (_Console == null)
                { _Console = new ConsoleScript(); }
                return _Console;
            }
        }

        private WebAppScript _WebApp = null;
        /// <summary>
        /// Приложението стартирано Hydra
        /// </summary>
        public WebAppScript WebApp
        {
            get
            {
                if (_WebApp == null)
                { _WebApp = new WebAppScript(); }
                return _WebApp;
            }
        }
        
        private SessionScript _Session = null;
        /// <summary>
        /// Сесия
        /// </summary>
        public SessionScript Session
        {
            get
            {
                if (_Session == null)
                { _Session = new SessionScript(); }
                return _Session;
            }
        }
    }
}
