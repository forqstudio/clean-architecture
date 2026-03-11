using Bookify.Application.Abstractions.Authentication;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Users;

namespace Bookify.Application.UserSettings.UpdateUserSettings;

internal sealed class UpdateUserSettingsCommandHandler(
    IUserSettingsRepository userSettingsRepository,
    IUserContext userContext,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateUserSettingsCommand>
{
    public async Task<Result> Handle(
        UpdateUserSettingsCommand command,
        CancellationToken cancellationToken)
    {
        var userId = userContext.UserId;

        var userSettings = await userSettingsRepository.GetByUserIdAsync(userId, cancellationToken);

        if (userSettings is null)
        {
            userSettings = Domain.Users.UserSettings.Create(userId);
            userSettingsRepository.Add(userSettings);
        }

        var result = userSettings.Update(
            command.PreferredLanguage,
            command.EmailNotificationsEnabled,
            command.Timezone);

        if (result.IsFailure)
        {
            return result;
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
