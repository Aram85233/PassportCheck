using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.DTO
{
   public class PassportModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PassportNumber { get; set; }
    }
}
