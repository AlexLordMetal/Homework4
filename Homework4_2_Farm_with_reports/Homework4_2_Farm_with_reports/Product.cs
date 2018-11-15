namespace Homework4_2_Farm_with_reports
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
