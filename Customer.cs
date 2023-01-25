using System;
using System.Collections.Generic;

namespace SkiStoreProject;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public string Telefon { get; set; } = null!;

    public DateTime? Birthday { get; set; }

    public virtual ICollection<Article> Articles { get; } = new List<Article>();
}
