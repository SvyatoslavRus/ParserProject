using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace TextParser
{
    public class Parser
    {
        /// <summary>
        /// Получает поток из выбранного файла
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static StreamReader GetStream(string path) => new StreamReader(path, System.Text.Encoding.Default);

        /// <summary>
        /// Преобразует поток в соответствии с задачей
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string[] TextParse(StreamReader stream)
        {
            List<string> result = new List<string>();
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {

                    Regex regex = new Regex(@"Request for(\w*)");
                    MatchCollection matches = regex.Matches(line);
                    if (matches.Count > 0)
                    {
                        Regex regexDate = new Regex("[0-9]{4}-[0-9]{2}-[0-9]{2}");
                        MatchCollection matchesDate = regexDate.Matches(line);

                        Regex regexTime = new Regex("[0-9]{2}:[0-9]{2}:[0-9]{2}.[0-9]{4}");
                        MatchCollection matchesTime = regexTime.Matches(line);

                        Regex regexValue = new Regex("[0-9]{5}_[0-9]{2,4}_[0-9]{1}");
                        MatchCollection matchesValue = regexValue.Matches(line);

                        string resultLine = matchesDate[0].ToString() + " " + matchesTime[0].ToString() + " " + matchesValue[0].ToString();
                        result.Add(resultLine);
                    }
                }
            }
            return result.ToArray();
        }
    }
}
