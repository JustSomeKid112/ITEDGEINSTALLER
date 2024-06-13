
using System;
using System.Diagnostics;
using System.Net;
using System.Text.Json;


public class Links
{
    public string adobeLink { get; set; }
    public string googleLink { get; set; }
    public string zipLink { get; set; }
    public string lastUpdated { get; set; }
}

class ReadJsonFile
{

    static void Main()
    {
        //Download the Links File
        WebClient wc = new WebClient();
        wc.DownloadFile(@"https://raw.githubusercontent.com/JustSomeKid112/ITEDGEINSTALLER/main/Links.json", @"C:\itedge\Links.json");
        
        //Parse the File
        string text = File.ReadAllText(@"C:\itedge\Links.json");
        var links = JsonSerializer.Deserialize<Links>(text);

        
        
        //Change the title
        Console.Title = $"Last Updated: {links.lastUpdated} by Aiden Kwiatkowski";
        

        Console.WriteLine("Fetching JSON values.");
        
        
        //Download Chrome
        Console.WriteLine($"Downloading Google from: {links.googleLink}");
        wc.DownloadFile($"{links.googleLink}", @"C:\itedge\Chrome.exe");
        //Download 7ZIP
        Console.WriteLine($"Downloading 7ZIP from: {links.zipLink}");
        wc.DownloadFile($"{links.zipLink}", @"C:\itedge\7ZIP.exe");
        //Download Adobe
        Console.WriteLine($"Downloading Adobe from: {links.adobeLink}");
        wc.DownloadFile($"{links.adobeLink}", @"C:\itedge\Adobe.exe");


        //Run the files
        ProcessStartInfo installer = new ProcessStartInfo();
        //Chrome:
        Console.WriteLine("Installing Chrome.");
        string inputFile = @"C:\itedge\Chrome.exe";
        installer.Arguments = "/silent /install";
        installer.FileName = inputFile;
        Process.Start(installer);
        Console.WriteLine("DONE!");
        

        //7ZIP:
        inputFile = @"C:\itedge\7ZIP.exe";
        installer.Arguments = "/S";
        installer.FileName = inputFile;
        Process.Start(installer);
        Console.WriteLine("Installing 7ZIP");
        Console.WriteLine("DONE!");

        //Adobe
        Console.WriteLine("Installing Adobe");
        Process.Start(@"C:\itedge\Adobe.exe");
        


       /* Process.Start(@"C:\itedge\Chrome.exe");
        Process.Start(@"C:\itedge\7ZIP.exe");
        Process.Start(@"C:\itedge\Adobe.exe");
       */



        //Pause and Display Last Time Updated
        //Console.ReadKey();

    }



}

