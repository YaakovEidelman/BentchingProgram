using DataAccessLayer;
using Microsoft.Data.SqlClient;

namespace BusinessLogicLayer
{
    public class bizMember : bizObject<bizMember>, IDeleteable
    {
        private int _memberid;
        private string _firstname = "";
        private string _lastname = "";
        private int _subtotal;
        private DateTime _birthdate;
        private int _amountpaidup;
        private int _finaltotal;

        public bizMember()
        {

        }

        public int MemberId
        {
            get => _memberid;
            set
            {
                _memberid = value;
                InvokePropertyChanged();
            }
        }
        public string FirstName
        {
            get => _firstname;
            set
            {
                _firstname = value;
                InvokePropertyChanged();
            }
        }
        public string LastName
        {
            get => _lastname; set
            {
                _lastname = value;
                InvokePropertyChanged();
            }
        }
        public int SubTotal
        {
            get => _subtotal;
            set
            {
                _subtotal = value;
                InvokePropertyChanged();
            }
        }
        public DateTime BirthDate
        {
            get => _birthdate; set
            {
                _birthdate = value;
                InvokePropertyChanged();
            }
        }
        public int AmountPaidUp
        {
            get => _amountpaidup; set
            {
                _amountpaidup = value;
                InvokePropertyChanged();
            }
        }
        public int FinalTotal
        {
            get => _finaltotal; set
            {
                _finaltotal = value;
                InvokePropertyChanged();
            }
        }


        public string ReloadListName { get => "LoadMemberList"; }
        public string Name { get => this.FirstName; }
        public async Task Delete()
        {
            SqlCommand cmd = SQLExecuter.GetSqlCommand(DeleteSproc);
            cmd.Parameters["@MemberId"].Value = this.MemberId;
            await SQLExecuter.ExecuteSqlCrud(cmd);
        }

    }
}
