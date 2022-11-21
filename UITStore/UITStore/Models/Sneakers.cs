namespace UITStore.Models
{
    public class Sneakers
    {
        public string sneakerId { get; set; }
        public string img { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public double saleprice { get; set; }
        public string description { get; set; }
        public string size { get; set; }
        public int stock { get; set; }
        public string category { get; set; }
        public double discount {  get; set;}
        public double rating { get; set; } = 5;
        
        public Sneakers(string sneakerId, string name, string img, double price, double saleprice, string description, string size, int stock, string category)
        {
            this.sneakerId = sneakerId;
            this.name = name;
            this.img = img;
            this.price = price;
            this.saleprice = saleprice;
            this.description = description;
            this.size = size;
            this.stock = stock;
            this.category = category;
            this.discount = (1 - (this.saleprice/ this.price))*100;
        }
        
    }
}