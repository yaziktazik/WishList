public class WishList
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsPrivate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public User User { get; set; }
    public List<WishListItem> WishListItems { get; set; }
}