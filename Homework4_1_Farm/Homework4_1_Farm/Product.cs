namespace Homework4_1_Farm
{
    class Product
    {
        public string Name { get; set; }
        public int Weight { get; set; }

        public Product(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }
    }
}
