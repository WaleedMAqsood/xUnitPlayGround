# xUnit-Shared-Context-between-Tests

Experimenting with xUNit to have a better understanding of sharing test context and dependencies.
Next Technologies will be
Moq
IhttpClientFactory
I have three Folders explaining each of the following:

## Constructer and Dispose: Shared setup/cleanup code without sharing object instances
- xUnit.net creates a new instance of the test class for every single test
- Any Code placed in the constructer of this test will run for every single test (New instance for every Test)
- Use this when a clean test context is required for every Test
- Implement IDisposable Interface in your Test Class and put the cleanup code in the Dispose method
- Xunit will Clean up after every test by calling the Dispose method after every test

## Class Fixtures: Shared object instance across tests in a single class
- Create a fixture class and add IClassFixture<> to the test class
- This will let you inject the dependency in the constructer instead of having to instantiate it
- The injected instance will be reused for every Test in the Class
- Use this when a single test context needs to be shared among all the Tests in the class
- For context cleanup Implement IDisposable in the fixture class and put the cleanup code in the Dispose method
- Xunit will Clean up the fixture object by calling Dispose after all the Tests in the class have finished running 
  Note: xUnit uses the presence of the interface   IClassFixture<> to know that you want a class fixture to be created and cleaned up. It will do this whether you take the instance of the class as a constructor argument or not.

## Collection Fixtures: Shared object instances across multiple test classes
- Create the fixture class and Add ICollectionFixture<> to the collection definition class
- Add the Collection attribute to the test class and use the same unique name to the test collection definition class's [CollectionDefination] attribute
- Use this When a single test context is needed and shared among tests in several test Classes
- This Collection will be shared between several test classes and will be cleaned up after all tests in the classes
- For context cleanup Implement IDisposable in the fixture class and put the cleanup code in the Dispose method
- Xunit will clean up by calling the Dispose method after all the Test Classes in the Collection have finished executing Tests
