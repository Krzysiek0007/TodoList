using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Start time")]
        public DateTime StartTime { get; set; }

        [Display(Name = "End time")]
        public DateTime EndTime { get; set; }

        //public virtual ApplicationUser User { get; set; }
    }
}
