namespace MyBlogAdmin.Domain.Entities;

public class Tag
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    const int TagNameLength = 20;
    const int TagValueLength = 100;

    public Tag(string name, string value)
    {
        if (name.Length > TagNameLength)
        {
            throw new ArgumentException($"Name length must be {TagNameLength} characters or less.");
        }

        if (value.Length > TagValueLength)
        {
            throw new ArgumentException($"Value length must be {TagValueLength} characters or less.");
        }

        Id = Guid.NewGuid();
        Name = name;
        Value = value;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}