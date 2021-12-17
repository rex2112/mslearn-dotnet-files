using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");

var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
// Directory.CreateDirectory(salesTotalDir);
// File.WriteAllText(Path.Combine(salesTotalDir, "totals.txt"), String.Empty);

var salesFiles = FindFiles(storesDirectory);

var salesTotal = CalculateSalesTotal(salesFiles);


foreach (var file in salesFiles)
{
    var salesJson = File.ReadAllText(file);
    var data = JsonConvert.DeserializeObject<salesTotalClass>(salesJson);
    Console.WriteLine($"{file}: {data.Total}");
    // File.AppendAllText(Path.Combine(salesTotalDir, "totals.txt"), $"{file}: {data.Total}{Environment.NewLine}");

}

System.Console.WriteLine();
System.Console.WriteLine($"Total Sales: {salesTotal}");
// File.AppendAllText(Path.Combine(salesTotalDir, "totals.txt"), $"Total Sales: {salesTotal}{Environment.NewLine}");


// string fileName = $"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales{Path.DirectorySeparatorChar}sales.json";
// Console.WriteLine(fileName);
// FileInfo info = new FileInfo(fileName);
// Console.WriteLine($"Full Name: {info.FullName}{Environment.NewLine}Directory: {info.Directory}{Environment.NewLine}Extension: {info.Extension}{Environment.NewLine}Create Date: {info.CreationTime}"); // And many more
// ----------- END OF MAIN ------------

// FindFiles method
IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        // The file name will contain the full path, so only check the end of it
        var extension = Path.GetExtension(file);
        if (extension == ".json")
        {
            salesFiles.Add(file);
        }
    }

    return salesFiles;
}

static double CalculateSalesTotal(IEnumerable<string> salesFiles)
{
    double salesTotal = 0;

    // READ FILES LOOP
    foreach (var file in salesFiles)
    {
        // Read the contents of the file
        string salesJson = File.ReadAllText(file);

        // Parse the contents as JSON
        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);

        // Add the amount found in the Total field to the salesTotal variable
        salesTotal += data?.Total ?? 0;        
    }

    return salesTotal;
}

class salesTotalClass 
{
    public double Total { get; set; }
}
record SalesData (double Total);

