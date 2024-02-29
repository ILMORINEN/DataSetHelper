using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetHelper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pathToSequences = args[0];
            var pathToFile = args[1];
            var savePath = args.Length >= 3 ? args[2] : Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop), 
                "DSHelper " + DateTime.Now.ToString("HH-mm-ss"));

            var saveDirectory = Directory.CreateDirectory(savePath);

            var sequences = Directory.EnumerateDirectories(pathToSequences);

            foreach ( var sequence in sequences ) 
            {
                var oldFilePath = Directory.EnumerateFiles(Path.Combine(sequence, pathToFile)).First();
                
                var newName = sequence.Split('\\').Last() + Path.GetExtension(oldFilePath);
                var newFilePath = Path.Combine(saveDirectory.FullName, newName);
                
                File.Copy(oldFilePath, newFilePath);
            }

            Console.WriteLine("Done");
        }
    }
}
