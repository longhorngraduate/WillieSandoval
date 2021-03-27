using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WillieSandoval_2_28_2021.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Location = table.Column<string>(maxLength: 50, nullable: false),
                    JobTitle = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 3000, nullable: false),
                    PayStart = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    PayEnd = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    PayType = table.Column<int>(nullable: false),
                    DateStart = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TopicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TopicId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    ProjectType = table.Column<int>(nullable: false),
                    ProjectDifficulty = table.Column<int>(nullable: false),
                    ProjectImportance = table.Column<int>(nullable: false),
                    Details = table.Column<string>(maxLength: 8000, nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsTopics",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false),
                    TopicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsTopics", x => new { x.ProjectId, x.TopicId });
                    table.ForeignKey(
                        name: "FK_ProjectsTopics_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectsTopics_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "DateEnd", "DateStart", "Description", "JobTitle", "Location", "Name", "PayEnd", "PayStart", "PayType" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Personal Project", "N/A", "N/A", "Personal Project", 0m, 0m, 0 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paid work I completed for others", "N/A", "N/A", "Paid Work", 0m, 0m, 0 },
                    { 3, new DateTime(2007, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2006, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Created test plans, manually tested, reported bugs, and created detailed documentation with supervision.", "Intern - QA", "Austin, TX", "Austin Logistics", 12m, 10m, 0 },
                    { 4, new DateTime(2008, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2007, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Created and ran unit tests, created test plans, manually tested, reported bugs, and created detailed documentation with supervision.", "Intern - QA", "Austin, TX", "Powered", 17m, 15m, 0 },
                    { 5, new DateTime(2009, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2009, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Created software for data validation using regular expressions with supervision.", "Contract - Software Developer", "Plano, TX", "Optimal Blue", 25m, 25m, 0 },
                    { 6, new DateTime(2011, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Created algorithms to predict and analyze stock market behaviour with no supervision.", "Contract - Software Developer", "Remotely", "Hedge Hog Capital", 20m, 10m, 0 },
                    { 7, new DateTime(2011, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2011, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Made improvements to front and backend to existing website with supervision.", "Intern - Web Developer", "Fort Worth, TX", "iProspect (Range Online Media)", 12m, 10m, 0 },
                    { 8, new DateTime(2012, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2011, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Created reports, analyzed data for errors, and created a website with no supervision.", "Software Developer", "Dallas, TX", "NexPay Inc (Talon)", 45000m, 40000m, 1 },
                    { 9, new DateTime(2018, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2012, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Managed and created new functionality to 3 websites on front and back end and tutored entry level programmer in a daily Agile environment.", "Software Developer", "Remotely", "MRN3", 65000m, 55000m, 1 },
                    { 10, new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Added new features and removed bugs from front and backend to existing websites and software, created a new .NET MVC website, updated and cleaned code (introduced Design Patterns, modularized code, and added abstraction), and tutored entry level programmer with little to no supervision using Agile, Waterfall, and Spiral methods.", "Software Developer", "Arlington, TX", "PPDocs", 115000m, 80000m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "TopicId", "Name" },
                values: new object[,]
                {
                    { 15, "JS/JQuery" },
                    { 16, "JQuery Datatables" },
                    { 17, "CSS" },
                    { 18, "CSS (mobile first)" },
                    { 23, "3rd Party Library" },
                    { 20, "JSON" },
                    { 21, "AJAX" },
                    { 22, "Web Services" },
                    { 14, "TSQL" },
                    { 19, "XML" },
                    { 13, "SQL" },
                    { 8, ".NET Webforms" },
                    { 11, "VB.NET" },
                    { 10, "C#" },
                    { 9, ".NET Winforms" },
                    { 24, "OCR" },
                    { 7, ".NET Core" },
                    { 6, ".NET MVC" },
                    { 5, "Design Patterns" },
                    { 4, "TDD" },
                    { 3, "Spiral" },
                    { 2, "Waterfall" },
                    { 1, "Agile" },
                    { 12, "VBScript" },
                    { 25, "JS Libraries" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "CompanyId", "Date", "Description", "Details", "ProjectDifficulty", "ProjectImportance", "ProjectType" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "WillieSandoval.com", @"  <ul>
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
                                                </ul>", 2, 3, 4 },
                    { 28, 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prevent user-error when entering emails with incorrect format - system wide", "<ul><li>Clients would copy and paste emails onto our forms from Excel files; the emails entered were formatted incorrectly at times.</li><li>For example, the string \"Willie Sandoval <willie@ppdocs.com>\" needed to be updated to \"willie@ppdocs.com\" on the client-side.</li><li>Created new JS function, made sure all pages included it, and applied to onblur.</li><li>Delegated portion of task to front end developer</li></ul>", 1, 1, 7 },
                    { 27, 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loan Compare for Sales and Fulfillment team", "<ul><li>Created new webpage that compared a loan's previous and current data.</li></ul>", 1, 2, 7 },
                    { 26, 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Calculator/Help Feature (Flood Calculator)", "<ul><li>Our clients needed a way to see if their new and existing loans passed government regulations in order to receive Flood insurance and how much they could be insured for.</li><li>I created a new webpage with a dynamic form that used VB.NET and Windows controls to display new input elements and determine what the next scenario/state would be as the client entered data.</li><li>The solution was table-based where each record had a next and prev state. This table-based approach simplified coding on the businesslogic tier.</li></ul>", 3, 3, 7 },
                    { 25, 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Client Search (for Sales)", "<ul><li>Our sales group needed a report to display all the necessary data for a client, their branches, and users, and easily search on it.  Also, they wanted a feature where they could enter an address and see any client within a certain mile radius.</li><li>I gathered project requirements and created a report with many search field that used a fuzzy search.</li><li>I added and used Google's Map API, along with a table specifying distances between zipcodes, to calculate and display all clients on a map within a certain mile radius from an address or zip code entered.</li></ul>", 3, 2, 8 },
                    { 24, 10, new DateTime(2018, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sales/Leads Reports and Form (for Sales)", "<ul><li>Our sales group needed an EASY way to track leads, onboarding, and commision.</li><li>I suggested we create our own CRM system instead of using Nutshell.com. A very simple customized system was needed in order to guarantee the Sales group would not stop using it down the road and was easy to learn.</li><li>Gathered requirements and desires from the Sales group and business owner.</li><li>As new interested parties registered for a demo, new entries were entered into the new Sales/Leads tables.</li><li>Introduced JQuery Datatables for the first time into our projects, added form submissions per row in order to update individual records.</li></ul>", 2, 3, 8 },
                    { 23, 10, new DateTime(2018, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nutshell's (CRM) Client data import (for Sales)", @"  <ul>
                                                    <li>PROBLEM:  Our sales group needed a way to track leads, onboarding, and commision.</li>
                                                    <li>SOLUTION:  I created new VB.NET code to utilize Nutshell's web services to send them client data when clients registered on our webpage.</li>
                                                    <li>SAMPLE CODE: <a href=""../SampleCodeVBDotNET/NutshellWebServices"">Nutshell - Web Services</a></li>
                                                </ul>", 2, 3, 8 },
                    { 22, 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reports - Create and Edit", "<ul><li>Applied 1 or more of these when creating new reports and updating existing ones:<ul><li>SQL query - optimized</li><li>SQL query - added pagination</li><li>C# - only returned requested rows</li><li>C# - update web services</li><li>JQuery Datatables - built in and custom pagination</li></ul></li></ul>", 2, 2, 7 },
                    { 21, 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reports - Prevent Timeouts", "<ul><li>Reports, especially ones with historical data, were timing out.</li><li>Applied 1 or more of these:<ul><li>SQL query - optimized</li><li>SQL query - added pagination</li><li>C# - only returned requested rows</li><li>C# - update web services</li><li>C# - edit attributes to increase time limit</li><li>JQuery Datatables - built in and custom pagination</li></ul></li></ul>", 2, 2, 1 },
                    { 20, 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Limit certain users and client branches to access certain loans/orders/products", "<ul><li>Use knowledge of DB and backend to limit access</li><li>Flags and user groups were used</li></ul>", 3, 3, 7 },
                    { 19, 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Add New Loans/Orders/Products", "<ul><li>Use knowledge of DB and backend to add new entries so clients can create new type of loans/orders/products</li></ul>", 2, 2, 7 },
                    { 18, 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Notify user that Template already locked", "<ul><li>When user is trying to gain access to the Templage Edit page, notify them that it is already locked/open by a different user</li><li>As a fail-safe, also prevent all the users already in the Template page from deleting or renaming locked templates.</li></ul>", 1, 2, 7 },
                    { 17, 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Title company with ampersands displayed incorrectly", "<ul><li>The title company's fee descriptions with \"&\" displayed incorrectly, which prevented the loan from being compliant with government regulations.</li><li>After debugging, I discovered the ampersand was causing issues but couldn't update the data on data submission because it wasn't/couldn't be decoded on other parts of the website; instead, I found the class that was used to display on this particular section and added the escape characters.</li></ul>", 2, 3, 1 },
                    { 16, 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prevent incorrect Hybrid eSign package from appearing", "<ul><li>The website the client used to upload data and create new Hybrid loans, which were loans that accepted both wet and eSign signatures, had the ability to create multiple envelope entries into our DB per loan. Each envelope contained multiple wet and eSign packages. I then noticed the software that was used internally for data validation only created and updated the initial envelope's package.</li><li>After research, I communicated this logic error to the group where we decided to remove the ability to create multiple envelopes per loan. Although a good feature because it gave the client the ability to create multiple envelopes for testing or audit/history purposes, we were not in the position to work on this project.</li></ul>", 1, 3, 1 },
                    { 29, 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Add date calendar to date textboxes - system wide", "<ul><li>Found a good library to use.</li><li>Delegated task to front end developer</li></ul>", 1, 1, 7 },
                    { 15, 10, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prevent multiple disclosures from being sent", @"  <ul>
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
                                                </ul>", 2, 3, 1 },
                    { 13, 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chrome 80 Release Repairs", @"  <ul>
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
                                                </ul>", 2, 3, 1 },
                    { 12, 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Supervised Programmer", "<ul><li>Tutored, mentored, and delegated tasks to mid-level programmer</li></ul>", 2, 3, 9 },
                    { 11, 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Package object's C# Sort to be used when Collapsing on the UI", @"  <ul>
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
                                                </ul>", 2, 2, 7 },
                    { 10, 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Improved Security", "<ul><li>Edited web.config to make websites more secure</li></ul>", 2, 3, 7 },
                    { 9, 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Runtime Error Notifications (Exception Handler)", "<ul><li>Created active monitoring of websites by emailing and logging new runtime errors</li><li>Edited web.config and other config file</li><li>Created new UI</li></ul>", 2, 3, 7 },
                    { 8, 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ability for non-borrowers to view and receive updates on the loan's DocuSign documents", @"  <ul>
                                                    <li>Gave ability to the client (non-borrower) to see their customers' DocuSign documents and signatures by also sending the client's data to DocuSign via web service</li>
                                                    <li>Created more clarity between client and borrowers</li>
                                                    <li>Reduced the time the Support and Doc Preparation teams had to spend diagnosing the problem and clarifying any confusion</li>
                                                    <li>Thinking outside the box to suggest new solutions to problems no one had thought about</li>
                                                    <li>Waterfall method</li>
                                                    <li>SAMPLE CODE: <a href=""../SampleCodeVBDotNET/NonBorrowerToViewDocuSignDisclosureUpdates"">non-Borrower To View DocuSign Disclosure Updates</a></li>
                                                </ul>", 2, 3, 7 },
                    { 7, 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System wide to use JQuery Datatable", @"  <ul>
                                                    <li>JQuery Datatables gives the ability to easily create UI tables and uses built in pagination, sorting, filtering, and export capabilities in Excel, PDF, and others</li>
                                                    <li>From programmer's POV, provides deferred loading with AJAX (web service), ability to use both HTTP Post and Get, reading data from JSON object that gets populated by and converted automatically from business object, strong library for client-side manipulation of the UI table when sorting and filtering, custom server-side pagination, and built in export</li>
                                                    <li>SAMPLE CODE: <a href=""../SampleCodeFrontEnd/JQueryDatatablesCustom"">JQuery Datatables - added to existing code</a></li>
                                                </ul>", 3, 3, 7 },
                    { 6, 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Separate PDF Into Smaller PDFs (software for internal Doc Preparation team)", @"  <ul>
                                                    <li>New internal software used to faciliate day-to-day operations when running audits for clients and their investors</li>
                                                    <li>Used 3rd party OCR library, regular expressions, and advanced logic to separate PDF files into new smaller PDF files</li>
                                                    <li>Read Data from PDF files</li>
                                                    <li>Waterfall method</li>
                                                    <li>Worked with and gathered project requirements from Doc Prep Lead</li>
                                                    <li>Ran Extensive Tests to verify all docs were being captured</li>
                                                    <li>Wrote both technical and non-technical documentation</li>
                                                    <li>Did not apply design patterns nor SOLID principal because limited programming time and we took the mock-up/proof-of-concept and transformed it into final product.</li>
                                                    <li>SAMPLE CODE: <a href=""../SampleCodeVBDotNET/SeparatePDFIntoSmallerPDFs"">Get Signature Coordinates From PDF</a></li>
                                                </ul>", 3, 2, 6 },
                    { 5, 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hybrid Closing (new revenue stream)", @"  <ul>
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
                                                </ul>", 3, 3, 7 },
                    { 4, 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Accounting website", @"  <ul>
                                                    <li>Old Accounting system had timeouts and runtime errors, had to be repaird or replaced</li>
                                                    <li>Two coworkers and I created a new .NET MVC website with new UI and models</li>
                                                    <li>Transferred data between old and new tables using TSQL in order to begin using code first migrations</li>
                                                    <li>SAMPLE CODE: <a href=""../SampleCodeFrontEnd/JQueryDatatables"">JQuery Datatables</a></li>
                                                </ul>", 3, 3, 3 },
                    { 31, 9, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FAQ page for clients with default and client-specific Topics and Articles", @"
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
                                        </ul>", 3, 3, 5 },
                    { 3, 2, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ParentAgent.com", @"  <ul>
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
                                                </ul>", 2, 1, 3 },
                    { 2, 2, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DFWAirConditioningExperts.com", @"  <ul>
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
                                                </ul>", 1, 1, 3 },
                    { 14, 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Remove \"Error Linking\" Runtime Errors", "<ul><li>One of our website's UI had an error that would appear randomly. Prevented users from saving.</li><li>Found the issue on the backend and fixed. Had to learn the business logic and steps clients took in order to pin point the issue.</li></ul>", 3, 3, 1 },
                    { 30, 10, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Add an \"owner\" to the new PDF changes when user made custom changes to the PDF & only allow \"owner\" or managers to remove custom document", "<ul><li>When the system-created PDFs had client-requested custom changes or incorrect format due to large data fields, the client and our Doc Prep team had the ability to edit the PDFs. We needed a way to prevent these custom changes made to these PDFs from being removed by a different user or by our automated system when a loan was resubmitted for approval.</li><li>Our IT team discussed and we decided to only give managers and the person who edited the PDF the ability to edit or delete. I create a new field in the doc/PDF table that specified the person who made the change and then added new code to this section to only allow them or managers to edit or remove. Also, I had to trace the system to find the code that triggered when resubmitting loans and edited it.</li></ul>", 3, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsTopics",
                columns: new[] { "ProjectId", "TopicId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 6 },
                    { 1, 10 },
                    { 1, 20 },
                    { 1, 21 },
                    { 1, 22 },
                    { 2, 3 },
                    { 2, 8 },
                    { 2, 10 },
                    { 2, 23 },
                    { 2, 24 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CompanyId",
                table: "Projects",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsTopics_TopicId",
                table: "ProjectsTopics",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ProjectsTopics");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
