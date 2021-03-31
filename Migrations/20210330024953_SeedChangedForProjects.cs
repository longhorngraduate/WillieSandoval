using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WillieSandoval_2_28_2021.Migrations
{
    public partial class SeedChangedForProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 1, 20 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 1, 21 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 1, 22 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 2, 23 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 2, 24 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 3,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 4,
                columns: new[] { "Date", "Details" },
                values: new object[] { new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), @"  <ul>
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
                                </ul>" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 5,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 6,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 7,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 8,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 9,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 10,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 11,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 12,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 13,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 14,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 15,
                column: "Details",
                value: @"  <ul>
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
                                            <li>Thinking outside the box to suggest new solutions to problems no one had thought about</li>
                                            <li>Wrote try catch to catch runtime error and display it on one of our submit pages</li>
                                            <li>Realized DocuSign reported false negatives, which we could do nothing about</li>
                                            <li>Diagnosed errors by reviewing our error logs and analysing what went wrong</li>
                                            <li>Waited for more instances of the error to have a large sample set</li>
                                            <li>Wrote code to only proceed with table entry when successfully submited to DocuSign</li>
                                        </ul>
                                    </li>
                                    <li>APPLIED KNOWLEDGE:
                                        <ul>
                                            <li>Diagnosing errors</li>
                                            <li>Analysing errors</li>
                                            <li>Decipher non-programmer's emails and steps to reproduce error</li>
                                        </ul>
                                    </li>
                                    <li>SAMPLE CODE:  None</li>
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 16,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 17,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 18,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 19,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 20,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 21,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 22,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 23,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 24,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 25,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.InsertData(
                table: "ProjectsTopics",
                columns: new[] { "ProjectId", "TopicId" },
                values: new object[,]
                {
                    { 25, 22 },
                    { 21, 21 },
                    { 21, 20 },
                    { 21, 17 },
                    { 21, 16 },
                    { 21, 15 },
                    { 21, 14 },
                    { 21, 13 },
                    { 21, 11 },
                    { 21, 8 },
                    { 21, 2 },
                    { 20, 13 },
                    { 20, 11 },
                    { 20, 8 },
                    { 20, 2 },
                    { 21, 22 },
                    { 19, 13 },
                    { 19, 8 },
                    { 18, 22 },
                    { 18, 21 },
                    { 18, 17 },
                    { 18, 15 },
                    { 18, 11 },
                    { 18, 8 },
                    { 18, 2 },
                    { 17, 22 },
                    { 17, 11 },
                    { 17, 8 },
                    { 17, 2 },
                    { 16, 13 },
                    { 16, 11 },
                    { 19, 11 },
                    { 22, 2 },
                    { 22, 8 },
                    { 22, 11 },
                    { 25, 21 },
                    { 25, 20 },
                    { 25, 16 },
                    { 25, 15 },
                    { 25, 14 },
                    { 25, 11 },
                    { 25, 8 },
                    { 25, 3 },
                    { 24, 22 },
                    { 24, 21 },
                    { 24, 20 },
                    { 24, 16 },
                    { 24, 15 },
                    { 24, 14 },
                    { 24, 13 },
                    { 24, 11 },
                    { 24, 8 },
                    { 22, 13 },
                    { 22, 14 },
                    { 22, 15 },
                    { 22, 16 },
                    { 22, 17 },
                    { 22, 20 },
                    { 25, 25 },
                    { 22, 21 },
                    { 23, 2 },
                    { 23, 8 },
                    { 16, 9 },
                    { 23, 20 },
                    { 23, 22 },
                    { 24, 3 },
                    { 22, 22 },
                    { 23, 11 },
                    { 16, 8 },
                    { 15, 23 },
                    { 5, 8 },
                    { 5, 9 },
                    { 5, 11 },
                    { 5, 13 },
                    { 5, 21 },
                    { 5, 22 },
                    { 5, 23 },
                    { 5, 24 },
                    { 6, 2 },
                    { 6, 9 },
                    { 6, 11 },
                    { 6, 23 },
                    { 6, 24 },
                    { 7, 1 },
                    { 7, 8 },
                    { 7, 11 },
                    { 7, 15 },
                    { 7, 16 },
                    { 7, 17 },
                    { 5, 3 },
                    { 4, 25 },
                    { 4, 22 },
                    { 4, 21 },
                    { 1, 7 },
                    { 1, 15 },
                    { 1, 16 },
                    { 2, 6 },
                    { 2, 15 },
                    { 2, 18 },
                    { 2, 25 },
                    { 3, 6 },
                    { 3, 10 },
                    { 7, 20 },
                    { 3, 15 },
                    { 3, 25 },
                    { 4, 1 },
                    { 4, 6 },
                    { 4, 10 },
                    { 4, 14 },
                    { 4, 15 },
                    { 4, 16 },
                    { 4, 17 },
                    { 4, 20 },
                    { 3, 17 },
                    { 16, 3 },
                    { 7, 21 },
                    { 7, 25 },
                    { 12, 17 },
                    { 12, 20 },
                    { 12, 21 },
                    { 12, 22 },
                    { 12, 25 },
                    { 13, 2 },
                    { 13, 8 },
                    { 13, 11 },
                    { 13, 15 },
                    { 13, 20 },
                    { 13, 21 },
                    { 13, 22 },
                    { 14, 2 },
                    { 14, 8 },
                    { 14, 11 },
                    { 15, 2 },
                    { 15, 8 },
                    { 15, 11 },
                    { 15, 22 },
                    { 12, 16 },
                    { 12, 15 },
                    { 12, 13 },
                    { 12, 11 },
                    { 8, 2 },
                    { 8, 8 },
                    { 8, 11 },
                    { 8, 22 },
                    { 9, 2 },
                    { 9, 8 },
                    { 9, 11 },
                    { 10, 3 },
                    { 10, 8 },
                    { 7, 22 },
                    { 11, 2 },
                    { 11, 11 },
                    { 11, 15 },
                    { 11, 20 },
                    { 11, 21 },
                    { 11, 22 },
                    { 12, 1 },
                    { 12, 6 },
                    { 12, 8 },
                    { 12, 10 },
                    { 11, 8 },
                    { 1, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 1, 15 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 1, 16 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 2, 15 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 2, 18 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 2, 25 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 3, 15 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 3, 17 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 3, 25 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 4, 14 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 4, 15 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 4, 16 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 4, 17 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 4, 20 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 4, 21 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 4, 22 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 4, 25 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 5, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 5, 13 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 5, 21 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 5, 22 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 5, 23 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 5, 24 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 6, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 6, 23 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 6, 24 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 7, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 7, 15 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 7, 16 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 7, 17 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 7, 20 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 7, 21 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 7, 22 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 7, 25 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 8, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 8, 22 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 9, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 9, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 10, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 11, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 11, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 11, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 11, 15 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 11, 20 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 11, 21 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 11, 22 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 12, 6 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 12, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 12, 10 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 12, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 12, 13 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 12, 15 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 12, 16 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 12, 17 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 12, 20 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 12, 21 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 12, 22 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 12, 25 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 13, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 13, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 13, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 13, 15 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 13, 20 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 13, 21 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 13, 22 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 14, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 14, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 14, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 15, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 15, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 15, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 15, 22 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 15, 23 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 16, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 16, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 16, 9 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 16, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 16, 13 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 17, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 17, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 17, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 17, 22 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 18, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 18, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 18, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 18, 15 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 18, 17 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 18, 21 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 18, 22 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 19, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 19, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 19, 13 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 20, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 20, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 20, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 20, 13 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 21, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 21, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 21, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 21, 13 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 21, 14 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 21, 15 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 21, 16 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 21, 17 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 21, 20 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 21, 21 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 21, 22 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 22, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 22, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 22, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 22, 13 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 22, 14 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 22, 15 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 22, 16 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 22, 17 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 22, 20 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 22, 21 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 22, 22 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 23, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 23, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 23, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 23, 20 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 23, 22 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 24, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 24, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 24, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 24, 13 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 24, 14 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 24, 15 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 24, 16 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 24, 20 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 24, 21 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 24, 22 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 25, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 25, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 25, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 25, 14 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 25, 15 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 25, 16 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 25, 20 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 25, 21 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 25, 22 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 25, 25 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 3,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 4,
                columns: new[] { "Date", "Details" },
                values: new object[] { new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), @"  <ul>
                                    <li>Old Accounting system had timeouts and runtime errors, had to be repaird or replaced</li>
                                    <li>Two coworkers and I created a new .NET MVC website with new UI and models</li>
                                    <li>Transferred data between old and new tables using TSQL in order to begin using code first migrations</li>
                                    <li>SAMPLE CODE: <a href=""../SampleCodeFrontEnd/JQueryDatatables"">JQuery Datatables</a></li>
                                </ul>" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 5,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 6,
                column: "Details",
                value: @"  <ul>
                                    <li>New internal software used to faciliate day-to-day operations when running audits for clients and their investors</li>
                                    <li>Used 3rd party OCR library, regular expressions, and advanced logic to separate PDF files into new smaller PDF files</li>
                                    <li>Read Data from PDF files</li>
                                    <li>Waterfall method</li>
                                    <li>Worked with and gathered project requirements from Doc Prep Lead</li>
                                    <li>Ran Extensive Tests to verify all docs were being captured</li>
                                    <li>Wrote both technical and non-technical documentation</li>
                                    <li>Did not apply design patterns nor SOLID principal because limited programming time and we took the mock-up/proof-of-concept and transformed it into final product.</li>
                                    <li>SAMPLE CODE: <a href=""../SampleCodeVBDotNET/SeparatePDFIntoSmallerPDFs"">Get Signature Coordinates From PDF</a></li>
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 7,
                column: "Details",
                value: @"  <ul>
                                    <li>JQuery Datatables gives the ability to easily create UI tables and uses built in pagination, sorting, filtering, and export capabilities in Excel, PDF, and others</li>
                                    <li>From programmer's POV, provides deferred loading with AJAX (web service), ability to use both HTTP Post and Get, reading data from JSON object that gets populated by and converted automatically from business object, strong library for client-side manipulation of the UI table when sorting and filtering, custom server-side pagination, and built in export</li>
                                    <li>SAMPLE CODE: <a href=""../SampleCodeFrontEnd/JQueryDatatablesCustom"">JQuery Datatables - added to existing code</a></li>
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 8,
                column: "Details",
                value: @"  <ul>
                                    <li>Gave ability to the client (non-borrower) to see their customers' DocuSign documents and signatures by also sending the client's data to DocuSign via web service</li>
                                    <li>Created more clarity between client and borrowers</li>
                                    <li>Reduced the time the Support and Doc Preparation teams had to spend diagnosing the problem and clarifying any confusion</li>
                                    <li>Thinking outside the box to suggest new solutions to problems no one had thought about</li>
                                    <li>Waterfall method</li>
                                    <li>SAMPLE CODE: <a href=""../SampleCodeVBDotNET/NonBorrowerToViewDocuSignDisclosureUpdates"">non-Borrower To View DocuSign Disclosure Updates</a></li>
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 9,
                column: "Details",
                value: "<ul><li>Created active monitoring of websites by emailing and logging new runtime errors</li><li>Edited web.config and other config file</li><li>Created new UI</li></ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 10,
                column: "Details",
                value: "<ul><li>Edited web.config to make websites more secure</li></ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 11,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 12,
                column: "Details",
                value: "<ul><li>Tutored, mentored, and delegated tasks to mid-level programmer</li></ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 13,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 14,
                column: "Details",
                value: "<ul><li>One of our website's UI had an error that would appear randomly. Prevented users from saving.</li><li>Found the issue on the backend and fixed. Had to learn the business logic and steps clients took in order to pin point the issue.</li></ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 15,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 16,
                column: "Details",
                value: "<ul><li>The website the client used to upload data and create new Hybrid loans, which were loans that accepted both wet and eSign signatures, had the ability to create multiple envelope entries into our DB per loan. Each envelope contained multiple wet and eSign packages. I then noticed the software that was used internally for data validation only created and updated the initial envelope's package.</li><li>After research, I communicated this logic error to the group where we decided to remove the ability to create multiple envelopes per loan. Although a good feature because it gave the client the ability to create multiple envelopes for testing or audit/history purposes, we were not in the position to work on this project.</li></ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 17,
                column: "Details",
                value: "<ul><li>The title company's fee descriptions with \"&\" displayed incorrectly, which prevented the loan from being compliant with government regulations.</li><li>After debugging, I discovered the ampersand was causing issues but couldn't update the data on data submission because it wasn't/couldn't be decoded on other parts of the website; instead, I found the class that was used to display on this particular section and added the escape characters.</li></ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 18,
                column: "Details",
                value: "<ul><li>When user is trying to gain access to the Templage Edit page, notify them that it is already locked/open by a different user</li><li>As a fail-safe, also prevent all the users already in the Template page from deleting or renaming locked templates.</li></ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 19,
                column: "Details",
                value: "<ul><li>Use knowledge of DB and backend to add new entries so clients can create new type of loans/orders/products</li></ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 20,
                column: "Details",
                value: "<ul><li>Use knowledge of DB and backend to limit access</li><li>Flags and user groups were used</li></ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 21,
                column: "Details",
                value: "<ul><li>Reports, especially ones with historical data, were timing out.</li><li>Applied 1 or more of these:<ul><li>SQL query - optimized</li><li>SQL query - added pagination</li><li>C# - only returned requested rows</li><li>C# - update web services</li><li>C# - edit attributes to increase time limit</li><li>JQuery Datatables - built in and custom pagination</li></ul></li></ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 22,
                column: "Details",
                value: "<ul><li>Applied 1 or more of these when creating new reports and updating existing ones:<ul><li>SQL query - optimized</li><li>SQL query - added pagination</li><li>C# - only returned requested rows</li><li>C# - update web services</li><li>JQuery Datatables - built in and custom pagination</li></ul></li></ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 23,
                column: "Details",
                value: @"  <ul>
                                    <li>PROBLEM:  Our sales group needed a way to track leads, onboarding, and commision.</li>
                                    <li>SOLUTION:  I created new VB.NET code to utilize Nutshell's web services to send them client data when clients registered on our webpage.</li>
                                    <li>SAMPLE CODE: <a href=""../SampleCodeVBDotNET/NutshellWebServices"">Nutshell - Web Services</a></li>
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 24,
                column: "Details",
                value: "<ul><li>Our sales group needed an EASY way to track leads, onboarding, and commision.</li><li>I suggested we create our own CRM system instead of using Nutshell.com. A very simple customized system was needed in order to guarantee the Sales group would not stop using it down the road and was easy to learn.</li><li>Gathered requirements and desires from the Sales group and business owner.</li><li>As new interested parties registered for a demo, new entries were entered into the new Sales/Leads tables.</li><li>Introduced JQuery Datatables for the first time into our projects, added form submissions per row in order to update individual records.</li></ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 25,
                column: "Details",
                value: "<ul><li>Our sales group needed a report to display all the necessary data for a client, their branches, and users, and easily search on it.  Also, they wanted a feature where they could enter an address and see any client within a certain mile radius.</li><li>I gathered project requirements and created a report with many search field that used a fuzzy search.</li><li>I added and used Google's Map API, along with a table specifying distances between zipcodes, to calculate and display all clients on a map within a certain mile radius from an address or zip code entered.</li></ul>");

            migrationBuilder.InsertData(
                table: "ProjectsTopics",
                columns: new[] { "ProjectId", "TopicId" },
                values: new object[,]
                {
                    { 2, 23 },
                    { 2, 8 },
                    { 2, 3 },
                    { 1, 22 },
                    { 1, 21 },
                    { 1, 20 },
                    { 1, 6 },
                    { 2, 24 },
                    { 1, 1 }
                });
        }
    }
}
