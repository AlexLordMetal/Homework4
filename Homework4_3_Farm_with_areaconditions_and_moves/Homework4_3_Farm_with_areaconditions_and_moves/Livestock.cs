namespace Homework4_3_Farm_with_areaconditions_and_moves
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
