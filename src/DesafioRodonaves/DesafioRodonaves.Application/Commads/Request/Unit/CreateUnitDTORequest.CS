using System.Text.Json.Serialization;

namespace DesafioRodonaves.Application.Commads.Request.Unit
{
    public class CreateUnitDTORequest
    {
        public string UnitName { get; set; }

        public string UnitCode { get; set; }

        [JsonIgnore]
        public bool Status { get; set; } = true;
    }
}