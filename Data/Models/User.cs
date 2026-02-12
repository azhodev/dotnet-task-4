namespace Task4.Data.Models;

public sealed class User
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public UserStatus Status { get; set; }

    public DateTime? LastLoginAt { get; set; }

    public DateTime? LastActivityAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public int RowVersion { get; set; }
}

public enum UserStatus
{
    unverified,
    active,
    blocked
}
