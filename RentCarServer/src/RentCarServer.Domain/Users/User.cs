using System.Security.Cryptography;
using System.Text;
using RentCarServer.Domain.Abstractions;
using RentCarServer.Domain.Users.ValueObjects;

namespace RentCarServer.Domain.Users;

public sealed class User : Entity
{
    private User() { }

    public User(
        FirstName firstName,
        LastName lastName,
        Email email,
        UserName userName,
        Password password,
        bool isActive
    )
    {
        SetFirstName(firstName);
        SetLastName(lastName);
        SetEmail(email);
        SetUserName(userName);
        SetPassword(password);
        SetFullName();
        SetStatus(isActive);
    }

    public FirstName FirstName { get; private set; } = null!;
    public LastName LastName { get; private set; } = null!;
    public FullName FullName { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public UserName UserName { get; private set; } = null!;
    public Password Password { get; private set; } = null!;

    public bool VerifyPasswordHash(string password)
    {
        using var hmac = new HMACSHA512(Password.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(Password.PasswordHash);
    }

    private void SetFirstName(FirstName firstName)
    {
        FirstName = firstName;
    }

    private void SetLastName(LastName lastName)
    {
        LastName = lastName;
    }

    private void SetEmail(Email email)
    {
        Email = email;
    }

    private void SetUserName(UserName userName)
    {
        UserName = userName;
    }

    private void SetFullName()
    {
        FullName = new FullName(FirstName.Value + " " + LastName.Value + " (" + Email.Value + ")");
    }

    private void SetPassword(Password password)
    {
        Password = password;
    }
}