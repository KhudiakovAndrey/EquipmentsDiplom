namespace Equipments.Identity.Services.EmailSender
{
    public class EmailSettings
    {
        public string Name { get; set; } = string.Empty;
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
