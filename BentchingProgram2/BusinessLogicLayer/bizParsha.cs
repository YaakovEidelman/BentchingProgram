using DataAccessLayer;
using Microsoft.Data.SqlClient;

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


        public string ReloadListName { get => "LoadParshaList"; }
        public string Name { get => this.ParshaName; }
        public async Task Delete()
        {
            SqlCommand cmd = SQLExecuter.GetSqlCommand(DeleteSproc);
            cmd.Parameters[$"@{nameof(ParshaId)}"].Value = this.ParshaId;
            await SQLExecuter.ExecuteSqlCrud(cmd);
        }
    }
}
