using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Models.Enums;

namespace server.DataTransfers.AccountDataTransfers
{
    public class AccountIdResponse : BaseDataTransfers<Account, AccountIdResponse>
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
