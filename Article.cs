using System;
using System.Collections.Generic;

namespace SkiStoreProject;

public partial class Article
{
    public int Id { get; set; }

    public string Number { get; set; } = null!;

    public string? Description { get; set; }

    public decimal PricePerDay { get; set; }

    public int? Counter { get; set; }

    public bool Available { get; set; }

    public int? CategoryId { get; set; }

    public int? CustomerId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Customer? Customer { get; set; }
}
