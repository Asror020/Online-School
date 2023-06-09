using Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Student : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string RegistrationId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public User User { get; set; }
    }
}
