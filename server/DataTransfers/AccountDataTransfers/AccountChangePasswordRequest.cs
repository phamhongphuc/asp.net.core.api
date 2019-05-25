namespace server.DataTransfers.AccountDataTransfers
{
    public class AccountChangePasswordRequest
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}
