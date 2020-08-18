using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Model
{
    public class Endereco
    {
        [Key]
        public int cod_endereco { get; set; }

        [Column(TypeName = "VARCHAR(40)")]
        public string rua { get; set; }

        [Column(TypeName = "VARCHAR(15)")]
        public string logradouro { get; set; }

        [Column(TypeName = "VARCHAR(25)")]
        public string bairro { get; set; }

        [Column(TypeName = "VARCHAR(15)")]
        public string numero { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        public string municipio { get; set; }

        [Column(TypeName = "CHAR(2)")]
        public string estado { get; set; }

        [Column(TypeName = "CHAR(9)")]
        public string cep { get; set; }

        public Endereco() { }

        public Endereco(int cod_endereco, string rua, string logradouro, string bairro, string numero, string municipio, string estado, string cep)
        {
            this.cod_endereco = cod_endereco;
            this.rua = rua;
            this.logradouro = logradouro;
            this.bairro = bairro;
            this.numero = numero;
            this.municipio = municipio;
            this.estado = estado;
            this.cep = cep;
        }
    }
}
