using ConsoleApp1;
using ConsoleApp1.Logging;

try
{
    var logger1 = new Logger(new Backuper());
    var logger2 = new Logger(new Backuper());

    await new Starter(logger1, logger2).Start();
}
catch(Exception ex)
{
    Console.WriteLine(ex.ToString());
}