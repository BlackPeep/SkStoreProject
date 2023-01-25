using System;
using System.Collections.Generic;

namespace SkiStoreProject.DbModels;

public partial class CustomerArticle
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int? ArticleId { get; set; }

    public virtual Article? Article { get; set; }

    public virtual Customer? Customer { get; set; }
}
