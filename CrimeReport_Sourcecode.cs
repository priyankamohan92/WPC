// CrimeReportingService.cs
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class CrimeReportingService
{
    private readonly HttpClient _httpClient;
    private const string PoliceApiBaseUrl = https://data.police.uk/api/crimes-street/all-crime?lat=51.44237&lng=-2.49810&date=2021-01;

    public CrimeReportingService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<string> ReportCrime(double latitude, double longitude, string crimeType)
    {
        var apiUrl = $"{PoliceApiBaseUrl}crimes-street/all-crime?lat={latitude}&lng={longitude}&category={crimeType}";

        try
        {
            var response = await _httpClient.GetStringAsync(apiUrl);
            return response;
        }
        catch (HttpRequestException ex)
        {
            // Log or handle the exception
            return $"Error: {ex.Message}";
        }
    }
}


