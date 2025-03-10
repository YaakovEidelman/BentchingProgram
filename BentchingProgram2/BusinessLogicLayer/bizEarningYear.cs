﻿using DataAccessLayer;
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


        public string ReloadListName { get => "LoadEarningYearList"; }
        public string Name { get => this.EarningYear.ToString(); }
        public async Task Delete()
        {
            SqlCommand cmd = SQLExecuter.GetSqlCommand(DeleteSproc);
            cmd.Parameters[$"@{nameof(EarningYearId)}"].Value = this.EarningYearId;
            await SQLExecuter.ExecuteSqlCrud(cmd);
        }
    }
}
