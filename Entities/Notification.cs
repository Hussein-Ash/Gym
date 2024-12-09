using System;
<<<<<<< HEAD
=======
using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> 6c75216 (Initial commit)

namespace EvaluationBackend.Entities;

public class Notification : BaseEntity<Guid>
{
    public Guid? SenderId { get; set; }
    public AppUser? Sender { get; set; }

<<<<<<< HEAD
    public Guid? ReseverId { get; set; }
    public AppUser? Resever { get; set; }
=======
    public Guid? UserId { get; set; }
    public AppUser? User { get; set; }
>>>>>>> 6c75216 (Initial commit)

    public string? Title { get; set; }
    public string? Body { get; set; }

<<<<<<< HEAD
=======

>>>>>>> 6c75216 (Initial commit)
    public Guid? RefrenceId { get; set; }
    public MessageTypeEnum Type { get; set; }

}
public enum MessageTypeEnum
{
    Problem
}