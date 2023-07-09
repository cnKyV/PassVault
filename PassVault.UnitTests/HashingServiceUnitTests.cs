using PassVault.Services;

namespace PassVault.UnitTests;

public class HashingServiceUnitTests
{
    [Theory]
    [InlineData("TestPassword123")]
    [InlineData("t3stP4ssw0rd123321")]
    [InlineData("@>@>@>@>@>")]
    public void PlainPasswordWithSalt_MustMatch_HashedPassword(string plainPassword)
    {
        var hashedPass = HashingService.HashString(plainPassword);
        var isMatch = HashingService.VerifyString(plainPassword, hashedPass);
    }
}