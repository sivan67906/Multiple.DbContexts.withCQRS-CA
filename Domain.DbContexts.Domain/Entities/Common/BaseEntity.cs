﻿namespace Domain.DbContexts.Domain.Entities.Common;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}
