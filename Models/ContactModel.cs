using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace contacts_app.Models
{
    public class ContactModel
    {
        public int Id {get; set;}
        [Required(ErrorMessage = "Digite o nome do contato")]
        public required string Name {get; set;}
        [Required(ErrorMessage = "Digite o e-mail do contato")]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido")]
        public required string Email {get; set;}
        [Required(ErrorMessage = "Digite o celular do contato")]
        [Phone(ErrorMessage = "O celular informado não é válido")]
        public required string Phone {get; set;}
    }
}