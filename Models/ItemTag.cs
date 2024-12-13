public class ItemTag
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public int TagId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Item Item { get; set; }
    public Tag Tag { get; set; }
}