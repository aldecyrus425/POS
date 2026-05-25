using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Domain.Entities
{
    public class Permissions
    {
        public int PermissionId { get; private set; }
        public string Code { get; private set; } // CREATE_SALE, VOID_SALE, EDIT_PRODUCT, ADJUST_STOCK
        public string Description { get; private set; } = string.Empty;
    }
}
