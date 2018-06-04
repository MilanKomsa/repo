using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESProjekat.Test
{
    [TestFixture]
    public class LoggerTest
    {
        [Test]
        public void Logger_Upisi()
        {
            //Arange
            Logger _logger = new Logger();
            string expected = "string";
            string actual;
            File.Delete(_logger.File);

            //Act
            _logger.Upisi(expected);

            //Post act arange
            using (StreamReader sr = new StreamReader(_logger.File))
            {
                // Read the stream to a string, and write the string to the console.
                actual = sr.ReadLine();
            }

            //Assert
            Assert.AreEqual(expected, actual);

            //Post assert cleanup
            File.Delete(_logger.File);
        }
    }
}
