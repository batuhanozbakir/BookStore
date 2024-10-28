﻿namespace BookStore.WebApp.Context.Entities.Abstract
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool ısActive { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? Updated { get; set; } 
        public DateTime? Deleted { get; set; }
        public bool IsDeleted { get; set; }
    }
}
