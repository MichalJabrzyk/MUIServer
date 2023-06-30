using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MUIServer.Models
{
    public class MainServerDTO
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? MainServerID { get; set; }
        public string? MainServerName { get; set; }
        public string? MainServerVersion { get; set; }
        public string? MainServerIP { get; set; }
        public int? MainServerPort { get; set; }
        public string? MainServerURL { get; set; }
        public string? MainServerTimeStart { get; set; }
        public string? MainServerTimeEnd { get; set; }
        public string? MainServerLifetime { get; set; }
    }
}
