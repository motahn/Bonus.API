using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bonus.API.Models
{
    [Table("TB_FUNCIONARIOS")]
    public class Funcionario
    {
        [Column("ID_FUNCIONARIO")]
        [Key()]
        [Required()]
        public int Id { get; set; }

        [Column("NU_MATRICULA")]
        [Required()]
        [StringLength(10)]
        public string CodigoMatricula { get; set; }

        [Column("TX_NOME_COMPLETO")]
        [Required()]
        [StringLength(50)]
        public string NomeCompleto { get; set; }

        [Column("TX_AREA_ATUACAO")]
        [Required()]
        [StringLength(30)]
        public string AreaAtuacao { get; set; }

        [Column("TX_CARGO")]
        [Required()]
        [StringLength(30)]
        public string Cargo { get; set; }

        [Required()]
        [Column("NU_SALARIO_BRUTO")]
        public double SalarioBruto { get; set; }

        [Required()]
        [Column("DT_ADMISSAO")]
        public DateTime DataAdmissao { get; set; }
    }
}
