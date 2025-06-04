namespace UserAuthApp.Common;

public static class Messages
{
    public static string LoginSuccessful => "Login successful";
    public static string UserLoggedIn(string email) => "User {0} logged in";
    public static string InvalidCredentials => "Invalid email or password";
}
