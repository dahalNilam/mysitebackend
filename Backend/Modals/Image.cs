namespace Backend.Modals
{
    using Newtonsoft.Json;

    public class Image
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public string Path { get; set; } = @"E:\Projects\MySite\Images\";

        public int HousingId { get; set; }

        [JsonIgnore]
        public Housing Housing { get; set; }
    }
}
