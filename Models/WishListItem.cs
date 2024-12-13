public class WishListItem
{
    public int Id { get; set; }
    public int WishListId { get; set; }
    public int ItemId { get; set; }
    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public WishList WishList { get; set; }
    public Item Item { get; set; }
    public List<Comment> Comments { get; set; }
}