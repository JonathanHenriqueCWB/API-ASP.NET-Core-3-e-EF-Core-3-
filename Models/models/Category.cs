using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.models
{
    public class Category
    {
        public int Id { get; set; }
        #region
        [Required(ErrorMessage ="Esse campo é obrigatório!")]
        [MaxLength(60, ErrorMessage = "Esse campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Esse campo de conter entre 3 e 60 caracteres")]
        public string Title { get; set; }
        #endregion
    }
}
