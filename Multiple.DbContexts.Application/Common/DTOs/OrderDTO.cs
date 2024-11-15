namespace Multiple.DbContexts.Application.Common.DTOs;
public class OrderDTO
{
    public int Id { get; set; }
    public string? OrderName { get; set; }
    public DateTime OrderDate { get; set; }
    public string? ProductName { get; set; }
    public int ProductQuantity { get; set; }
    public decimal ProductPrice { get; set; }
}