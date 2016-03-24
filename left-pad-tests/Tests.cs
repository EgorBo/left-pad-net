using System;
using System.Threading.Tasks;
using Xunit;
using left_pad;

namespace left_pad_tests
{
    public class Tests
    {
        [Fact]
        public void LeftPadWorks()
        {
            Assert.Equal("0001", "1".LeftPad('0', 4));
            Assert.Equal("0001", "0001".LeftPad('1', 4));
            Assert.Equal("01 1", "1 1".LeftPad('0', 4));
            Assert.Equal("0000", "".LeftPad('0', 4));
            Assert.Equal("123", "123".LeftPad('0', 2));
            Assert.Throws<InvalidOperationException>(() => "123".LeftPad('0', -1));
        }

        [Fact]
        public async Task LeftPadAsyncAlsoWorks()
        {
            Assert.Equal("0001", await "1".LeftPadAsync('0', 4));
            Assert.Equal("01 1", await "1 1".LeftPadAsync('0', 4));
            Assert.Equal("0001", await "0001".LeftPadAsync('1', 4));
            Assert.Equal("0000", await "".LeftPadAsync('0', 4));
            Assert.Equal("123", await "123".LeftPadAsync('0', 2));
        }
    }
}
