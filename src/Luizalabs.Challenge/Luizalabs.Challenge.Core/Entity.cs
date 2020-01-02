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
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
