using API.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Candidato
    {
        [Key]
        public int id { get; set; }
        public string nomeCompleto { get; set; }
        public string email { get; set; }


        public static object getAll()
        {
            try
            {
                EasyDevContext context = new EasyDevContext();

                return context.Candidatos.AsEnumerable();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}