public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int PermissionId { get; set; }
    public Permission Permission { get; set; }
    public List<User> Users { get; set; }
}