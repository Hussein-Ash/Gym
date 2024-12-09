using System;
<<<<<<< HEAD
=======
using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> 6c75216 (Initial commit)

namespace EvaluationBackend.Entities;

public class Set : BaseEntity<Guid>
{
<<<<<<< HEAD
    public string? Sets { get; set; }
=======
    public string? Name { get; set; }

    public Guid? SetId { get; set; }
    [ForeignKey(nameof(SetId))]
    public Set? ExerciseSet { get; set; }
>>>>>>> 6c75216 (Initial commit)
}
