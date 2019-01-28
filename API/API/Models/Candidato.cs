using API.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Candidato
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string nomeCompleto { get; set; }

        [Required]
        [StringLength(220)]
        [Index(IsUnique = true)]
        [Column(TypeName = "VARCHAR")]
        public string email { get; set; }
        public string conhecimentoOutros { get; set; }

        
        public string skype { get; set; }
        public string phone { get; set; }
        public string linkedIn { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string portfolio { get; set; }
        public string disponibilidadeTrabalho { get; set; }
        public string melhorHorarioTrabalho { get; set; }
        public decimal? pretensaoSalario { get; set; }

        public bool horasAteQuatro { get; set; }
        public bool horasQuatroASeis { get; set; }
        public bool horasSeisAOito { get; set; }
        public bool horasAcimaDeOito { get; set; }
        public bool horasFimDeSemana { get; set; }
        public bool periodoManha { get; set; }
        public bool periodoTarde { get; set; }
        public bool periodoNoite { get; set; }
        public bool periodoMadrugada { get; set; }
        public bool periodoComercial { get; set; }


        public DateTime dtHoraCadastro { get; set; }

        public virtual ICollection<CandidatoConhecimento> conhecimentos { get; set; }


        public static Candidato getById(int id)
        {
            try
            {
                EasyDevContext context = new EasyDevContext();

                return context.Candidatos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static object getAll(string nome = "", string email = "")
        {
            try
            {
                EasyDevContext context = new EasyDevContext();

                var objs = context.Candidatos.AsEnumerable();

                if (!string.IsNullOrEmpty(nome))
                    objs = objs.Where(x => !string.IsNullOrEmpty(x.nomeCompleto) && x.nomeCompleto.IndexOf(nome, StringComparison.OrdinalIgnoreCase) >= 0);

                if (!string.IsNullOrEmpty(email))
                    objs = objs.Where(x => !string.IsNullOrEmpty(x.email) && x.email.IndexOf(email, StringComparison.OrdinalIgnoreCase) >= 0);

                return objs;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Candidato save(int id = 0)
        {
            try
            {
                EasyDevContext context = new EasyDevContext();

                if (this.id == 0 && id == 0)
                {
                    this.dtHoraCadastro = DateTime.Now;

                    var conhecimentos = new List<CandidatoConhecimento>(this.conhecimentos);
                    this.conhecimentos = null;
                   
                    context.Candidatos.Add(this);

                    context.SaveChanges();

                    CandidatoConhecimento.save(this.id, conhecimentos);
                }
                else
                {
                    if (this.id != id)
                        throw new HttpException(404, "id do registro difere do id passado como parâmetro");

                    Candidato oldObj = context.Candidatos.Find(this.id);
                    if (oldObj == null)
                        throw new HttpException(404, "Registro não localizado.");
                    else
                        context.Entry(oldObj).CurrentValues.SetValues(this);

                    foreach (var candidatoConhecimento in this.conhecimentos)
                    {
                        candidatoConhecimento.save(candidatoConhecimento.id);
                    }

                    context.SaveChanges();
                }

                return this;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}