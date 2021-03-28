using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WillieSandoval_2_28_2021.Models
{
    public static class MyEnumExtensions
    {
        public static string ToDescriptionString(this ProjectType val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }


    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [DisplayName("Type")]
        public ProjectType ProjectType { get; set; }

        [Required]
        [DisplayName("Difficulty")]
        public ProjectDifficulty ProjectDifficulty { get; set; }

        [DisplayName("Importance")]
        public ProjectImportance ProjectImportance { get; set; }

        [Required]
        [MaxLength(8000)]
        public string Details { get; set; }

        [Required]
        public Company Company { get; set; }

        [Required]
        public int CompanyId { get; set; }

        // Display date data field in the short format 11/12/08.
        // Also, apply format in edit mode.
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM}")]
        public DateTime Date { get; set; }


        #region NotMapped
        public IEnumerable<ProjectsTopics> ProjectsTopics { get; set; }

        public string TopicsStringWithDelimeter
        {
            get
            {
                string topicStringWithDelimeter;
                StringBuilder sb = new StringBuilder();
                foreach (ProjectsTopics pt in ProjectsTopics)
                {
                    sb.Append(pt.Topic.Name + ", ");
                }

                //if (ProjectsTopics.Count() > 1)
                //    topicStringWithDelimeter = sb.ToString().Substring(0, sb.ToString().Length - 2);
                //else
                //    topicStringWithDelimeter = sb.ToString();
                topicStringWithDelimeter = sb.ToString().Substring(0, sb.ToString().Length - 2);

                return topicStringWithDelimeter;
            }
        }

        public string GetProjectType
        {
            get
            {
                return MyEnumExtensions.ToDescriptionString(ProjectType);
            }
        }
        #endregion
    }

    public enum ProjectType
    {
        [Description("Bug Fix")]
        BugFix = 1,
        [Description("New .NET Webforms Website")]
        NewDotNETWebformsWebsite = 2,
        [Description("New .NET MVC Website")]
        NewDotNETMVCWebsite = 3,
        [Description("New .NET CORE MVC Website")]
        NewDotNETCOREMVCWebsite = 4,
        [Description("New classic ASP Website")]
        NewClassicASPWebsite = 5,
        [Description("New .NET Winforms")]
        NewDotNETWinforms = 6,
        [Description("New Feature")]
        NewFeature = 7,
        [Description("New Project")]
        NewProject = 8,
        [Description("Teach/Mentor")]
        TeachMentor = 9,
        [Description("Other")]
        Other = 10
    }

    public enum ProjectDifficulty
    {
        Beginner = 1,
        Intermediate = 2,
        Advanced = 3
    }

    public enum ProjectImportance
    {
        Low = 1,
        Medium = 2,
        High = 3
    }
}
