using Newtonsoft.Json;
using RestSharp;

namespace ProPatria_GergoAmbrus_HomeWork;

public class Keywords
{
    public TestDataBreed BreedDeserialise(RestResponse res)
    {
        var json = res.Content;
        return JsonConvert.DeserializeObject<TestDataBreed>(json);
    }

    public TestDataFacts FactDeserialise(RestResponse res)
    {
        var json = res.Content;
        return JsonConvert.DeserializeObject<TestDataFacts>(json);
    }
    public void CollectBreeds(TestDataBreed testData, List<string> breedsList)
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

    public void CollectFacts(TestDataFacts testData, List<string> factList)
    {
        if (!string.IsNullOrEmpty(testData?.fact))
        {
            factList.Add(testData.fact);
        }

        if (testData?.data != null)
        {
            foreach (var nestedData in testData.data)
            {
                CollectFacts(nestedData, factList);
            }
        }

        if (testData?.links != null)
        {
            foreach (var nestedLink in testData.links)
            {
                CollectFacts(nestedLink, factList);
            }
        }
    }
}