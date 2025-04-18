using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static async Task Main(string[] args)
    {
        string URL = "http://raw.githubusercontent.com/l3oxer/Doggo/main/README.md";

        Stopwatch sw = new Stopwatch();
        sw.Start();
        var tasks = new List<Task> {SummonPreguica(),SummonPreguicaURL(URL)};
        await Task.WhenAll(tasks);
        sw.Stop();

        Console.WriteLine("We are "+sw.Elapsed.TotalSeconds);

    }

    static async Task SummonPreguica()
    {
        Console.WriteLine("Eu convoco a preguiça...");
        string preguicaText = await File.ReadAllTextAsync("Preguica.txt");
        Console.WriteLine($"{preguicaText}");
    }

    static async Task SummonPreguicaURL(string URL)    
    {
        Console.WriteLine("Eu convoco url...");
        using(var httpClient = new HttpClient())
        {
            string result = await httpClient.GetStringAsync(URL);
            Console.WriteLine($"{result}"); 
        }
    }
}