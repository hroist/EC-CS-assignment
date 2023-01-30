using ConsoleApp.Services;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp.Tests
{
    [TestClass]
    public class FileService_Tests
    {
        [TestMethod]
        public void Should_Create_File_With_Json_Content()
        {
            // Arrange
            FileService fileService = new FileService();
            string FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\testList.json";
            string content = JsonConvert.SerializeObject(new {FirstName = "Test", LastName = "Testson", Email = "test@mail.com", PhoneNumber = "0701457889", StreetName = "Testvägen 1", PostalCode = "12345", City = "Teststaden"});

            // Act
            fileService.Save(FilePath, content);

            // Assert
            Assert.IsTrue(File.Exists(FilePath));
            Assert.IsTrue(!string.IsNullOrWhiteSpace(fileService.Read(FilePath)));
        }
    }
}