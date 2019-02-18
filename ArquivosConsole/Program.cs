using System;
using System.Globalization;
using System.IO;
using ArquivosConsole.Entities;

namespace ArquivosConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file full path: ");
            string sourcePath = Console.ReadLine();

            try
            {
                string[] lines = File.ReadAllLines(sourcePath);

                string targetFolderPath = Path.GetDirectoryName(sourcePath) + @"\out";
                string targetFilePath = targetFolderPath + @"\summary.csv";

                Directory.CreateDirectory(targetFolderPath);

                using (StreamWriter sw = File.AppendText(targetFilePath))
                {
                    foreach (string s in lines)
                    {
                        string[] line = s.Split(',');
                        string name = line[0];
                        double price = double.Parse(line[1], CultureInfo.InvariantCulture);
                        int qtt = int.Parse(line[2]);

                        Product product = new Product(name, price, qtt);

                        sw.WriteLine(product.Name + "," + product.Subtotal().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }
            catch(IOException e)
            {
                Console.WriteLine("An error occurred:");
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
