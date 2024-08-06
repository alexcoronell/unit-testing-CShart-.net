using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulation.Tests
{
    public class StringOperationsTest
    {
        [Fact]
        public void ConcatenateStrings()
        {
            var strOperarrions = new StringOperations();

            var result = strOperarrions.ConcatenateStrings("Hello", "Platzi");
            Console.WriteLine(result);
            Assert.Equal("Hello Platzi", result);
        }
    }
}
