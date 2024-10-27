namespace Dotnet_Web_Api.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public string Email { get; set; } = string.Empty;

    }
}
