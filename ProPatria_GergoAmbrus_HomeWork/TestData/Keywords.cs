using Newtonsoft.Json;
using RestSharp;

namespace ProPatria_GergoAmbrus_HomeWork;

public class Keywords
{
    public TestDataModel Deserialise(RestResponse res)
    {
        var json = res.Content;
        return JsonConvert.DeserializeObject<TestDataModel>(json);
    }
    public void CollectBreeds(TestDataModel testData, List<string> breedsList)
    {
        if (!string.IsNullOrEmpty(testData?.breed))
        {
            breedsList.Add(testData.breed);
        }
        if (testData?.data != null)
        {
            foreach (var nestedData in testData.data)
            {
                CollectBreeds(nestedData, breedsList);
            }
        }
        if (testData?.links != null)
        {
            foreach (var nestedLink in testData.links)
            {
                CollectBreeds(nestedLink, breedsList);
            }
        }
    }
}