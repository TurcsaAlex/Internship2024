namespace AngularApp1.Server.DTOs
{
    public class AuthDTO
    {
        public int Code { get; set; }
        public string Token { get; set; }
        public AuthDTO(int code)
        {
            Code = code;
        }
        public AuthDTO(int code,string token)
        {
            Code = code;
            Token = token;
        }
    }
}
