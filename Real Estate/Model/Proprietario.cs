using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Model
{
    public class Proprietario
    {
        [Key]
        public int cod_proprietario { get; set; }
        public string nome_proprietario { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string telefone { get; set; }

        public List<Imovel> Imoveis { get; set; }

        public Proprietario()
        { }

        public Proprietario(int cod_proprietario, string nome_proprietario, string email, string senha, string telefone, List<Imovel> imoveis)
        {
            this.cod_proprietario = cod_proprietario;
            this.nome_proprietario = nome_proprietario;
            this.email = email;
            this.senha = senha;
            this.telefone = telefone;
            Imoveis = imoveis;
        }
    }
}
