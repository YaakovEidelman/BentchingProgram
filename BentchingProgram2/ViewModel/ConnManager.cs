using DataAccessLayer;

namespace ViewModel
{
    public class ConnManager
    {
        public static void SetConnString(string conn)
        {
            SQLExecuter.SetConn(conn);
        }
    }
}
