using Bookify.Application.Abstractions.Authentication;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Users;

namespace Bookify.Application.UserSettings.GetUserSettings;

internal sealed class GetUserSettingsQueryHandler(
    IUserSettingsRepository userSettingsRepository,
    IUserContext userContext)
    : IQueryHandler<GetUserSettingsQuery, UserSettingsResponse>
{
    public async Task<Result<UserSettingsResponse>> Handle(
        GetUserSettingsQuery request,
        CancellationToken cancellationToken)
    {
        var userId = userContext.UserId;

        var userSettings = await userSettingsRepository.GetByUserIdAsync(userId, cancellationToken);

        if (userSettings is null)
        {
            return new UserSettingsResponse(Guid.Empty, userId, null, null, null);
        }

        return new UserSettingsResponse(
            userSettings.Id,
            userSettings.UserId,
            userSettings.PreferredLanguage,
            userSettings.EmailNotificationsEnabled,
            userSettings.Timezone);
    }
}
