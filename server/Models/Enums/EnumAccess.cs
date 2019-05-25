using System;

namespace server.Models.Enums
{
    [Flags]
    public enum EnumAccess : int
    {
        Administrator = 1,
        Moderator = 2,
        NormalUser = 4,
        BannedUser = 8
    }
}
