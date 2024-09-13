namespace TorqueAndTread.Server.DTOs
{
    public class AuthDTO
    {
        public int Code { get; set; }
        public string Token { get; set; }
        public string ImgFile { get; set; }
        public AuthDTO(int code)
        {
            Code = code;
        }
        public AuthDTO(int code,string token)
        {
            Code = code;
            Token = token;
        }
        public AuthDTO(int code, string token, string imgFile)
        {
            Code = code;
            Token = token;
            ImgFile =imgFile;
        }
    }
}
