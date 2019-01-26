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
    }
}