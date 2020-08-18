using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;

namespace TextParser.Test
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Обычный тест
        /// </summary>
        [TestMethod]
        public void OrdinaryTest()
        {
            var stream = Parser.GetStream((Path.Combine(Environment.CurrentDirectory, "Тестовый файл.txt")));

            var solverResult = Parser.TextParse(stream);
            string[] result = new string[] {"2017-05-23 12:27:34.2011 37041_1212_1",
                                            "2017-05-23 12:27:57.2858 37041_1284_1",
                                            "2017-05-23 12:28:21.7686 37041_1337_1" };
            for(int i = 0; i< result.Length; i++)
            {
                Assert.AreEqual(solverResult[i], result[i]);
            }
        }

        /// <summary>
        /// Тестовый файл не содержит необходимых данных
        /// </summary>
        [TestMethod]
        public void EmptyTest()
        {
            var stream = Parser.GetStream((Path.Combine(Environment.CurrentDirectory, "Тестовый файл 2.txt")));

            var solverResult = Parser.TextParse(stream);
            string[] result = new string[] { };
            
                Assert.AreEqual(solverResult.Length, result.Length);
            
        }
    }
}
