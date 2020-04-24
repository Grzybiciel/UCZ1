using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCZ1.DTOs.Requests;

namespace UCZ1.DAL
{
    public interface IDbService
    {
        public GetAnimalsResponse GetAnimals(string orderBy);
    }
}
