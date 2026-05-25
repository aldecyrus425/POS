using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Domain.Entities
{
    public class AuditLogs
    {
        public int AuditLogId { get; private set; }
        public Users Users { get; private set; }
        public int UserId { get; private set; }
        public string Action { get; private set; }
        public string TableName { get; private set; }
        public string OldValues { get; private set; }
        public string NewValues { get; private set; }
        public string IPAddress { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
