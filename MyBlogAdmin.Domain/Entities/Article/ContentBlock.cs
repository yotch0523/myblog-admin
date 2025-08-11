namespace MyBlogAdmin.Domain.Entities;

public class Block
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public EntityType Type { get; set; } = EntityType.ContentBlock;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    const int ContentLength = 100000;

    public Guid? Block(string content)
    {
        if (content.Length > ContentLength)
        {
            throw new ArgumentException($"Content length must be {ContentLength} characters or less.");
        }

        if (string.IsNullOrWhiteSpace(content))
        {
            return null;
        }

        Id = Guid.NewGuid();
        Content = System.Net.WebUtility.HtmlEncode(content);
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;

        return Id;
    }
}

private interface IBlockHtmlRenderer
{ 
    RenderResult Render(string markdown);
}