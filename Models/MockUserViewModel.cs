namespace Task4.Models;

public class MockUserViewModel
{
    public required string Name { get; init; }

    public required string Email { get; init; }

    public required string LastActivity { get; init; }

    public required string Status { get; init; }

    public bool IsSelected { get; init; }
}
