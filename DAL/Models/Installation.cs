using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    public class Installation
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Street { get; set; }
        public string? No { get; set; }
        public int PostCode { get; set; }
        public string? City { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public int AzimutOrientation { get; set; }
        public int TiltOrientation { get; set; }
        public string? EnergyType { get; set; }
        public string? IntegrationType { get; set; }
        public string? CellsType { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
    }
}

