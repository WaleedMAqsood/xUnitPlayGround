using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;
using Xunit.Abstractions;
using ConstructerAndDipose;

namespace ConstructerAndDipose
{
    // Constructer and Dispose: Shared setup/cleanup code without sharing object instances
    // xUnit.net creates a new instance of the test class for every test
    // Any Code placed in the constructer of this test will run for every single test (New instance for every Test).
    // Use this when a clean test context is needed for every Test
    // Implement IDisposable Interface in your Test Class and put the cleanup code in the Dispose method
    // Xunit will Clean up after every test by calling the Dispose method after every test

    public class SimpleReverseServiceTest : IDisposable
    {
        private readonly SimpleReverseService _simpleReverseService;
        private readonly ITestOutputHelper _testOutputHelper;
        public SimpleReverseServiceTest(ITestOutputHelper testOutputHelper)
        {
            _simpleReverseService = new SimpleReverseService();
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [ClassData(typeof(TestDataSimpleReverse))]
        public void SimpleReverseMethod_ShouldReverseString(string expected, string valueToReverse)
        {

            var actual = _simpleReverseService.SimpleReverse(valueToReverse);

            Assert.True(string.Equals(expected, actual, StringComparison.CurrentCultureIgnoreCase));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void SimpleReverseMethod_ShouldFailWhenInputIsEmptyOrWhiteSpace(string valuesToTest)
        {
            const string INPUT = "input";

            Action actual = () => _simpleReverseService.SimpleReverse(valuesToTest);

            Assert.Throws<ArgumentNullException>(INPUT, actual);
        }

        [Fact]
        public void SimpleReverseMethod_ShouldFailWhenInputIsSpecialCharacters()
        {
            const string INPUT = "input";
            string valueToTest = "$#%^&*()&^%";

            Action actual = () => _simpleReverseService.SimpleReverse(valueToTest);

            Assert.Throws<ArgumentException>(INPUT, actual);
        }

        [Fact]
        public void SimpleReverseMethod_ShouldFailWhenInputIsNotEqual()
        {
            string value = "Reverse this word";
            string valueToReverse = "It did not reverse";

            var actual = _simpleReverseService.SimpleReverse(valueToReverse);

            Assert.False(string.Equals(value, valueToReverse, StringComparison.CurrentCultureIgnoreCase));
        }

        public void Dispose()
        {
            // CleanUp Dispose after Every Test
        }
    }

    //For Complex Test Data
    public class TestDataSimpleReverse : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Non xUnit Topic (Yield): A method with Yield in it is rebuilt by compiler as a 
            // state-machine class that implements IEnumerble and IEnumerator. Depending on the method
            // signature compiler will create code that will return IEnumerable or already initialized IEnumerator
            yield return new object[] { "This is a Test", "Test a is This" };
            yield return new object[] { "This is another Test", "Test another is This" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
