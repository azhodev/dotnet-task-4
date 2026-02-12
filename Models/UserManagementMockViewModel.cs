namespace Task4.Models;

public class UserManagementMockViewModel
{
    public required IReadOnlyList<MockUserViewModel> Users { get; init; }

    public int TotalUsers { get; init; }

    public int ActiveUsers { get; init; }

    public int BlockedUsers { get; init; }

    public int UnverifiedUsers { get; init; }
}
