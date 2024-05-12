﻿namespace Bookify.Domain.Users;

public sealed class Role
{
    public static readonly Role Registered = new(1, "registered");
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public ICollection<User> Users { get; init; } = new List<User>();

    public Role(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
