using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.UserSettings.GetUserSettings;

public sealed record GetUserSettingsQuery : IQuery<UserSettingsResponse>;
