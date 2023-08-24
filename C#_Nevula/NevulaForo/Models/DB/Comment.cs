﻿using System;
using System.Collections.Generic;

namespace NevulaForo.Models.DB;

public partial class Comment
{
    public int Id { get; set; }

    public int IdPublication { get; set; }

    public int IdUser { get; set; }

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime? DeletedAt { get; set; }

    public virtual Publication IdPublicationNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}