using Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Grade : IEntity
    {
        public int Id { get; set; }
        public byte Score { get; set; }
        public string SubjectName { get; set; }
        public int StudentId { get; set; }
    }
}
