using API.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class CandidatoConhecimento
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int valor { get; set; }

        [Required]
        [Index("ORDER_CC", 1, IsUnique = true)]
        public int candidatoId { get; set; }

        [Required]
        [Index("ORDER_CC", 2, IsUnique = true)]
        public int conhecimentoId { get; set; }

        [Required]
        public DateTime dtHoraCadastro { get; set; }

        [ForeignKey("conhecimentoId")]
        public virtual Conhecimento conhecimento { get; set; }

        [ForeignKey("candidatoId")]
        public virtual Candidato candidato { get; set; }

        public CandidatoConhecimento save(int id = 0)
        {
            try
            {
                this.conhecimento = null;
                this.candidato = null;

                EasyDevContext context = new EasyDevContext();

                if (this.id == 0 && id == 0)
                {
                    this.dtHoraCadastro = DateTime.Now;
                 
                    context.CandidatoConhecimentos.Add(this);
                }
                else
                {
                    if (this.id != id)
                        throw new HttpException(404, "id do registro difere do id passado como parâmetro");

                    CandidatoConhecimento oldObj = context.CandidatoConhecimentos.Find(this.id);
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

        public static void save(int candidatoId, List<CandidatoConhecimento> conhecimentos)
        {
            try
            {
                foreach (var item in conhecimentos)
                {
                    CandidatoConhecimento obj = new CandidatoConhecimento();
                    obj.candidatoId = candidatoId;
                    obj.conhecimentoId = item.conhecimentoId;
                    obj.valor = item.valor;
                    obj.dtHoraCadastro = DateTime.Now;

                    obj.save();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}