namespace Task4.Models;

public class UserManagementViewModel
{
    public required IReadOnlyList<UserListItemViewModel> Users { get; init; }

    public int TotalUsers { get; init; }

    public int ActiveUsers { get; init; }

    public int BlockedUsers { get; init; }

    public int UnverifiedUsers { get; init; }
}
