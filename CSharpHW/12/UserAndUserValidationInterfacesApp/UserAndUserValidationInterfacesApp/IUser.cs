namespace UserAndUserValidationInterfacesApp
{
    public interface IUser
    {
        string Name { get; }
        string Password { get; }
        string Email { get; }
        string GetFullInfo();
    }
}
