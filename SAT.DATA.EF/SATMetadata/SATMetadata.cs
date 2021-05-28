using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SAT.DATA.EF
{
    public class StudentMetadata
    {
        [Display(Name = "Student ID")]
        public int StudentId { get; set; }

        [StringLength(20, ErrorMessage = "value must be 20 characters or less")]
        [Required(ErrorMessage = "* First name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(20, ErrorMessage = "value must be 20 characters or less")]
        [Required(ErrorMessage = "* Last name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(15, ErrorMessage = "value must be 15 characters or less")]
        public string Major { get; set; }

        [StringLength(50, ErrorMessage = "value must be 50 characters or less")]
        public string Address { get; set; }

        [StringLength(25, ErrorMessage = "value must be 25 characters or less")]
        public string City { get; set; }

        [StringLength(2, ErrorMessage = "value must be 2 characters or less")]
        public string State { get; set; }

        [StringLength(10, ErrorMessage = "value must be 10 characters or less")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [StringLength(13, ErrorMessage = "value must be 13 characters or less")]
        public string Phone { get; set; }

        [StringLength(60, ErrorMessage = "value must be 60 characters or less")]
        [Required(ErrorMessage = "* Email is required")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "value must be 100 characters or less")]
        [Display(Name = "Image")]
        public string PhotoUrl { get; set; }

        [Range(0, int.MaxValue)]
        public int SSID { get; set; }

    }

    [MetadataType(typeof(StudentMetadata))]
    public partial class Student
    {
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }

    public class StudentStatusMetadata
    {
        public int SSID { get; set; }

        [StringLength(30, ErrorMessage = "value must be 30 characters or less")]
        [Required(ErrorMessage = "* Student Status is required")]
        [Display(Name = "Student Status")]
        public string SSName { get; set; }

        [StringLength(250, ErrorMessage = "value must be 250 characters or less")]
        [Display(Name = "Student Status Description")]
        [UIHint("MultilineText")]
        public string SSDescription { get; set; }
    }

    [MetadataType(typeof(StudentStatusMetadata))]
    public partial class StudentStatus
    {

    }

    public class CourseMetadata 
    {
        [Display(Name = "Course")]
        public int CourseId { get; set; }

        [StringLength(50, ErrorMessage = "value must be 50 characters or less")]
        [Required(ErrorMessage = "* Course Name is required")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }


        [Required(ErrorMessage = "* Course Description is required")]
        [Display(Name = "Course Description")]
        [UIHint("MultilineText")]
        public string CourseDescription { get; set; }

        [Range(0, 255)]
        [Required(ErrorMessage = "* Credit Hours are required")]
        [Display(Name = "Credit Hours")]
        public byte CreditHours { get; set; }

        [StringLength(250, ErrorMessage = "value must be 250 characters or less")]
        [UIHint("MultilineText")]
        public string Curriculum { get; set; }

        [StringLength(250, ErrorMessage = "value must be 250 characters or less")]
        [UIHint("MultilineText")]
        public string Notes { get; set; }

        [Required]
        [Display(Name = "Is Active?")]
        public bool IsActive { get; set; }
    }

    [MetadataType(typeof(CourseMetadata))]
    public partial class Course
    {

    }

    public class ScheduledClassMetadata
    {
        public int ScheduledClassId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int CourseId { get; set; }


        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "[-N/A-]")]
        [Required]
        [Display(Name = "Start date ")]
        public System.DateTime StartDate { get; set; }


        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "[-N/A-]")]
        [Required]
        [Display(Name = "End date")]
        public System.DateTime EndDate { get; set; }


        [StringLength(40, ErrorMessage = "value must be 40 characters or less")]
        [Required(ErrorMessage = "* Instructor Name is required")]
        [Display(Name = "Instructor Name")]
        public string InstructorName { get; set; }


        [StringLength(20, ErrorMessage = "value must be 20 characters or less")]
        [Required(ErrorMessage = "* Location is required")]
        public string Location { get; set; }


        [Range(0,int.MaxValue)]
        [Required(ErrorMessage = "* SCSID is required")]
        public int SCSID { get; set; }



    }

    [MetadataType(typeof(ScheduledClassMetadata))]
    public partial class ScheduledClass
    {
        public string Description { get { return StartDate.ToShortDateString() + ", " + InstructorName + ", " + Location + ". "; } }
    }

    public class EnrollmentMetadata
    {
        public int EnrollmentId { get; set; }


        [Required(ErrorMessage = "* Student ID is required")]
        [Display(Name = "Student ID")]
        public int StudentId { get; set; }


        [Required(ErrorMessage = "* Student Class ID is required")]
        [Display(Name = "Scheduled Class ID")]
        public int ScheduledClassId { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "[-N/A-]")]
        [Required]
        [Display(Name = "Enrollment Date")]
        public System.DateTime EnrollmentDate { get; set; }

    }

    [MetadataType(typeof(EnrollmentMetadata))]
    public partial class Enrollment
    {

    }

    public class ScheduledClassStatusMetadata
    {
        public int SCSID { get; set; }

        [StringLength(50, ErrorMessage = "value must be 50 characters or less")]
        [Required(ErrorMessage = "* Scheduled class status is required")]
        [Display(Name = "Class Status")]
        public string SCSName { get; set; }
    }

    [MetadataType(typeof(ScheduledClassStatusMetadata))]
    public partial class ScheduledClassStatus
    { }
}
