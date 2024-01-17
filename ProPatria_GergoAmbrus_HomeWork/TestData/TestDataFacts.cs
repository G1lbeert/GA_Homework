namespace ProPatria_GergoAmbrus_HomeWork;

public class TestDataFacts
{
    public string fact { get; set; }
    public int length { get; set; }
    public string url { get; set; }
    public string label { get; set; }
    public bool active { get; set; }
    public int current_page { get; set; }
    public List<TestDataFacts> data { get; set; }
    public string first_page_url { get; set; }
    public int from { get; set; }
    public int last_page { get; set; }
    public string last_page_url { get; set; }
    public List<TestDataFacts> links { get; set; }
    public string next_page_url { get; set; }
    public string path { get; set; }
    public int per_page { get; set; }
    public object prev_page_url { get; set; }
    public int to { get; set; }
    public int total { get; set; }
}