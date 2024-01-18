using System.Net;
using RestSharp;

namespace ProPatria_GergoAmbrus_HomeWork;

public class FactEndpointTests
{
    
    private readonly string _factsUrl = "https://catfact.ninja/facts";
    private readonly RestClient _restClient;
    private readonly RestRequest _restRequest;
    readonly Keywords _keyword = new Keywords();
    
    public FactEndpointTests()
    {
        _restClient = new RestClient();
        _restRequest = new RestRequest();
    }
    
    [Test]
    public void IsAPIAcceccible()
    {
        _restRequest.Resource = _factsUrl;
        var response = _restClient.Get(_restRequest);
        
        Console.WriteLine(response.StatusCode);
        Assert.That(response.IsSuccessStatusCode, Is.True);
    }
    
    [Test]
    public void GetFactsFromOnePage()
    {
        _restRequest.Resource = _factsUrl;
        var response = _restClient.Get(_restRequest);

        var testData = _keyword.FactDeserialise(response);
        List<string> factList = new List<string>();

        _keyword.CollectFacts(testData, factList);
        
        Assert.That(testData.to, Is.EqualTo(factList.Count));
        
    }
    
    [Test]
    public void AskForLimit()
    {
        int limit = 3;
        string limitedUrl = $"https://catfact.ninja/facts?limit={limit}";

        _restRequest.Resource = limitedUrl;
        var response = _restClient.Get(_restRequest);

        var testData = _keyword.FactDeserialise(response);
        
        Assert.That(testData.to, Is.EqualTo(limit));
    }

    [Test]
    public void AskForIrrationalLimit()
    {
        double limit = 3.14;
        string limitedUrl = $"https://catfact.ninja/facts?limit={limit}";

        _restRequest.Resource = limitedUrl;
        var response = _restClient.Get(_restRequest);

        var testData = _keyword.FactDeserialise(response);
        
        Assert.That(testData.to, Is.EqualTo(testData.per_page));
        Assert.IsTrue(response.IsSuccessStatusCode);
    }

    [Test]
    public void AskForNegativeLimit()
    {
        int limit = -2;
        string limitedUrl = $"https://catfact.ninja/facts?limit={limit}";

        _restRequest.Resource = limitedUrl;
        var response = _restClient.Get(_restRequest);

        var testData = _keyword.FactDeserialise(response);
        
        Assert.AreEqual(testData.per_page, testData.to);
        Assert.IsTrue(response.IsSuccessStatusCode);
    }
    
}