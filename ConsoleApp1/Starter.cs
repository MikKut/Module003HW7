using ConsoleApp1.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Starter
    {
        private int _N;
        private ILogger _logger1;
        private ILogger _logger2;
        public Starter(ILogger logger1, ILogger logger2)
        {
            _N = GetN();
            _logger1 = logger1 ?? throw new Exception($"The {nameof(logger2)} is null");
            _logger2 = logger2 ?? throw new Exception($"The {nameof(logger2)} is null");
            _logger1.BackupIsNeeded += WrireLogWithBackup;
            _logger2.BackupIsNeeded += WrireLogWithBackup;
        }

        public async Task Start()
        {
            await CreateLogRecords(_logger1, _N);
            _N *= 2;
            await CreateLogRecords(_logger2, _N);
        }

        private async Task CreateLogRecords(ILogger logger, int quantityOfRecords = 50)
        {
            for (int i = 1; i < quantityOfRecords; i++)
            {
                await logger.WriteLogAsync(false);
                Thread.Sleep(1000);
            }

            await logger.OnBackupIsNeeded();
            Thread.Sleep(1000);
        }

        private int GetN()
        {
            var config = ConfigurationManager.AppSettings["N"];
            int val;
            if (!int.TryParse(config, out val))
            {
                throw new Exception($"Cannot parse N from App.config");
            }

            return val;
        }

        private async Task WrireLogWithBackup(ILogger logger)
        {
            await logger.WriteLogAsync(true);
        }
    }
}
