using EcoBuildAI.Models;
using System.Text;

namespace EcoBuildAI.Services
{
    public class AiAnalysisService
    {
        public string Analyze(ConstructionInput input)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Environmental Analysis");
            sb.AppendLine("----------------------\n");

            // 1️⃣ Construction type analysis
            sb.AppendLine("Construction Type Impact:");
            if (input.ConstructionType.ToLower().Contains("road"))
            {
                sb.AppendLine("- Roads increase land sealing and surface runoff.");
                sb.AppendLine("- Use permeable asphalt where possible.");
                sb.AppendLine("- Plan proper drainage to protect soil and nearby ecosystems.");
            }
            else if (input.ConstructionType.ToLower().Contains("house") ||
                     input.ConstructionType.ToLower().Contains("building"))
            {
                sb.AppendLine("- Buildings impact energy consumption and land use.");
                sb.AppendLine("- Use passive design to reduce heating and cooling needs.");
            }
            else
            {
                sb.AppendLine("- Analyze land use impact carefully for this construction type.");
            }

            sb.AppendLine();

            // 2️⃣ Material analysis
            sb.AppendLine("Material Recommendations:");
            if (input.Materials.ToLower().Contains("concrete"))
                sb.AppendLine("- Concrete has high CO₂ emissions; consider low-carbon or recycled concrete.");

            if (input.Materials.ToLower().Contains("asphalt"))
                sb.AppendLine("- Use recycled asphalt (RAP) to reduce raw material extraction.");

            if (input.Materials.ToLower().Contains("steel"))
                sb.AppendLine("- Prefer recycled steel to lower environmental footprint.");

            sb.AppendLine("- Source materials locally to reduce transportation emissions.");
            sb.AppendLine();

            // 3️⃣ Size-based impact
            sb.AppendLine("Project Size Considerations:");
            if (input.AreaSize > 3000)
            {
                sb.AppendLine("- Large-scale project detected.");
                sb.AppendLine("- Conduct an environmental impact assessment (EIA).");
                sb.AppendLine("- Plan construction phases to minimize ecosystem disruption.");
            }
            else
            {
                sb.AppendLine("- Small to medium project size.");
                sb.AppendLine("- Environmental impact can be managed with proper planning.");
            }

            sb.AppendLine();

            // 4️⃣ Sustainability suggestions
            sb.AppendLine("Sustainability Suggestions:");
            sb.AppendLine("- Install solar panels where feasible.");
            sb.AppendLine("- Implement rainwater harvesting systems.");
            sb.AppendLine("- Reduce construction waste and recycle materials.");
            sb.AppendLine("- Protect nearby vegetation during construction.");

            return sb.ToString();
        }
    }
}
