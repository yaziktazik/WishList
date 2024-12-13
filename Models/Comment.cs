public class Comment
{
    public int Id { get; set; }
    public int WishListItemId { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public WishListItem WishListItem { get; set; }
    public User User { get; set; }
}