using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMSys.Systems.SynchronizerFile
{
    /// <summary>
    /// Тип на елемента за синхронизиране
    /// </summary>
    public enum SynchItemType { File, Directorie }

    /// <summary>
    /// Статус на елемента за синхронизиране. Причина
    /// </summary>
    public enum SynchItemStatus { New, Modified }
}
