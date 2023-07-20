namespace ORM_Dapper;

public class Product
{
    public int ProductID { get; set; }
    
    public string Name { get; set; }
    
    public int StockLevel { get; set; }
    public decimal Price { get; set; }
}