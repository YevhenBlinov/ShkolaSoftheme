namespace UserAndUserValidationInterfacesApp
{
    interface IValidator
    {
        void ValidateUser(IUser user, string nameOrEmail, string password);
    }
}
