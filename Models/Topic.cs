using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WillieSandoval_2_28_2021.Models
{
    public class Topic
    {
        public Topic()
        {
        }

        public Topic(int TopicId)
        {
            this.TopicId = TopicId;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TopicId { get; set; }

        // Applying DisplayFormatAttribute
        // Display the text [Null] when the data field is empty.
        // Also, convert empty string to null for storing.
        [Required]
        [MaxLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "[Null]")]
        [DisplayName("Topics")]
        public string Name { get; set; }


        public IEnumerable<ProjectsTopics> ProjectsTopics { get; set; }
    }
}
