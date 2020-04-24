using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCZ1.DTOs.Requests
{
    public class GetAnimalsResponse
    {
        public string Name { get; set; }
        public string AnimalType { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public string LastNameOfOwner { get; set; }
    }
}
