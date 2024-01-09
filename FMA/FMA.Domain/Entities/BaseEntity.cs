using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; private set; } = string.Empty;
        public DateTime CreatedDate { get; private set; }
        public string LastModifiedBy { get; private set; } = string.Empty;
        public DateTime LastModifiedDate { get; private set; }

        public BaseEntity()
        {
            AddAuditable();
        }

        private void AddAuditable()
        {
            CreatedDate = DateTime.Now;
            LastModifiedDate = DateTime.Now;

        }
    }
}
