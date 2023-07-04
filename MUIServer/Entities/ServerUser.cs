using VisioForge.Libs.NAudio.CoreAudioApi;

namespace MUIServer.Entities
{
    public class ServerUser
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public string EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }

        public string? Country { get; set; }
        public string? PostCode { get; set; }
        public string? County { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? FlatNumber { get; set; }
       
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public int? RoleId { get; set; }

        public virtual ServerUserRole Role { get; set; }

    }
}
