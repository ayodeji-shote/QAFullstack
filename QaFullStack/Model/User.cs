using System.ComponentModel.DataAnnotations.Schema;

namespace JWTCarsAuth.WebApi.Models
{
    [Table("user")]
    public class User
    {
        [Column(name: "id")]
        public int Id { get; set; }
        [Column(name: "password")]
        public string Password { get; set; }
        [Column(name: "username")]
        public string UserName { get; set; }    
    }
}
