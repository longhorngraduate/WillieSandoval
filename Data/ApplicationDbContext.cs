using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WillieSandoval_2_28_2021.Models;

namespace WillieSandoval_2_28_2021.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());

            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<ProjectsTopics> ProjectsTopics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Project>()
            //    .HasMany<Topic>(p => p.Topics)
            //    .WithMany(t => t.Projects)
            //    .Map(cs =>
            //    {
            //        cs.MapLeftKey("ProjectRefId");
            //        cs.MapRightKey("CourseRefId");
            //        cs.ToTable("ProjectCourse");
            //    });

            modelBuilder.Entity<ProjectsTopics>()
        .HasKey(pt => new { pt.ProjectId, pt.TopicId });

            modelBuilder.Entity<ProjectsTopics>()
                .HasOne(pt => pt.Project)
                .WithMany(p => p.ProjectsTopics)
                .HasForeignKey(pt => pt.ProjectId);

            modelBuilder.Entity<ProjectsTopics>()
                .HasOne(pt => pt.Topic)
                .WithMany(t => t.ProjectsTopics)
                .HasForeignKey(pt => pt.TopicId);


            var companies = new Company[]
            {
                new Company{
                    CompanyId=1,
                    Name="Personal Project",
                    Location="N/A",
                    JobTitle="N/A",
                    Description="Personal Project",
                    PayType=null,
                    Display=false
                },
                new Company{
                    CompanyId=2,
                    Name="Paid Work",
                    Location="N/A",
                    JobTitle="N/A",
                    Description="Paid work I completed for others",
                    PayType=null,
                    Display=false
                },
                new Company{
                    CompanyId=3,
                    Name="Austin Logistics",
                    Location="Austin, TX",
                    JobTitle="Intern - QA",
                    Description=@"  <ul>
                                        <li>SUMMARY:
                                            <ul>
                                                <li>Intership position to help test and document the software and user experience</li>
                                                <li>Worked under QA and IT managers</li>
                                            </ul>
                                        </li>
                                        <li>ABOUT POSITION:
                                            <ul>
                                                <li>Observed and documented how users without previous knowledge, including me, interacted with the software components</li>
                                                <li>Made suggestions to help improve software</li>
                                                <li>Manually ran black box tests on software</li>
                                                <li>Reported logic and runtime errors on Jira</li>
                                                <li>Created test plans for Software Developers</li>
                                                <li>Created documentation for Sales</li>
                                                <li>Ran regression tests</li>
                                            </ul>
                                        </li>
                                    </ul>",
                    PayStart=10,
                    PayEnd=12,
                    PayType = PayType.Hour,
                    DateStart=DateTime.Parse("2006-07-01"),
                    DateEnd=DateTime.Parse("2007-07-01"),
                    Display=true
                },
                new Company{
                    CompanyId=4,
                    Name="Powered",
                    Location="Austin, TX",
                    JobTitle="Intern - QA",
                    Description=@"  <ul>
                                        <li>SUMMARY:
                                            <ul>
                                                <li>Powered is a company that creates FAQ/tutorial content for other companies and publishes the customer-specific content on the companies' websites.</li>
                                                <li>Intership position to help test websites</li>
                                                <li>Worked under QA manager</li>
                                            </ul>
                                        </li>
                                        <li>ABOUT POSITION:
                                            <ul>
                                                <li>Manually ran tests on customers' websites</li>
                                                <li>Reported logic and runtime errors on Jira</li>
                                                <li>Created test plans for QA</li>
                                                <li>Ran regression tests</li>
                                            </ul>
                                        </li>
                                    </ul>",
                    PayStart=15,
                    PayEnd=17,
                    PayType = PayType.Hour,
                    DateStart=DateTime.Parse("2007-07-01"),
                    DateEnd=DateTime.Parse("2008-11-01"),
                    Display=true
                },
                new Company{
                    CompanyId=5,
                    Name="Optimal Blue",
                    Location="Plano, TX",
                    JobTitle="Contract - Software Developer",
                    Description=@"  <ul>
                                        <li>SUMMARY:
                                            <ul>
                                                <li>Contract position for C# programming</li>
                                                <li>Worked under Lead Developers, IT Manager, and business owners</li>
                                            </ul>
                                        </li>
                                        <li>ABOUT POSITION:
                                            <ul>
                                                <li>Used C#, XML, and regular expressions to traverse through webpages in order to capture and validate data</li>
                                            </ul>
                                        </li>
                                    </ul>",
                    PayStart=25,
                    PayEnd=25,
                    PayType = PayType.Hour,
                    DateStart=DateTime.Parse("2009-06-01"),
                    DateEnd=DateTime.Parse("2009-11-01"),
                    Display=true
                },
                new Company{
                    CompanyId=6,
                    Name="Hedge Hog Capital",
                    Location="Remotely",
                    JobTitle="Contract - Software Developer",
                    Description=@"  <ul>
                                        <li>SUMMARY:
                                            <ul>
                                                <li>Hedge Hog Capital is a hedge fund in Atlanta, GA.</li>
                                                <li>Contract position as sole software developer to create new C# software</li>
                                                <li>Created algorithms to predict and analyze stock market behaviour</li>
                                                <li>Main goal was to help improve the hedge fund's algorithms</li>
                                                <li>Secondary goal was to notify the user of the exact time/date to buy/sell</li>
                                                <li>Reported to business owner</li>
                                            </ul>
                                        </li>
                                        <li>ABOUT POSITION:
                                            <ul>
                                                <li>Gathered functional requirements from non-programmer (business owner) in order to conceptualize, design, develop, and test programs and algorithms</li>
                                                <li>Created C# proof-of-concept software to implement algorithms that consisted of many functions (data points) on a graph</li>
                                                <li>Proof-of-concept read data from Excel files, plotted by date and functions' data points</li>
                                                <li>Each algorithm was triggered to run using .NET Winform's buttons</li>
                                                <li>Key Words: .NET Framework, C#, SQL</li>
                                            </ul>
                                        </li>
                                    </ul>",
                    PayStart=10,
                    PayEnd=20,
                    PayType = PayType.Hour,
                    DateStart=DateTime.Parse("2010-07-01"),
                    DateEnd=DateTime.Parse("2011-03-01"),
                    Display=true
                },
                new Company{
                    CompanyId=7,
                    Name="iProspect (Range Online Media)",
                    Location="Fort Worth, TX",
                    JobTitle="Intern - Web Developer",
                    Description=@"  <ul>
                                        <li>SUMMARY:
                                            <ul>
                                                <li>Internship position for C# and ASP.NET programming</li>
                                                <li>Worked under Lead Developer and IT Manager</li>
                                            </ul>
                                        </li>
                                        <li>ABOUT POSITION:
                                            <ul>
                                                <li>Agile Environment</li>
                                                <li>Gathered functional requirements from programmers and project manager in order to design and develop websites</li>
                                                <li>Made improvements to front and backend on existing website</li>
                                                <li>Made IIS changes</li>
                                                <li>Created drag-and-drop website using ASP.NET</li>
                                                <li>Key Words: .NET Framework, C#, ASP.NET, IIS, .htaccess and php .ini configurations</li>
                                            </ul>
                                        </li>
                                    </ul>",
                    PayStart=10,
                    PayEnd=12,
                    PayType = PayType.Hour,
                    DateStart=DateTime.Parse("2011-03-01"),
                    DateEnd=DateTime.Parse("2011-06-01"),
                    Display=true
                },
                new Company{
                    CompanyId=8,
                    Name="NexPay Inc (Talon)",
                    Location="Dallas, TX",
                    JobTitle="Software Developer",
                    Description=@"  <ul>
                                        <li>SUMMARY:
                                            <ul>
                                                <li>Full-time position as SoftWare and Web Developer with C#, VB.NET, VB6, and front-end programming</li>
                                                <li>Worked under Lead Developer</li>
                                            </ul>
                                        </li>
                                        <li>ABOUT POSITION:
                                            <ul>
                                                <li>Created reports by massaging data from delimited and flat files</li>
                                                <li>Created reports by developing dynamic programs in C# and VB.NET that used regular expressions to traverse through websites to gather data</li>
                                                <li>Suggested solutions to payment errors by analyzing data</li>
                                                <li>Key Words: C#, VB.NET, VB6, Delimited Files, Flat Files, Windows PowerShell</li>
                                            </ul>
                                        </li>
                                    </ul>",
                    PayStart=40000,
                    PayEnd=45000,
                    PayType = PayType.Year,
                    DateStart=DateTime.Parse("2011-07-01"),
                    DateEnd=DateTime.Parse("2012-11-01"),
                    Display=true
                },
                new Company{
                    CompanyId=9,
                    Name="MRN3",
                    Location="Remotely",
                    JobTitle="Software Developer",
                    Description=@"  <ul>
                                        <li>SUMMARY:
                                            <ul>
                                                <li>Full-time remote position</li>
                                                <li>Worked under Lead Developer and CTO</li>
                                                <li>Minimal supervision after my 2nd year there</li>
                                            </ul>
                                        </li>
                                        <li>ABOUT POSITION:
                                            <ul>
                                                <li>Involved in all stages of programming life cycle</li>
                                                <li>Developed 3 websites on front and back end</li>
                                                <li>Developed intricate SQL queries for reports (optimization)</li>
                                                <li>Created complex mathematical calculations (complex algorithms in VBScript)</li>
                                                <li>Tutored new programmer in order to fill my position</li>
                                                <li>Key Words: Agile, VBScript (classic ASP), SQL, TSQL, JS, JQuery, AJAX, CSS, Semantic UI</li>
                                            </ul>
                                        </li>
                                    </ul>",
                    PayStart=55000,
                    PayEnd=65000,
                    PayType = PayType.Year,
                    DateStart=DateTime.Parse("2012-11-01"),
                    DateEnd=DateTime.Parse("2018-02-01"),
                    Display=true
                },
                new Company{
                    CompanyId=10,
                    Name="PPDocs",
                    Location="Arlington, TX",
                    JobTitle="Software Developer",
                    Description=@"  <ul>
                                        <li>SUMMARY:
                                            <ul>
                                                <li>Full-time .NET position as Software Developer</li>
                                                <li>Worked under IT Manager, CTO, and Lead Software Developer. Reported primarily to IT Manager.</li>
                                                <li>""No Red Tape"" environment where I was involved in all projects, no limitations</li>
                                                <li>Worked independantly and as part of a group</li>
                                                <li>Not micromanaged (trusted with designs, time-management, to meet deadlines, and having flawless results)</li>
                                                <li>Minimal to no supervision</li>
                                            </ul>
                                        </li>
                                        <li>ABOUT POSITION:
                                            <ul>
                                                <li>Created new features to .NET Webforms and .NET Winforms</li>
                                                <li>Created a new .NET MVC website for our new accounting system</li>
                                                <li>Created software to facilitate day-to-day operations</li>
                                                <li>Created a new revenue stream</li>
                                                <li>Created and enhanced reports</li>
                                                <li>Diagnosed and implemented solutions to runtime & logic errors on front & backend</li>
                                                <li>Delegated tasks to and tutored intermediate-level programmer</li>
                                                <li>Key Words: Agile/Spiral/Waterfall models, .NET MVC, .NET Web and Win Forms, C#, VB.NET, Web.Config, Design Patterns, TDD, SQL, TSQL, XML, JS, JQuery, JQuery Datatables, AJAX, Bootstrap, CSS (Mobile First), Spire.PDF (OCR Software), Lead Tools (OCR Software), BootBox (UI Library), Toastr (UI Library), Intro.js (lightweight onboarding tour library)</li>
                                            </ul>
                                        </li>
                                    </ul>",
                    PayStart=80000,
                    PayEnd=115000,
                    PayType = PayType.Year,
                    DateStart=DateTime.Parse("2018-09-05"),
                    DateEnd=DateTime.Parse("2020-09-04"),
                    Display=true
                }
            };


            var topics = new Topic[]
            {
                new Topic{
                    TopicId=1,
                    Name="Agile"
                },
                new Topic{
                    TopicId=2,
                    Name="Waterfall"
                },
                new Topic{
                    TopicId=3,
                    Name="Spiral"
                },
                new Topic{
                    TopicId=4,
                    Name="TDD"
                },
                new Topic{
                    TopicId=5,
                    Name="Design Patterns"
                },
                new Topic{
                    TopicId=6,
                    Name=".NET MVC"
                },
                new Topic{
                    TopicId=7,
                    Name=".NET Core"
                },
                new Topic{
                    TopicId=8,
                    Name=".NET Webforms"
                },
                new Topic{
                    TopicId=9,
                    Name=".NET Winforms"
                },
                new Topic{
                    TopicId=10,
                    Name="C#"
                },
                new Topic{
                    TopicId=11,
                    Name="VB.NET"
                },
                new Topic{
                    TopicId=12,
                    Name="VBScript"
                },
                new Topic{
                    TopicId=13,
                    Name="SQL"
                },
                new Topic{
                    TopicId=14,
                    Name="TSQL"
                },
                new Topic{
                    TopicId=15,
                    Name="JS/JQuery"
                },
                new Topic{
                    TopicId=16,
                    Name="JQuery Datatables"
                },
                new Topic{
                    TopicId=17,
                    Name="CSS"
                },
                new Topic{
                    TopicId=18,
                    Name="CSS (mobile first)"
                },
                new Topic{
                    TopicId=19,
                    Name="XML"
                },
                new Topic{
                    TopicId=20,
                    Name="JSON"
                },
                new Topic{
                    TopicId=21,
                    Name="AJAX"
                },
                new Topic{
                    TopicId=22,
                    Name="Web Services"
                },
                new Topic{
                    TopicId=23,
                    Name="3rd Party Library"
                },
                new Topic{
                    TopicId=24,
                    Name="OCR"
                },
                new Topic{
                    TopicId=25,
                    Name="JS Libraries"
                }
            };


            //The seed entity for entity type 'Project' cannot be added because it has the navigation 'Company' set. To seed relationships you need to add the related entity seed to 'Company' and specify the foreign key values {'CompanyId'}. Consider using 'DbContextOptionsBuilder.EnableSensitiveDataLogging' to see the involved property values.
            var projects = new Project[]
            {
                new Project
                {
                    ProjectId=1,
                    ProjectType=ProjectType.NewDotNETCOREMVCWebsite,
                    ProjectDifficulty=ProjectDifficulty.Intermediate,
                    ProjectImportance=ProjectImportance.High,
                    Description="WillieSandoval.com",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>Created this website to display my portfolio, list of projects and previous employers, and share my knowledge with others</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:  None</li>
                                    <li>PROBLEMS/ISSUES:
                                        <ul>
                                            <li>Seeding DB.  Using DBInitializer and context.Database.EnsureCreated(); at startup only ran once, not per migration</li>
                                        </ul>
                                    </li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>Went with OnModelCreating() to seed DB per migration</li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>.NET CORE</li>
                                            <li>Seeding DB</li>
                                            <li>Dependency Injection</li>
                                            <li>SOLID Principal</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:
                                        <ul>
                                            <li><a href=""../SampleCodeCSharp/RepositoryPatternWithGenericsInDotNETCore"">Repository Pattern With Generics In .NET Core</a></li>
                                            <li><a href=""https://github.com/longhorngraduate/WillieSandoval"">WillieSandoval.com on GitHub</a></li>
                                        </ul>
                                    </li>
                                </ul>",
                    CompanyId=companies[0].CompanyId,
                    Date=DateTime.Parse("2021-03-01")
                },
                new Project
                {
                    ProjectId=2,
                    ProjectType=ProjectType.NewDotNETMVCWebsite,
                    ProjectDifficulty=ProjectDifficulty.Beginner,
                    ProjectImportance=ProjectImportance.Low,
                    Description="DFWAirConditioningExperts.com",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>Created this website for a new HVAC servicing business a friend and I started</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:
                                        <ul>
                                            <li>Automate everything so I don't have to spend time on this in the future</li>
                                            <li>SEO optimized</li>
                                            <li>Ads</li>
                                        </ul>
                                    </li>
                                    <li>PROBLEMS/ISSUES:  None</li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>Hired Customer Service Rep and HVAC Technicians</li>
                                            <li>Customer Service Rep will answer all phone calls, IMs, and customer surveys and complaints</li>
                                            <li>Customer Service Rep will keep in constant communication with the manager and Lead HVAC Technician</li>
                                            <li>My friend (manager) and Lead HVAC Tech will take care of day-to-day operations</li>
                                            <li>Work on SEO and advertisements on the weekends</li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>.NET MVC</li>
                                            <li>CSS (Mobile First)</li>
                                            <li>SEO</li>
                                            <li>Google Analytics</li>
                                            <li>Google Ads</li>
                                            <li>Facebook, Yelp, and Craigslist Ads</li>
                                            <li>Tidio (integrated chat)</li>
                                            <li>Flickity</li>
                                            <li>FlexSlider</li>
                                            <li>Interviewing people for the Customer Service Rep and HVAC Technician positions</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:
                                        <ul>
                                            <li><a href=""https://github.com/longhorngraduate/DFWAirConditioningExperts"">DFWAirConditioningExperts.com on GitHub</a></li>
                                        </ul>
                                    </li>
                                </ul>",
                    CompanyId=companies[1].CompanyId,
                    Date=DateTime.Parse("2021-02-01")
                },
                new Project
                {
                    ProjectId=3,
                    ProjectType=ProjectType.NewDotNETMVCWebsite,
                    ProjectDifficulty=ProjectDifficulty.Intermediate,
                    ProjectImportance=ProjectImportance.Low,
                    Description="ParentAgent.com",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>Created this website for a friend for his new tutoring business</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:
                                        <ul>
                                            <li>Create FB login</li>
                                            <li>Enable Parents to log in</li>
                                            <li>Allow Parents to enter their personal info, their children, and their children's classes</li>
                                            <li>Create notifications to admins when new parent registers</li>
                                        </ul>
                                    </li>
                                    <li>PROBLEMS/ISSUES:  None</li>
                                    <li>SOLUTION:  None</li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>.NET MVC</li>
                                            <li>CSS Template</li>
                                            <li>LINQ</li>
                                            <li>.NET Identity (FB Login, User Roles)</li>
                                            <li>Did not apply design patterns nor SOLID principal because limited programming time</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:
                                        <ul>
                                            <li><a href=""https://github.com/longhorngraduate/ParentAgent"">ParentAgent.com on GitHub</a></li>
                                        </ul>
                                    </li>
                                </ul>",
                    CompanyId=companies[1].CompanyId,
                    Date=DateTime.Parse("2020-12-01")
                },
                new Project{
                    ProjectId=4,
                    ProjectType=ProjectType.NewDotNETMVCWebsite,
                    ProjectDifficulty=ProjectDifficulty.Advanced,
                    ProjectImportance=ProjectImportance.High,
                    Description="Accounting website",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>Old Accounting system had timeouts and runtime errors, had to be repaird or replaced</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:
                                        <ul>
                                            <li>Agile method to work with two other programmers to create a new .NET MVC website with new UI and models</li>
                                            <li>Transfer data from old DB to new</li>
                                            <li>Create new model structure</li>
                                            <li>Assist mid-level programmer with front end</li>
                                            <li>Use JQuery Datatables</li>
                                            <li>Use AJAX for web services to update tables dynamically</li>
                                            <li>Add custom JQuery</li>
                                        </ul>
                                    </li>
                                    <li>PROBLEMS/ISSUES:  None</li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>Took it day-by-day/sprint-by-sprint to solve all issues</li>
                                            <li>Transferred data between old and new tables using TSQL in order to begin using code first migrations</li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>.NET MVC</li>
                                            <li>TSQL to transfer data between old and new DB</li>
                                            <li>Model Creation</li>
                                            <li>Code First Migrations</li>
                                            <li>Delegating tasks</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:
                                        <ul>
                                            <li><a href=""../SampleCodeFrontEnd/JQueryDatatables"">JQuery Datatables</a></li>
                                        </ul>
                                    </li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-08-01")
                },
                new Project{
                    ProjectId=5,
                    ProjectType=ProjectType.NewFeature,
                    ProjectDifficulty=ProjectDifficulty.Advanced,
                    ProjectImportance=ProjectImportance.High,
                    Description="Hybrid Closing (new revenue stream)",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>New project that read client's data from PDF files instead of web services and webforms</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:
                                        <ul>
                                            <li>Use 3rd party OCR library and regular expressions to find specific pages, gather data from pages, and find the customers' signature lines</li>
                                            <li>Work with Lead Programmer to design tables, backend (Webform and Winform), UI, and create code to existing internal .NET Winform software to enable internal Doc Preparation team to run audits of the new retrieved data</li>
                                            <li>Create new Webform UI</li>
                                            <li>Edit existing Webform UI and business objects to work with the new logic (code to understand this was a new type of product and send PDF to DocuSign instead of custom Word/PDF files)</li>
                                            <li>Add a tutorial using 3rd party JS Library that moves the user through sections of the project, highlighting active divs, and display explanations/details</li>
                                            <li>Table based</li>
                                            <li>Did not apply design patterns nor SOLID principal because limited programming time and we took the mock-up/proof-of-concept and transformed it into final product.</li>
                                        </ul>
                                    </li>
                                    <li>PROBLEMS/ISSUES:
                                        <ul>
                                            <li>Communicating with team member (programmer) that prefered to work independently</li>
                                            <li>Miscommunication on table design that caused my code to have logic errors</li>
                                        </ul>
                                    </li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>Slowly, calmly, and informally communicated with programmer</li>
                                            <li>When encountered issue with our table design, communicated with other programmer to clear our the table design, then edited my code to remove some of the new functionality and work with that programmer's table design</li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>OCR Library (Spire.PDF)</li>
                                            <li>Learned to communicate with programmer</li>
                                            <li>Did not apply design patterns nor SOLID principal because limited programming time</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:
                                        <ul>
                                            <li><a href=""../SampleCodeVBDotNET/GetSignatureCoordinatesFromPDF"">Get Signature Coordinates From PDF</a></li>
                                        </ul>
                                    </li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                },
                new Project
                {
                    ProjectId=6,
                    ProjectType=ProjectType.NewDotNETWinforms,
                    ProjectDifficulty=ProjectDifficulty.Advanced,
                    ProjectImportance=ProjectImportance.Medium,
                    Description="Separate PDF Into Smaller PDFs (software for internal Doc Preparation team)",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>New internal software used to faciliate day-to-day operations when running audits for clients and their investors</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:
                                        <ul>
                                            <li>Use 3rd party OCR library, regular expressions, and advanced logic to separate PDF files into new smaller PDF files</li>
                                            <li>Read Data from PDF files</li>
                                            <li>Waterfall method</li>
                                            <li>Work with and gather project requirements from Lead Document Preparation member</li>
                                            <li>Run extensive tests to verify all docs are being captured</li>
                                            <li>Write both technical and non-technical documentation</li>
                                            <li>Did not apply design patterns nor SOLID principal because limited programming time and we took the mock-up/proof-of-concept and transformed it into final product.</li>
                                        </ul>
                                    </li>
                                    <li>PROBLEMS/ISSUES:
                                        <ul>
                                            <li>Created new proof-of-concept</li>
                                            <li>Some docs were very similar but needed to be separated and saved as different docs</li>
                                            <li>Time constrainst</li>
                                        </ul>
                                    </li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>Used line and multi-line regular expressions</li>
                                            <li>Cycled on and off this project to work on other high priority issues</li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>OCR Library (LeadTools)</li>
                                            <li>Distinct Regular Expressions to capture over 100 possible documents (single and multi-line matches)</li>
                                            <li>Did not apply design patterns nor SOLID principal because limited programming time</li>
                                            <li>Multi-tasking</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:
                                        <ul>
                                            <li><a href=""../SampleCodeVBDotNET/SeparatePDFIntoSmallerPDFs"">Get Signature Coordinates From PDF</a></li>
                                        </ul>
                                    </li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                },
                new Project
                {
                    ProjectId=7,
                    ProjectType=ProjectType.NewFeature,
                    ProjectDifficulty=ProjectDifficulty.Advanced,
                    ProjectImportance=ProjectImportance.High,
                    Description="System wide to use JQuery Datatable",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>Change the websites to use JQuery Datatables</li>
                                            <li>JQuery Datatables gives the ability to easily create UI tables and uses built in pagination, sorting, filtering, and export capabilities in Excel, PDF, and others</li>
                                            <li>From programmer's POV, provides deferred loading with AJAX (web service), ability to use both HTTP Post and Get, reading data from JSON object that gets populated by and converted automatically from business object, strong library for client-side manipulation of the UI table when sorting and filtering, custom server-side pagination, and built in export</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:
                                        <ul>
                                            <li>Use all the built in features of JQuery Datatables</li>
                                        </ul>
                                    </li>
                                    <li>PROBLEMS/ISSUES:
                                        <ul>
                                            <li>Tables weren't displaying correctly because of CSS on outer divs</li>
                                            <li>Front End programmer was new to this technology</li>
                                            <li>Too many changes required</li>
                                        </ul>
                                    </li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>Worked with front end programmer on custom CSS</li>
                                            <li>Taught programmer about different ways to apply JQuery Datatables and all the details behind it</li>
                                            <li>At times only redesigned the HTML to apply JQuery Datatables, no JS/JQuery required</li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>JQuery Datatables</li>
                                            <li>CSS</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:
                                        <ul>
                                            <li><a href=""../SampleCodeFrontEnd/JQueryDatatablesCustom"">JQuery Datatables - added to existing code</a></li>
                                        </ul>
                                    </li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                },
                new Project
                {
                    ProjectId=8,
                    ProjectType=ProjectType.NewFeature,
                    ProjectDifficulty=ProjectDifficulty.Intermediate,
                    ProjectImportance=ProjectImportance.High,
                    Description="Ability for non-borrowers to view and receive updates on the loan's DocuSign documents",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>Give our client (non-borrower) the ability to see their clients' (borrowers) DocuSign documents and signatures by also sending our client's data to DocuSign via web service</li>
                                            <li>Creates more clarity between client and borrowers</li>
                                            <li>Reduces the time the Support and Doc Preparation teams have to spend diagnosing the problem and clarifying any confusion</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:
                                        <ul>
                                            <li>Waterfall method</li>
                                        </ul>
                                    </li>
                                    <li>PROBLEMS/ISSUES:  None</li>
                                    <li>SOLUTION:  None</li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>Thinking outside the box to suggest new solutions to problems no one had thought about</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:
                                        <ul>
                                            <li><a href=""../SampleCodeVBDotNET/NonBorrowerToViewDocuSignDisclosureUpdates"">non-Borrower To View DocuSign Disclosure Updates</a></li>
                                        </ul>
                                    </li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                },
                new Project
                {
                    ProjectId=9,
                    ProjectType=ProjectType.NewFeature,
                    ProjectDifficulty=ProjectDifficulty.Intermediate,
                    ProjectImportance=ProjectImportance.High,
                    Description="Runtime Error Notifications (Exception Handler)",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>Actively monitor website errors by emailing and logging new runtime errors</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:  None</li>
                                    <li>PROBLEMS/ISSUES:  None</li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>Edited web.config and other config file</li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>Thinking outside the box to suggest new solutions to problems no one had thought about</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:  None</li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                },
                new Project
                {
                    ProjectId=10,
                    ProjectType=ProjectType.NewFeature,
                    ProjectDifficulty=ProjectDifficulty.Intermediate,
                    ProjectImportance=ProjectImportance.High,
                    Description="Improved Security",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>Focus on websites' security</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:  None</li>
                                    <li>PROBLEMS/ISSUES:  None</li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>Edited web.config files to make websites more secure</li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>Thinking outside the box to suggest new solutions to problems no one had thought about</li>
                                            <li>web.config</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:  None</li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                },
                new Project
                {
                    ProjectId=11,
                    ProjectType=ProjectType.NewFeature,
                    ProjectDifficulty=ProjectDifficulty.Intermediate,
                    ProjectImportance=ProjectImportance.Medium,
                    Description="Package object's C# Sort to be used when Collapsing on the UI",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>Create custom C# sort to rearrange Package objects on UI by datetime and then by their description, grouped by datetime</li>
                                            <li>Ability to collapse similar Packages on UI into 1 table row (edited UI to only display most recent and hide the visibility of the others until the maximize/minimize (+/-) feature were used on that table row)</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:  None</li>
                                    <li>PROBLEMS/ISSUES:
                                        <ul>
                                            <li>I wasn't able to use LINQ twice because it wouldn't return the desired behavior; after sorting by datetime with LINQ, I needed to sort by the objects' description, so running the 2nd sort would unorganize them and wouldn't be sorted by datetime anymore.</li>
                                        </ul>
                                    </li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>My approach was to run the datetime sort first using LINQ and then move any Package with the same description right behind the 1st occurence of that Package description. I wasn't able to use advanced sorting algorithms because of the situation I was in where I needed to keep the current datetime sort order.</li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>Thinking outside the box to suggest new solutions to problems no one had thought about</li>
                                            <li>Custom Sorting - Complex Algorithm</li>
                                            <li>Web Services with AJAX and AJAXPro</li>
                                            <li>Complex JS/JQuery to dynamically manipulate the DOM</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:
                                        <ul>
                                            <li><a href=""../SampleCodeVBDotNET/CustomSort"">Package Object's C# Sort</a></li>
                                        </ul>
                                    </li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                },
                new Project
                {
                    ProjectId=12,
                    ProjectType=ProjectType.TeachMentor,
                    ProjectDifficulty=ProjectDifficulty.Intermediate,
                    ProjectImportance=ProjectImportance.High,
                    Description="Supervised Programmer",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>Tutor, mentor, and delegate tasks to mid-level programmer</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:  None</li>
                                    <li>PROBLEMS/ISSUES:  None</li>
                                    <li>SOLUTION:  None</li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>Tutor</li>
                                            <li>Mentor</li>
                                            <li>Delegate tasks</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:  None</li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                },
                new Project
                {
                    ProjectId=13,
                    ProjectType=ProjectType.BugFix,
                    ProjectDifficulty=ProjectDifficulty.Intermediate,
                    ProjectImportance=ProjectImportance.High,
                    Description="Chrome 80 Release Repairs",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>Many clients reported not being able to save their data on our main webform.</li>
                                            <li>With the release of a new Chrome version that disabled onunload, onbeforeunload, and synchronous calls from running when the user closed/left a webpage, many company's websites worldwide had issues. Chrome made this change to prevent websites from delaying or preventing user from leaving a webpage or closing a tab/window.</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:
                                        <ul>
                                            <li>Research error</li>
                                            <li>Finish coding quickly and publish</li>
                                            <li>Notify clients or error and fix</li>
                                        </ul>
                                    </li>
                                    <li>PROBLEMS/ISSUES:
                                        <ul>
                                            <li>There were many places where we used synchronous calls to backend.</li>
                                        </ul>
                                    </li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>I diagnosed the error by isolating the bug to Chrome, stepping through JS and pin pointing the issue, then investigating on Google and found the Chrome 80 release notes.</li>
                                            <li>Replaced all synchronous calls with asynchronous calls</li>
                                            <li>We were up and running later that day</li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>Research issues</li>
                                            <li>Make Executive Decisions on major change</li>
                                            <li>JS, JQuery, AJAX, and Web Services</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:
                                        <ul>
                                            <li><a href=""../SampleCodeFrontEnd/ChangeExitToAsyncCall"">Change Existing Exit Code to use Async calls</a></li>
                                        </ul>
                                    </li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                },
                new Project
                {
                    ProjectId=14,
                    ProjectType=ProjectType.BugFix,
                    ProjectDifficulty=ProjectDifficulty.Advanced,
                    ProjectImportance=ProjectImportance.High,
                    Description="Remove \"Error Linking\" Runtime Errors",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>One of our website's UI had an error that would appear randomly. Prevented users from saving.</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:  None</li>
                                    <li>PROBLEMS/ISSUES:
                                        <ul>
                                            <li>There was a lot of business logic I had to go through.</li>
                                        </ul>
                                    </li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>Found the issue on the backend and fixed. Had to learn the business logic and steps clients took in order to pin point the issue.</li>
                                            <li>Don't remember the exact code fix.</li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>Diagnose Error</li>
                                            <li>Understanding all business logic</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:  None</li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                },
                new Project
                {
                    ProjectId=15,
                    ProjectType=ProjectType.BugFix,
                    ProjectDifficulty=ProjectDifficulty.Intermediate,
                    ProjectImportance=ProjectImportance.High,
                    Description="Prevent multiple disclosures from being sent",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>Data was being sent multiple times to DocuSign via web service when our submit page encountered errors</li>
                                            <li>Caused confusion when the client's clients were to begin the eSign process and people (clients, client's clients, and our internal groups) began to track these multiple documents created</li>
                                            <li>If the incorrect package(s) was eSigned, then the process had to be restarted, preventing loans from closing on the predicted date.</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:
                                        <ul>
                                            <li>Prevent multiple table entries from being created</li>
                                            <li>Only create entries into table after receiving response synchronously from DocuSign</li>
                                            <li>Notify user of error</li>
                                        </ul>
                                    </li>
                                    <li>PROBLEMS/ISSUES:
                                        <ul>
                                            <li>Clients and their clients suggested the issue was on different sections of our website.</li>
                                            <li>DocuSign returned false negatives/errors</li>
                                        </ul>
                                    </li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>Wrote try catch to catch runtime error and display it on one of our submit pages</li>
                                            <li>Realized DocuSign reported false negatives, which we could do nothing about</li>
                                            <li>Diagnosed errors by reviewing our error logs and analysing what went wrong</li>
                                            <li>Waited for more instances of the error to have a large sample set</li>
                                            <li>Wrote code to only proceed with table entry when successfully submited to DocuSign</li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>Thinking outside the box to suggest new solutions to problems no one had thought about</li>
                                            <li>Diagnosing errors</li>
                                            <li>Analysing errors</li>
                                            <li>Decipher non-programmer's emails and steps to reproduce error</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:  None</li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2019-01-01")
                },
                new Project
                {
                    ProjectId=16,
                    ProjectType=ProjectType.BugFix,
                    ProjectDifficulty=ProjectDifficulty.Beginner,
                    ProjectImportance=ProjectImportance.High,
                    Description="Prevent incorrect Hybrid eSign package from appearing",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>Clients weren't seeing the latest Package object on their loan dashboard.</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:  None</li>
                                    <li>PROBLEMS/ISSUES:
                                        <ul>
                                            <li>The webpage the client used to upload data and create new Hybrid loans, which were loans that accepted both wet and eSign signatures, had the ability to create multiple envelope entries into our DB per loan. Each envelope contained multiple wet and eSign packages. I then noticed the software that was used internally for data validation only created and updated the initial envelope's package.  So we had a section that had a 1-to-many relationship between loans and envelopes and a different section that had a 1-to-1 relationship.</li>
                                        </ul>
                                    </li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>After research, I communicated this logic error to the group where we decided to remove the ability to create multiple envelopes per loan. Although a good feature because it gave the client the ability to create multiple envelopes for testing or audit/history purposes, we were not in the position to work on this project.</li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>Diagnosing Errors</li>
                                            <li>Understanding Business Logic and Table Design</li>
                                            <li>Find, suggest, and code Quick and Safe solution</li>
                                            <li>SQL - Table Design</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:  None</li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                },
                new Project
                {
                    ProjectId=17,
                    ProjectType=ProjectType.BugFix,
                    ProjectDifficulty=ProjectDifficulty.Intermediate,
                    ProjectImportance=ProjectImportance.High,
                    Description="Title company with ampersands displayed incorrectly",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>The title company's fee descriptions with ""&"" displayed incorrectly, which prevented the loan from being compliant with government regulations.</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:
                                        <ul>
                                            <li>Find and fix quickly.</li>
                                        </ul>
                                    </li>
                                    <li>PROBLEMS/ISSUES:
                                        <ul>
                                            <li>After debugging, I discovered the ampersand was causing issues but I couldn't update the data on data submission because it couldn't be decoded on other parts of the website because of the way they were coded.</li>
                                        </ul>
                                    </li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>I found the class/code that was used to display on this particular section and added the escape characters there only.</li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>Diagnosing Errors</li>
                                            <li>Understanding Business Logic</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:  None</li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                },
                new Project
                {
                    ProjectId=18,
                    ProjectType=ProjectType.NewFeature,
                    ProjectDifficulty=ProjectDifficulty.Beginner,
                    ProjectImportance=ProjectImportance.Medium,
                    Description="Notify user that Template already locked",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>When user is trying to gain access to the Templage Edit page, notify them that it is already locked/open by a different user.</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:  None</li>
                                    <li>PROBLEMS/ISSUES:
                                        <ul>
                                            <li>Users with the webform/Template page open could still make changes.</li>
                                        </ul>
                                    </li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>Web Service to get and set the lock for the Template</li>
                                            <li>Used JQuery/JS to display modals/popup windows</li>
                                            <li>Custom CSS</li>
                                            <li>As a fail-safe, also prevented all users already in the Template page from deleting or renaming locked Templates via backend.</li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>Web Services</li>
                                            <li>JQuery/JS</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:  None</li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                },
                new Project
                {
                    ProjectId=19,
                    ProjectType=ProjectType.NewFeature,
                    ProjectDifficulty=ProjectDifficulty.Intermediate,
                    ProjectImportance=ProjectImportance.Medium,
                    Description="Add New Loans/Orders/Products",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>Use knowledge of DB and backend to add new entries so clients can create new type of loans/orders/products</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:
                                        <ul>
                                            <li>Thread lightly</li>
                                            <li>Follow naming conventions</li>
                                            <li>Enter all necessary info</li>
                                            <li>Consult Sales group for pricing</li>
                                            <li>Enter detailed descriptions</li>
                                            <li>Don't enter redundant data</li>
                                        </ul>
                                    </li>
                                    <li>PROBLEMS/ISSUES:  None</li>
                                    <li>SOLUTION:  None</li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>Understand Business Logic</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:  None</li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                },
                new Project
                {
                    ProjectId=20,
                    ProjectType=ProjectType.NewFeature,
                    ProjectDifficulty=ProjectDifficulty.Advanced,
                    ProjectImportance=ProjectImportance.High,
                    Description="Limit certain users and client branches to access certain loans/orders/products",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>Use knowledge of DB and backend to limit user access to certain features</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:
                                        <ul>
                                            <li>Table based</li>
                                            <li>Create test accounts to test thoroughly</li>
                                        </ul>
                                    </li>
                                    <li>PROBLEMS/ISSUES:  None</li>
                                    <li>SOLUTION:  None</li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>Flags and user groups were used</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:  None</li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                },
                new Project
                {
                    ProjectId=21,
                    ProjectType=ProjectType.BugFix,
                    ProjectDifficulty=ProjectDifficulty.Intermediate,
                    ProjectImportance=ProjectImportance.Medium,
                    Description="Reports - Prevent Timeouts",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>Reports, especially ones with historical data, were timing out.</li>
                                            <li>Optimize SPs and edit business objects</li>
                                            <li>Add pagination, sorting (by 1 or more columns), and filtering (search) features</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:
                                        <ul>
                                            <li>Decrease load time</li>
                                            <li>Enhance UI</li>
                                        </ul>
                                    </li>
                                    <li>PROBLEMS/ISSUES:  None</li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>Applied 1 or more of these:
                                                <ul>
                                                    <li>SQL query - optimized</li>
                                                    <li>SQL query - added pagination</li>
                                                    <li>VB.NET - only returned requested rows</li>
                                                    <li>VB.NET - update web services</li>
                                                    <li>VB.NET - edit attributes to increase time limit</li>
                                                    <li>JQuery Datatables - built in and custom pagination</li>
                                                </ul>
                                            </li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>SQL Optimization</li>
                                            <li>JQuery Datatables</li>
                                            <li>Understand business logic (how tables relate to each other)</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:  None</li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                },
                new Project
                {
                    ProjectId=22,
                    ProjectType=ProjectType.NewFeature,
                    ProjectDifficulty=ProjectDifficulty.Intermediate,
                    ProjectImportance=ProjectImportance.Medium,
                    Description="Reports - Create and Edit",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>Optimize SPs and edit business objects</li>
                                            <li>Add pagination, sorting (by 1 or more columns), and filtering (search) features</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:
                                        <ul>
                                            <li>Decrease load time</li>
                                            <li>Enhance UI</li>
                                        </ul>
                                    </li>
                                    <li>PROBLEMS/ISSUES:  None</li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>Applied 1 or more of these when creating new reports and updating existing ones:
                                                <ul>
                                                    <li>SQL query - optimized</li>
                                                    <li>SQL query - added pagination</li>
                                                    <li>C# - only returned requested rows</li>
                                                    <li>C# - update web services</li>
                                                    <li>JQuery Datatables - built in and custom pagination</li>
                                                </ul>
                                            </li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>SQL Optimization</li>
                                            <li>JQuery Datatables</li>
                                            <li>Understand business logic (how tables relate to each other)</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:  None</li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                },
                new Project
                {
                    ProjectId=23,
                    ProjectType=ProjectType.NewProject,
                    ProjectDifficulty=ProjectDifficulty.Intermediate,
                    ProjectImportance=ProjectImportance.High,
                    Description="Nutshell's (CRM) Client data import (for Sales)",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>Our sales group needed a way to track leads, onboarding, and commision.
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:  None</li>
                                    <li>PROBLEMS/ISSUES:  None</li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>I created new VB.NET code to utilize Nutshell's web services to send them client data when clients registered on our webpage.</li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>Web Services</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:
                                        <ul>
                                            <li><a href=""../SampleCodeVBDotNET/NutshellWebServices"">Nutshell - Web Services</a></li>
                                        </ul>
                                    </li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2018-10-01")
                },
                new Project
                {
                    ProjectId=24,
                    ProjectType=ProjectType.NewProject,
                    ProjectDifficulty=ProjectDifficulty.Intermediate,
                    ProjectImportance=ProjectImportance.High,
                    Description="Sales/Leads Reports and Form (for Sales)",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>Our sales group needs an EASY way to track leads, onboarding, and commision.</li>
                                            <li>I suggested we create our own CRM system instead of using Nutshell.com.</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:
                                        <ul>
                                            <li>Easy to learn and use</li>
                                            <li>Create a very simple customized system in order to guarantee the Sales group would not stop using it down the road.</li>
                                            <li>Individual rows needed to be updated.</li>
                                            <li>Always display current/updated data to not confuse Sales group.</li>
                                        </ul>
                                    </li>
                                    <li>PROBLEMS/ISSUES:  None</li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>As new interested parties registered for a demo, new entries were entered into the new Sales/Leads tables.</li>
                                            <li>Introduced JQuery Datatables for the first time into our projects</li>
                                            <li>Found solution to use form submissions per row in order to update individual records</li>
                                            <li>JQuery Datatables, along with web services via AJAX, solved the issue of dynamically updating UI</li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>Thinking outside the box to suggest new solutions to problems no one had thought about</li>
                                            <li>Gather requirements and wish-list items from non-programmers</li>
                                            <li>Table Design</li>
                                            <li>Vertical Partitioning</li>
                                            <li>JQuery Datatables</li>
                                            <li>Web Services</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:  None</li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2018-12-01")
                },
                new Project
                {
                    ProjectId=25,
                    ProjectType=ProjectType.NewProject,
                    ProjectDifficulty=ProjectDifficulty.Advanced,
                    ProjectImportance=ProjectImportance.Medium,
                    Description="Client Search (for Sales)",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>Add a report to display all the necessary data for a client, their branches, and users.</li>
                                            <li>Add a feature where Sales can enter an address and a distance in miles and then returns any clients within that mile radius on a map.</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:
                                        <ul>
                                            <li>Make easy to use (user-friendly).</li>
                                            <li>Create a report with many search field that uses a fuzzy search.</li>
                                            <li>Add Google's Map API, along with a table specifying distances between zipcodes, to calculate and display all clients on a map within a certain mile radius from an address or zip code entered.</li>
                                        </ul>
                                    </li>
                                    <li>PROBLEMS/ISSUES:
                                        <ul>
                                            <li>There were issues with Google Map API, can't remember them precisely.  If I remember correctly, their API didn't display pins on their maps by zipcode nor calculate distances by zipcode...</li>
                                        </ul>
                                    </li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>Researched and used Google's Map API</li>
                                            <li>Created my own table with all US zipcodes in order to calculate distances between them</li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>Thinking outside the box to suggest new solutions to problems no one had thought about</li>
                                            <li>Gather requirements and wish-list items from non-programmers</li>
                                            <li>Google Map API</li>
                                            <li>Understand Business Logic</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:  None</li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                },
                new Project
                {
                    ProjectId=26,
                    ProjectType=ProjectType.NewFeature,
                    ProjectDifficulty=ProjectDifficulty.Advanced,
                    ProjectImportance=ProjectImportance.High,
                    Description="Calculator/Help Feature (Flood Calculator)",
                    Details=@"<ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>Our clients needed a way to see if their new and existing loans passed government regulations in order to receive Flood insurance and how much they could be insured for.</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:
                                        <ul>
                                            <li>Use .NET Web Controls</li>
                                            <li>Easy to maintain</li>
                                        </ul>
                                    </li>
                                    <li>PROBLEMS/ISSUES:  None</li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>Created a new webpage with a dynamic form that used VB.NET and Windows controls to display new input elements and determine what the next scenario/state would be as the client entered data.</li>
                                            <li>The solution was table-based where each record had a next and prev state. This table-based approach simplified coding on the businesslogic tier.</li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>Thinking outside the box to suggest new solutions to problems no one had thought about</li>
                                            <li>.NET Web Controls</li>
                                            <li>Dynamic Table Based Solution</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:  None</li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                },
                new Project
                {
                    ProjectId=27,
                    ProjectType=ProjectType.NewFeature,
                    ProjectDifficulty=ProjectDifficulty.Beginner,
                    ProjectImportance=ProjectImportance.Medium,
                    Description="Loan Compare for Sales and Fulfillment team",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>Make webpage that compares a loan's previous and current data given its state more user-friendly</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:  None</li>
                                    <li>PROBLEMS/ISSUES:  None</li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>Used JQuery/JS to:
                                                <ul>
                                                    <li>Collapse and expand section and field data</li>
                                                    <li>Highlight fields in green and yellow given their validity</li>
                                                    <li>Show/display fields that have changed/not changed</li>
                                                </ul>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>Understand Business Objects</li>
                                            <li>JQuery/JS</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:  None</li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                },
                new Project
                {
                    ProjectId=28,
                    ProjectType=ProjectType.NewFeature,
                    ProjectDifficulty=ProjectDifficulty.Beginner,
                    ProjectImportance=ProjectImportance.Low,
                    Description="Prevent user-error when entering emails with incorrect format - system wide",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>Clients copy and paste users emails from Excel files to our forms, which are sometimes formatted incorrectly. This causes runtime errors on other parts of our website.</li>
                                            <li>For example, the string ""Willie Sandoval <willie@domain.com>"" needs to be updated to ""willie@domain.com"".</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:  None</li>
                                    <li>PROBLEMS/ISSUES:  None</li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>I made the change on the front-end so the client could see their mistake and in order to not slow down the backend code when form submitted</li>
                                            <li>Created new JS function and applied to onblur events for email inputs</li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>Thinking outside the box to suggest new solutions to problems no one had thought about</li>
                                            <li>Delegate portion of task to front end developer</li>
                                            <li>JQuery/JS</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:  None</li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                },
                new Project
                {
                    ProjectId=29,
                    ProjectType=ProjectType.NewFeature,
                    ProjectDifficulty=ProjectDifficulty.Beginner,
                    ProjectImportance=ProjectImportance.Low,
                    Description="Add date calendar to date textboxes - system wide",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>Users complained of errors when submitting forms and entering dates</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:  None</li>
                                    <li>PROBLEMS/ISSUES:  None</li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>Found a good JS library to allow users to enter dates via UI calendar and automatically format dates</li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>Thinking outside the box to suggest new solutions to problems no one had thought about</li>
                                            <li>Delegated task to front end developer</li>
                                            <li>JQuery/JS</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:  None</li>
                                <li>
                                <li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                },
                new Project
                {
                    ProjectId=30,
                    ProjectType=ProjectType.BugFix,
                    ProjectDifficulty=ProjectDifficulty.Advanced,
                    ProjectImportance=ProjectImportance.High,
                    Description="Add an \"owner\" to the new PDF changes when user made custom changes to the PDF & only allow \"owner\" or managers to remove custom document",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>When the system-created PDFs has client-requested custom changes or incorrect format due to large data fields, the client and our Doc Prep team has the ability to edit the PDFs. We need a way to prevent these custom changes made to these PDFs from being removed by a different user or by our automated system when a loan is resubmitted for approval.</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:
                                        <ul>
                                            <li>Our IT team discussed and we decided to only give managers and the person who edited the PDF the ability to edit or delete.</li>
                                        </ul>
                                    </li>
                                    <li>PROBLEMS/ISSUES:
                                        <ul>
                                            <li>Resubmitting the loan for approval/review resets the custom PDFs, deleting the custom changes.</li>
                                        </ul>
                                    </li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>I create a new field in the doc/PDF table that specified the person who made the change and then added new code to this section to only allow them or managers to edit or remove.</li>
                                            <li>I had to review the code to find the code that was triggered when resubmitting loans and edited it to not trigger on custom PDFs.</li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>Thinking outside the box to suggest new solutions to problems no one had thought about</li>
                                            <li>Understanding Business Logic</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:  None</li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                },
                new Project
                {
                    ProjectId=31,
                    ProjectType=ProjectType.NewClassicASPWebsite,
                    ProjectDifficulty=ProjectDifficulty.Advanced,
                    ProjectImportance=ProjectImportance.High,
                    Description="FAQ page for clients with default and client-specific Topics and Articles",
                    Details=@"  <ul>
                                    <li>DETAILS:
                                        <ul>
                                            <li>We need an FAQ page for clients in order to display both default and client-specific topics and articles.</li>
                                        </ul>
                                    </li>
                                    <li>REQUIREMENTS:
                                        <ul>
                                            <li>Both topics and articles could become client-specific.</li>
                                            <li>If a default topic or article was edited for a client, it would only display the new version to the client.</li>
                                            <li>The client-specific topic and articles were tied back to the main default topic and article by referencing it in a field. If the field was null or 0, then that was the default topic or article.</li>
                                            <li>Vertical partioning was used to reduce the amount of data stored and returned.</li>
                                            <li>I was told by IT managers to move away from VBScript classes and use sps instead because it was prefered internally.</li>
                                            <li>...the list of requirements and design notes goes on and on...</li>
                                        </ul>
                                    </li>
                                    <li>PROBLEMS/ISSUES:
                                        <ul>
                                            <li>The IT managers prefered SQL over VBScript and objects. They told me to focus on complicated SPs for CRUD operations, not creating the logic through objects. This overcomplicated the project, with many if-statements/special cases in both the SPs and VBScript code.</li>
                                        </ul>
                                    </li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>I respectfully argued/discussed with them that the solution they proposed would be hard to implement and maintain. Ultimately, I went with their proposed implementation of the project.</li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>SQL</li>
                                            <li>TSQL</li>
                                            <li>Complicated Algorithms</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:
                                        <ul>
                                            <li><a href=""../SampleCodeSQL/AdvancedQuery"">Advanced Query</a></li>
                                        </ul>
                                    </li>
                                </ul>",
                    CompanyId=companies[8].CompanyId,
                    Date=DateTime.Parse("2018-02-01")
                }
            };


            var projectsTopics = new ProjectsTopics[]
            {
                //WillieSandoval.com
                new ProjectsTopics{
                    ProjectId=projects[0].ProjectId,
                    TopicId=topics[4].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[0].ProjectId,
                    TopicId=topics[6].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[0].ProjectId,
                    TopicId=topics[9].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[0].ProjectId,
                    TopicId=topics[14].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[0].ProjectId,
                    TopicId=topics[15].TopicId
                },
                //DFWAirConditioningExperts.com
                new ProjectsTopics{
                    ProjectId=projects[1].ProjectId,
                    TopicId=topics[5].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[1].ProjectId,
                    TopicId=topics[9].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[1].ProjectId,
                    TopicId=topics[14].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[1].ProjectId,
                    TopicId=topics[17].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[1].ProjectId,
                    TopicId=topics[24].TopicId
                },
                //ParentAgent.com
                new ProjectsTopics{
                    ProjectId=projects[2].ProjectId,
                    TopicId=topics[5].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[2].ProjectId,
                    TopicId=topics[9].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[2].ProjectId,
                    TopicId=topics[14].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[2].ProjectId,
                    TopicId=topics[16].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[2].ProjectId,
                    TopicId=topics[24].TopicId
                },
                //Accounting website
                new ProjectsTopics{
                    ProjectId=projects[3].ProjectId,
                    TopicId=topics[0].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[3].ProjectId,
                    TopicId=topics[5].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[3].ProjectId,
                    TopicId=topics[9].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[3].ProjectId,
                    TopicId=topics[13].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[3].ProjectId,
                    TopicId=topics[14].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[3].ProjectId,
                    TopicId=topics[15].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[3].ProjectId,
                    TopicId=topics[16].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[3].ProjectId,
                    TopicId=topics[19].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[3].ProjectId,
                    TopicId=topics[20].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[3].ProjectId,
                    TopicId=topics[21].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[3].ProjectId,
                    TopicId=topics[24].TopicId
                },
                //Hybrid Closing (new revenue stream)
                new ProjectsTopics{
                    ProjectId=projects[4].ProjectId,
                    TopicId=topics[2].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[4].ProjectId,
                    TopicId=topics[7].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[4].ProjectId,
                    TopicId=topics[8].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[4].ProjectId,
                    TopicId=topics[10].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[4].ProjectId,
                    TopicId=topics[12].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[4].ProjectId,
                    TopicId=topics[20].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[4].ProjectId,
                    TopicId=topics[21].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[4].ProjectId,
                    TopicId=topics[22].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[4].ProjectId,
                    TopicId=topics[23].TopicId
                },
                //Separate PDF Into Smaller PDFs (software for internal Doc Preparation team)
                new ProjectsTopics{
                    ProjectId=projects[5].ProjectId,
                    TopicId=topics[1].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[5].ProjectId,
                    TopicId=topics[8].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[5].ProjectId,
                    TopicId=topics[10].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[5].ProjectId,
                    TopicId=topics[22].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[5].ProjectId,
                    TopicId=topics[23].TopicId
                },
                //System wide to use JQuery Datatable
                new ProjectsTopics{
                    ProjectId=projects[6].ProjectId,
                    TopicId=topics[0].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[6].ProjectId,
                    TopicId=topics[7].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[6].ProjectId,
                    TopicId=topics[10].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[6].ProjectId,
                    TopicId=topics[14].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[6].ProjectId,
                    TopicId=topics[15].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[6].ProjectId,
                    TopicId=topics[16].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[6].ProjectId,
                    TopicId=topics[19].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[6].ProjectId,
                    TopicId=topics[20].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[6].ProjectId,
                    TopicId=topics[21].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[6].ProjectId,
                    TopicId=topics[24].TopicId
                },
                //Ability for non-borrowers to view and receive updates on the loan's DocuSign documents
                new ProjectsTopics{
                    ProjectId=projects[7].ProjectId,
                    TopicId=topics[1].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[7].ProjectId,
                    TopicId=topics[7].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[7].ProjectId,
                    TopicId=topics[10].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[7].ProjectId,
                    TopicId=topics[21].TopicId
                },
                //Runtime Error Notifications (Exception Handler)
                new ProjectsTopics{
                    ProjectId=projects[8].ProjectId,
                    TopicId=topics[1].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[8].ProjectId,
                    TopicId=topics[7].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[8].ProjectId,
                    TopicId=topics[10].TopicId
                },
                //Improved Security
                new ProjectsTopics{
                    ProjectId=projects[9].ProjectId,
                    TopicId=topics[2].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[9].ProjectId,
                    TopicId=topics[7].TopicId
                },
                //Package object's C# Sort to be used when Collapsing on the UI
                new ProjectsTopics{
                    ProjectId=projects[10].ProjectId,
                    TopicId=topics[1].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[10].ProjectId,
                    TopicId=topics[7].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[10].ProjectId,
                    TopicId=topics[10].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[10].ProjectId,
                    TopicId=topics[14].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[10].ProjectId,
                    TopicId=topics[19].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[10].ProjectId,
                    TopicId=topics[20].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[10].ProjectId,
                    TopicId=topics[21].TopicId
                },
                //Supervised Programmer
                new ProjectsTopics{
                    ProjectId=projects[11].ProjectId,
                    TopicId=topics[0].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[11].ProjectId,
                    TopicId=topics[5].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[11].ProjectId,
                    TopicId=topics[7].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[11].ProjectId,
                    TopicId=topics[9].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[11].ProjectId,
                    TopicId=topics[10].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[11].ProjectId,
                    TopicId=topics[12].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[11].ProjectId,
                    TopicId=topics[14].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[11].ProjectId,
                    TopicId=topics[15].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[11].ProjectId,
                    TopicId=topics[16].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[11].ProjectId,
                    TopicId=topics[19].TopicId
                },new ProjectsTopics{
                    ProjectId=projects[11].ProjectId,
                    TopicId=topics[20].TopicId
                },new ProjectsTopics{
                    ProjectId=projects[11].ProjectId,
                    TopicId=topics[21].TopicId
                },new ProjectsTopics{
                    ProjectId=projects[11].ProjectId,
                    TopicId=topics[24].TopicId
                },
                //Chrome 80 Release Repairs
                new ProjectsTopics{
                    ProjectId=projects[12].ProjectId,
                    TopicId=topics[1].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[12].ProjectId,
                    TopicId=topics[7].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[12].ProjectId,
                    TopicId=topics[10].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[12].ProjectId,
                    TopicId=topics[14].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[12].ProjectId,
                    TopicId=topics[19].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[12].ProjectId,
                    TopicId=topics[20].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[12].ProjectId,
                    TopicId=topics[21].TopicId
                },
                //Remove \"Error Linking\" Runtime Errors
                new ProjectsTopics{
                    ProjectId=projects[13].ProjectId,
                    TopicId=topics[1].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[13].ProjectId,
                    TopicId=topics[7].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[13].ProjectId,
                    TopicId=topics[10].TopicId
                },
                //Prevent multiple disclosures from being sent
                new ProjectsTopics{
                    ProjectId=projects[14].ProjectId,
                    TopicId=topics[1].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[14].ProjectId,
                    TopicId=topics[7].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[14].ProjectId,
                    TopicId=topics[10].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[14].ProjectId,
                    TopicId=topics[21].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[14].ProjectId,
                    TopicId=topics[22].TopicId
                },
                //Prevent incorrect Hybrid eSign package from appearing
                new ProjectsTopics{
                    ProjectId=projects[15].ProjectId,
                    TopicId=topics[2].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[15].ProjectId,
                    TopicId=topics[7].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[15].ProjectId,
                    TopicId=topics[8].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[15].ProjectId,
                    TopicId=topics[10].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[15].ProjectId,
                    TopicId=topics[12].TopicId
                },
                //Title company with ampersands displayed incorrectly
                new ProjectsTopics{
                    ProjectId=projects[16].ProjectId,
                    TopicId=topics[1].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[16].ProjectId,
                    TopicId=topics[7].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[16].ProjectId,
                    TopicId=topics[10].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[16].ProjectId,
                    TopicId=topics[21].TopicId
                },
                //Notify user that Template already locked
                new ProjectsTopics{
                    ProjectId=projects[17].ProjectId,
                    TopicId=topics[1].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[17].ProjectId,
                    TopicId=topics[7].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[17].ProjectId,
                    TopicId=topics[10].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[17].ProjectId,
                    TopicId=topics[14].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[17].ProjectId,
                    TopicId=topics[16].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[17].ProjectId,
                    TopicId=topics[20].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[17].ProjectId,
                    TopicId=topics[21].TopicId
                },
                //Add New Loans/Orders/Products
                new ProjectsTopics{
                    ProjectId=projects[18].ProjectId,
                    TopicId=topics[7].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[18].ProjectId,
                    TopicId=topics[10].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[18].ProjectId,
                    TopicId=topics[12].TopicId
                },
                //Limit certain users and client branches to access certain loans/orders/products
                new ProjectsTopics{
                    ProjectId=projects[19].ProjectId,
                    TopicId=topics[1].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[19].ProjectId,
                    TopicId=topics[7].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[19].ProjectId,
                    TopicId=topics[10].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[19].ProjectId,
                    TopicId=topics[12].TopicId
                },
                //Reports - Prevent Timeouts
                new ProjectsTopics{
                    ProjectId=projects[20].ProjectId,
                    TopicId=topics[1].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[20].ProjectId,
                    TopicId=topics[7].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[20].ProjectId,
                    TopicId=topics[10].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[20].ProjectId,
                    TopicId=topics[12].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[20].ProjectId,
                    TopicId=topics[13].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[20].ProjectId,
                    TopicId=topics[14].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[20].ProjectId,
                    TopicId=topics[15].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[20].ProjectId,
                    TopicId=topics[16].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[20].ProjectId,
                    TopicId=topics[19].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[20].ProjectId,
                    TopicId=topics[20].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[20].ProjectId,
                    TopicId=topics[21].TopicId
                },
                //Reports - Create and Edit
                new ProjectsTopics{
                    ProjectId=projects[21].ProjectId,
                    TopicId=topics[1].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[21].ProjectId,
                    TopicId=topics[7].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[21].ProjectId,
                    TopicId=topics[10].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[21].ProjectId,
                    TopicId=topics[12].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[21].ProjectId,
                    TopicId=topics[13].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[21].ProjectId,
                    TopicId=topics[14].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[21].ProjectId,
                    TopicId=topics[15].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[21].ProjectId,
                    TopicId=topics[16].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[21].ProjectId,
                    TopicId=topics[19].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[21].ProjectId,
                    TopicId=topics[20].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[21].ProjectId,
                    TopicId=topics[21].TopicId
                },
                //Nutshell's (CRM) Client data import (for Sales)
                new ProjectsTopics{
                    ProjectId=projects[22].ProjectId,
                    TopicId=topics[1].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[22].ProjectId,
                    TopicId=topics[7].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[22].ProjectId,
                    TopicId=topics[10].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[22].ProjectId,
                    TopicId=topics[19].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[22].ProjectId,
                    TopicId=topics[21].TopicId
                },
                //Sales/Leads Reports and Form (for Sales)
                new ProjectsTopics{
                    ProjectId=projects[23].ProjectId,
                    TopicId=topics[2].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[23].ProjectId,
                    TopicId=topics[7].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[23].ProjectId,
                    TopicId=topics[10].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[23].ProjectId,
                    TopicId=topics[12].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[23].ProjectId,
                    TopicId=topics[13].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[23].ProjectId,
                    TopicId=topics[14].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[23].ProjectId,
                    TopicId=topics[15].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[23].ProjectId,
                    TopicId=topics[19].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[23].ProjectId,
                    TopicId=topics[20].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[23].ProjectId,
                    TopicId=topics[21].TopicId
                },
                //Client Search (for Sales)
                new ProjectsTopics{
                    ProjectId=projects[24].ProjectId,
                    TopicId=topics[2].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[24].ProjectId,
                    TopicId=topics[7].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[24].ProjectId,
                    TopicId=topics[10].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[24].ProjectId,
                    TopicId=topics[13].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[24].ProjectId,
                    TopicId=topics[14].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[24].ProjectId,
                    TopicId=topics[15].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[24].ProjectId,
                    TopicId=topics[19].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[24].ProjectId,
                    TopicId=topics[20].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[24].ProjectId,
                    TopicId=topics[21].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[24].ProjectId,
                    TopicId=topics[24].TopicId
                },
                //Calculator/Help Feature (Flood Calculator)
                new ProjectsTopics{
                    ProjectId=projects[25].ProjectId,
                    TopicId=topics[2].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[25].ProjectId,
                    TopicId=topics[7].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[25].ProjectId,
                    TopicId=topics[10].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[25].ProjectId,
                    TopicId=topics[12].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[25].ProjectId,
                    TopicId=topics[13].TopicId
                },
                //Loan Compare for Sales and Fulfillment team
                new ProjectsTopics{
                    ProjectId=projects[26].ProjectId,
                    TopicId=topics[2].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[26].ProjectId,
                    TopicId=topics[14].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[26].ProjectId,
                    TopicId=topics[16].TopicId
                },
                //Prevent user-error when entering emails with incorrect format - system wide
                new ProjectsTopics{
                    ProjectId=projects[27].ProjectId,
                    TopicId=topics[1].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[27].ProjectId,
                    TopicId=topics[14].TopicId
                },
                //Add date calendar to date textboxes - system wide
                new ProjectsTopics{
                    ProjectId=projects[28].ProjectId,
                    TopicId=topics[1].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[28].ProjectId,
                    TopicId=topics[14].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[28].ProjectId,
                    TopicId=topics[24].TopicId
                },
                //Add an \"owner\" to the new PDF changes when user made custom changes to the PDF & only allow \"owner\" or managers to remove custom document
                new ProjectsTopics{
                    ProjectId=projects[29].ProjectId,
                    TopicId=topics[1].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[29].ProjectId,
                    TopicId=topics[7].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[29].ProjectId,
                    TopicId=topics[10].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[29].ProjectId,
                    TopicId=topics[12].TopicId
                },
                //FAQ page for clients with default and client-specific Topics and Articles
                new ProjectsTopics{
                    ProjectId=projects[30].ProjectId,
                    TopicId=topics[0].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[30].ProjectId,
                    TopicId=topics[11].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[30].ProjectId,
                    TopicId=topics[12].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[30].ProjectId,
                    TopicId=topics[13].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[30].ProjectId,
                    TopicId=topics[14].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[30].ProjectId,
                    TopicId=topics[16].TopicId
                }
            };


            modelBuilder.Entity<Company>().HasData(
                companies
            );

            modelBuilder.Entity<Topic>().HasData(
                topics
            );

            modelBuilder.Entity<Project>().HasData(
                projects
            );

            modelBuilder.Entity<ProjectsTopics>().HasData(
                projectsTopics
            );
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Project>().ToTable("Project");
        //    modelBuilder.Entity<Company>().ToTable("Company");
        //    modelBuilder.Entity<Topic>().ToTable("Topic");
        //}
    }
}
