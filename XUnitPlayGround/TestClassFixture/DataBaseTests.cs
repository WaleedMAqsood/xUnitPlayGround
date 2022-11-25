using System;
using Xunit;

namespace TestClassFixture
{
    // Class Fixtures: Shared object instance across tests in a single class
    // Create a fixture class and IClassFixture<> to the test class
    // This will let you inject the dependency in the constructer instead of having to instantiate it.
    // The injected instance will be reused for every Test in the Class
    // Use this when a single test context needs to be shared among all the Tests in the class
    // For context cleanup Implement IDisposable in the fixture class and put the cleanup code in the Dispose method
    // Xunit will Clean up the fixture object by calling Dispose after all the Tests in the class have finished running.
    // Note: xUnit uses the presence of the interface IClassFixture<> to know that you want a class fixture
    // to be created and cleaned up. It will do this whether you take the instance of the class as a
    // constructor argument or not.

    public class DataBaseTests : IClassFixture<DataBaseFixture>
    {
        private readonly DataBaseFixture _dataBaseFixture;

        public DataBaseTests(DataBaseFixture dataBaseFixture)
        {
            // The injected dependency in the constructer will be resued for every Test.
            _dataBaseFixture = dataBaseFixture;
        }

        // Tests
    }
}