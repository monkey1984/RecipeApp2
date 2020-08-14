using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RecipeApp2.Models
{
    public class RecipeAccessLayer
    {
        public int RecipeID { get; set; }
        [System.ComponentModel.DisplayName("Recipe Name")]
        [Required(ErrorMessage = "Recipe Name is required")]
        public string RecipeName { get; set; }
        [System.ComponentModel.DisplayName("Difficulty Rating")]
        [Required(ErrorMessage = "Rating is required")]
        public int Rating { get; set; }
        [System.ComponentModel.DisplayName("Hours (ex. 01)")]
        [Required(ErrorMessage = "Hours is required")]
        [MaxLength(2)]
        public int Hours { get; set; }
        [System.ComponentModel.DisplayName("Minutes (ex. 25)")]
        [Required(ErrorMessage = "Minutes is required")]
        [MaxLength(2)]
        public int Minutes { get; set; }
        [System.ComponentModel.DisplayName("Instructions")]
        [Required(ErrorMessage = "Recipe Intstructions required")]
        public string Instructions { get; set; }
    }
}