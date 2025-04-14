namespace PT2.data.API.model;

public interface IItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
}