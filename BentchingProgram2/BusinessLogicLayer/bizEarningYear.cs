using DataAccessLayer;
using Microsoft.Data.SqlClient;

namespace BusinessLogicLayer
{
    public class bizEarningYear : bizObject<bizEarningYear>, IDeleteable
    {
        public bizEarningYear()
        {

        }

        public int EarningYearId { get; set; }
        public int EarningYear { get; set; }

        public async Task Delete()
        {
            SqlCommand cmd = SQLExecuter.GetSqlCommand(DeleteSproc);
            cmd.Parameters["@EarningYearId"].Value = this.EarningYearId;
            await SQLExecuter.ExecuteSqlCrud(cmd);
        }
    }
}
