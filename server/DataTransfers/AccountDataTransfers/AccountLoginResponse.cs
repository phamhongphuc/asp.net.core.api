namespace server.DataTransfers.AccountDataTransfers
{
    public class AccountLoginResponse
    {
        public AccountLoginResponse(string token) { Token = token; }

        public string Token { get; set; }
    }
}
