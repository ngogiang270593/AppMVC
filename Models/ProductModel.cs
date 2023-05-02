namespace LearnAspNet.Models;

public class ProductModel
{
    public int ID {get;set;}
    public string Name {get;set;}
    public double Price {get;set;}

    public ProductModel(int ID,string Name,double Price)
    {
        this.ID = ID;
        this.Name = Name;
        this.Price = Price;
    }
}
