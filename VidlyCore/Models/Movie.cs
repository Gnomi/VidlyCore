using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

//using System.Threading.Tasks;

namespace VidlyCore.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }
         
        [Display(Name="Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name ="Number In Stock")]
        [Range(1, 25)]
        public byte NumberInStock { get; set; }

     //   [Required]
        public Genre Genre { get; set; }

        [Display(Name="Genre")]
        public byte GenreId { get; set; }
    }
}
