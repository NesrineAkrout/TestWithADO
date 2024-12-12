using System.ComponentModel.DataAnnotations;

namespace TestWithADO.Models
{
        public class Personne
        {
        public int PersonneID { get; set; }
      
        [Required(ErrorMessage = "Le nom est requis.")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom est requis.")]
        [StringLength(100, ErrorMessage = "Le prénom ne peut pas dépasser 100 caractères.")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "La date de naissance est requise.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date de naissance")]
        public DateTime DateNaissance { get; set; }
    }
}
    


