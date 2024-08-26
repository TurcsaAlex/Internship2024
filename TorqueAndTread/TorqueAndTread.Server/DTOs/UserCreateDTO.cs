namespace TorqueAndTread.Server.DTOs
{
  public class UserCreateDTO
  {
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public bool Active { get; set; }
  }
}
