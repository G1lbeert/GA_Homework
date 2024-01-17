using System.Text.Json;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ProPatria_GergoAmbrus_HomeWork;

public class Tests
{

    private string _breedUrl = "https://catfact.ninja/breeds";
    private string _factsUrl = "https://catfact.ninja/facts";
    private RestClient _restClient;
    private RestRequest _restRequest;
    Keywords keyword = new Keywords();

    public Tests()
    {
        _restClient = new RestClient();
        _restRequest = new RestRequest();
    }

    [Test]
    public void IsGetRequestSuccessful()
    {
        _restRequest.Resource = _breedUrl;
        var response = _restClient.Get(_restRequest);
        _restRequest.AddHeader("Accept", "application/json");
        
        Console.WriteLine(response.StatusCode);
        Assert.That(response.IsSuccessStatusCode, Is.True);
    }

    [Test]
    public void FindBreedsAmountOnOnePage()
    {
        _restRequest.Resource = _breedUrl;
        var response = _restClient.Get(_restRequest);
        _restRequest.AddHeader("Accept", "application/json");

        var testData = keyword.Deserialise(response);
        List<string> breedsList = new List<string>();
        
        keyword.CollectBreeds(testData, breedsList);
        
        Assert.That(testData.to, Is.EqualTo(breedsList.Count));
    }

    [Test]
    public void FindTotalNumberOfBreeds()
    {
        int breedsFound = 0;
        int currentPage = 1;
        TestDataModel testData;
        
        do
        {
            string apiUrl = $"https://catfact.ninja/breeds?page={currentPage}";
            _restRequest.Resource = apiUrl;
            var response = _restClient.Get(_restRequest);
            testData = keyword.Deserialise(response);
            breedsFound += testData?.data?.Count ?? 0;
            currentPage++;

        } while (currentPage <= testData.last_page);
        
        
        Assert.That(testData.total, Is.EqualTo(breedsFound));
        
    }
    
    [Test]
    public void FindWantedBreed()
    {
        
    }
    
}