using Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Subject : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProfessorId { get; set; }
        public string StudentsList { get; set; }
    }
}
