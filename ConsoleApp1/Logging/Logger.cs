using ConsoleApp1;
using System.Configuration;

namespace ConsoleApp1.Logging
{
    internal class Logger : ILogger
    {
        private static int rubbishCounter = 1;
        private IBackuper _backuper;
        public event Func<ILogger, Task> BackupIsNeeded;
        public Logger(IBackuper backuper)
        {
            _backuper = backuper ?? throw new ArgumentNullException($"The {nameof(backuper)} is null");
        }
        public async Task OnBackupIsNeeded()
        {
            await this.BackupIsNeeded?.Invoke(this);
        }
        public async Task WriteLogAsync(bool makeBackup)
        {
            await FileService.WriteTextAsync($"Some log {rubbishCounter++}");
            if (makeBackup)
            {
                await _backuper.WriteLogAsync();
            }
        }
    }
}
