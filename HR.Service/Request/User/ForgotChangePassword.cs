namespace HR.Service.Request.User
{
    public class ForgotChangePassword
    {
        public Guid AuthKey { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordRepeat { get; set; }
    }
}
