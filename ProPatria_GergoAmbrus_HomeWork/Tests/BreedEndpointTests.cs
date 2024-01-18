using System.Net;
using RestSharp;

namespace ProPatria_GergoAmbrus_HomeWork;

public class BreedEndpointTests
{

    private readonly string _breedUrl = "https://catfact.ninja/breeds";
    private readonly RestClient _restClient;
    private readonly RestRequest _restRequest;
    readonly Keywords _keyword = new Keywords();

    public BreedEndpointTests()
    {
        _restClient = new RestClient();
        _restRequest = new RestRequest();
    }

    [Test]
    public void IsAPIAcceccible()
    {
        _restRequest.Resource = _breedUrl;
        var response = _restClient.Get(_restRequest);
        
        Assert.That(response.IsSuccessStatusCode, Is.True);
    }

    [Test]
    public void FindBreedsAmountOnOnePage()
    {
        _restRequest.Resource = _breedUrl;
        var response = _restClient.Get(_restRequest);

        var testData = _keyword.BreedDeserialise(response);
        List<string> breedsList = new List<string>();
        
        _keyword.CollectBreeds(testData, breedsList);
        
        Assert.That(testData.to, Is.EqualTo(breedsList.Count));
    }

    [Test]
    public void FindTotalNumberOfBreeds()
    {
        int breedsFound = 0;
        int currentPage = 1;
        TestDataBreed testData;
        
        do
        {
            string apiUrl = $"https://catfact.ninja/breeds?page={currentPage}";
            _restRequest.Resource = apiUrl;
            var response = _restClient.Get(_restRequest);
            testData = _keyword.BreedDeserialise(response);
            breedsFound += testData?.data?.Count ?? 0;
            currentPage++;

        } while (currentPage <= testData.last_page);
        
        
        Assert.That(testData.total, Is.EqualTo(breedsFound));
        
    }
    
    [Test]
    public void FindWantedBreed()
    {
        string wantedBreed = "Bengal";

        _restRequest.Resource = _breedUrl;
        var response = _restClient.Get(_restRequest);

        var testData = _keyword.BreedDeserialise(response);

        bool isBreedFound = testData.data.Any(breed => breed.breed == wantedBreed);
        
        Assert.That(isBreedFound, Is.True);
    }

    [Test]
    public void BadEndpointCall()
    {
        string badUrl = "https://catfact.ninja/breedz";
        _restRequest.Resource = badUrl;
        
        var response = _restClient.Get(_restRequest);
        
        Assert.IsTrue(response.StatusCode == HttpStatusCode.NotFound);
    }
    
}