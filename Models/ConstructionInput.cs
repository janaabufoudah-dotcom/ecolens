namespace EcoBuildAI.Models
{
    public class ConstructionInput
    {
        public string ClientEmail { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string ConstructionType { get; set; } = string.Empty;
        public string Materials { get; set; } = string.Empty;
        public double AreaSize { get; set; }
    }
}
