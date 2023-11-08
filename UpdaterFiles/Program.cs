// See https://aka.ms/new-console-template for more information

using UpdaterFiles;

Console.WriteLine("Hello, World!");



string db = "C:\\Shared\\_04_Dev\\dbSergio.json";

Migrator myMigraor = new Migrator((IGetterInfoFiles)new JsonReaderDB(db));


myMigraor.CopyFiles();


Console.ReadLine();