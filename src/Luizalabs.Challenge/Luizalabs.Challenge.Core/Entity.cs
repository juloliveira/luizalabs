using System;
using System.Collections.Generic;
using System.Text;

namespace Luizalabs.Challenge.Core
{
    public abstract class Entity
    {
        public Entity()
        {
            CreatedAt = UpdatedAt = DateTime.UtcNow;
        }

        public long Id { get; set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public void Update()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
