using System.ComponentModel.DataAnnotations;

namespace LibraryWithCustomAttributeConsoleApp
{
    public class OnlyForViewingAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            ErrorMessage = "Sorry, but you can't take books.";
            return false;
        }
    }
}
