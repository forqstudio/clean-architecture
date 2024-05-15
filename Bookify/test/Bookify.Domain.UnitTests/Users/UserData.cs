﻿using Bookify.Domain.Users;

namespace Bookify.Domain.UnitTests.Users;

internal static class UserData 
{
    public static readonly FirstName FirstName = new("Howard");
    public static readonly LastName LastName = new("Seraus");
    public static readonly Email Email = new("test@test.com");
}
