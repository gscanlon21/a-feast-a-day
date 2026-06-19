using Core.Models.Nutrients;

namespace Core.Dtos.Users;

public class UserFamilyDto
{
    public int Id { get; init; }

    public int UserId { get; init; }

    public int Weight { get; init; }

    public int CaloriesPerDay { get; init; }

    public Person Person { get; init; }
}
