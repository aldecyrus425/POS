using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Domain.Entities
{
    public class RolePermissions
    {
        public int RolePermissionId { get; private set; }
        public Roles Roles { get; private set; }
        public int RoleId { get; private set; }
        public Permissions Permissions { get; private set; }
        public int PermissionId { get; private set; }
    }
}
