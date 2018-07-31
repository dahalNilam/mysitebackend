namespace Backend.Modals
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Image
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public string Path { get; set; }

        public int HousingId { get; set; }

        [JsonIgnore]
        public Housing Housing { get; set; }
    }
}
