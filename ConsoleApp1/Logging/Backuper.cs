using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Logging
{
    internal class Backuper : IBackuper
    {
        public async Task WriteLogAsync()
        {
            await FileService.CopyAllFilesInDirectoryAsync();
        }
    }
}
