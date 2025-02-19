using DataAccessLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class bizParsha : bizObject<bizParsha>, IDeleteable
    {
        public bizParsha()
        {

        }

        public int ParshaId { get; set; }
        public string ParshaName { get; set; } = "";
        public string ParshaNameEnglish { get; set; } = "";

        public async Task Delete()
        {
            SqlCommand cmd = SQLExecuter.GetSqlCommand(DeleteSproc);
            cmd.Parameters["@ParshaId"].Value = this.ParshaId;
            await SQLExecuter.ExecuteSqlCrud(cmd);
        }
    }
}
