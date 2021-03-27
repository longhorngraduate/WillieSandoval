using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillieSandoval_2_28_2021.ViewModels
{
    public class SampleCodeSQLViewModel
    {
        public string AdvancedQuery { get; } = @"
----- EXAMPLE -----
--Application
--	Topics
--		Articles
--CLDD
--	Ad-Hoc Report
--		Fields
--		Where-Clause
--UW
--	MD-Sub-GeneralInfo
--		Fields
----- end of EXAMPLE -----
----- CREATE TABLES -----
USE [someDB];
IF EXISTS
(
    SELECT *
    FROM sys.columns
    WHERE object_id = OBJECT_ID(N'[dbo].[Articles_references]')
)
    DROP TABLE [someDB].[dbo].[Articles_references];
IF EXISTS
(
    SELECT *
    FROM sys.columns
    WHERE object_id = OBJECT_ID(N'[dbo].[Articles_config]')
)
    DROP TABLE [someDB].[dbo].[Articles_config];
IF EXISTS
(
    SELECT *
    FROM sys.columns
    WHERE object_id = OBJECT_ID(N'[dbo].[Articles]')
)
    DROP TABLE [someDB].[dbo].[Articles];
IF EXISTS
(
    SELECT *
    FROM sys.columns
    WHERE object_id = OBJECT_ID(N'[dbo].[Topics]')
)
    DROP TABLE [someDB].[dbo].[Topics];
IF EXISTS
(
    SELECT *
    FROM sys.columns
    WHERE object_id = OBJECT_ID(N'[dbo].[Applications]')
)
    DROP TABLE [someDB].[dbo].[Applications];
CREATE TABLE [someDB].[dbo].[Applications]
(app_ID   INT
 PRIMARY KEY IDENTITY, 
 app_name VARCHAR(50) NOT NULL, 
 app_path VARCHAR(250) NULL
);
CREATE TABLE [someDB].[dbo].[Topics]
(T_ID              INT
 PRIMARY KEY IDENTITY, 
 app_ID            INT NOT NULL
                       FOREIGN KEY REFERENCES [someDB].[dbo].[Applications](app_ID), 
 JobID             VARCHAR(6) NULL, 
 parent_T_ID       INT NULL, 
 topic_name        VARCHAR(50) NOT NULL, 
 topic_path        VARCHAR(250) NULL, 
 topic_created_by  INT NOT NULL, 
 topic_created_DTS DATETIME NULL
                            DEFAULT(GETDATE()), 
 topic_edited_by   INT NOT NULL, 
 topic_edited_DTS  DATETIME NULL
                            DEFAULT(GETDATE()), 
 topic_active      BIT NULL, 
 [Order]           INT NULL
);
CREATE TABLE [someDB].[dbo].[Articles]
(A_ID                INT
 PRIMARY KEY IDENTITY, 
 article_text        VARCHAR(4000) NULL, 
 article_name        VARCHAR(50) NOT NULL, 
 article_path        VARCHAR(250) NULL, 
 article_created_by  INT NOT NULL, 
 article_created_DTS DATETIME NULL
                              DEFAULT(GETDATE()), 
 article_edited_by   INT NOT NULL, 
 article_edited_DTS  DATETIME NULL
                              DEFAULT(GETDATE()), 
 article_active      BIT NULL
);
CREATE TABLE [someDB].[dbo].[Articles_config]
(AC_ID          INT
 PRIMARY KEY IDENTITY, 
 JobID          VARCHAR(6) NULL, 
 parent_AC_ID   INT NULL, 
 T_ID           INT NOT NULL
                    FOREIGN KEY REFERENCES [someDB].[dbo].[Topics](T_ID), 
 A_ID           INT NOT NULL
                    FOREIGN KEY REFERENCES [someDB].[dbo].[Articles](A_ID), 
 overwritten    BIT NULL, 
 ac_created_by  INT NOT NULL, 
 ac_created_DTS DATETIME NULL
                         DEFAULT(GETDATE()), 
 ac_edited_by   INT NOT NULL, 
 ac_edited_DTS  DATETIME NULL
                         DEFAULT(GETDATE()), 
 ac_active      BIT NULL, 
 [Order]        INT NULL
);
CREATE TABLE [someDB].[dbo].[Articles_references]
(AR_ID            INT
 PRIMARY KEY IDENTITY, 
 AC_ID_main       INT NOT NULL
                      FOREIGN KEY REFERENCES [someDB].[dbo].[Articles_config](AC_ID), 
 AC_ID_references INT NOT NULL
                      FOREIGN KEY REFERENCES [someDB].[dbo].[Articles_config](AC_ID), 
 ar_created_by    INT NOT NULL, 
 ar_created_DTS   DATETIME NULL
                           DEFAULT(GETDATE()), 
 ar_edited_by     INT NOT NULL, 
 ar_edited_DTS    DATETIME NULL
                           DEFAULT(GETDATE()), 
 [Order]          INT NULL
);

----- end of CREATE TABLES -----
----- INSERT SAMPLE DATA -----
--INSERT INTO 	   [someDB].[dbo].[Applications](app_name
--												   ,app_path)
--  VALUES		   ('someDB3', 'www.Stage.website.com')
--				  ,('someDB2', 'www.Stage.website.com')
--				  ,('someDB4', 'www.Stage.website.com');
--
--INSERT INTO 	   [someDB].[dbo].[Topics](app_ID
--											 ,JobID
--											 ,parent_T_ID
--											 ,topic_name
--											 ,topic_path
--											 ,topic_created_by
--											 ,topic_edited_by
--											 ,topic_active
--											 ,[Order])
--  VALUES		   (1, NULL, NULL, 'Topic 1', 'Topic Path here', 965, 965, 1, 1)
--				  ,(1, NULL, NULL, 'Topic 2', 'Topic Path here', 965, 965, 1, 2)
--				  ,(1, '6033', 2, 'Topic 2 for JobID 6033', 'Topic Path here', 965, 965, 1, 2)
--				  ,(1, NULL, NULL, 'Topic 3', 'Topic Path here', 965, 965, 1, 3)
--				  ,(1, NULL, NULL, 'Topic 4', 'Topic Path here', 965, 965, 1, 4)
--				  ,(1, '6033', 5, 'Topic 4 for JobID 6033', 'Topic Path here', 965, 965, 1, 4)
--				  ,(1, NULL, NULL, 'Topic 5', 'Topic Path here', 965, 965, 1, 5)
--				  ,(1, NULL, NULL, 'Topic 6', 'Topic Path here', 965, 965, 1, 6)
--				  ,(1, NULL, NULL, 'Topic 7', 'Topic Path here', 965, 965, 1, 7)
--				  ,(1, '6033', 9, 'Topic 7 for JobID 6033', 'Topic Path here', 965, 965, 1, 7)
--				  ,(1, NULL, NULL, 'Topic 8', 'Topic Path here', 965, 965, 1, 8)
--				  ,(1, NULL, NULL, 'Topic 9', 'Topic Path here', 965, 965, 1, 9)
--				  ,(1, NULL, NULL, 'Topic 10 with a really long name, just in case', 'Topic Path here', 965, 965, 1, 10)
--				  ,(1, NULL, NULL, 'Topic 11', 'Topic Path here', 965, 965, 1, 11)
--				  ,(1, '6034', 14, 'Topic 11 for JobID 6034', 'Topic Path here', 965, 965, 1, 11)
--				  ,(1, '6034', NULL, 'Topic 12 for JobID 6034 ONLY', 'Topic Path here', 965, 965, 1, 11);
--
----16
--
--INSERT INTO 	   [someDB].[dbo].[Articles](article_text
--											   ,article_name
--											   ,article_path
--											   ,article_created_by
--											   ,article_edited_by
--											   ,article_active)
--  VALUES		   ('Article 1 Article', 'Article 1', '/someDB3/pages/reports/ReportsMenu.asp', 965, 965, 1)
--				  ,('Article 2 Article', 'Article 2', '/someDB3/pages/reports/ReportsMenu_2.asp', 965, 965, 1)
--				  ,('Article 2 Article for JOB ID 6033 ONLY!', 'Article 2 for JobID 6033', '/someDB3/pages/reports/ReportsMenu_2.asp', 965, 965, 1)
--				  ,('Article 3 Article', 'Article 3', '/someDB3/pages/reports/ReportsMenu_3.asp', 965, 965, 1)
--				  ,('Article 4 Article', 'Article 4', '/someDB3/pages/reports/ReportsMenu_4.asp', 965, 965, 1)
--				  ,('Article 4 Article for JOB ID 6033 ONLY!', 'Article 4 for JobID 6033', '/someDB3/pages/reports/ReportsMenu_4.asp', 965, 965, 1)
--				  ,('Article 5 Article', 'Article 5', '/someDB3/pages/reports/ReportsMenu_5.asp', 965, 965, 1)
--				  ,('Article 6 Article', 'Article 6', '/someDB3/pages/reports/ReportsMenu_6.asp', 965, 965, 1)
--				  ,('Article 7 Article', 'Article 7', '/someDB3/pages/reports/ReportsMenu_7.asp', 965, 965, 1)
--				  ,('Article 8 Article', 'Article 8', '/someDB3/pages/reports/ReportsMenu_8.asp', 965, 965, 1)
--				  ,('Article 9 Article', 'Article 9', '/someDB3/pages/reports/ReportsMenu_9.asp', 965, 965, 1)
--				  ,('Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--				  		Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.  Test test test test test test test test test test test.
--						Testing, LONG TEST.  This is where all my 4000 max char text goes for Article 10.', 'Article with a really long name, just in case'
--				   ,'/someDB3/pages/reports/ReportsMenu_10.asp', 965, 965, 1)
--				  ,('Article 10 Article for JOB ID 6033 ONLY!', 'Article 10 for JobID 6033', '/someDB3/pages/reports/ReportsMenu_10.asp', 965, 965, 1)
--				  ,('Article 5 Article', 'Article 5', '/someDB3/pages/reports/ReportsMenu_5.asp', 965, 965, 1);
--
----14
--
----the field overwritten is used when it points to a unique article.  If NULL or 0, that means it points to it's parent's Article
--INSERT INTO 	   [someDB].[dbo].[Articles_config](JobID
--													  ,parent_AC_ID
--													  ,T_ID
--													  ,A_ID
--													  ,overwritten
--													  ,ac_created_by
--													  ,ac_edited_by
--													  ,ac_active
--													  ,[Order])
--  VALUES		   (NULL, NULL, 1, 1, 1, 965, 965, 1, 1)
--				  ,(NULL, NULL, 1, 2, 1, 965, 965, 1, 2)
--				  ,('6033', 2, 1, 3, 1, 965, 965, 1, 2)
--				  ,(NULL, NULL, 1, 4, 1, 965, 965, 1, 3)
--				  ,(NULL, NULL, 1, 5, 1, 965, 965, 1, 4)
--				  ,('6033', 5, 1, 6, 1, 965, 965, 1, 4)
--				  ,(NULL, NULL, 1, 7, 1, 965, 965, 1, 5)
--				  ,(NULL, NULL, 1, 8, 1, 965, 965, 1, 6)
--				  ,(NULL, NULL, 1, 9, 1, 965, 965, 1, 7)
--				  ,(NULL, NULL, 1, 10, 1, 965, 965, 1, 8)
--				  ,(NULL, NULL, 1, 11, 1, 965, 965, 1, 9)
--				  ,(NULL, NULL, 1, 12, 1, 965, 965, 1, 10)
--				  ,('6033', 12, 1, 13, 1, 965, 965, 1, 10)
--				  ,(NULL, NULL, 7, 1, NULL, 965, 965, 1, 1)
--				  ,(NULL, NULL, 7, 2, NULL, 965, 965, 1, 2)
--				  ,('6034', NULL, 7, 14, 1, 965, 965, 1, 1);
----16
----- end of INSERT SAMPLE DATA -----
----- NOTES -----
--  SELECT		*
--  FROM			[someDB].[dbo].[Applications] WITH(NOLOCK)
--
--  SELECT		*
--  FROM			[someDB].[dbo].[Topics] WITH(NOLOCK)
--
--  SELECT		*
--  FROM			[someDB].[dbo].[Articles] WITH(NOLOCK)
--
--  SELECT		*
--  FROM			[someDB].[dbo].[Articles_config] WITH(NOLOCK)
--  SELECT		*
--  FROM			[someDB].[dbo].[Articles_references] WITH(NOLOCK)
----- end of NOTES -----
------------------------------
--NEW SECTION
--CREATE PROCEDURE [dbo].[usp_GET_Article_App]
---  someDB1
------------------------------

USE [someDB1];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
IF EXISTS
(
    SELECT *
    FROM information_schema.routines WITH(NOLOCK)
    WHERE routine_type = 'PROCEDURE'
          AND routine_name = 'usp_GET_Article_App'
)
    DROP PROCEDURE usp_GET_Article_App;
GO
CREATE PROCEDURE [dbo].[usp_GET_Article_App] @app_name AS      VARCHAR(50), 
                                             @topic_ID AS      VARCHAR(50) = NULL, 
                                             @A_ID AS          INT         = 0, 
                                             @AC_ID AS         INT         = 0, 
                                             @article_path AS  VARCHAR(75), 
                                             @JobID AS         VARCHAR(6)  = NULL, 
                                             @JobID_changed AS BIT         = 0
AS
    BEGIN
        SET NOCOUNT ON;
        IF ISNULL(@app_name, '') = ''
            SET @app_name = '%';
        IF ISNULL(@topic_ID, '') = ''
            SET @topic_ID = '%';
        IF ISNULL(@A_ID, 0) = 0
            SET @A_ID = 0;
        IF ISNULL(@AC_ID, 0) = 0
            SET @AC_ID = 0;
        IF ISNULL(@article_path, '') = ''
            --OR @AC_ID <> 0
            SET @article_path = '%';
        IF ISNULL(@JobID, '') = ''
            SET @JobID = '';

        --@AC_ID is correct
        IF @JobID_changed = 0
            BEGIN
                SELECT t_join.T_ID, 
                       t_join.topic_name, 
                       ac.parent_AC_ID, 
                       ac.AC_ID, 
                       ac.JobID, 
                       ac.overwritten, 
                       a.A_ID, 
                       a.article_name, 
                       a.article_text
                FROM [someDB1].[dbo].[Applications] app WITH(NOLOCK)
                     JOIN
                (
                    SELECT t2.T_ID, 
                           t2.topic_name, 
                           t2.[Order], 
                           t2.app_ID
                    FROM [someDB1].[dbo].[Applications] app WITH(NOLOCK)
                         JOIN [someDB1].[dbo].[Topics] t1 WITH(NOLOCK) ON app.app_ID = t1.app_ID
                                                                          AND t1.topic_active = 1
                         JOIN [someDB1].[dbo].[Topics] t2 WITH(NOLOCK) ON t1.T_ID = t2.parent_T_ID
                                                                          AND t2.topic_active = 1
                                                                          AND t2.JobID = @JobID
                    WHERE app.app_name LIKE @app_name
                    UNION ALL
                    SELECT t1.T_ID, 
                           t1.topic_name, 
                           t1.[Order], 
                           t1.app_ID
                    FROM [someDB1].[dbo].[Applications] app WITH(NOLOCK)
                         JOIN [someDB1].[dbo].[Topics] t1 WITH(NOLOCK) ON app.app_ID = t1.app_ID
                                                                          AND t1.topic_active = 1
                         LEFT JOIN [someDB1].[dbo].[Topics] t2 WITH(NOLOCK) ON t1.T_ID = t2.parent_T_ID
                                                                               AND t2.topic_active = 1
                                                                               AND t2.JobID = @JobID
                    WHERE app.app_name LIKE @app_name
                          AND ISNULL(t1.JobID, @JobID) = @JobID
                          AND t1.parent_T_ID IS NULL
                          AND t2.T_ID IS NULL
                ) t_join ON app.app_ID = t_join.app_ID
                    --only client-specific Articles UNION ALL parent Articles w/out children and parentless client-specific Articles UNION ALL parent Articles w/ disabled children
                     JOIN
                (
                    SELECT ac2.AC_ID, 
                           ac2.[Order], 
                           ac2.T_ID, 
                           ac2.A_ID, 
                           ac2.JobID, 
                           ac2.parent_AC_ID, 
                           ac2.overwritten, 
                           STR(ac2.[Order]) + '.2.' + STR(ac2.AC_ID) AS 'myOrder'
                    FROM [someDB1].[dbo].[Articles_config] ac1 WITH(NOLOCK)
                         JOIN [someDB1].[dbo].[Articles_config] ac2 WITH(NOLOCK) ON ac1.AC_ID = ac2.parent_AC_ID
                                                                                    --AND ac2.ac_active = 1
                                                                                    AND ac2.JobID = @JobID
                    --WHERE   ac1.ac_active = 1
                    UNION ALL
                    SELECT ac1.AC_ID, 
                           ac1.[Order], 
                           ac1.T_ID, 
                           ac1.A_ID, 
                           ac1.JobID, 
                           ac1.parent_AC_ID, 
                           ac1.overwritten, 
                           STR(ac1.[Order]) + '.1.' + STR(ac1.AC_ID) AS 'myOrder'
                    FROM [someDB1].[dbo].[Articles_config] ac1 WITH(NOLOCK)
                         LEFT JOIN [someDB1].[dbo].[Articles_config] ac2 WITH(NOLOCK) ON ac1.AC_ID = ac2.parent_AC_ID
                                                                                         --AND ac2.ac_active = 1
                                                                                         AND ac2.JobID = @JobID
                    WHERE ISNULL(ac1.JobID, @JobID) = @JobID
                          --AND ac1.ac_active = 1
                          AND ac1.parent_AC_ID IS NULL
                          AND ac2.AC_ID IS NULL
                    UNION ALL
                    SELECT ac1.AC_ID, 
                           ac1.[Order], 
                           ac1.T_ID, 
                           ac1.A_ID, 
                           ac1.JobID, 
                           ac1.parent_AC_ID, 
                           ac1.overwritten, 
                           STR(ac2.[Order]) + '.1.' + STR(ac1.AC_ID) AS 'myOrder'
                    FROM [someDB1].[dbo].[Articles_config] ac1 WITH(NOLOCK)
                         JOIN [someDB1].[dbo].[Articles_config] ac2 WITH(NOLOCK) ON ac1.AC_ID = ac2.parent_AC_ID
                                                                                    AND ac1.JobID IS NULL
                                                                                    AND ac2.JobID = @JobID
                                                                                    AND ac2.ac_active = 0
                ) ac ON t_join.T_ID = ac.T_ID
                     JOIN [someDB1].[dbo].[Articles] a WITH(NOLOCK) ON ac.A_ID = a.A_ID
                                                                       AND a.article_active = 1
                                                                       AND a.article_path = @article_path
                WHERE app.app_name LIKE @app_name
                      AND t_join.T_ID LIKE @topic_ID
                      AND ac.A_ID = (CASE
                                         WHEN @A_ID = 0
                                         THEN ac.A_ID
                                         ELSE @A_ID
                                     END)
                      AND ac.AC_ID = (CASE
                                          WHEN @AC_ID = 0
                                          THEN ac.AC_ID
                                          ELSE @AC_ID
                                      END)
                ORDER BY t_join.[Order], 
                         ac.myOrder, 
                         ac.[Order];
            END
                --get data using article_path;
            ELSE
            BEGIN
                SELECT t_join.T_ID, 
                       t_join.topic_name, 
                       ac.parent_AC_ID, 
                       ac.AC_ID, 
                       ac.JobID, 
                       ac.overwritten, 
                       a.A_ID, 
                       a.article_name, 
                       a.article_text
                FROM [someDB1].[dbo].[Applications] app WITH(NOLOCK)
                     JOIN
                (
                    SELECT t2.T_ID, 
                           t2.topic_name, 
                           t2.[Order], 
                           t2.app_ID
                    FROM [someDB1].[dbo].[Applications] app WITH(NOLOCK)
                         JOIN [someDB1].[dbo].[Topics] t1 WITH(NOLOCK) ON app.app_ID = t1.app_ID
                                                                          AND t1.topic_active = 1
                         JOIN [someDB1].[dbo].[Topics] t2 WITH(NOLOCK) ON t1.T_ID = t2.parent_T_ID
                                                                          AND t2.topic_active = 1
                                                                          AND t2.JobID = @JobID
                    WHERE app.app_name LIKE @app_name
                    UNION ALL
                    SELECT t1.T_ID, 
                           t1.topic_name, 
                           t1.[Order], 
                           t1.app_ID
                    FROM [someDB1].[dbo].[Applications] app WITH(NOLOCK)
                         JOIN [someDB1].[dbo].[Topics] t1 WITH(NOLOCK) ON app.app_ID = t1.app_ID
                                                                          AND t1.topic_active = 1
                         LEFT JOIN [someDB1].[dbo].[Topics] t2 WITH(NOLOCK) ON t1.T_ID = t2.parent_T_ID
                                                                               AND t2.topic_active = 1
                                                                               AND t2.JobID = @JobID
                    WHERE app.app_name LIKE @app_name
                          AND ISNULL(t1.JobID, @JobID) = @JobID
                          AND t1.parent_T_ID IS NULL
                          AND t2.T_ID IS NULL
                ) t_join ON app.app_ID = t_join.app_ID
                    --only client-specific Articles UNION ALL parent Articles w/out children and parentless client-specific Articles UNION ALL parent Articles w/ disabled children
                     JOIN
                (
                    SELECT ac2.AC_ID, 
                           ac2.[Order], 
                           ac2.T_ID, 
                           ac2.A_ID, 
                           ac2.JobID, 
                           ac2.parent_AC_ID, 
                           ac2.overwritten, 
                           STR(ac2.[Order]) + '.2.' + STR(ac2.AC_ID) AS 'myOrder'
                    FROM [someDB1].[dbo].[Articles_config] ac1 WITH(NOLOCK)
                         JOIN [someDB1].[dbo].[Articles_config] ac2 WITH(NOLOCK) ON ac1.AC_ID = ac2.parent_AC_ID
                                                                                    --AND ac2.ac_active = 1
                                                                                    AND ac2.JobID = @JobID
                    --WHERE   ac1.ac_active = 1
                    UNION ALL
                    SELECT ac1.AC_ID, 
                           ac1.[Order], 
                           ac1.T_ID, 
                           ac1.A_ID, 
                           ac1.JobID, 
                           ac1.parent_AC_ID, 
                           ac1.overwritten, 
                           STR(ac1.[Order]) + '.1.' + STR(ac1.AC_ID) AS 'myOrder'
                    FROM [someDB1].[dbo].[Articles_config] ac1 WITH(NOLOCK)
                         LEFT JOIN [someDB1].[dbo].[Articles_config] ac2 WITH(NOLOCK) ON ac1.AC_ID = ac2.parent_AC_ID
                                                                                         --AND ac2.ac_active = 1
                                                                                         AND ac2.JobID = @JobID
                    WHERE ISNULL(ac1.JobID, @JobID) = @JobID
                          --AND ac1.ac_active = 1
                          AND ac1.parent_AC_ID IS NULL
                          AND ac2.AC_ID IS NULL
                    UNION ALL
                    SELECT ac1.AC_ID, 
                           ac1.[Order], 
                           ac1.T_ID, 
                           ac1.A_ID, 
                           ac1.JobID, 
                           ac1.parent_AC_ID, 
                           ac1.overwritten, 
                           STR(ac2.[Order]) + '.1.' + STR(ac1.AC_ID) AS 'myOrder'
                    FROM [someDB1].[dbo].[Articles_config] ac1 WITH(NOLOCK)
                         JOIN [someDB1].[dbo].[Articles_config] ac2 WITH(NOLOCK) ON ac1.AC_ID = ac2.parent_AC_ID
                                                                                    AND ac1.JobID IS NULL
                                                                                    AND ac2.JobID = @JobID
                                                                                    AND ac2.ac_active = 0
                ) ac ON t_join.T_ID = ac.T_ID
                     JOIN [someDB1].[dbo].[Articles] a WITH(NOLOCK) ON ac.A_ID = a.A_ID
                                                                       AND a.article_active = 1
                                                                       AND a.article_path = @article_path
                WHERE app.app_name LIKE @app_name
                      AND t_join.T_ID LIKE @topic_ID
                      AND ac.A_ID = (CASE
                                         WHEN @A_ID = 0
                                         THEN ac.A_ID
                                         ELSE @A_ID
                                     END)
                      AND ac.AC_ID <> @AC_ID
                ORDER BY ac.JobID DESC;
            END;
    END;
GO

------------------------------
--NEW SECTION
--CREATE PROCEDURE [dbo].[usp_GET_Article_Non_References]
---  someDB1
------------------------------

USE [someDB1];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
IF EXISTS
(
    SELECT *
    FROM information_schema.routines WITH(NOLOCK)
    WHERE routine_type = 'PROCEDURE'
          AND routine_name = 'usp_GET_Article_Non_References'
)
    DROP PROCEDURE usp_GET_Article_Non_References;
GO
CREATE PROCEDURE [dbo].[usp_GET_Article_Non_References] @app_name AS            VARCHAR(50), 
                                                        @topic_ID AS            VARCHAR(50) = NULL, 
                                                        @article_path AS        VARCHAR(75) = NULL, 
                                                        @JobID AS               VARCHAR(6)  = NULL, 
                                                        @search_topic_name AS   VARCHAR(50) = '%', 
                                                        @search_article_name AS VARCHAR(50) = '%', 
                                                        @AC_ID AS               INT
AS
    BEGIN
        SET NOCOUNT ON;
        IF ISNULL(@app_name, '') = ''
            SET @app_name = '%';
        IF ISNULL(@topic_ID, '') = ''
            SET @topic_ID = '%';
        IF ISNULL(@article_path, '') = ''
            SET @article_path = '%';
        IF ISNULL(@JobID, '') = ''
            SET @JobID = '';
        IF ISNULL(@search_topic_name, '') = ''
            BEGIN
                SET @search_topic_name = '%';
            END;
            ELSE
            BEGIN
                SET @search_topic_name = '%' + @search_topic_name + '%';
            END;
        IF ISNULL(@search_article_name, '') = ''
            BEGIN
                SET @search_article_name = '%';
            END;
            ELSE
            BEGIN
                SET @search_article_name = '%' + @search_article_name + '%';
            END;
        SELECT t_join.T_ID, 
               t_join.topic_name, 
               t_join.JobID 'T_JobID', 
               t_join.parent_T_ID, 
               ac.AC_ID, 
               ac.JobID, 
               ac.parent_AC_ID, 
               ac.overwritten, 
               ac.ac_active, 
               ac.scenario, 
               a.A_ID, 
               a.article_name, 
               a.article_text, 
               a.article_path
        FROM
        (
            SELECT t2.T_ID, 
                   t2.topic_name, 
                   t2.JobID, 
                   t2.parent_T_ID, 
                   t2.[Order]
            FROM [someDB1].[dbo].[Applications] app WITH(NOLOCK)
                 JOIN [someDB1].[dbo].[Topics] t1 WITH(NOLOCK) ON app.app_ID = t1.app_ID
                                                                  AND t1.topic_active = 1
                 JOIN [someDB1].[dbo].[Topics] t2 WITH(NOLOCK) ON t1.T_ID = t2.parent_T_ID
                                                                  AND t2.topic_active = 1
                                                                  AND t2.JobID = @JobID
            WHERE app.app_name LIKE @app_name
            UNION ALL
            SELECT t1.T_ID, 
                   t1.topic_name, 
                   t1.JobID, 
                   t1.parent_T_ID, 
                   t1.[Order]
            FROM [someDB1].[dbo].[Applications] app WITH(NOLOCK)
                 JOIN [someDB1].[dbo].[Topics] t1 WITH(NOLOCK) ON app.app_ID = t1.app_ID
                                                                  AND t1.topic_active = 1
                 LEFT JOIN [someDB1].[dbo].[Topics] t2 WITH(NOLOCK) ON t1.T_ID = t2.parent_T_ID
                                                                       AND t2.topic_active = 1
                                                                       AND t2.JobID = @JobID
            WHERE app.app_name LIKE @app_name
                  AND ISNULL(t1.JobID, @JobID) = @JobID
                  AND t1.parent_T_ID IS NULL
                  AND t2.T_ID IS NULL
        ) t_join
            --only client-specific Articles UNION ALL parent Articles w/out children and parentless client-specific Articles UNION ALL parent Articles w/ disabled children
        LEFT JOIN
        (
            SELECT ac2.AC_ID, 
                   ac2.[Order], 
                   ac2.T_ID, 
                   ac2.A_ID, 
                   ac2.JobID, 
                   ac2.parent_AC_ID, 
                   ac2.overwritten, 
                   ac2.ac_active, 
                   '1' AS 'scenario', 
                   STR(ac2.[Order]) + '.2.' + STR(ac2.AC_ID) AS 'myOrder'
            FROM [someDB1].[dbo].[Articles_config] ac1 WITH(NOLOCK)
                 JOIN [someDB1].[dbo].[Articles_config] ac2 WITH(NOLOCK) ON ac1.AC_ID = ac2.parent_AC_ID
                                                                            --AND ac2.ac_active = 1
                                                                            AND ac2.JobID = @JobID
            --WHERE   ac1.ac_active = 1
            UNION ALL
            SELECT ac1.AC_ID, 
                   ac1.[Order], 
                   ac1.T_ID, 
                   ac1.A_ID, 
                   ac1.JobID, 
                   ac1.parent_AC_ID, 
                   ac1.overwritten, 
                   ac1.ac_active,
                   CASE
                       WHEN ISNULL(
            (
                SELECT COUNT(ac2_inner.AC_ID)
                FROM [someDB1].[dbo].[Articles_config] ac2_inner WITH(NOLOCK)
                WHERE ac2_inner.parent_AC_ID = ac1.AC_ID
                      AND ac2_inner.ac_active = 1
            ), 0) > 0
                       THEN '2.1'
                       WHEN ISNULL(
            (
                SELECT COUNT(ac2_inner.AC_ID)
                FROM [someDB1].[dbo].[Articles_config] ac2_inner WITH(NOLOCK)
                WHERE ac2_inner.parent_AC_ID = ac1.AC_ID
                      AND ISNULL(ac2_inner.ac_active, 0) = 0
            ), 0) > 0
                       THEN '2.2'
                       ELSE '2'
                   END AS 'scenario', 
                   STR(ac1.[Order]) + '.1.' + STR(ac1.AC_ID) AS 'myOrder'
            FROM [someDB1].[dbo].[Articles_config] ac1 WITH(NOLOCK)
                 LEFT JOIN [someDB1].[dbo].[Articles_config] ac2 WITH(NOLOCK) ON ac1.AC_ID = ac2.parent_AC_ID
                                                                                 --AND ac2.ac_active = 1
                                                                                 AND ac2.JobID = @JobID
            WHERE ISNULL(ac1.JobID, @JobID) = @JobID
                  --AND ac1.ac_active = 1
                  AND ac1.parent_AC_ID IS NULL
                  AND ac2.AC_ID IS NULL
            UNION ALL
            SELECT ac1.AC_ID, 
                   ac1.[Order], 
                   ac1.T_ID, 
                   ac1.A_ID, 
                   ac1.JobID, 
                   ac1.parent_AC_ID, 
                   ac1.overwritten, 
                   ac1.ac_active,
                   CASE
                       WHEN ISNULL(
            (
                SELECT COUNT(ac2_inner.AC_ID)
                FROM [someDB1].[dbo].[Articles_config] ac2_inner WITH(NOLOCK)
                WHERE ac2_inner.parent_AC_ID = ac1.AC_ID
                      AND ac2_inner.ac_active = 1
            ), 0) > 0
                       THEN '3.1'
                       WHEN ISNULL(
            (
                SELECT COUNT(ac2_inner.AC_ID)
                FROM [someDB1].[dbo].[Articles_config] ac2_inner WITH(NOLOCK)
                WHERE ac2_inner.parent_AC_ID = ac1.AC_ID
                      AND ISNULL(ac2_inner.ac_active, 0) = 0
            ), 0) > 0
                       THEN '3.2'
                       ELSE '3'
                   END AS 'scenario', 
                   STR(ac2.[Order]) + '.1.' + STR(ac1.AC_ID) AS 'myOrder'
            FROM [someDB1].[dbo].[Articles_config] ac1 WITH(NOLOCK)
                 JOIN [someDB1].[dbo].[Articles_config] ac2 WITH(NOLOCK) ON ac1.AC_ID = ac2.parent_AC_ID
                                                                            AND ac1.JobID IS NULL
                                                                            AND ac2.JobID = @JobID
                                                                            AND ac2.ac_active = 0
        ) ac ON t_join.T_ID = ac.T_ID
        LEFT JOIN [someDB1].[dbo].[Articles] a WITH(NOLOCK) ON ac.A_ID = a.A_ID
                                                               AND a.article_active = 1
                                                               AND a.article_path LIKE @article_path
        WHERE t_join.T_ID LIKE @topic_ID
              AND t_join.topic_name LIKE @search_topic_name
              AND ISNULL(a.article_name, '%') LIKE @search_article_name
              AND ac.AC_ID NOT IN
        (
            SELECT ar.AC_ID_references
            FROM [someDB1].[dbo].[Articles_references] ar WITH(NOLOCK)
            WHERE ar.AC_ID_main = @AC_ID
        )
              AND ac.AC_ID IS NOT NULL
        ORDER BY t_join.[Order], 
                 ac.myOrder, 
                 ac.[Order];
    END;
GO
USE [myDB];
GO
--SET  ANSI_NULL ON;
GO
SET QUOTED_IDENTIFIER ON;
		GO
ALTER PROCEDURE [dbo].[usp_UPDATE_Article] @A_ID AS                 INT, 
                                           @article_name AS         VARCHAR(50), 
                                           @article_text AS         VARCHAR(4000) = NULL, 
                                           @theUser AS              INT, 
                                           @AC_ID AS                INT, 
                                           @JobPKID_Article AS      VARCHAR(6), 
                                           @JobPKID_overwritting AS VARCHAR(6)
AS
    BEGIN
        SET NOCOUNT ON;

        --DECLARE @AC_ID_ClientSpecific_exists AS INT;
        --DECLARE @AC_ID_overwritten_exists AS INT;
        DECLARE @ID TABLE(ID INT);
        DECLARE @ID_2 TABLE(ID INT);
        DECLARE @childs_AC_ID INT;
        DECLARE @parents_AC_ID INT;
        DECLARE @overwritten INT;
        DECLARE @result INT;
        SET @result = 0;
        IF ISNULL(@JobPKID_Article, '') = ''
            SET @JobPKID_Article = '';
        IF ISNULL(@JobPKID_overwritting, '') = ''
            SET @JobPKID_overwritting = '';
        IF @JobPKID_Article = ''
            BEGIN
                IF @JobPKID_overwritting = ''
                    BEGIN
                        --overwrite
                        UPDATE [myDB].[dbo].[Articles]
                          SET 
                              article_text = @article_text, 
                              article_name = @article_name, 
                              article_edited_by = @theUser, 
                              article_edited_DTS = GETDATE()
                        WHERE A_ID = @A_ID;
                        --UPDATE[myDB].[dbo].[Articles_config]
                        --SET overwritten = 1
                        --WHERE AC_ID = @AC_ID;
                    END
                        --IF ISNULL(@JobPKID_overwritting,'') <> '';
                    ELSE
                    BEGIN
                        SET @childs_AC_ID =
                        (
                            SELECT AC_ID
                            FROM [myDB].[dbo].[Articles_config] WITH(NOLOCK)
                            WHERE parent_AC_ID = @AC_ID
                                  AND JobPKID = @JobPKID_overwritting
                        );

                        --child exists for @JobPKID_overwritting
                        IF ISNULL(@childs_AC_ID, 0) <> 0
                            BEGIN
                                SET @overwritten = ISNULL(
                                (
                                    SELECT overwritten
                                    FROM [myDB].[dbo].[Articles_config] WITH(NOLOCK)
                                    WHERE AC_ID = @childs_AC_ID
                                ), 0);

                                --the parent and child are pointing to the same Article(per the arrows). Create a new Article here.
                                IF @overwritten <> 1
                                    BEGIN
                                        --create new
                                        INSERT INTO [myDB].[dbo].[Articles]
                                        (article_text, 
                                         article_name, 
                                         article_path, 
                                         article_created_by, 
                                         article_edited_by, 
                                         article_active
                                        )
                                        OUTPUT INSERTED.A_ID
                                               INTO @ID(ID)
                                               SELECT @article_text, 
                                                      @article_name, 
                                                      article_path, 
                                                      @theUser, 
                                                      @theUser, 
                                                      1
                                               FROM [myDB].[dbo].[Articles]
                                               WHERE A_ID = @A_ID;
                                        UPDATE [myDB].[dbo].[Articles_config]
                                          SET 
                                              A_ID =
                                        (
                                            SELECT TOP 1 ID
                                            FROM @ID
                                        ), 
                                              overwritten = 1, 
                                              ac_edited_by = @theUser, 
                                              ac_edited_DTS = @theUser
                                        WHERE AC_ID = @childs_AC_ID;
                                    END;
                                    ELSE
                                    BEGIN
                                        --overwrite
                                        UPDATE [myDB].[dbo].[Articles]
                                          SET 
                                              article_text = @article_text, 
                                              article_name = @article_name, 
                                              article_edited_by = @theUser, 
                                              article_edited_DTS = GETDATE()
                                        WHERE A_ID =
                                        (
                                            SELECT A_ID
                                            FROM [myDB].[dbo].[Articles_config] WITH(NOLOCK)
                                            WHERE AC_ID = @childs_AC_ID
                                        );
                                    END;
                            END
                                        --child does NOT exists for @JobPKID_overwritting;
                            ELSE
                            BEGIN
                                --create new
                                INSERT INTO [myDB].[dbo].[Articles]
                                (article_text, 
                                 article_name, 
                                 article_path, 
                                 article_created_by, 
                                 article_edited_by, 
                                 article_active
                                )
                                OUTPUT INSERTED.A_ID
                                       INTO @ID(ID)
                                       SELECT @article_text, 
                                              @article_name, 
                                              article_path, 
                                              @theUser, 
                                              @theUser, 
                                              1
                                       FROM [myDB].[dbo].[Articles]
                                       WHERE A_ID = @A_ID;
                                INSERT INTO [myDB].[dbo].[Articles_config]
                                (JobPKID, 
                                 parent_AC_ID, 
                                 T_ID, 
                                 A_ID, 
                                 overwritten, 
                                 ac_created_by, 
                                 ac_edited_by, 
                                 ac_active, 
                                 [Order]
                                )
                                       SELECT @JobPKID_overwritting, 
                                              @AC_ID, 
                                              T_ID, 
                                       (
                                           SELECT TOP 1 ID
                                           FROM @ID
                                       ), 
                                              1, 
                                              @theUser, 
                                              @theUser, 
                                              1, 
                                              [Order]
                                       FROM [myDB].[dbo].[Articles_config]
                                       WHERE AC_ID = @AC_ID;
                                SET @result = 1;
                            END;
                    END;
            END
                                --IF ISNULL(@JobPKID_Article,'') <> '';
            ELSE
            BEGIN
                IF ISNULL(@JobPKID_overwritting, '') = ''
                    BEGIN
                        SET @parents_AC_ID =
                        (
                            SELECT parent_AC_ID
                            FROM [myDB].[dbo].[Articles_config] WITH(NOLOCK)
                            WHERE AC_ID = @AC_ID
                                  AND JobPKID = @JobPKID_Article
                        );
                        IF ISNULL(@parents_AC_ID, 0) <> 0
                            BEGIN
                                --overwrite parent
                                UPDATE [myDB].[dbo].[Articles]
                                  SET 
                                      article_text = @article_text, 
                                      article_name = @article_name, 
                                      article_edited_by = @theUser, 
                                      article_edited_DTS = GETDATE()
                                WHERE A_ID =
                                (
                                    SELECT A_ID
                                    FROM [myDB].[dbo].[Articles_config] WITH(NOLOCK)
                                    WHERE AC_ID = @parents_AC_ID
                                );
                                --UPDATE[myDB].[dbo].[Articles_config]
                                --SET overwritten = 1
                                --WHERE AC_ID = @parents_AC_ID;
                            END
                                --this is an example where an Article is client specific and has no parent
                                --IF ISNULL(@parents_AC_ID,0) = 0;
                            ELSE
                            BEGIN
                                --create a parent
                                INSERT INTO [myDB].[dbo].[Articles]
                                (article_text, 
                                 article_name, 
                                 article_path, 
                                 article_created_by, 
                                 article_edited_by, 
                                 article_active
                                )
                                OUTPUT INSERTED.A_ID
                                       INTO @ID(ID)
                                       SELECT @article_text, 
                                              @article_name, 
                                              article_path, 
                                              @theUser, 
                                              @theUser, 
                                              1
                                       FROM [myDB].[dbo].[Articles]
                                       WHERE A_ID = @A_ID;
                                INSERT INTO [myDB].[dbo].[Articles_config]
                                (JobPKID, 
                                 parent_AC_ID, 
                                 T_ID, 
                                 A_ID, 
                                 overwritten, 
                                 ac_created_by, 
                                 ac_edited_by, 
                                 ac_active, 
                                 [Order]
                                )
                                OUTPUT INSERTED.AC_ID
                                       INTO @ID_2(ID)
                                       SELECT NULL, 
                                              NULL, 
                                              T_ID, 
                                       (
                                           SELECT TOP 1 ID
                                           FROM @ID
                                       ), 
                                              1, 
                                              @theUser, 
                                              @theUser, 
                                              1, 
                                              [Order]
                                       FROM [myDB].[dbo].[Articles_config]
                                       WHERE AC_ID = @AC_ID;

                                --move existing @JobPKID_Article as child
                                UPDATE [myDB].[dbo].[Articles_config]
                                  SET 
                                      parent_AC_ID =
                                (
                                    SELECT TOP 1 ID
                                    FROM @ID_2
                                ), 
                                      overwritten = 1, 
                                      ac_edited_by = @theUser, 
                                      ac_edited_DTS = @theUser
                                WHERE AC_ID = @AC_ID;
                                SET @result = 1;
                            END;
                    END
                                --IF ISNULL(@JobPKID_overwritting,'') <> '';
                    ELSE
                    BEGIN
                        IF @JobPKID_Article = @JobPKID_overwritting
                            BEGIN
                                SET @overwritten = ISNULL(
                                (
                                    SELECT overwritten
                                    FROM [myDB].[dbo].[Articles_config] WITH(NOLOCK)
                                    WHERE AC_ID = @AC_ID
                                ), 0);

                                --the parent and child are pointing to the same Article(per the arrows). Create a new Article here.
                                IF @overwritten <> 1
                                    BEGIN
                                        --create new
                                        INSERT INTO [myDB].[dbo].[Articles]
                                        (article_text, 
                                         article_name, 
                                         article_path, 
                                         article_created_by, 
                                         article_edited_by, 
                                         article_active
                                        )
                                        OUTPUT INSERTED.A_ID
                                               INTO @ID(ID)
                                               SELECT @article_text, 
                                                      @article_name, 
                                                      article_path, 
                                                      @theUser, 
                                                      @theUser, 
                                                      1
                                               FROM [myDB].[dbo].[Articles]
                                               WHERE A_ID = @A_ID;
                                        UPDATE [myDB].[dbo].[Articles_config]
                                          SET 
                                              A_ID =
                                        (
                                            SELECT TOP 1 ID
                                            FROM @ID
                                        ), 
                                              overwritten = 1, 
                                              ac_edited_by = @theUser, 
                                              ac_edited_DTS = @theUser
                                        WHERE AC_ID = @AC_ID;
                                    END;
                                    ELSE
                                    BEGIN
                                        --overwrite
                                        UPDATE [myDB].[dbo].[Articles]
                                          SET 
                                              article_text = @article_text, 
                                              article_name = @article_name, 
                                              article_edited_by = @theUser, 
                                              article_edited_DTS = GETDATE()
                                        WHERE A_ID = @A_ID;
                                    END;
                            END
                                        --IF @JobPKID_Article<> @JobPKID_overwritting;
                            ELSE
                            BEGIN
                                SET @parents_AC_ID =
                                (
                                    SELECT parent_AC_ID
                                    FROM [myDB].[dbo].[Articles_config] WITH(NOLOCK)
                                    WHERE AC_ID = @AC_ID
                                          AND JobPKID = @JobPKID_Article
                                );

                                --IF @JobPKID_Article contains a parent
                                IF ISNULL(@parents_AC_ID, 0) <> 0
                                    BEGIN
                                        SET @childs_AC_ID =
                                        (
                                            SELECT AC_ID
                                            FROM [myDB].[dbo].[Articles_config] WITH(NOLOCK)
                                            WHERE parent_AC_ID = @parents_AC_ID
                                                  AND JobPKID = @JobPKID_overwritting
                                        );

                                        --child exists for @JobPKID_overwritting
                                        IF ISNULL(@childs_AC_ID, 0) <> 0
                                            BEGIN
                                                SET @overwritten = ISNULL(
                                                (
                                                    SELECT overwritten
                                                    FROM [myDB].[dbo].[Articles_config] WITH(NOLOCK)
                                                    WHERE AC_ID = @childs_AC_ID
                                                ), 0);

                                                --the parent and child are pointing to the same Article(per the arrows). Create a new Article here.
                                                IF @overwritten <> 1
                                                    BEGIN
                                                        --create new
                                                        INSERT INTO [myDB].[dbo].[Articles]
                                                        (article_text, 
                                                         article_name, 
                                                         article_path, 
                                                         article_created_by, 
                                                         article_edited_by, 
                                                         article_active
                                                        )
                                                        OUTPUT INSERTED.A_ID
                                                               INTO @ID(ID)
                                                               SELECT @article_text, 
                                                                      @article_name, 
                                                                      article_path, 
                                                                      @theUser, 
                                                                      @theUser, 
                                                                      1
                                                               FROM [myDB].[dbo].[Articles]
                                                               WHERE A_ID = @A_ID;
                                                        UPDATE [myDB].[dbo].[Articles_config]
                                                          SET 
                                                              A_ID =
                                                        (
                                                            SELECT TOP 1 ID
                                                            FROM @ID
                                                        ), 
                                                              overwritten = 1, 
                                                              ac_edited_by = @theUser, 
                                                              ac_edited_DTS = @theUser
                                                        WHERE AC_ID = @childs_AC_ID;
                                                    END;
                                                    ELSE
                                                    BEGIN
                                                        --overwrite
                                                        UPDATE [myDB].[dbo].[Articles]
                                                          SET 
                                                              article_text = @article_text, 
                                                              article_name = @article_name, 
                                                              article_edited_by = @theUser, 
                                                              article_edited_DTS = GETDATE()
                                                        WHERE A_ID =
                                                        (
                                                            SELECT A_ID
                                                            FROM [myDB].[dbo].[Articles_config] WITH(NOLOCK)
                                                            WHERE AC_ID = @childs_AC_ID
                                                        );
                                                    END;
                                            END;
                                            ELSE
                                        --the other child DNE
                                            BEGIN
                                                --create new
                                                INSERT INTO [myDB].[dbo].[Articles]
                                                (article_text, 
                                                 article_name, 
                                                 article_path, 
                                                 article_created_by, 
                                                 article_edited_by, 
                                                 article_active
                                                )
                                                OUTPUT INSERTED.A_ID
                                                       INTO @ID(ID)
                                                       SELECT @article_text, 
                                                              @article_name, 
                                                              article_path, 
                                                              @theUser, 
                                                              @theUser, 
                                                              1
                                                       FROM [myDB].[dbo].[Articles]
                                                       WHERE A_ID = @A_ID;
                                                INSERT INTO [myDB].[dbo].[Articles_config]
                                                (JobPKID, 
                                                 parent_AC_ID, 
                                                 T_ID, 
                                                 A_ID, 
                                                 overwritten, 
                                                 ac_created_by, 
                                                 ac_edited_by, 
                                                 ac_active, 
                                                 [Order]
                                                )
                                                       SELECT @JobPKID_overwritting, 
                                                              @parents_AC_ID, 
                                                              T_ID, 
                                                       (
                                                           SELECT TOP 1 ID
                                                           FROM @ID
                                                       ), 
                                                              1, 
                                                              @theUser, 
                                                              @theUser, 
                                                              1, 
                                                              [Order]
                                                       FROM [myDB].[dbo].[Articles_config]
                                                       WHERE AC_ID = @AC_ID;
                                                SET @result = 1;
                                            END;
                                    END
                                                --IF ISNULL(@parents_AC_ID,0) = 0;
                                    ELSE
                                --this is an example where an Article is client specific and has no parent
                                    BEGIN
                                        --create new parent
                                        INSERT INTO [myDB].[dbo].[Articles]
                                        (article_text, 
                                         article_name, 
                                         article_path, 
                                         article_created_by, 
                                         article_edited_by, 
                                         article_active
                                        )
                                        OUTPUT INSERTED.A_ID
                                               INTO @ID(ID)
                                               SELECT @article_text, 
                                                      @article_name, 
                                                      article_path, 
                                                      @theUser, 
                                                      @theUser, 
                                                      1
                                               FROM [myDB].[dbo].[Articles]
                                               WHERE A_ID = @A_ID;
                                        INSERT INTO [myDB].[dbo].[Articles_config]
                                        (JobPKID, 
                                         parent_AC_ID, 
                                         T_ID, 
                                         A_ID, 
                                         overwritten, 
                                         ac_created_by, 
                                         ac_edited_by, 
                                         ac_active, 
                                         [Order]
                                        )
                                        OUTPUT INSERTED.AC_ID
                                               INTO @ID_2(ID)
                                               SELECT NULL, 
                                                      NULL, 
                                                      T_ID, 
                                               (
                                                   SELECT TOP 1 ID
                                                   FROM @ID
                                               ), 
                                                      1, 
                                                      @theUser, 
                                                      @theUser, 
                                                      1, 
                                                      [Order]
                                               FROM [myDB].[dbo].[Articles_config]
                                               WHERE AC_ID = @AC_ID;

                                        --         IF @JobPKID_overwritting = ''
                                        --          BEGIN
                                        --           SET @result = 1;
                                        --          END
                                        --         ELSE
                                        --          BEGIN
                                        SET @result = 2;

                                        --create new child
                                        DELETE FROM @ID;
                                        INSERT INTO [myDB].[dbo].[Articles]
                                        (article_text, 
                                         article_name, 
                                         article_path, 
                                         article_created_by, 
                                         article_edited_by, 
                                         article_active
                                        )
                                        OUTPUT INSERTED.A_ID
                                               INTO @ID(ID)
                                               SELECT @article_text, 
                                                      @article_name, 
                                                      article_path, 
                                                      @theUser, 
                                                      @theUser, 
                                                      1
                                               FROM [myDB].[dbo].[Articles]
                                               WHERE A_ID = @A_ID;
                                        INSERT INTO [myDB].[dbo].[Articles_config]
                                        (JobPKID, 
                                         parent_AC_ID, 
                                         T_ID, 
                                         A_ID, 
                                         overwritten, 
                                         ac_created_by, 
                                         ac_edited_by, 
                                         ac_active, 
                                         [Order]
                                        )
                                               SELECT @JobPKID_overwritting, 
                                               (
                                                   SELECT TOP 1 ID
                                                   FROM @ID_2
                                               ), 
                                                      T_ID, 
                                               (
                                                   SELECT TOP 1 ID
                                                   FROM @ID
                                               ), 
                                                      1, 
                                                      @theUser, 
                                                      @theUser, 
                                                      1, 
                                                      [Order]
                                               FROM [myDB].[dbo].[Articles_config]
                                               WHERE AC_ID = @AC_ID;

                                        --move existing @JobPKID_Article as child
                                        UPDATE [myDB].[dbo].[Articles_config]
                                          SET 
                                              parent_AC_ID =
                                        (
                                            SELECT TOP 1 ID
                                            FROM @ID_2
                                        ), 
                                              overwritten = 1, 
                                              ac_edited_by = @theUser, 
                                              ac_edited_DTS = GETDATE()
                                        WHERE AC_ID = @AC_ID;
                                    END;
                            END;
                    END;
            END;
        IF @result = 1
            BEGIN
                SELECT TOP 1 JobPKID, 
                             AC_ID
                FROM [myDB].[dbo].[Articles_config] WITH(NOLOCK)
                ORDER BY AC_ID DESC;
            END;
            ELSE
            IF @result = 2
                BEGIN
                    SELECT TOP 2 JobPKID, 
                                 AC_ID
                    FROM [myDB].[dbo].[Articles_config] WITH(NOLOCK)
                    ORDER BY AC_ID DESC;
                END;
                ELSE
                BEGIN
                    SELECT TOP 0 NULL;
                END;
    END;
GO";


		public string CustomPagination { get; } = @"
USE [oneOfMyDBs];
GO
SET QUOTED_IDENTIFIER ON;
GO
ALTER PROCEDURE [dbo].[usp_someLog_Report] @StartDate  DATETIME    = '', 
                                           @EndDate    DATETIME    = '', 
                                           @JobPKID    NVARCHAR(6) = '%', 
                                           @someField  VARCHAR(20) = '', 
                                           @PageSize   INT         = 50, 
                                           @PageNumber INT         = 1, 
                                           @SortCol    VARCHAR(25) = NULL, 
                                           @SortDir    VARCHAR(10) = 'ASC'
AS
    BEGIN
        --Pagination
        DECLARE @RowStart INT;
        DECLARE @RowEnd INT;
        SET @PageNumber = @PageNumber - 1;
        SET @RowStart = @PageSize * @PageNumber + 1;
        SET @RowEnd = @RowStart + @PageSize - 1;

        --end of Pagination
        --Main Data
        IF ISNULL(@StartDate, '') = ''
            BEGIN
                SET @StartDate = GETDATE() - 30;
            END;
        IF @EndDate = ''
            BEGIN
                SET @EndDate = GETDATE() + 1;
            END;
        IF ISNULL(@JobPKID, '') = ''
           OR @JobPKID = 'All'
            SET @JobPKID = '%';

        --end of Main Data
        --Sort Date
        DECLARE @SortDir_int INT;
        IF ISNULL(@SortCol, '') = ''
            SET @SortCol = 'dateMade';
        IF ISNULL(@SortDir, '') = ''
           OR @SortDir = 'ASC'
            SET @SortDir_int = 1;
            ELSE
            SET @SortDir_int = -1;

        --end of Sort Date

        IF @PageNumber = -1
            BEGIN
                IF(@someField IN('someGroup1', 'someGroup2'))
                    BEGIN
                        WITH Results
                             AS (SELECT ROW_NUMBER() OVER(
                                 ORDER BY(CASE @SortDir
                                              WHEN 'ASC'
                                              THEN CASE @SortCol
                                                       WHEN 'dateMade'
                                                       THEN ii.dateMade
                                                   END
                                          END) ASC, 
                                         (CASE @SortDir
                                              WHEN 'DESC'
                                              THEN CASE @SortCol
                                                       WHEN 'dateMade'
                                                       THEN ii.dateMade
                                                   END
                                          END) DESC, 
                                         ii.dateMade ASC) AS RowNumber, 
                                        tps.[thePrimaryKey], 
                                        someMoreFieldsHere, 
                                        myDB.dbo.fx_Get_some_name(ii.clientId, ii.some_name_id) AS [someGroup Name], 
                                        someMoreFieldsHere
                                 FROM myImages.dbo.ImgInfo ii WITH(NOLOCK)
                                      JOIN myDB2.dbo.table1 t1 WITH(NOLOCK) ON ii.primaryKey = t1.[thePrimaryKey]
                                      JOIN myDB2.dbo.stats s1 WITH(NOLOCK) ON(ii.primaryKey = s1.[thePrimaryKey])
                                      JOIN myDB2.dbo.table2 it WITH(NOLOCK) ON ii.primaryKey = t2.[thePrimaryKey]
                                      JOIN tps tps WITH(NOLOCK) ON t1.[thePrimaryKey] = tps.[thePrimaryKey]
                                      LEFT JOIN myDB.dbo.userTable ut_comp WITH(NOLOCK) ON ut_comp.theUsersPK = ii.somePerson1
                                      LEFT JOIN myDB.dbo.userTable ut_cred WITH(NOLOCK) ON ut_cred.theUsersPK = ii.somePerson2
                                      LEFT JOIN myDB.dbo.userTable ut_upload WITH(NOLOCK) ON ut_upload.theUsersPK = ii.theUser
                                      LEFT JOIN
                                 (
                                     SELECT TOP 1 CASE
                                                      WHEN(ut_inside.CompanyName IN('theCompany', 'theCompany1')
                                                           OR ut_inside.EmailAddress LIKE '%theCompany2.com')
                                                          AND ISNULL(random_inside.idUsedForLinking, '') = ''
                                                      THEN 'theCompany Internal'
                                                      WHEN random_inside.JobPKID IS NOT NULL
                                                           AND random_inside.idUsedForLinking IS NOT NULL
                                                      THEN 'someGroup'
                                                      WHEN random_inside.JobPKID IS NOT NULL
                                                           AND random_inside.idUsedForLinking IS NULL
                                                      THEN 'Client'
                                                      ELSE 'Unknown'
                                                  END AS job_role, 
                                                  ut_inside.theUsersPK AS [theUsersPK], 
                                                  random_inside.JobPKID AS [JobPKID]
                                     FROM myDB.dbo.userTable ut_inside WITH(NOLOCK)
                                          LEFT OUTER JOIN myDB.dbo.someTable4_Leves1 random_inside WITH(NOLOCK) ON(ut_inside.theUsersPK = random_inside.theUsersPK)
                                     WHERE random_inside.GroupID = 3
                                 ) user_job_role ON user_job_role.theUsersPK = ii.theUser
                                                    AND user_job_role.JobPKID = ii.clientId
                                 WHERE ii.clientId LIKE @JobPKID
                                       AND ii.clientId NOT IN('1000', '1001', '1010', '1011', '1100')
                                      AND (ii.dateMade BETWEEN @StartDate AND @EndDate)
                                      --AND (myDB.dbo.fx_Get_User_someField_Flag(ii.theUser,ii.clientId) = 1)
                                      AND (ii.system_someField_flag = 1)
                                      AND (tps.STATUS <> 'status1/status2/status3')
                                      AND (s1.Open_abcs >= 1)
                                      AND ((ii.imgName LIKE '%someField%'
                                            OR ii.docFormat = 'someField')
                                           OR ii.dateMade > t1.[process date]
                                           OR (ii.imgName LIKE '%zdocs%'
                                               AND ii.dateMade > t1.[process date]))
                                      AND ((ii.compliance_someField_clear_dts IS NULL
                                            AND @someField = 'Compliance'
                                            AND s1.Open_Compliance_abcs > 0)
                                           OR (ii.credit_someField_clear_dts IS NULL
                                               AND @someField = 'Credit'
                                               AND s1.Open_Credit_abcs > 0))),
                             Counts
                             AS (SELECT COUNT(*) AS TotalRows
                                 FROM Results)
                             SELECT Counts.TotalRows, 
                                    Results.*
                             FROM Results
                                  CROSS APPLY Counts;
                    END;
                    ELSE
                    BEGIN
                        WITH Results
                             AS (SELECT ROW_NUMBER() OVER(
                                 ORDER BY(CASE @SortDir
                                              WHEN 'ASC'
                                              THEN CASE @SortCol
                                                       WHEN 'dateMade'
                                                       THEN ii.dateMade
                                                   END
                                          END) ASC, 
                                         (CASE @SortDir
                                              WHEN 'DESC'
                                              THEN CASE @SortCol
                                                       WHEN 'dateMade'
                                                       THEN ii.dateMade
                                                   END
                                          END) DESC, 
                                         ii.dateMade ASC) AS RowNumber, 
                                        tps.[thePrimaryKey], 
                                        tps.STATUS, 
                                        someMoreFieldsHere, 
                                        myDB.dbo.fx_Get_some_name(ii.clientId, ii.some_name_id) AS [someGroup Name], 
                                        ii.ln AS [Loan Number], 
                                        someMoreFieldsHere
                                 FROM myImages.dbo.ImgInfo ii WITH(NOLOCK)
                                      JOIN myDB2.dbo.table1 t1 WITH(NOLOCK) ON ii.primaryKey = t1.[thePrimaryKey]
                                      JOIN myDB2.dbo.stats s1 WITH(NOLOCK) ON ii.primaryKey = s1.[thePrimaryKey]
                                      JOIN myDB2.dbo.table2 t2 WITH(NOLOCK) ON ii.primaryKey = t2.[thePrimaryKey]
                                      JOIN tps tps WITH(NOLOCK) ON t1.[thePrimaryKey] = tps.[thePrimaryKey]
                                      LEFT JOIN myDB.dbo.userTable ut_comp WITH(NOLOCK) ON ut_comp.theUsersPK = ii.somePerson1
                                      LEFT JOIN myDB.dbo.userTable ut_cred WITH(NOLOCK) ON ut_cred.theUsersPK = ii.somePerson2
                                      LEFT JOIN myDB.dbo.userTable ut_upload WITH(NOLOCK) ON ut_upload.theUsersPK = ii.theUser
                                      LEFT JOIN
                                 (
                                     SELECT TOP 1 CASE
                                                      WHEN(ut_inside.CompanyName IN('theCompany', 'theCompany1')
                                                           OR ut_inside.EmailAddress LIKE '%theCompany2.com')
                                                          AND ISNULL(random_inside.idUsedForLinking, '') = ''
                                                      THEN 'theCompany Internal'
                                                      WHEN random_inside.JobPKID IS NOT NULL
                                                           AND random_inside.idUsedForLinking IS NOT NULL
                                                      THEN 'someGroup'
                                                      WHEN random_inside.JobPKID IS NOT NULL
                                                           AND random_inside.idUsedForLinking IS NULL
                                                      THEN 'Client'
                                                      ELSE 'Unknown'
                                                  END AS job_role, 
                                                  ut_inside.theUsersPK AS [theUsersPK], 
                                                  random_inside.JobPKID AS [JobPKID]
                                     FROM myDB.dbo.userTable ut_inside WITH(NOLOCK)
                                          LEFT OUTER JOIN myDB.dbo.someTable4_Leves1 random_inside WITH(NOLOCK) ON(ut_inside.theUsersPK = random_inside.theUsersPK)
                                     WHERE random_inside.GroupID = 3
                                 ) user_job_role ON user_job_role.theUsersPK = ii.theUser
                                                    AND user_job_role.JobPKID = ii.clientId
                                 WHERE ii.clientId LIKE @JobPKID
                                       AND ii.clientId NOT IN('1000', '1001', '1010', '1011', '1100')
                                      AND (ii.dateMade BETWEEN @StartDate AND @EndDate)
                                      --AND (myDB.dbo.fx_Get_User_someField_Flag(ii.theUser,ii.clientId) = 1)
                                      AND (ii.system_someField_flag = 1)
                                      AND (tps.STATUS <> 'status1/status2/status3')
                                      AND (s1.Open_abcs >= 1)
                                      AND ((ii.imgName LIKE '%someField%'
                                            OR ii.docFormat = 'someField')
                                           OR ii.dateMade > t1.[process date]
                                           OR (ii.imgName LIKE '%zdocs%'
                                               AND ii.dateMade > t1.[process date]))
                                      AND (s1.Open_abcs > 0
                                           AND (ii.compliance_someField_clear_dts IS NULL
                                                OR ii.credit_someField_clear_dts IS NULL))),
                             Counts
                             AS (SELECT COUNT(*) AS TotalRows
                                 FROM Results)
                             SELECT Counts.TotalRows, 
                                    Results.*
                             FROM Results
                                  CROSS APPLY Counts;
                    END;
            END;
            ELSE
            BEGIN
                IF(@someField IN('Compliance', 'Credit'))
                    BEGIN
                        WITH Results
                             AS (SELECT ROW_NUMBER() OVER(
                                 ORDER BY(CASE @SortDir
                                              WHEN 'ASC'
                                              THEN CASE @SortCol
                                                       WHEN 'dateMade'
                                                       THEN ii.dateMade
                                                   END
                                          END) ASC, 
                                         (CASE @SortDir
                                              WHEN 'DESC'
                                              THEN CASE @SortCol
                                                       WHEN 'dateMade'
                                                       THEN ii.dateMade
                                                   END
                                          END) DESC, 
                                         ii.dateMade ASC) AS RowNumber, 
                                        tps.[thePrimaryKey], 
                                        tps.STATUS, 
                                        ii.clientId, 
                                        someMoreFieldsHere, 
                                        myDB.dbo.fx_Get_some_name(ii.clientId, ii.some_name_id) AS some_name, 
                                        someMoreFieldsHere
                                 FROM myImages.dbo.ImgInfo ii WITH(NOLOCK)
                                      JOIN myDB2.dbo.table1 t1 WITH(NOLOCK) ON ii.primaryKey = t1.[thePrimaryKey]
                                      JOIN myDB2.dbo.stats s1 WITH(NOLOCK) ON(ii.primaryKey = s1.[thePrimaryKey])
                                      JOIN myDB2.dbo.table2 it WITH(NOLOCK) ON ii.primaryKey = t2.[thePrimaryKey]
                                      JOIN tps tps WITH(NOLOCK) ON t1.[thePrimaryKey] = tps.[thePrimaryKey]
                                      LEFT JOIN myDB.dbo.userTable ut_comp WITH(NOLOCK) ON ut_comp.theUsersPK = ii.somePerson1
                                      LEFT JOIN myDB.dbo.userTable ut_cred WITH(NOLOCK) ON ut_cred.theUsersPK = ii.somePerson2
                                      LEFT JOIN myDB.dbo.userTable ut_upload WITH(NOLOCK) ON ut_upload.theUsersPK = ii.theUser
                                      LEFT JOIN
                                 (
                                     SELECT TOP 1 CASE
                                                      WHEN(ut_inside.CompanyName IN('theCompany', 'theCompany1')
                                                           OR ut_inside.EmailAddress LIKE '%theCompany2.com')
                                                          AND ISNULL(random_inside.idUsedForLinking, '') = ''
                                                      THEN 'theCompany Internal'
                                                      WHEN random_inside.JobPKID IS NOT NULL
                                                           AND random_inside.idUsedForLinking IS NOT NULL
                                                      THEN 'someGroup'
                                                      WHEN random_inside.JobPKID IS NOT NULL
                                                           AND random_inside.idUsedForLinking IS NULL
                                                      THEN 'Client'
                                                      ELSE 'Unknown'
                                                  END AS job_role, 
                                                  ut_inside.theUsersPK AS [theUsersPK], 
                                                  random_inside.JobPKID AS [JobPKID]
                                     FROM myDB.dbo.userTable ut_inside WITH(NOLOCK)
                                          LEFT OUTER JOIN myDB.dbo.someTable4_Leves1 random_inside WITH(NOLOCK) ON(ut_inside.theUsersPK = random_inside.theUsersPK)
                                     WHERE random_inside.GroupID = 3
                                 ) user_job_role ON user_job_role.theUsersPK = ii.theUser
                                                    AND user_job_role.JobPKID = ii.clientId
                                 WHERE ii.clientId LIKE @JobPKID
                                       AND ii.clientId NOT IN('1000', '1001', '1010', '1011', '1100')
                                      AND (ii.dateMade BETWEEN @StartDate AND @EndDate)
                                      --AND (myDB.dbo.fx_Get_User_someField_Flag(ii.theUser,ii.clientId) = 1)
                                      AND (ii.system_someField_flag = 1)
                                      AND (tps.STATUS <> 'status1/status2/status3')
                                      AND (s1.Open_abcs >= 1)
                                      AND ((ii.imgName LIKE '%someField%'
                                            OR ii.docFormat = 'someField')
                                           OR ii.dateMade > t1.[process date]
                                           OR (ii.imgName LIKE '%zdocs%'
                                               AND ii.dateMade > t1.[process date]))
                                      AND ((ii.compliance_someField_clear_dts IS NULL
                                            AND @someField = 'Compliance'
                                            AND s1.Open_Compliance_abcs > 0)
                                           OR (ii.credit_someField_clear_dts IS NULL
                                               AND @someField = 'Credit'
                                               AND s1.Open_Credit_abcs > 0))),
                             Counts
                             AS (SELECT COUNT(*) AS TotalRows
                                 FROM Results)
                             SELECT Counts.TotalRows, 
                                    Results.*
                             FROM Results
                                  CROSS APPLY Counts
                             WHERE RowNumber >= @RowStart
                                   AND RowNumber <= @RowEnd;
                    END;
                    ELSE
                    BEGIN
                        WITH Results
                             AS (SELECT ROW_NUMBER() OVER(
                                 ORDER BY(CASE @SortDir
                                              WHEN 'ASC'
                                              THEN CASE @SortCol
                                                       WHEN 'dateMade'
                                                       THEN ii.dateMade
                                                   END
                                          END) ASC, 
                                         (CASE @SortDir
                                              WHEN 'DESC'
                                              THEN CASE @SortCol
                                                       WHEN 'dateMade'
                                                       THEN ii.dateMade
                                                   END
                                          END) DESC, 
                                         ii.dateMade ASC) AS RowNumber, 
                                        tps.[thePrimaryKey], 
                                        tps.STATUS, 
                                        ii.clientId, 
                                        someMoreFieldsHere, 
                                        myDB.dbo.fx_Get_some_name(ii.clientId, ii.some_name_id) AS some_name, 
                                        someMoreFieldsHere
                                 FROM myImages.dbo.ImgInfo ii WITH(NOLOCK)
                                      JOIN myDB2.dbo.table1 t1 WITH(NOLOCK) ON ii.primaryKey = t1.[thePrimaryKey]
                                      JOIN myDB2.dbo.stats s1 WITH(NOLOCK) ON ii.primaryKey = s1.[thePrimaryKey]
                                      JOIN myDB2.dbo.table2 it WITH(NOLOCK) ON ii.primaryKey = t2.[thePrimaryKey]
                                      JOIN tps tps WITH(NOLOCK) ON t1.[thePrimaryKey] = tps.[thePrimaryKey]
                                      LEFT JOIN myDB.dbo.userTable ut_comp WITH(NOLOCK) ON ut_comp.theUsersPK = ii.somePerson1
                                      LEFT JOIN myDB.dbo.userTable ut_cred WITH(NOLOCK) ON ut_cred.theUsersPK = ii.somePerson2
                                      LEFT JOIN myDB.dbo.userTable ut_upload WITH(NOLOCK) ON ut_upload.theUsersPK = ii.theUser
                                      LEFT JOIN
                                 (
                                     SELECT TOP 1 CASE
                                                      WHEN(ut_inside.CompanyName IN('theCompany', 'theCompany1')
                                                           OR ut_inside.EmailAddress LIKE '%theCompany2.com')
                                                          AND ISNULL(random_inside.idUsedForLinking, '') = ''
                                                      THEN 'theCompany Internal'
                                                      WHEN random_inside.JobPKID IS NOT NULL
                                                           AND random_inside.idUsedForLinking IS NOT NULL
                                                      THEN 'someGroup'
                                                      WHEN random_inside.JobPKID IS NOT NULL
                                                           AND random_inside.idUsedForLinking IS NULL
                                                      THEN 'Client'
                                                      ELSE 'Unknown'
                                                  END AS job_role, 
                                                  ut_inside.theUsersPK AS [theUsersPK], 
                                                  random_inside.JobPKID AS [JobPKID]
                                     FROM myDB.dbo.userTable ut_inside WITH(NOLOCK)
                                          LEFT OUTER JOIN myDB.dbo.someTable4_Leves1 random_inside WITH(NOLOCK) ON(ut_inside.theUsersPK = random_inside.theUsersPK)
                                     WHERE random_inside.GroupID = 3
                                 ) user_job_role ON user_job_role.theUsersPK = ii.theUser
                                                    AND user_job_role.JobPKID = ii.clientId
                                 WHERE ii.clientId LIKE @JobPKID
                                       AND ii.clientId NOT IN('1000', '1001', '1010', '1011', '1100')
                                      AND (ii.dateMade BETWEEN @StartDate AND @EndDate)
                                      --AND (myDB.dbo.fx_Get_User_someField_Flag(ii.theUser,ii.clientId) = 1)
                                      AND (ii.system_someField_flag = 1)
                                      AND (tps.STATUS <> 'status1/status2/status3')
                                      AND (s1.Open_abcs >= 1)
                                      AND ((ii.imgName LIKE '%someField%'
                                            OR ii.docFormat = 'someField')
                                           OR ii.dateMade > t1.[process date]
                                           OR (ii.imgName LIKE '%zdocs%'
                                               AND ii.dateMade > t1.[process date]))
                                      AND (s1.Open_abcs > 0
                                           AND (ii.compliance_someField_clear_dts IS NULL
                                                OR ii.credit_someField_clear_dts IS NULL))),
                             Counts
                             AS (SELECT COUNT(*) AS TotalRows
                                 FROM Results)
                             SELECT Counts.TotalRows, 
                                    Results.*
                             FROM Results
                                  CROSS APPLY Counts
                             WHERE RowNumber >= @RowStart
                                   AND RowNumber <= @RowEnd;
                    END;
            END;
    END;
GO";

	}
}
