﻿namespace Domain.Entities
{
    public abstract class BaseEntity <Tkey>
    {
        public Tkey Id { get; set; }
    }
}
