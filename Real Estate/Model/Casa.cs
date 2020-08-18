using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Model
{
    [Table("Casas")]
    public class Casa
    {
        [Key]
        public int cod_casa { get; set; }

        [Column(TypeName = "VARCHAR(25)")]
        public string tipo { get; set; }

        [Column(TypeName = "BIT")]
        public bool quintal { get; set; }

        [Column(TypeName = "BIT")]
        public bool garagem { get; set; }

        [Column(TypeName = "TINYINT")]
        public int numero_vagas { get; set; }

        [Column(TypeName = "SMALLMONEY")]
        public float valor_p_metro2 { get; set; }

        public Proprietario Proprietario { get; set; }
        public Imovel Imovel { get; set; }

        public Casa() { }

        public Casa(string tipo, bool quintal, bool garagem, byte numero_vagas, float valor_p_metro2)
        {
            this.tipo = tipo;
            this.quintal = quintal;
            this.garagem = garagem;
            this.numero_vagas = numero_vagas;
            this.valor_p_metro2 = valor_p_metro2;
        }


        
    }
}
