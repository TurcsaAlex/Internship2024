namespace TorqueAndTread.Server.Helpers
{
    public class ServerException:Exception
    {
        public int ErrCode { get; set; }
        public ServerException():base(){}
        
    }
}
