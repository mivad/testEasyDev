﻿using API.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Conhecimento
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(120)]
        [Index(IsUnique = true)]
        [Column(TypeName = "VARCHAR")]
        public string descricao { get; set; }

        [Required]
        public DateTime dtHoraCadastro { get; set; }

        public static Conhecimento getById(int id)
        {
            try
            {
                EasyDevContext context = new EasyDevContext();

                return context.Conhecimentos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static object getAll(string descricao = "")
        {
            try
            {
                EasyDevContext context = new EasyDevContext();

                var objs = context.Conhecimentos.AsEnumerable();

                if (!string.IsNullOrEmpty(descricao))
                    objs = objs.Where(x => !string.IsNullOrEmpty(x.descricao) && x.descricao.IndexOf(descricao, StringComparison.OrdinalIgnoreCase) >= 0);

                return objs;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Conhecimento save(int id = 0)
        {
            try
            {
                EasyDevContext context = new EasyDevContext();

                if (this.id == 0 && id == 0)
                {
                    this.dtHoraCadastro = DateTime.Now;
                    context.Conhecimentos.Add(this);
                }
                else
                {
                    if (this.id != id)
                        throw new HttpException(404, "id do registro difere do id passado como parâmetro");

                        Conhecimento oldObj = context.Conhecimentos.Find(this.id);
                    if (oldObj == null)
                        throw new HttpException(404, "Registro não localizado.");
                    else
                        context.Entry(oldObj).CurrentValues.SetValues(this);
                }

                context.SaveChanges();

                return this;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static void delete(int id)
        {
            try
            {
                EasyDevContext context = new EasyDevContext();

                var obj = context.Conhecimentos.Find(id);

                if (obj == null)
                    throw new HttpException(400, "Registro não localizado.");

                context.Conhecimentos.Remove(obj);
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}