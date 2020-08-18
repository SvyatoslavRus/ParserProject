using System;
using System.IO;

namespace TextParser
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string path = (Path.Combine(Environment.CurrentDirectory, "EventService.log"));  // Файлы с заданием и результатом лежат рабочем каталоге проекта

            string[] result = Parser.TextParse(Parser.GetStream(path));
           
            File.WriteAllLines(Path.Combine(Environment.CurrentDirectory, "Solve.log"), result);
        }
    }
}
