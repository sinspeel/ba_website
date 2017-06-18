using System.ComponentModel.DataAnnotations;

namespace ba_website.model
{
    public interface IEntity
    {
        [Key]
        long Id { get; set; }
    }
}
