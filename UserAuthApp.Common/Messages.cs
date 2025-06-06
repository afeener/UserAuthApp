namespace UserAuthApp.Common;

public static class Messages
{
    public static string LoginSuccessful => "Login successful";
    public static string UserLoggedIn(string email) => $"User {email} logged in";
    public static string InvalidCredentials => "Invalid email or password";
    public static string PasswordChanged => "Password changed";
    public static string PasswordNotChanged => "Unable to change password";
}
