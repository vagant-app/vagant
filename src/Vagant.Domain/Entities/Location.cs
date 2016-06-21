﻿namespace Vagant.Domain.Entities
{
    public class Location : BaseEntity
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string DisplayName { get; set; }
    }
}
