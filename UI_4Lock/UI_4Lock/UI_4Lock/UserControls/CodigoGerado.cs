using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_4Lock.UserControls
{
    public static class CodigoGerado
    {
        private static int codigo;

        public static int GerarCodigo()
        {
            Random random = new Random();
            codigo = random.Next(1000, 9999);
            return codigo;
        }

        public static int ObterCodigo()
        {
            return codigo;
        }
    }
}
