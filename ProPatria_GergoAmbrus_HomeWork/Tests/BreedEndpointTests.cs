using System.Net;
using ProPatria_GergoAmbrus_HomeWork.TestData;
using RestSharp;
using static NUnit.Framework.Assert;

namespace ProPatria_GergoAmbrus_HomeWork.Tests;

public class BreedEndpointTests
{

    private readonly string _breedUrl = "https://catfact.ninja/breeds";
    private readonly RestClient _restClient = new();
    private readonly RestRequest _restRequest = new();
    readonly Keywords _keyword = new Keywords();

    [Test]
    public void IsApiAccessible()
    {
        _restRequest.Resource = _breedUrl;
        var response = _restClient.Get(_restRequest);
        
        That(response.IsSuccessStatusCode, Is.True);
    }

    [Test]
    public void FindBreedsAmountOnOnePage()
    {
        _restRequest.Resource = _breedUrl;
        var response = _restClient.Get(_restRequest);

        var testData = _keyword.BreedDeserialise(response);
        List<string> breedsList = new List<string>();
        
        _keyword.CollectBreeds(testData, breedsList);
        
        That(testData.to, Is.EqualTo(breedsList.Count));
    }

    [Test]
    public void FindTotalNumberOfBreeds()
    {
        var breedsFound = 0;
        var currentPage = 1;
        TestDataBreed testData;
        
        do
        {
            string apiUrl = $"https://catfact.ninja/breeds?page={currentPage}";
            _restRequest.Resource = apiUrl;
            var response = _restClient.Get(_restRequest);
            testData = _keyword.BreedDeserialise(response);
            breedsFound += testData?.data?.Count ?? 0;
            currentPage++;

        } while (testData != null && currentPage <= testData.last_page);


        if (testData != null) That(breedsFound, Is.EqualTo(testData.total));
    }
    
    [Test]
    public void FindWantedBreed()
    {
        var wantedBreed = "Bengal";

        _restRequest.Resource = _breedUrl;
        var response = _restClient.Get(_restRequest);

        var testData = _keyword.BreedDeserialise(response);

        bool isBreedFound = testData.data.Any(breed => breed.breed == wantedBreed);
        
        That(isBreedFound, Is.True);
    }

    [Test]
    public void BadEndpointCall()
    {
        var badUrl = "https://catfact.ninja/breedz";
        _restRequest.Resource = badUrl;
        
        var response = _restClient.Get(_restRequest);
        
        That(response is { StatusCode: HttpStatusCode.NotFound }, Is.True);
    }
    
}