using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class Constantes
    {
        public static readonly Dictionary<string, string> Opcoes = new Dictionary<string, string>()
            {
                { "1", "Depósito" },
                { "2", "Saque" },
                { "3", "Sair" }
            };
    }
}
