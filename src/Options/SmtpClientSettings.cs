using Bazario.AspNetCore.Shared.Options;
using System.ComponentModel.DataAnnotations;

namespace Bazario.Notification.Options
{
    public sealed class SmtpClientSettings : IAppOptions
    {
        public const string SectionName = nameof(SmtpClientSettings);

        [Required]
        public required string Username { get; set; }

        [Required(AllowEmptyStrings = true)]
        public required string Password { get; set; }

        [Required]
        public required string Host { get; set; }

        [Required]
        public int Port { get; set; }

        [Required]
        public bool EnableSsl { get; set; }
    }
}
