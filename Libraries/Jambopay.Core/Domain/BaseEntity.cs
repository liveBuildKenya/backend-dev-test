using System;

namespace Jambopay.Core.Domain
{
    /// <summary>
    /// Represents the Base entity properties
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the date and time of entity creation
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}
