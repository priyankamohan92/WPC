// CrimeReportingServiceTests.cs
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class CrimeReportingServiceTests
{
    private CrimeReportingService _crimeReportingService;

    [SetUp]
    public void Setup()
    {
        var httpClient = new HttpClient();
        _crimeReportingService = new CrimeReportingService(httpClient);
    }

    [Test]
    public async Task ReportCrime_ValidInput_ReturnsApiResponse()
    {
        // Arrange
        double latitude = 51.509865;
        double longitude = -0.118092;
        string crimeType = "violent-crime";

        // Act
        var result = await _crimeReportingService.ReportCrime(latitude, longitude, crimeType);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsFalse(result.Contains("Error")); // Check for potential errors
    }

    [Test]
    public async Task ReportCrime_InvalidInput_ReturnsErrorMessage()
    {
        // Arrange
        double invalidLatitude = 91.0; // Latitude should be between -90 and 90
        double invalidLongitude = -181.0; // Longitude should be between -180 and 180
        string crimeType = "violent-crime";

        // Act
        var result = await _crimeReportingService.ReportCrime(invalidLatitude, invalidLongitude, crimeType);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Contains("Error")); // Check for potential errors
    }
}


////////////////////////////////////////////////////////////////////////////////////////////
//		Include necessary NuGet packages:
//		Make sure you have the necessary NuGet packages installed for NUnit and NUnit3TestAdapter.
//		Install-Package NUnit -Version 3.13.1
//		Install-Package NUnit3TestAdapter -Version 3.17.0
//		dotnet list package
////////////////////////////////////////////////////////////////////////////////////////////
