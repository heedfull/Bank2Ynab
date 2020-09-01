using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Csv;

namespace Bank2Ynab
{
    class Program
    {
        private static string inputFile;
        private static string outputFile;

        static void Main(string[] args)
        {
            inputFile = args[0];
            outputFile = args[1];

            var csv = File.ReadAllText(inputFile);
            var output = CsvReader.ReadFromText(csv)
                .Select(csvLine => new[]
                {
                    csvLine[1],
                    csvLine[" Description1"],
                    csvLine[" Debit Amount"],
                    csvLine[" Credit Amount"]
                }).ToList();

            var outputWriter = new StreamWriter(outputFile);
            var headers = new[]{"Date","Payee","Outflow","Inflow"};
            CsvWriter.Write(outputWriter,headers,output);
            outputWriter.Flush();
        }
    }
}
