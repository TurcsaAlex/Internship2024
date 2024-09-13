namespace TorqueAndTread.Server.DTOs
{
    public class AuthDTO
    {
        public int Code { get; set; }
        public string Token { get; set; }
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
    }
}
