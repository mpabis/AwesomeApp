using System;
using AwesomeApp.SharedKernel;

namespace AwesomeApp.Core.ProjectAggregate
{
    public class AuditEntry : BaseEntity
    {
        public DateTime DateTime { get; set; }
        public string Entry { get; set; } = string.Empty;
    }
}
