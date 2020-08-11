using System;
using System.ComponentModel.DataAnnotations;

namespace Models.models
{
    public class Product
    {
        #region Id
        [Key]
        public int Id { get; set; }
        #endregion
        #region Title
        [Required(ErrorMessage ="Campo Título é obrigatório!")]
        [MaxLength(60, ErrorMessage ="Máximo de 60 caracteres")]
        [MinLength(4, ErrorMessage ="Mínimo de 4 caracteres")]
        public string Title { get; set; }
        #endregion
        #region Description
        [MaxLength(60, ErrorMessage = "Máximo de 60 caracteres")]
        [MinLength(4, ErrorMessage = "Mínimo de 4 caracteres")]
        public string Description { get; set; }
        #endregion
        #region Price
        [Required(ErrorMessage ="Campo preço é obrigatorio!")]
        [Range(1, int.MaxValue, ErrorMessage ="O preço de ser maior que zero")]
        public decimal Price { get; set; }
        #endregion
        #region Category
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Range(1, int.MaxValue, ErrorMessage ="Categoria invalida")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        #endregion
    }
}
