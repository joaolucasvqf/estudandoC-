using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MimicAPI.Helpers
{
    public class Paginacao
    {
        public int PagNum { get; set; }
        public int RegPerPag { get; set; }
        public int RegistersTotal { get; set; }
        public int PagesTotal { get; set; }
    }
}
