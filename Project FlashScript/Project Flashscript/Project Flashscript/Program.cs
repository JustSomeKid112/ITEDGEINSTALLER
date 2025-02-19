
using System;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json.Linq;


/*public class Links
{
    public string adobeLink { get; set; }
    public string googleLink { get; set; }
    public string zipLink { get; set; }
    public string lastUpdated { get; set; }
    public string numLink { get; set; }

    public string link1 { get; set; }


}*/

class MainClass
{

    static void Main()
    {
        //Download the Links File

        if (Directory.Exists(@"C:\itedge")==false)
        {
            Directory.CreateDirectory(@"C:\itedge");
        }

        WebClient wc = new WebClient();
        wc.DownloadFile(@"https://raw.githubusercontent.com/JustSomeKid112/ITEDGEINSTALLER/main/Links.json", @"C:\itedge\Links.json");



        // Path to your JSON file
        string filePath = @"C:\itedge\Links.json";

        // Read the content of the JSON file
        string jsonContent = File.ReadAllText(filePath);

        // Parse the JSON content
        JObject jsonObject = JObject.Parse(jsonContent);

        // Get the value for "link1"
        string link1Value = jsonObject["1"]?.ToString();

        Console.WriteLine(link1Value);

        int i = 1;
        int linkNumber;

        string linkNumberString = jsonObject["numLink"].ToString();
        //Console.WriteLine(linkNumberString);

        if (linkNumberString != null)
        {
            linkNumber = Int32.Parse(linkNumberString);




            for (i = 1; i <= linkNumber; i++)
            {




                string downloadNow = jsonObject[$"{i}"]?.ToString();
                Console.WriteLine(downloadNow);


                

                Console.WriteLine(i);

                wc.DownloadFile($@"{downloadNow}", @$"C:\itedge\{i}.exe");

                if (i > 3)
                {
                    ProcessStartInfo myInstaller = new ProcessStartInfo();
                    string myInputFile = $@"C:\itedge\{i}.exe";
                    myInstaller.FileName = myInputFile;
                    Process.Start(myInstaller);
                    Console.WriteLine("DONE!");
                }


            }


            //Run the big three
            ProcessStartInfo installer = new ProcessStartInfo();
            //Chrome:
            Console.WriteLine("Installing Chrome.");
            string inputFile = @"C:\itedge\2.exe";
            installer.Arguments = "/silent /install";
            installer.FileName = inputFile;
            Process.Start(installer);
            Console.WriteLine("DONE!");


            //7ZIP:
            inputFile = @"C:\itedge\1.exe";
            installer.Arguments = "/S";
            installer.FileName = inputFile;
            Process.Start(installer);
            Console.WriteLine("Installing 7ZIP");
            Console.WriteLine("DONE!");

            //Adobe
            inputFile = @"C:\itedge\3.exe";
            Console.WriteLine("Installing Adobe.");
            installer.Arguments = "/Sall";
            installer.FileName = inputFile;
            Process.Start(installer);
            Console.WriteLine("DONE!");



        }






        /* Check if "link1" exists and print the value
        if (link1Value != null)
        {
            Console.WriteLine($"The value of 'link1' is: {link1Value}");
        }
        else
        {
            Console.WriteLine("'link1' not found in the JSON file.");
        }*/





    }



}

