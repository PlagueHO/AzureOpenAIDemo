# Explain SQL for Database Migration

- [Explain a SQL Stored Procedure for Database Migration](#explain-a-sql-stored-procedure-for-database-migration)

## Explain a SQL Stored Procedure for Database Migration

> Recommended models: GPT-4-TURBO

Explains a SQL Stored Procedure definition as part of a migration assessment to a new database.

```text
System: You are an AI assistant for Adventure Works database operations team. You assist in the migration process of the Adventure Works software from an on-premises SQL Database to a SaaS based Adventure Works solution using Azure SQL Database. You assess a SQL Stored Procedure created by the customer in their on-premises Adventure Works database and explain their intended purpose and identify any potential issues with the stored procedure.

For the Stored Procedure definition provided by the user you will:
1. A summary of the purpose of the Stored Procedure.
2. Does the Stored Procedure name align to the intended purpose?
3. What are the inputs and outputs of the Stored Procedure.
4. A detailed explanation of the logic and flow of the Stored Procedure.
5. Identify any bugs or potential issues with the Stored Procedure.
6. Identify any potential performance issues with the Stored Procedure.

User:
CREATE PROCEDURE [dbo].[stp_CityHealthResearchRequestsReport]
@FromDate DATETIME,
@ToDate DATETIME,
@StatusId int,
@BranchId int,
@Count INT OUTPUT
AS
BEGIN
DECLARE @TempTable TABLE
(
    ProjectId INT,
    Recieved DATETIME,
    Concluded DATETIME,
    Comment VARCHAR(8000)
)

IF @StatusId <> 0 AND @BranchId <> 0
BEGIN

    INSERT INTO @TempTable (ProjectId, Recieved, Concluded, Comment)
    SELECT DISTINCT
        p.ProjectId,
        (SELECT TOP 1 wf.ActionedOn
         FROM WorkflowHistory wf
         WHERE wf.ProjectId = p.ProjectId
         AND wf.WorkflowStep = 1
         ORDER BY wf.WorkflowHistoryId DESC) AS Recieved,
        (SELECT TOP 1 wf.ActionedOn
         FROM WorkflowHistory wf
         WHERE wf.ProjectId = p.ProjectId
         AND wf.WorkflowStep = 4
         OR wf.ProjectId = p.ProjectId
         AND wf.WorkflowStep = 5
         ORDER BY wf.WorkflowHistoryId DESC) AS Concluded,
        (SELECT TOP 1 wf.Comment
         FROM WorkflowHistory wf
         WHERE wf.ProjectId = p.ProjectId
         AND wf.WorkflowStep = 4
         OR wf.ProjectId = p.ProjectId
         AND wf.WorkflowStep = 5
         ORDER BY wf.WorkflowHistoryId DESC) AS Comment
    FROM
        Project p
        JOIN WorkflowHistory w ON p.ProjectId = w.ProjectId
        JOIN ProjectBranch pb ON pb.ProjectId = p.ProjectId
    WHERE
        p.ProjectId = w.ProjectId
        AND p.StatusId = @StatusId
        AND pb.BranchId = @BranchId
        AND w.WorkflowStep = 1
        AND (w.ActionedOn BETWEEN @FromDate AND @ToDate)

    SELECT DISTINCT
        p.ProjectId,
        p.Title,
        STUFF (
               (SELECT ', ' + f.Name
                FROM dbo.Facility f
                LEFT JOIN dbo.ProjectFacility pf ON f.FacilityId = pf.FacilityId
                WHERE pf.ProjectId = p.ProjectId
                FOR XML PATH (''))
                , 1, 1, '') AS Facilities,
        tt.Recieved,
        tt.Concluded,
        b.BranchName,
        st.Description AS StatusText,
        tt.Comment,
        tt.Concluded - tt.Recieved AS Turnaround
    FROM
        dbo.Project p
        INNER JOIN @TempTable tt ON p.ProjectId = tt.ProjectId
        LEFT JOIN dbo.ProjectBranch pb ON p.ProjectId = pb.ProjectId
        LEFT JOIN dbo.Branch b ON pb.BranchId = b.BranchId
        LEFT JOIN dbo.Status st ON p.StatusId = st.StatusId
    WHERE
        p.StatusId = @StatusId
        AND b.BranchId = @BranchId
    SET @Count = @@ROWCOUNT
END

IF @StatusId <> 0 AND @BranchId = 0
BEGIN

    INSERT INTO @TempTable (ProjectId, Recieved, Concluded, Comment)
    SELECT DISTINCT
        p.ProjectId,
        (SELECT TOP 1 wf.ActionedOn
         FROM WorkflowHistory wf
         WHERE wf.ProjectId = p.ProjectId
         AND wf.WorkflowStep = 1
         ORDER BY wf.WorkflowHistoryId DESC) AS Recieved,
        (SELECT TOP 1 wf.ActionedOn
         FROM WorkflowHistory wf
         WHERE wf.ProjectId = p.ProjectId
         AND wf.WorkflowStep = 4
         OR wf.ProjectId = p.ProjectId
         AND wf.WorkflowStep = 5
         ORDER BY wf.WorkflowHistoryId DESC) AS Concluded,
        (SELECT TOP 1 wf.Comment
         FROM WorkflowHistory wf
         WHERE wf.ProjectId = p.ProjectId
         AND wf.WorkflowStep = 4
         OR wf.ProjectId = p.ProjectId
         AND wf.WorkflowStep = 5
         ORDER BY wf.WorkflowHistoryId DESC) AS Comment
    FROM
        Project p
        JOIN WorkflowHistory w ON p.ProjectId = w.ProjectId
        JOIN ProjectBranch pb ON pb.ProjectId = p.ProjectId
    WHERE
        p.ProjectId = w.ProjectId
        AND p.StatusId = @StatusId
        AND w.WorkflowStep = 1
        AND (w.ActionedOn BETWEEN @FromDate AND @ToDate)

    SELECT DISTINCT
        p.ProjectId,
        p.Title,
        STUFF (
               (SELECT ', ' + f.Name
                FROM dbo.Facility f
                LEFT JOIN dbo.ProjectFacility pf ON f.FacilityId = pf.FacilityId
                WHERE pf.ProjectId = p.ProjectId
                FOR XML PATH (''))
                , 1, 1, '') AS Facilities,
        tt.Recieved,
        tt.Concluded,
        b.BranchName,
        st.Description AS StatusText,
        tt.Comment,
        tt.Concluded - tt.Recieved AS Turnaround
    FROM
        dbo.Project p
        INNER JOIN @TempTable tt ON p.ProjectId = tt.ProjectId
        LEFT JOIN dbo.ProjectBranch pb ON p.ProjectId = pb.ProjectId
        LEFT JOIN dbo.Branch b ON pb.BranchId = b.BranchId
        LEFT JOIN dbo.Status st ON p.StatusId = st.StatusId
    WHERE
        p.StatusId = @StatusId
    SET @Count = @@ROWCOUNT
END

IF @StatusId = 0 AND @BranchId <> 0
BEGIN

    INSERT INTO @TempTable (ProjectId, Recieved, Concluded, Comment)
    SELECT DISTINCT
        p.ProjectId,
        (SELECT TOP 1 wf.ActionedOn
         FROM WorkflowHistory wf
         WHERE wf.ProjectId = p.ProjectId
         AND wf.WorkflowStep = 1
         ORDER BY wf.WorkflowHistoryId DESC) AS Recieved,
        (SELECT TOP 1 wf.ActionedOn
         FROM WorkflowHistory wf
         WHERE wf.ProjectId = p.ProjectId
         AND wf.WorkflowStep = 4
         OR wf.ProjectId = p.ProjectId
         AND wf.WorkflowStep = 5
         ORDER BY wf.WorkflowHistoryId DESC) AS Concluded,
        (SELECT TOP 1 wf.Comment
         FROM WorkflowHistory wf
         WHERE wf.ProjectId = p.ProjectId
         AND wf.WorkflowStep = 4
         OR wf.ProjectId = p.ProjectId
         AND wf.WorkflowStep = 5
         ORDER BY wf.WorkflowHistoryId DESC) AS Comment
    FROM
        Project p
        JOIN WorkflowHistory w ON p.ProjectId = w.ProjectId
        JOIN ProjectBranch pb ON pb.ProjectId = p.ProjectId
    WHERE
        p.ProjectId = w.ProjectId
        AND p.StatusId = 5
        AND pb.BranchId = @BranchId
        AND w.WorkflowStep = 1
        AND (w.ActionedOn BETWEEN @FromDate AND @ToDate)
        OR p.ProjectId = w.ProjectId
        AND p.StatusId = 6
        AND pb.BranchId = @BranchId
        AND w.WorkflowStep = 1
        AND (w.ActionedOn BETWEEN @FromDate AND @ToDate)
        OR p.ProjectId = w.ProjectId
        AND p.StatusId = 7
        AND pb.BranchId = @BranchId
        AND w.WorkflowStep = 1
        AND (w.ActionedOn BETWEEN @FromDate AND @ToDate)

    SELECT DISTINCT
        p.ProjectId,
        p.Title,
        STUFF (
               (SELECT ', ' + f.Name
                FROM dbo.Facility f
                LEFT JOIN dbo.ProjectFacility pf ON f.FacilityId = pf.FacilityId
                WHERE pf.ProjectId = p.ProjectId
                FOR XML PATH (''))
                , 1, 1, '') AS Facilities,
        tt.Recieved,
        tt.Concluded,
        b.BranchName,
        st.Description AS StatusText,
        tt.Comment,
        tt.Concluded - tt.Recieved AS Turnaround
    FROM
        dbo.Project p
        INNER JOIN @TempTable tt ON p.ProjectId = tt.ProjectId
        LEFT JOIN dbo.ProjectBranch pb ON p.ProjectId = pb.ProjectId
        LEFT JOIN dbo.Branch b ON pb.BranchId = b.BranchId
        LEFT JOIN dbo.Status st ON p.StatusId = st.StatusId
    WHERE
        p.StatusId = 5
        AND pb.BranchId = @BranchId
        OR p.StatusId = 6
        AND pb.BranchId = @BranchId
        OR p.StatusId = 7
        AND pb.BranchId = @BranchId
    SET @Count = @@ROWCOUNT
END

IF @StatusId = 0 AND @BranchId = 0
BEGIN

    INSERT INTO @TempTable (ProjectId, Recieved, Concluded, Comment)
    SELECT DISTINCT
        p.ProjectId,
        (SELECT TOP 1 wf.ActionedOn
         FROM WorkflowHistory wf
         WHERE wf.ProjectId = p.ProjectId
         AND wf.WorkflowStep = 1
         ORDER BY wf.WorkflowHistoryId DESC) AS Recieved,
        (SELECT TOP 1 wf.ActionedOn
         FROM WorkflowHistory wf
         WHERE wf.ProjectId = p.ProjectId
         AND wf.WorkflowStep = 4
         OR wf.ProjectId = p.ProjectId
         AND wf.WorkflowStep = 5
         ORDER BY wf.WorkflowHistoryId DESC) AS Concluded,
        (SELECT TOP 1 wf.Comment
         FROM WorkflowHistory wf
         WHERE wf.ProjectId = p.ProjectId
         AND wf.WorkflowStep = 4
         OR wf.ProjectId = p.ProjectId
         AND wf.WorkflowStep = 5
         ORDER BY wf.WorkflowHistoryId DESC) AS Comment
    FROM
        Project p
        JOIN WorkflowHistory w ON p.ProjectId = w.ProjectId
        JOIN ProjectBranch pb ON pb.ProjectId = p.ProjectId
    WHERE
        p.ProjectId = w.ProjectId
        AND p.StatusId = 5
        AND w.WorkflowStep = 1
        AND (w.ActionedOn BETWEEN @FromDate AND @ToDate)
        OR p.ProjectId = w.ProjectId
        AND p.StatusId = 6
        AND w.WorkflowStep = 1
        AND (w.ActionedOn BETWEEN @FromDate AND @ToDate)
        OR p.ProjectId = w.ProjectId
        AND p.StatusId = 7
        AND w.WorkflowStep = 1
        AND (w.ActionedOn BETWEEN @FromDate AND @ToDate)

    SELECT DISTINCT
        p.ProjectId,
        p.Title,
        STUFF (
               (SELECT ', ' + f.Name
                FROM dbo.Facility f
                LEFT JOIN dbo.ProjectFacility pf ON f.FacilityId = pf.FacilityId
                WHERE pf.ProjectId = p.ProjectId
                FOR XML PATH (''))
                , 1, 1, '') AS Facilities,
        tt.Recieved,
        tt.Concluded,
        b.BranchName,
        st.Description AS StatusText,
        tt.Comment,
        tt.Concluded - tt.Recieved AS Turnaround
    FROM
        dbo.Project p
        INNER JOIN @TempTable tt ON p.ProjectId = tt.ProjectId
        LEFT JOIN dbo.ProjectBranch pb ON p.ProjectId = pb.ProjectId
        LEFT JOIN dbo.Branch b ON pb.BranchId = b.BranchId
        LEFT JOIN dbo.Status st ON p.StatusId = st.StatusId
    WHERE
        p.StatusId = 5
        OR p.StatusId = 6
        OR p.StatusId = 7
    SET @Count = @@ROWCOUNT
END
END
```
