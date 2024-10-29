using System;

namespace EvaluationBackend.Entities;

public class Section :BaseEntity<Guid>
{
    public string? Name { get; set; }

}


