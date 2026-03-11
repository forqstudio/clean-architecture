using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.UserSettings.UpdateUserSettings;

public sealed record UpdateUserSettingsCommand(
    string? PreferredLanguage,
    bool? EmailNotificationsEnabled,
    string? Timezone) : ICommand;
