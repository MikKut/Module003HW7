using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Logging
{
    internal interface ILogger
    {
        event Func<ILogger, Task> BackupIsNeeded;
        public Task WriteLogAsync(bool makeBackup);
        public Task OnBackupIsNeeded();
    }
}
