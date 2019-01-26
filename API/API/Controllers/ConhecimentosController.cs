using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ConhecimentosController : ApiController
    {
        [HttpGet]
        public object GetAll(string descricao = "")
        {
            return Conhecimento.getAll(descricao);
        }

        [HttpGet]
        public object GetById(int id)
        {
            return Conhecimento.getById(id);
        }

        [HttpPost]
        public object Cadastrar([FromBody]Conhecimento item)
        {
            return item.save();
        }

        [HttpPut]
        public object Alterar(int id, [FromBody]Conhecimento item)
        {
            return item.save(id);
        }
    }
}

