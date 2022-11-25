using Xunit;

namespace IcollectionFixture
{
    // Collection Fixtures: Shared object instances across multiple test classes
    // Create the fixture class and Add ICollectionFixture<> to the collection definition class
    // Add Collection attribute to the test class and use the same unique name to the test collection defination class's
    // [[CollectionDefination] attribute
    // Use this When a single test context is needed and shared among tests in several test Classes
    // This Collection will be shared between several test classes and will be cleaned up after all tests in the classes
    // For context cleanup Implement IDisposable in the fixture class and put the cleanup code in the Dispose method
    // Xunit will clean up by calling the Dispose method after all the Test Classes in the Collection have finished running

    [CollectionDefinition("Database Collection")]
    public class DataBaseCollection : ICollectionFixture<DataBaseFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

    [Collection("Database Collection")]
    public class DataBaseTests1
    {
        private readonly DataBaseFixture _databaseFixture;

        public DataBaseTests1(DataBaseFixture databaseFixture)
        {

            _databaseFixture = databaseFixture;
        }

    }

    [Collection("Database Collection")]
    public class DataBaseTests2
    {
        private readonly DataBaseFixture _dbContextFixture;

        public DataBaseTests2(DataBaseFixture databaseFixture)
        {

            _dbContextFixture = databaseFixture;
        }

    }
}
