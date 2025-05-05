using PT2.data.API;

namespace PT2.logic

{
    public class ItemDto: IItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        public ItemDto(int id, string name, string description, float price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}