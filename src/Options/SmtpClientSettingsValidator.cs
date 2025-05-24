using Microsoft.Extensions.Options;

namespace Bazario.Notification.Options
{
    [OptionsValidator]
    public partial class SmtpClientSettingsValidator
        : IValidateOptions<SmtpClientSettings>
    {
    }
}
