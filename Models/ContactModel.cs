using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contacts_app.Models
{
    public class ContactModel
    {
        public int Id {get; set;}
        public required string Name {get; set;}
        public required string Email {get; set;}
        public required string Phone {get; set;}
    }
}