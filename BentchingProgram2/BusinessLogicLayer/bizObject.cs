using DataAccessLayer;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BusinessLogicLayer
{
    public class bizObject<T> : INotifyPropertyChanged where T : new()
    {
        private string _type = "";
        private string _sprocread = "";
        private string _sprocupsert = "";
        private string _sprocdelete = "";
        public bizObject()
        {
            _type = this.GetType().Name;
            if (_type.ToLower().StartsWith("biz"))
            {
                _sprocread = $"{_type.Substring(3)}Read";
                _sprocupsert = $"{_type.Substring(3)}Upsert";
                _sprocdelete = $"{_type.Substring(3)}Delete";
            }
        }

        public async Task<List<T>> GetList()
        {
            SqlCommand cmd = SQLExecuter.GetSqlCommand(_sprocread);
            cmd.Parameters["@All"].Value = 1;
            return await SQLExecuter.GetDBResultList<T>(cmd);
        }

        public async Task<List<T>> Load(int id, params (string name, object val)[]? sprocparams)
        {
            SqlCommand cmd = SQLExecuter.GetSqlCommand(_sprocread);
            cmd.Parameters["@MemberId"].Value = id;
            if(sprocparams != null && sprocparams.Length > 0)
            {
                foreach((string name, object val)p in sprocparams)
                {
                    cmd.Parameters[p.name].Value = p.val;
                }
            }
            return await SQLExecuter.GetDBResultList<T>(cmd);
        }

        public async Task Update(params (string name, object val)[]? sprocparams)
        {
            SqlCommand cmd = SQLExecuter.GetSqlCommand(_sprocupsert);
            if(sprocparams != null && sprocparams.Length > 0)
            {
                foreach ((string name, object val) p in sprocparams)
                {
                    cmd.Parameters[p.name].Value = p.val;
                }
            }
            await SQLExecuter.ExecuteSqlCrud(cmd);
        }

        public async Task Delete(int id)
        {
            SqlCommand cmd = SQLExecuter.GetSqlCommand(_sprocdelete);
            cmd.Parameters[$"@{_type.Substring(3)}Id"].Value = id;
            await SQLExecuter.ExecuteSqlCrud(cmd);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void InvokePropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
