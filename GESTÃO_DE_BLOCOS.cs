using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTÃO_DE_BLOCOS
{
    // Classe 'Bloco' para armazenar os detalhes do bloco
    class Bloco
    {
        public string Codigo { get; set; }
        public string NumeroDoBloco { get; set; }
        public double Medidas { get; set; }
        public string Descricao { get; set; }
        public string TipoMaterial { get; set; }
        public double ValorCompra { get; set; }
        public double ValorVenda { get; set; }
        public string Pedreira { get; set; }
    }
}
