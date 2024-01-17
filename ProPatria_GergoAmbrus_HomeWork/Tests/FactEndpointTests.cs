using RestSharp;

namespace ProPatria_GergoAmbrus_HomeWork;

public class FactEndpointTests
{
    
    private string _factsUrl = "https://catfact.ninja/facts";
    private RestClient _restClient;
    private RestRequest _restRequest;
    Keywords keyword = new Keywords();
    
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
        _restRequest.AddHeader("Accept", "application/json");
        
        Console.WriteLine(response.StatusCode);
        Assert.That(response.IsSuccessStatusCode, Is.True);
    }
    
    [Test]
    public void GetFacts()
    {
        _restRequest.Resource = _factsUrl;
        var response = _restClient.Get(_restRequest);
        _restRequest.AddHeader("Accept", "application/json");
        
        
    }
    
    [Test]
    public void CheckCurrentFactPage()
    {
        
    }
}