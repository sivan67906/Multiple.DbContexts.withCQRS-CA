﻿namespace Multiple.DbContexts.Application.Common.DTOs;

public class ProductDTO {
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}