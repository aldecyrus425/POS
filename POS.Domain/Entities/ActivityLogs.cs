using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Domain.Entities
{
    public class ActivityLogs
    {
        public int ActivityLogId { get; private set; }
        public Users Users { get; private set; }
        public int UserId { get; private set; }
        public string Activity { get; private set; }
        public DateTime CreatedAt { get; private set; }

    }
}
