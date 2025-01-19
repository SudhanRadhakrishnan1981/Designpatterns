internal class CompletionRequest
{
    public string Prompt { get; set; }
    public string Model { get; set; }
    public int MaxTokens { get; set; }
}