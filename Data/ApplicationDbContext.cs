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
                    Description="Personal Project"
                },
                new Company{
                    CompanyId=2,
                    Name="Paid Work",
                    Location="N/A",
                    JobTitle="N/A",
                    Description="Paid work I completed for others"
                },
                new Company{
                    CompanyId=3,
                    Name="Austin Logistics",
                    Location="Austin, TX",
                    JobTitle="Intern - QA",
                    Description="Created test plans, manually tested, reported bugs, and created detailed documentation with supervision.",
                    PayStart=10,
                    PayEnd=12,
                    PayType = PayType.Hour,
                    DateStart=DateTime.Parse("2006-07-01"),
                    DateEnd=DateTime.Parse("2007-07-01")
                },
                new Company{
                    CompanyId=4,
                    Name="Powered",
                    Location="Austin, TX",
                    JobTitle="Intern - QA",
                    Description="Created and ran unit tests, created test plans, manually tested, reported bugs, and created detailed documentation with supervision.",
                    PayStart=15,
                    PayEnd=17,
                    PayType = PayType.Hour,
                    DateStart=DateTime.Parse("2007-07-01"),
                    DateEnd=DateTime.Parse("2008-11-01")
                },
                new Company{
                    CompanyId=5,
                    Name="Optimal Blue",
                    Location="Plano, TX",
                    JobTitle="Contract - Software Developer",
                    Description="Created software for data validation using regular expressions with supervision.",
                    PayStart=25,
                    PayEnd=25,
                    PayType = PayType.Hour,
                    DateStart=DateTime.Parse("2009-06-01"),
                    DateEnd=DateTime.Parse("2009-11-01")
                },
                new Company{
                    CompanyId=6,
                    Name="Hedge Hog Capital",
                    Location="Remotely",
                    JobTitle="Contract - Software Developer",
                    Description="Created algorithms to predict and analyze stock market behaviour with no supervision.",
                    PayStart=10,
                    PayEnd=20,
                    PayType = PayType.Hour,
                    DateStart=DateTime.Parse("2010-07-01"),
                    DateEnd=DateTime.Parse("2011-03-01")
                },
                new Company{
                    CompanyId=7,
                    Name="iProspect (Range Online Media)",
                    Location="Fort Worth, TX",
                    JobTitle="Intern - Web Developer",
                    Description="Made improvements to front and backend to existing website with supervision.",
                    PayStart=10,
                    PayEnd=12,
                    PayType = PayType.Hour,
                    DateStart=DateTime.Parse("2011-03-01"),
                    DateEnd=DateTime.Parse("2011-06-01")
                },
                new Company{
                    CompanyId=8,
                    Name="NexPay Inc (Talon)",
                    Location="Dallas, TX",
                    JobTitle="Software Developer",
                    Description="Created reports, analyzed data for errors, and created a website with no supervision.",
                    PayStart=40000,
                    PayEnd=45000,
                    PayType = PayType.Year,
                    DateStart=DateTime.Parse("2011-07-01"),
                    DateEnd=DateTime.Parse("2012-11-01")
                },
                new Company{
                    CompanyId=9,
                    Name="MRN3",
                    Location="Remotely",
                    JobTitle="Software Developer",
                    Description="Managed and created new functionality to 3 websites on front and back end and tutored entry level programmer in a daily Agile environment.",
                    PayStart=55000,
                    PayEnd=65000,
                    PayType = PayType.Year,
                    DateStart=DateTime.Parse("2012-11-01"),
                    DateEnd=DateTime.Parse("2018-02-01")
                },
                new Company{
                    CompanyId=10,
                    Name="PPDocs",
                    Location="Arlington, TX",
                    JobTitle="Software Developer",
                    Description="Added new features and removed bugs from front and backend to existing websites and software, created a new .NET MVC website, updated and cleaned code (introduced Design Patterns, modularized code, and added abstraction), and tutored entry level programmer with little to no supervision using Agile, Waterfall, and Spiral methods.",
                    PayStart=80000,
                    PayEnd=115000,
                    PayType = PayType.Year,
                    DateStart=DateTime.Parse("2018-09-05"),
                    DateEnd=DateTime.Parse("2020-09-04")
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
                                    <li>Created this website to display my portfolio, list of projects and previous employers, and share my knowledge with others</li>
                                    <li>Gained knowledge of:
                                        <ul>
                                            <li>.NET CORE</li>
                                            <li>Dependency Injection</li>
                                            <li>SOLID Principal</li>
                                        </ul>
                                    <li>Applied design patterns and SOLID principal</li>
                                    <li>SAMPLE CODE: <a href=""../SampleCodeCSharp/RepositoryPatternWithGenericsInDotNETCore"">Repository Pattern With Generics In .NET Core</a></li>
                                    <li>SAMPLE CODE: <a href=""https://github.com/longhorngraduate/WillieSandoval"">WillieSandoval.com on GitHub</a></li>
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
                                    <li>Created this website for a friend for his new HVAC repair business</li>
                                    <li>Gained knowledge of:
                                        <ul>
                                            <li>.NET MVC</li>
                                            <li>CSS (Mobile First)</li>
                                            <li>SEO</li>
                                            <li>Google Ads</li>
                                            <li>Google Analytics</li>
                                            <li>Tidio (integrated chat)</li>
                                            <li>Flickity</li>
                                            <li>FlexSlider</li>
                                        </ul>
                                    <li>No models were required</li>
                                    <li>SAMPLE CODE: <a href=""https://github.com/longhorngraduate/DFWAirConditioningExperts"">DFWAirConditioningExperts.com on GitHub</a></li>
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
                                    <li>Created this website for a friend for his new tutoring business</li>
                                    <li>Gained knowledge of:
                                        <ul>
                                            <li>.NET MVC</li>
                                            <li>CSS Template</li>
                                            <li>LINQ</li>
                                            <li>.NET Identity (FB Login, User Roles)</li>
                                        </ul>
                                    <li>Did not apply design patterns nor SOLID principal because limited programming time</li>
                                    <li>SAMPLE CODE: <a href=""https://github.com/longhorngraduate/ParentAgent"">ParentAgent.com on GitHub</a></li>
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
                                    <li>Old Accounting system had timeouts and runtime errors, had to be repaird or replaced</li>
                                    <li>Two coworkers and I created a new .NET MVC website with new UI and models</li>
                                    <li>Transferred data between old and new tables using TSQL in order to begin using code first migrations</li>
                                    <li>SAMPLE CODE: <a href=""../SampleCodeFrontEnd/JQueryDatatables"">JQuery Datatables</a></li>
                                </ul>",
                    CompanyId=companies[9].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                },
                new Project{
                    ProjectId=5,
                    ProjectType=ProjectType.NewFeature,
                    ProjectDifficulty=ProjectDifficulty.Advanced,
                    ProjectImportance=ProjectImportance.High,
                    Description="Hybrid Closing (new revenue stream)",
                    Details=@"  <ul>
                                    <li>New project that read client's data from PDF files instead of webservices or webforms</li>
                                    <li>Used 3rd party OCR library and regular expressions to find specific pages, gather data from pages, and find the customers' signature lines</li>
                                    <li>Worked with Lead Programmer to design tables, backend (Webform and Winform), and UI</li>
                                    <li>Worked with Lead Programmer to create code to existing internal .NET Winform software to enable internal Doc Preparation team to run audits of the new retrieved data</li>
                                    <li>created new Webform UI</li>
                                    <li>edited existing Webform UI and business objects to work with the new logic (code to understand this was a new type of product and send PDF to DocuSign instead of custom Word/PDF files)</li>
                                    <li>added a tutorial using 3rd party JS Library that moved the user through sections of the project, highlighted active divs, and showed explanations</li>
                                    <li>Table based</li>
                                    <li>Did not apply design patterns nor SOLID principal because limited programming time and we took the mock-up/proof-of-concept and transformed it into final product.</li>
                                    <li>SAMPLE CODE: <a href=""../SampleCodeVBDotNET/GetSignatureCoordinatesFromPDF"">Get Signature Coordinates From PDF</a></li>
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
                                    <li>New internal software used to faciliate day-to-day operations when running audits for clients and their investors</li>
                                    <li>Used 3rd party OCR library, regular expressions, and advanced logic to separate PDF files into new smaller PDF files</li>
                                    <li>Read Data from PDF files</li>
                                    <li>Waterfall method</li>
                                    <li>Worked with and gathered project requirements from Doc Prep Lead</li>
                                    <li>Ran Extensive Tests to verify all docs were being captured</li>
                                    <li>Wrote both technical and non-technical documentation</li>
                                    <li>Did not apply design patterns nor SOLID principal because limited programming time and we took the mock-up/proof-of-concept and transformed it into final product.</li>
                                    <li>SAMPLE CODE: <a href=""../SampleCodeVBDotNET/SeparatePDFIntoSmallerPDFs"">Get Signature Coordinates From PDF</a></li>
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
                                    <li>JQuery Datatables gives the ability to easily create UI tables and uses built in pagination, sorting, filtering, and export capabilities in Excel, PDF, and others</li>
                                    <li>From programmer's POV, provides deferred loading with AJAX (web service), ability to use both HTTP Post and Get, reading data from JSON object that gets populated by and converted automatically from business object, strong library for client-side manipulation of the UI table when sorting and filtering, custom server-side pagination, and built in export</li>
                                    <li>SAMPLE CODE: <a href=""../SampleCodeFrontEnd/JQueryDatatablesCustom"">JQuery Datatables - added to existing code</a></li>
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
                                    <li>Gave ability to the client (non-borrower) to see their customers' DocuSign documents and signatures by also sending the client's data to DocuSign via web service</li>
                                    <li>Created more clarity between client and borrowers</li>
                                    <li>Reduced the time the Support and Doc Preparation teams had to spend diagnosing the problem and clarifying any confusion</li>
                                    <li>Thinking outside the box to suggest new solutions to problems no one had thought about</li>
                                    <li>Waterfall method</li>
                                    <li>SAMPLE CODE: <a href=""../SampleCodeVBDotNET/NonBorrowerToViewDocuSignDisclosureUpdates"">non-Borrower To View DocuSign Disclosure Updates</a></li>
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
                    Details="<ul>" +
                    "<li>Created active monitoring of websites by emailing and logging new runtime errors</li>" +
                    "<li>Edited web.config and other config file</li>" +
                    "<li>Created new UI</li>" +
                    "</ul>",
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
                    Details="<ul>" +
                    "<li>Edited web.config to make websites more secure</li>" +
                    "</ul>",
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
                                    <li>TASK:
                                        <ul>
                                            <li>Created custom C# sort to rearrange Package objects, by datetime and then by their description</li>
                                            <li>Ability to collapse similar Packages on UI into 1 table row (edited UI to only display most recent and hide the visibility of the others until the maximize/minimize (+/-) feature were used on that table row)</li>
                                        </ul>
                                    </li>
                                    <li>PROBLEM:  I wasn't able to use LINQ twice because it wouldn't return the desired behavior; after sorting by datetime with LINQ, I needed to sort by the objects' description, so running the 2nd sort would unorganize them and wouldn't be sorted by datetime anymore.</li>
                                    <li>SOLUTION:  My approach was to run the datetime sort first using LINQ and then move any Package with the same description right behind the 1st occurence of that Package description. I wasn't able to use advanced sorting algorithms because of the situation I was in where I needed to keep the current datetime sort order.</li>
                                    <li>LEARNED/APPLIED KNOWLEDGE:  
                                        <ul>
                                            <li>Custom Sorting - Complex Algorithm</li>
                                            <li>Web Services with AJAX and AJAXPro</li>
                                            <li>Complex JS/JQuery to dynamically manipulate the DOM</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE: <a href=""../SampleCodeVBDotNET/CustomSort"">Package Object's C# Sort</a></li>
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
                    Details="<ul>" +
                    "<li>Tutored, mentored, and delegated tasks to mid-level programmer</li>" +
                    "</ul>",
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
                                    <li>TASK:  Many clients reported not being able to save their data</li>
                                    <li>PROBLEM:  With the release of a new Chrome version that disabled onunload, onbeforeunload, and synchronous calls from running when the user left a webpage, many company's websites worldwide had issues. Chrome made this change to prevent websites from delaying or preventing user from leaving a webpage or closing a tab/window.</li>
                                    <li>SOLUTION:
                                        <ul>
                                            <li>I diagnosed the error by isolating the bug to Chrome, stepping through JS and pin pointing the issue, then investigating on Google and found the Chrome 80 release notes.</li>
                                            <li>Replaced all synchronous calls with asynchronous calls</li>
                                            <li>We were up and running later that day</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE: <a href=""../SampleCodeFrontEnd/ChangeExitToAsyncCall"">Change Existing Exit Code to use Async calls</a></li>
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
                    Details="<ul>" +
                    "<li>One of our website's UI had an error that would appear randomly. Prevented users from saving.</li>" +
                    "<li>Found the issue on the backend and fixed. Had to learn the business logic and steps clients took in order to pin point the issue.</li>" +
                    "</ul>",
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
                                    <li>Logic Error:
                                        <ul>
                                            <li>Data was being sent to DocuSign via web service multiple times when it encountered errors</li>
                                            <li>caused confusion when the client's customers were to begin the eSign process and people were tracking these multiple documents created</li>
                                            <li>If the incorrect package(s) was eSigned, then the process had to be restarted, preventing loans from closing on the predicted date.</li>
                                        </ul>
                                    </li>
                                    <li>TASK:
                                        <ul>
                                            <li>Prevent multiple table entries from being created</li>
                                            <li>Only create entries into table after received response from DocuSign</li>
                                            <li>Notify user of error</li>
                                        </ul>
                                    </li>
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
                    Details="<ul>" +
                    "<li>The website the client used to upload data and create new Hybrid loans, which were loans that accepted both wet and eSign signatures, had the ability to create multiple envelope entries into our DB per loan. Each envelope contained multiple wet and eSign packages. I then noticed the software that was used internally for data validation only created and updated the initial envelope's package.</li>" +
                    "<li>After research, I communicated this logic error to the group where we decided to remove the ability to create multiple envelopes per loan. Although a good feature because it gave the client the ability to create multiple envelopes for testing or audit/history purposes, we were not in the position to work on this project.</li>" +
                    "</ul>",
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
                    Details="<ul>" +
                    "<li>The title company's fee descriptions with \"&\" displayed incorrectly, which prevented the loan from being compliant with government regulations.</li>" +
                    "<li>After debugging, I discovered the ampersand was causing issues but couldn't update the data on data submission because it wasn't/couldn't be decoded on other parts of the website; instead, I found the class that was used to display on this particular section and added the escape characters.</li>" +
                    "</ul>",
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
                    Details="<ul>" +
                    "<li>When user is trying to gain access to the Templage Edit page, notify them that it is already locked/open by a different user</li>" +
                    "<li>As a fail-safe, also prevent all the users already in the Template page from deleting or renaming locked templates.</li>" +
                    "</ul>",
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
                    Details="<ul>" +
                    "<li>Use knowledge of DB and backend to add new entries so clients can create new type of loans/orders/products</li>" +
                    "</ul>",
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
                    Details="<ul>" +
                    "<li>Use knowledge of DB and backend to limit access</li>" +
                    "<li>Flags and user groups were used</li>" +
                    "</ul>",
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
                    Details="<ul>" +
                    "<li>Reports, especially ones with historical data, were timing out.</li>" +
                    "<li>Applied 1 or more of these:" +
                    "<ul>" +
                    "<li>SQL query - optimized</li>" +
                    "<li>SQL query - added pagination</li>" +
                    "<li>C# - only returned requested rows</li>" +
                    "<li>C# - update web services</li>" +
                    "<li>C# - edit attributes to increase time limit</li>" +
                    "<li>JQuery Datatables - built in and custom pagination</li>" +
                    "</ul>" +
                    "</li>" +
                    "</ul>",
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
                    Details="<ul>" +
                    "<li>Applied 1 or more of these when creating new reports and updating existing ones:" +
                    "<ul>" +
                    "<li>SQL query - optimized</li>" +
                    "<li>SQL query - added pagination</li>" +
                    "<li>C# - only returned requested rows</li>" +
                    "<li>C# - update web services</li>" +
                    "<li>JQuery Datatables - built in and custom pagination</li>" +
                    "</ul>" +
                    "</li>" +
                    "</ul>",
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
                                    <li>PROBLEM:  Our sales group needed a way to track leads, onboarding, and commision.</li>
                                    <li>SOLUTION:  I created new VB.NET code to utilize Nutshell's web services to send them client data when clients registered on our webpage.</li>
                                    <li>SAMPLE CODE: <a href=""../SampleCodeVBDotNET/NutshellWebServices"">Nutshell - Web Services</a></li>
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
                    Details="<ul>" +
                    "<li>Our sales group needed an EASY way to track leads, onboarding, and commision.</li>" +
                    "<li>I suggested we create our own CRM system instead of using Nutshell.com. A very simple customized system was needed in order to guarantee the Sales group would not stop using it down the road and was easy to learn.</li>" +
                    "<li>Gathered requirements and desires from the Sales group and business owner.</li>" +
                    "<li>As new interested parties registered for a demo, new entries were entered into the new Sales/Leads tables.</li>" +
                    "<li>Introduced JQuery Datatables for the first time into our projects, added form submissions per row in order to update individual records.</li>" +
                    "</ul>",
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
                    Details="<ul>" +
                    "<li>Our sales group needed a report to display all the necessary data for a client, their branches, and users, and easily search on it.  Also, they wanted a feature where they could enter an address and see any client within a certain mile radius.</li>" +
                    "<li>I gathered project requirements and created a report with many search field that used a fuzzy search.</li>" +
                    "<li>I added and used Google's Map API, along with a table specifying distances between zipcodes, to calculate and display all clients on a map within a certain mile radius from an address or zip code entered.</li>" +
                    "</ul>",
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
                    Details="<ul>" +
                    "<li>Our clients needed a way to see if their new and existing loans passed government regulations in order to receive Flood insurance and how much they could be insured for.</li>" +
                    "<li>I created a new webpage with a dynamic form that used VB.NET and Windows controls to display new input elements and determine what the next scenario/state would be as the client entered data.</li>" +
                    "<li>The solution was table-based where each record had a next and prev state. This table-based approach simplified coding on the businesslogic tier.</li>" +
                    "</ul>",
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
                    Details="<ul>" +
                    "<li>Created new webpage that compared a loan's previous and current data.</li>" +
                    "</ul>",
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
                    Details="<ul>" +
                    "<li>Clients would copy and paste emails onto our forms from Excel files; the emails entered were formatted incorrectly at times.</li>" +
                    "<li>For example, the string \"Willie Sandoval <willie@ppdocs.com>\" needed to be updated to \"willie@ppdocs.com\" on the client-side.</li>" +
                    "<li>Created new JS function, made sure all pages included it, and applied to onblur.</li>" +
                    "<li>Delegated portion of task to front end developer</li>" +
                    "</ul>",
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
                    Details="<ul>" +
                    "<li>Found a good library to use.</li>" +
                    "<li>Delegated task to front end developer</li>" +
                    "</ul>",
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
                    Details="<ul>" +
                    "<li>When the system-created PDFs had client-requested custom changes or incorrect format due to large data fields, the client and our Doc Prep team had the ability to edit the PDFs. We needed a way to prevent these custom changes made to these PDFs from being removed by a different user or by our automated system when a loan was resubmitted for approval.</li>" +
                    "<li>Our IT team discussed and we decided to only give managers and the person who edited the PDF the ability to edit or delete. I create a new field in the doc/PDF table that specified the person who made the change and then added new code to this section to only allow them or managers to edit or remove. Also, I had to trace the system to find the code that triggered when resubmitting loans and edited it.</li>" +
                    "</ul>",
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
                    Details=@"
                        <ul>
                            <li>We needed an FAQ page for clients in order to display both default and client-specific topics and articles.</li>
                            <li>Requirements & Notes:
                                <ul>
                                    <li>Both topics and articles could become client-specific.</li>
                                    <li>If a default topic or article was edited for a client, it would only display the new version to the client.</li>
                                    <li>The client-specific topic and articles were tied back to the main default topic and article by referencing it in a field. If the field was null or 0, then that was the default topic or article.</li>
                                    <li>Vertical partioning was used to reduce the amount of data stored and returned.</li>
                                    <li>I was told by IT managers to move away from VBScript classes and use sps instead because it was prefered internally.</li>
                                    <li>...the list of requirements and design notes goes on and on....................</li>
                                </ul>
                            </li>
                            <li>SAMPLE CODE: <a href=""../SampleCodeSQL/AdvancedQuery"">Advanced Query</a></li>
                        </ul>",
                    CompanyId=companies[8].CompanyId,
                    Date=DateTime.Parse("2020-01-01")
                }
            };


            var projectsTopics = new ProjectsTopics[]
            {
                new ProjectsTopics{
                    ProjectId=projects[0].ProjectId,
                    TopicId=topics[0].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[0].ProjectId,
                    TopicId=topics[5].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[0].ProjectId,
                    TopicId=topics[9].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[0].ProjectId,
                    TopicId=topics[19].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[0].ProjectId,
                    TopicId=topics[20].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[0].ProjectId,
                    TopicId=topics[21].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[1].ProjectId,
                    TopicId=topics[2].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[1].ProjectId,
                    TopicId=topics[7].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[1].ProjectId,
                    TopicId=topics[9].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[1].ProjectId,
                    TopicId=topics[22].TopicId
                },
                new ProjectsTopics{
                    ProjectId=projects[1].ProjectId,
                    TopicId=topics[23].TopicId
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
