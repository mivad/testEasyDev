﻿using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CandidatosController : ApiController
    {
        [HttpGet]
        public object GetAll(string descricao = "")
        {
            return Candidato.getAll(descricao);
        }

        [HttpGet]
        public object GetById(int id)
        {
            return Candidato.getById(id);
        }

        [HttpPost]
        public object Cadastrar([FromBody]Candidato item)
        {
            return item.save();
        }

        [HttpPut]
        public object Alterar(int id, [FromBody]Candidato item)
        {
            return item.save(id);
        }

        [HttpDelete]
        public void Excluir(int id)
        {
            Candidato.delete(id);
        }
    }

     
}
