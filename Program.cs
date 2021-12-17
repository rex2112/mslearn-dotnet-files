using System.IO;
using System.Collections.Generic;

var salesFiles = FindFiles("stores");

foreach (var file in salesFiles)
{
    System.Console.WriteLine(file);
}

Console.WriteLine(Directory.GetCurrentDirectory());
System.Console.WriteLine(Environment.GetFolderPath());

// ----------- END OF MAIN ------------

// FindFiles method
IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

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
