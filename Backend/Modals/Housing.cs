﻿namespace Backend.Modals
{
    using Backend.Modals.enums;
    using System.Collections.Generic;

    public class Housing
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public HousingType Type { get; set; }

        public int NumberOfBedroom { get; set; }

        public double NumberOfBathroom { get; set; }

        public string Description { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
