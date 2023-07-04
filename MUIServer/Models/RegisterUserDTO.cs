using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace MUIServer.Models
{
    public class RegisterUserDTO
    {
       
        public DateTime BirthDate { get; set; }
        
        public string UserName { get; set; } 
        
        public string EmailAddress { get; set; }
        
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public int RoleId { get; set; }

        public string Country { get; set; }

    }
}
