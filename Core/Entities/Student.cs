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

        public string RegistrationId { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
