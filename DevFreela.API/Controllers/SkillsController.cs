﻿using DevFreela.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        [HttpGet]
        public  IActionResult GetAll()
        {
            return Ok();
        }

        [HttpPost]
        public  IActionResult Post(CreateSkillInputModel model)
        {
            return Ok();
        }
    }
}
