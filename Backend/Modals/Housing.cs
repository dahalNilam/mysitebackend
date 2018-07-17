namespace Backend.Modals
{
    using System.ComponentModel.DataAnnotations;

    public class Housing
    {
        [Key]
        public int Id { get; set; }

        public double Price { get; set; }
    }
}
