namespace MyBlogAdmin.Domain.Entities;

// define content type enum to distinguish between different types of article, content blocks, etc.
internal enum EntityType
{
    Article,
    Block,
}

public class Article
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Block[] Content { get; set; }
    public EntityType Type { get; set; } = EntityType.Article;
    public Tag[] Tags { get; set; } = Array.Empty<Tag>();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    const int TitleLength = 100;
    const int ContentLength = 100000;

    public Article(string title, ContentBlock[] content, Tag[] tags)
    {
        if (title.Length > TitleLength)
        {
            throw new ArgumentException($"Title length must be {TitleLength} characters or less.");
        }

        if (content.Length > ContentLength)
        {
            throw new ArgumentException($"Content length must be {ContentLength} characters or less.");
        }

        Title = title;
        Content = content.Select(c => new Block(c.Content)).ToArray();
        Tags = tags;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}