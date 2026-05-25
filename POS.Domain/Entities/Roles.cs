using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Domain.Entities
{
    public class Roles
    {
        public int RoleId { get; private set; }
        public string RoleName { get; private set; } //Owner, Admin, Cashier
        public string RoleDescription { get; private set; } = string.Empty;
    }
}
