SELECT * 
  FROM DatabaseName.INFORMATION_SCHEMA.ROUTINES
 WHERE ROUTINE_TYPE = 'PROCEDURE'


 DROP PROCEDURE dbo.spGetEmployee, dbo.spAddNew, dbo.spUpdateEmployee, dbo.spDeleteEmployee;  