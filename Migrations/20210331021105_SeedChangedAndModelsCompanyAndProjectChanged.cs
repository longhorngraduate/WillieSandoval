using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WillieSandoval_2_28_2021.Migrations
{
    public partial class SeedChangedAndModelsCompanyAndProjectChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PayType",
                table: "Companies",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "PayStart",
                table: "Companies",
                type: "decimal(9,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PayEnd",
                table: "Companies",
                type: "decimal(9,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,2)");

            migrationBuilder.AddColumn<bool>(
                name: "Display",
                table: "Companies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 1,
                columns: new[] { "PayEnd", "PayStart" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2,
                columns: new[] { "PayEnd", "PayStart" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 3,
                column: "Display",
                value: true);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 4,
                column: "Display",
                value: true);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 5,
                column: "Display",
                value: true);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 6,
                column: "Display",
                value: true);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 7,
                column: "Display",
                value: true);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 8,
                column: "Display",
                value: true);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 9,
                column: "Display",
                value: true);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 10,
                column: "Display",
                value: true);

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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 26,
                column: "Details",
                value: @"<ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 27,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 28,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 29,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 30,
                column: "Details",
                value: @"  <ul>
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
                                </ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 31,
                columns: new[] { "Date", "Details" },
                values: new object[] { new DateTime(2018, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), @"  <ul>
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
                                </ul>" });

            migrationBuilder.InsertData(
                table: "ProjectsTopics",
                columns: new[] { "ProjectId", "TopicId" },
                values: new object[,]
                {
                    { 31, 17 },
                    { 31, 15 },
                    { 31, 14 },
                    { 31, 13 },
                    { 31, 1 },
                    { 26, 8 },
                    { 26, 11 },
                    { 26, 13 },
                    { 26, 14 },
                    { 27, 3 },
                    { 27, 15 },
                    { 27, 17 },
                    { 31, 12 },
                    { 28, 2 },
                    { 29, 2 },
                    { 29, 15 },
                    { 29, 25 },
                    { 30, 2 },
                    { 30, 8 },
                    { 30, 11 },
                    { 30, 13 },
                    { 28, 15 },
                    { 26, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 26, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 26, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 26, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 26, 13 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 26, 14 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 27, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 27, 15 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 27, 17 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 28, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 28, 15 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 29, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 29, 15 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 29, 25 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 30, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 30, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 30, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 30, 13 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 31, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 31, 12 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 31, 13 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 31, 14 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 31, 15 });

            migrationBuilder.DeleteData(
                table: "ProjectsTopics",
                keyColumns: new[] { "ProjectId", "TopicId" },
                keyValues: new object[] { 31, 17 });

            migrationBuilder.DropColumn(
                name: "Display",
                table: "Companies");

            migrationBuilder.AlterColumn<int>(
                name: "PayType",
                table: "Companies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PayStart",
                table: "Companies",
                type: "decimal(9,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PayEnd",
                table: "Companies",
                type: "decimal(9,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,0)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 1,
                columns: new[] { "PayEnd", "PayStart" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2,
                columns: new[] { "PayEnd", "PayStart" },
                values: new object[] { 0m, 0m });

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
                keyValue: 26,
                column: "Details",
                value: "<ul><li>Our clients needed a way to see if their new and existing loans passed government regulations in order to receive Flood insurance and how much they could be insured for.</li><li>I created a new webpage with a dynamic form that used VB.NET and Windows controls to display new input elements and determine what the next scenario/state would be as the client entered data.</li><li>The solution was table-based where each record had a next and prev state. This table-based approach simplified coding on the businesslogic tier.</li></ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 27,
                column: "Details",
                value: "<ul><li>Created new webpage that compared a loan's previous and current data.</li></ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 28,
                column: "Details",
                value: "<ul><li>Clients would copy and paste emails onto our forms from Excel files; the emails entered were formatted incorrectly at times.</li><li>For example, the string \"Willie Sandoval <willie@ppdocs.com>\" needed to be updated to \"willie@ppdocs.com\" on the client-side.</li><li>Created new JS function, made sure all pages included it, and applied to onblur.</li><li>Delegated portion of task to front end developer</li></ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 29,
                column: "Details",
                value: "<ul><li>Found a good library to use.</li><li>Delegated task to front end developer</li></ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 30,
                column: "Details",
                value: "<ul><li>When the system-created PDFs had client-requested custom changes or incorrect format due to large data fields, the client and our Doc Prep team had the ability to edit the PDFs. We needed a way to prevent these custom changes made to these PDFs from being removed by a different user or by our automated system when a loan was resubmitted for approval.</li><li>Our IT team discussed and we decided to only give managers and the person who edited the PDF the ability to edit or delete. I create a new field in the doc/PDF table that specified the person who made the change and then added new code to this section to only allow them or managers to edit or remove. Also, I had to trace the system to find the code that triggered when resubmitting loans and edited it.</li></ul>");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 31,
                columns: new[] { "Date", "Details" },
                values: new object[] { new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), @"
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
                        </ul>" });
        }
    }
}
