namespace Homework4_3_Farm_with_areaconditions_and_moves
{
    class Product
    {
        public string Name { get; set; }
        public int Weight { get; set; }

        public Product(string name="Default", int weight = 0)
        {
            Name = name;
            Weight = weight;
        }
    }
}
