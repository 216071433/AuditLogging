﻿namespace AuditLogging.Models
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string User { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
