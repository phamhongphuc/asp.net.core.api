using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Models.Enums;

namespace server.DataTransfers.AccountDataTransfers
{
    public class AccountLoginResponse
    {
        public string Token { get; set; }
    }
}
