// See https://aka.ms/new-console-template for more information

using System.CommandLine;

namespace seesv;

class Program
{
    static async Task<int> Main(string[] args)
    {
        var fileOption = new Option<FileInfo?>(
            name: "--file",
            description: "The csv file to use as input.");

        var rootCommand = new RootCommand("A simple CLI for viewing and modifying CSV files.");
        rootCommand.AddOption(fileOption);
        
        rootCommand.SetHandler((file) =>
            {
                ReadFile(file!);
            },
            fileOption);

        return await rootCommand.InvokeAsync(args);
    }

    static void ReadFile(FileInfo file)
    {
        File.ReadLines(file.FullName).ToList()
            .ForEach(line => Console.WriteLine(line));
    }
}