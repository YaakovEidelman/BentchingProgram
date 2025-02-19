using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class bizParsha : bizObject<bizParsha>
    {
        public bizParsha()
        {

        }

        public int ParshaId { get; set; }
        public string ParshaName { get; set; } = "";
        public string ParshaNameEnglish { get; set; } = "";
    }
}
