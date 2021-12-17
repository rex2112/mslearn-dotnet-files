using System.IO;
using System.Collections.Generic;

var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");
var salesFiles = FindFiles(storesDirectory);


foreach (var file in salesFiles)
{
    Console.WriteLine(file);
}

// Console.WriteLine("CurrentDirectory: " + Directory.GetCurrentDirectory());
// Console.WriteLine("ApplicationData: " + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
// Console.WriteLine("MyDocuments: " + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
// Console.WriteLine("MyMusic: " + Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
// Console.WriteLine("Desktop: " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
// Console.WriteLine();
// string fileName = $"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales{Path.DirectorySeparatorChar}sales.json";
// Console.WriteLine(fileName);
// FileInfo info = new FileInfo(fileName);
// Console.WriteLine($"Full Name: {info.FullName}{Environment.NewLine}Directory: {info.Directory}{Environment.NewLine}Extension: {info.Extension}{Environment.NewLine}Create Date: {info.CreationTime}"); // And many more
// ----------- END OF MAIN ------------

// FindFiles method
IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(currentDirectory, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        // The file name will contain the full path, so only check the end of it
        if (file.EndsWith("sales.json"))
        {
            salesFiles.Add(file);
        }
    }

    return salesFiles;
}

