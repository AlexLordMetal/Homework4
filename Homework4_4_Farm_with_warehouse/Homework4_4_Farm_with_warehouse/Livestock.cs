namespace Homework4_4_Farm_with_warehouse
{
    class Livestock
    {
        public string Name { get; set; }
        public Product Production { get; set; }

        public Livestock(string name = "Default")
        {
            Name = name;
        }
    }
}
