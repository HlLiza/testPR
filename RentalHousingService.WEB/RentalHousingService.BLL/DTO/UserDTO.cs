namespace RentalHousingService.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public int TypeUser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Language { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
    }
}
