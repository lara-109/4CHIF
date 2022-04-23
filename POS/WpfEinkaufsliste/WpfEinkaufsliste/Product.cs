namespace WpfEinkaufsliste
{
    public class Product
    {
        public Product(string name, Category category)
        {
            this.Name = name;
            this.Category = category;
        }

        public Category Category { get; set; }

        public string Name { get; set; }
    }
}