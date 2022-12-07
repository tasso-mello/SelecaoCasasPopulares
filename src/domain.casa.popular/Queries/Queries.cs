using domain.casa.popular.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.casa.popular.Queries
{
    public static class Queries
    {
        public static string AddFamiliaSeed()
            => Resources.FamiliaSeed;

        public static string AddPessoaSeed()
            => Resources.PessoaSeed;
    }
}
