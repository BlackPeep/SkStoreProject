using System;
using System.Collections.Generic;

namespace SkiStoreProject;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Article> Articles { get; } = new List<Article>();
}
