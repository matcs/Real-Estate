using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Model
{
    public class Apartamento
    {
        [Key]
        public int cod_apartamento { get; set; }
        
        [Column(TypeName = "VARCHAR(25)")]
        public string nome_bloco { get; set; }

        [Column(TypeName = "TINYINT")]
        public char numero_bloco { get; set; }

        public Proprietario Proprietario { get; set; }
        public Imovel Imovel { get; set; }

        public Apartamento ( ) { }

        public Apartamento(string nome_bloco, char numero_bloco)
        {
            this.nome_bloco = nome_bloco;
            this.numero_bloco = numero_bloco;
        }
    }
}
