namespace UserBlogSite.Queries
{
    public static class UserQueries
    {
        public static string UserRegister = @"insert into dbo.UserDetails(UserName, EmailId, PasswordHash) 
                                                values(@UserName, @UserEmail, @Password)";

        public static string UserLogin = @"select UserId, UserName, EmailId as UserEmail, PasswordHash as Password from UserDetails where EmailId = @UserEmail";

        public static string CheckUserExists = @"select * from UserDetails where EmailId = @UserEmail";
    }
}
