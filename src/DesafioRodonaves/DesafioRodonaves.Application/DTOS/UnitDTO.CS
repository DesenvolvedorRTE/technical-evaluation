using DesafioRodonaves.Domain.Commons;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Text.Json.Serialization;


namespace DesafioRodonaves.Application.DTOS
{
    public class UnitDTO
    {
        public string UnitName { get; set; }

        public string UnitCode { get; set; }

        public bool Status { get; set; }

    }
}
