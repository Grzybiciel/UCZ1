using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using UCZ1.DAL;
using UCZ1.DTOs.Requests;

namespace UCZ1.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IDbService _dbService;
        public IConfiguration Configuration { get; set; }

        public AnimalsController(IConfiguration configuration, IDbService dbService)
        {
            _dbService = dbService;
            Configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetAnimals(string orderBy)
        {
            GetAnimalsResponse animalsResponse;
            IActionResult response;
            try
            {
                animalsResponse = _dbService.GetAnimals(orderBy);
                response = Ok(animalsResponse);
            }
            catch(Exception e)
            {
                response = NotFound($"{e}");
            }
            
            return response;
        }
    }
}