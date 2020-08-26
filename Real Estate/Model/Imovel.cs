using Real_Estate.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Model
{
    [Table("Imoveis")]
    public class Imovel
    {
        [Key]
        public int cod_imovel { get; set; }

        [Column(TypeName = "DECIMAL(8,2)")]
        public float metro_quadrado { get; set; }
        
        [Column(TypeName = "TEXT")]
        public string descricao { get; set; }
        
        [Column(TypeName = "TINYINT")]
        public int numero_quartos { get; set; }
        
        [Column(TypeName = "TINYINT")]
        public int numero_banheiros { get; set; }

        [Column(TypeName = "INT")]
        public TipoImovel _tipoImovel { get; set; }

        [ForeignKey("Proprietario")]
        public int ProprietarioRefId { get; set; }
        public Proprietario Proprietario { get; set; }

        [ForeignKey("Endereco")]
        public int EnderecoRefId { get; set; }
        public Endereco Endereco { get; set; }

        public Imovel () { }

        public Imovel(int cod_imovel, float metro_quadrado, string descricao, int numero_quartos, int numero_banheiros, TipoImovel tipoImovel, int proprietarioRefId, int enderecoRefId)
        {
            this.cod_imovel = cod_imovel;
            this.metro_quadrado = metro_quadrado;
            this.descricao = descricao;
            this.numero_quartos = numero_quartos;
            this.numero_banheiros = numero_banheiros;
            _tipoImovel = tipoImovel;
            ProprietarioRefId = proprietarioRefId;
            EnderecoRefId = enderecoRefId;
        }
    }
}
