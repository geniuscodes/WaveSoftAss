SELECT       
     ev.EventID,
     ev.EventName,
     ev.EventNumber,
     ev.EventDateTime,
     ev.EventEndDateTime, 
     ev.AutoClose,
     evd.EventDetailName, 
     evd.EventDetailOdd,
     evd.FirstTimer, 
     evds.EventDetailStatusName
FROM            dbo.Event AS ev INNER JOIN
                         dbo.EventDetail AS evd ON ev.EventID = evd.FK_EventID INNER JOIN
                         dbo.EventDetailStatus AS evds ON evd.FK_EventDetailsStatusID = evds.EventDetailStatusID



--Events of Tournament pROCEDURE 
-- Select rows from a Table or View '[TableOrViewName]' in schema '[dbo]'
SELECT 
EventName,
TournamentName,
t.TournamentID
 FROM [dbo].[Event] e
 INNER JOIN Tournament t ON t.TournamentID = e.FK_TournamentID
 WHERE e.EventID = 1
GO