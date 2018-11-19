namespace Homework4_4_Farm_with_warehouse
{
    class Product
    {
        public string Name { get; set; }
        public int Weight { get; set; }

        public Product(string name="Default", int weight = 1)
        {
            Name = name;
            Weight = weight;
        }
    }
}
