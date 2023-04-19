﻿using Agence.API.Models;
using Agence.BusinessLogic.Services;
using Agence.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agence.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaqueteController : Controller
    {
        private readonly AgenceService _agenceService;
        private readonly IMapper _mapper;

        public PaqueteController(AgenceService agenceService, IMapper mapper)
        {
            _agenceService = agenceService;
            _mapper = mapper;
        }


        [HttpGet("Listado")]
        public IActionResult Index()
        {
            var list = _agenceService.ListadoPaquetes();
            return Ok(list);
        }

        [HttpGet("Listado5Caros")]
        public IActionResult caros5()
        {
            var list = _agenceService.ListadoPaquetesCaros();
            return Ok(list);
        }

         [HttpGet("Listado10Baratos")]
        public IActionResult baratos10()
        {
            var list = _agenceService.ListadoPaquetesBaratos();
            return Ok(list);
        }
        
        [HttpGet("ListadoPorPersona")]
        public IActionResult listXPerson(int id)
        {
            var list = _agenceService.ListadoPorPersona(id);
            return Ok(list);
        }

        [HttpGet("Find")]
        public IActionResult Find(int id)
        {
            var list = _agenceService.FindPaquetes(id);
            return Ok(list);
        }

        [HttpPost("Insertar")]
        public IActionResult Insert(PaqueteViewModel paquete)
        {
            var item = _mapper.Map<tbPaquetes>(paquete);
            var response = _agenceService.InsertarPaquete(item);
            return Ok(response);
        }


    }
}
