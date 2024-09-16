namespace TorqueAndTread.Server.DTOs
{
    public class AuthDTO
    {
        public int Code { get; set; }
        public string Token { get; set; }
        public string ImgFile { get; set; }
        public List <MenuItemDTO> MenuItems { get; set; }

        public List<RoleDTO> Roles {  get; set; }
        public AuthDTO(int code)
        {
            Code = code;
        }
        public AuthDTO(int code,string token, List<MenuItemDTO> menuItems, List<RoleDTO> roles)
        {
            Code = code;
            Token = token;
            MenuItems = menuItems;
            Roles = roles;
        }

        public AuthDTO(int code, string token, List<MenuItemDTO> menuItems, List<RoleDTO> roles, string imgFile)
        {
            Code = code;
            Token = token;
            MenuItems = menuItems;
            Roles = roles;
            ImgFile = imgFile;
        }

        public AuthDTO(int code, string token, string imgFile)
        {
            Code = code;
            Token = token;
            ImgFile =imgFile;
        }
    }
}
