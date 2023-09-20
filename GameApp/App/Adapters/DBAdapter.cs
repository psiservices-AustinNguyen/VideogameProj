using App.Models;
using Insight.Database;
using System.Data;

namespace App.Adapters
{
    //[DatabaseService(ConnectionStrings.Videogame)]
    [DatabaseService("ResultsServicePlaygroundConnection")]
    public abstract class DBAdapter
    {

        [Sql("Get_DevCompanyList", Schema = "dbo")]
        public abstract Task<IEnumerable<DevCompany>> GetAllDevCompanies();

        [Sql("Get_DevCompany", Schema = "dbo")]
        public abstract Task<DevCompany> GetDevCompany(int DevCoId);

        [Sql("Add_DevCompany", Schema = "dbo")]
        public abstract Task AddDevCo(DevCompany model);

        [Sql("Delete_DevCompany", Schema = "dbo")]
        public abstract Task DeleteDevCo(int DevCoId);

        [Sql("Update_DevCompany", Schema = "dbo")]
        public abstract Task UpdateDevCo(int DevCoId, DevCompany model);

        [Sql(bcen_sql, Schema = "dbo")]
        public abstract Task<BcenModel> GetBCENResults();



		private const string bcen_sql = @"
		begin
		use LXRdata
			declare @tblContentAreas table (
				[BCGR-SEQ] int,
				[TEST-GUID] uniqueidentifier,
				[SRPT-ExamId] int,
				[BCGR-GUID] uniqueidentifier,
				[BCGR-TITLE] nvarchar(50),
				[BCGR-DESC] nvarchar(2000),		
				GroupString nvarchar(max),
				MaxScoreMajor int);
		


			declare @tblData table (
			GroupString nvarchar(max),
				[STUD-FNAME] nvarchar(max),
				[STUD-LNAME] nvarchar(max),
				[SRPT-COL50] nvarchar(50),
				SchoolCode nvarchar(max),
				ClientCode nvarchar(max),
				clientCandidateId nvarchar(max),
				regId nvarchar(max),
				ExamId nvarchar(max),
				examForm nvarchar(max),
				series nvarchar(max),
				pfa nvarchar(2),	
				DateScheduled date,
				[TEST-GUID] uniqueidentifier,
				[BCGR-GUID] uniqueidentifier,
				StudentScore REAL,
				passingScore REAL,
				skipped int,
				[TSCH-GUID] UNIQUEIDENTIFIER,
				ScheduleID nvarchar(50),
				MaxScore REAL);
		
		


		 
		  
			--Step 1: Fetch all the data for our dataset.
			insert into @tblData
			SELECT
			'', --GroupString,
				Stud.[STUD-FNAME],
				Stud.[STUD-LNAME],
				SRPT.[SRPT-COL50], --CourseName
				SRPT.[SRPT-COL1],
				SRPT.[SRPT-COL33] as regId,
				SRPT.[SRPT-COL6] as clientCandidateId,
				SRPT.[SRPT-COL2], --ClientCode,
				SRPT.[SRPT-ExamId], --ExamID,
				FORM.[FORM-NAME] as examForm,
				SRPT.[SRPT-COL3] as series, --ExamPortionCode,		
				SSCR.[SSCR-PFA],
				SRPT.[SRPT-COL15] as examDate,
				TEST.[TEST-GUID],
				QUES.[QUES-CONTENTAREA] as sectionTitle,-- as [BCGR-GUID],
				sum(SITM.[SITM-FINALPOINTS]) as rawscore,
				form.[FORM-RAWCUT] as passingScore,
				'' as skipped,
				SRPT.[SRPT-TSCH],
				SRPT.[SRPT-COL16] as ScheduleID,
		TEST.[TEST-TOTALPOINTS] as maxScore
	

		
			FROM ScoreReportData SRPT WITH (NOLOCK)	
			INNER JOIN TestSchedules TSCH WITH (NOLOCK) ON (TSCH.[TSCH-GUID] = SRPT.[SRPT-TSCH])
			INNER JOIN TestPackages TPKG WITH (NOLOCK) ON (TSCH.[TSCH-TPKG] = TPKG.[TPKG-GUID])
			INNER JOIN TestLists TLST WITH (NOLOCK) ON (TPKG.[TPKG-GUID] = TLST.[TLST-TPKG])
			INNER JOIN Tests TEST WITH (NOLOCK) ON (TLST.[TLST-TEST] = TEST.[TEST-GUID])	
			INNER JOIN dbo.TestSegments TSEG WITH (NOLOCK) ON (TSEG.[TSEG-TEST] = TEST.[TEST-GUID])
			INNER JOIN TestQuestions TQUE WITH (NOLOCK) ON (TQUE.[TQUE-TSEG] = TSEG.[TSEG-GUID])
			INNER JOIN Questions QUES WITH (NOLOCK) ON (QUES.[QUES-GUID] = TQUE.[TQUE-QUES])
			INNER JOIN StudentGroups SGRP WITH (NOLOCK) ON (SGRP.[SGRP-GUID] = TSCH.[TSCH-SGRP])
			INNER JOIN StudentLists SLST WITH (NOLOCK) ON (SLST.[SLST-SGRP] = SGRP.[SGRP-GUID])
			INNER JOIN Students STUD WITH (NOLOCK) ON (STUD.[STUD-GUID] = SLST.[SLST-STUD])	
			INNER JOIN AMPFormsTable FORM with (NOLOCK) ON (FORM.[FORM-TEST] = TEST.[TEST-GUID])
			LEFT OUTER JOIN StudentScores SSCR WITH (NOLOCK) ON (SSCR.[SSCR-TSCH] = TSCH.[TSCH-GUID] AND SSCR.[SSCR-TLST] = TLST.[TLST-GUID])
			LEFT OUTER JOIN StudentItems SITM WITH (NOLOCK) ON (SITM.[SITM-SSCR] = SSCR.[SSCR-GUID] AND SITM.[SITM-TQUE] = TQUE.[TQUE-GUID])

			WHERE TEST.[TEST-CLASS] = 1 --Network Exam (not pre or post test)
					AND TEST.[TEST-SIM] = 0 --Only Show MC
					AND [QUES-EXTRAPOINTSTYPE] <> 2 --ignore pretest
					AND SRPT.[SRPT-COL2] = 'BCEN' --@ClientCode is REQUIRED for the report
					--AND SRPT.[SRPT-COL6] = '7014546'
					AND SRPT.[SRPT-COL15] BETWEEN '2023-06-27' AND '2023-06-27' --Date range is required;
					--AND SRPT.[SRPT-COL3] = 'CTRN'
					--AND not SSCR.[SSCR-PFA] is null --Only filled out PFAGs (P/F/A/G) -- WE WANT ABSENTEES SO WE CAN'T INCLUDE THIS IN WHERE
					--AND FORM.[FORM-ADMINTYPE] IN ('C7','P7')
					--AND FORM.[FORM-ID] = SRPT.[SRPT-COL31] -- link for specific form
			GROUP BY
				Stud.[STUD-FNAME],
				Stud.[STUD-LNAME],
				SRPT.[SRPT-COL50], -- CourseNumber
				SSCR.[SSCR-GUID],
				STUD.[STUD-FNAME],
				STUD.[STUD-LNAME],
				STUD.[STUD-EMAIL],
				SRPT.[SRPT-COL1],
				SRPT.[SRPT-COL33],
				SRPT.[SRPT-COL6], --SSN,
				SRPT.[SRPT-COL2], --ClientCode,
				SRPT.[SRPT-ExamId], --ExamID,
				FORM.[FORM-NAME],
				SRPT.[SRPT-COL3], --ExamPortionCode,		
				SSCR.[SSCR-PFA],
				SRPT.[SRPT-COL15], --DateScheduled,
				TEST.[TEST-GUID],
				QUES.[QUES-CONTENTAREA],-- as [BCGR-GUID],		
				SRPT.[SRPT-TSCH],
				SRPT.[SRPT-COL16], /*ScheduleID*/
				form.[FORM-RAWCUT],
				TEST.[TEST-TOTALPOINTS];

			--Step 2: Build our Content Area Outlines based on our prevous query result set.
			insert into @tblContentAreas	
			SELECT 
			ca.[BCGR-SEQ] as ordinal,
					q.[TEST-GUID],
					q.ExamId,
					ca.[BCGR-GUID],
					ca.[BCGR-TITLE] as sectionName,
					ca.[BCGR-DESC] as sectionTitle,			
					'', --GroupString,
					SUM(dbo.getQuestionTotalPoint(ca.[QUES-TYPE], ca.[QUES-MAXPOINTS], ca.[QUES-EXTRAPOINTS], ca.[QUES-EXTRAPOINTSTYPE])) as possibleScore --MaxScore

		
		FROM ContentAreasAdapter ca WITH (NOLOCK)
			INNER JOIN (SELECT distinct [TEST-GUID], ExamId	FROM @tblData) q ON (q.[TEST-GUID] = ca.[TEST-GUID])
			WHERE 1=1--ca.[BCAT-TITLE] <> '00000000-0000-0000-0000-000000000000'
			--  AND ca.[QUES-EXTRAPOINTSTYPE] <> 2 --ignore pretest

			GROUP BY 
					ca.[BCGR-SEQ],
					q.[TEST-GUID],
					q.ExamId,
					ca.[BCGR-GUID],
		
					ca.[BCGR-TITLE],
					ca.[BCGR-DESC];

			update c
			set c.GroupString = q1.Signature
			FROM @tblContentAreas c
			INNER JOIN (
				select q.[TEST-GUID], dbo.AMPTestSignatureMCMajor(q.[TEST-GUID]) as Signature
				FROM (
					select distinct [TEST-GUID]
					FROM @tblData) q) q1 ON (c.[TEST-GUID] = q1.[TEST-GUID]);
	
			SELECT 
			  ca.GroupString,
				t.[STUD-FNAME],
				t.[STUD-LNAME],
				t.[SRPT-COL50],
				t.SchoolCode,
				t.regId as ClientCode,
				t.clientCandidateId,
				t.ClientCode as regID,
				t.ExamID,
				t.examForm,
				t.series,		
				t.pfa,
				t.DateScheduled as examDate,
				t.[TEST-GUID],
				ca.[BCGR-GUID],
				ca.[BCGR-SEQ] as ordinal,
				ca.[BCGR-TITLE] as sectionName,
				ca.[BCGR-DESC] as sectionTitle,
				IsNull(t.StudentScore, 0) as sectionScore,
				ca.MaxScoreMajor as possibleScore,
				t.skipped,
				t.[TSCH-GUID],
				t.ScheduleID as examAuthorization,
				t.MaxScore
		
		
		
			FROM @tblContentAreas ca
			LEFT JOIN @tblData t ON (t.[BCGR-GUID] = ca.[BCGR-GUID] AND t.[TEST-GUID] = ca.[TEST-GUID] AND t.ExamId = ca.[SRPT-ExamId])
			WHERE NOT t.[TEST-GUID] IS NULL AND NOT t.[pfa] IS NULL --JDH 1/15/2015 if the test-guid is null don't return the record
			Order BY [clientCandidateId],[BCGR-SEQ]
			end";
    }
}
