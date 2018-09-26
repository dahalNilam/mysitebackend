namespace Backend.Modals
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        [Key]
        public int Id { get; set; }

        public string FileName { get; set; }

        public string Path { get; set; } = @"E:\Projects\MySite\Images\";

        public int HousingId { get; set; }
        public string Hash { get; set; }

        [JsonIgnore]
        public Housing Housing { get; set; }
    }
}
