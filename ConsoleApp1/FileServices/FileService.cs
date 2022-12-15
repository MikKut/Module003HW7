using ConsoleApp1.FileServices;
using System.Text;

namespace ConsoleApp1
{
    public static class FileService
    {
        static FileService()
        {
            if (!Directory.Exists(LogPathCreator.PathToTheLogs))
            {
                Directory.CreateDirectory(LogPathCreator.PathToTheLogs);
            }

            if (!Directory.Exists(LogPathCreator.PathToTheBackups))
            {
                Directory.CreateDirectory(LogPathCreator.PathToTheBackups);
            }
        }

        public static async Task CopyAllFilesInDirectoryAsync()
        {
            DirectoryInfo StartDirectory = new DirectoryInfo(LogPathCreator.PathToTheLogs);
            DirectoryInfo EndDirectory = new DirectoryInfo(LogPathCreator.PathToTheBackups);

                foreach (FileInfo file in StartDirectory.EnumerateFiles())
                {
                    string outputPath = EndDirectory.FullName;
                    using (FileStream SourceStream = file.OpenRead())
                    {
                        using (FileStream DestinationStream = File.Create(outputPath + "\\" + file.Name))
                        {
                            await SourceStream.CopyToAsync(DestinationStream);
                        }
                    }
                }
        }
        public static async Task WriteTextAsync(string text)
        {
            using (FileStream sourceStream = new FileStream(LogPathCreator.GetPathToTheLogWithTheName(DateTime.Now.ToString("hh.mm.ss dd.MM.yyyy")),
                FileMode.OpenOrCreate, FileAccess.Write, FileShare.None,
                bufferSize: 4096, useAsync: true))
            {
                byte[] encodedText = Encoding.Unicode.GetBytes(text);
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            };
        }
    }
}
