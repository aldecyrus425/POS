using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Domain.Entities
{
    public class SystemSettings
    {
        public int SystemSettingsId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
    }
}
