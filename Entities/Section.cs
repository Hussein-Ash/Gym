using System;

namespace EvaluationBackend.Entities;

<<<<<<< HEAD
public class Section :BaseEntity<Guid>
{
    public string? Name { get; set; }

=======
public class Section : BaseEntity<Guid>
{
    public string? Name { get; set; }

    public ICollection<Course>? CourseName { get; set; }

    public ICollection<Subscription>? Subscriptions { get; set; }

>>>>>>> 6c75216 (Initial commit)
}


