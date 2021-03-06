USE [APMC]
GO
/****** Object:  StoredProcedure [dbo].[SaveArrival]    Script Date: 05-08-2020 6.48.44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[SaveArrival](@date datetime,@Truck_No varchar(50),@RSTNo varchar(50),
@Memo_No varchar(50),@Dest varchar(50),@Maldhani varchar(50),@LF varchar(50),@Series varchar(50),
@Shop varchar(50),@NO varchar(50),@ID varchar(50),@COMD varchar(50),@VR varchar(50),@UM varchar(50),
@UMCONV varchar(50),@NAG varchar(50),@QTY varchar(50),@AMT varchar(50),@Mandi varchar(50),@RSTDATE datetime,@RSTTIME datetime)
as
begin
/*
exec [SaveAr_Em] '2','Mh43y3434','','2','2'

exec [SaveArrival] '2019-05-03','Mh12F0553','41882355','555','vashi','fhfh','3451','S','1','1','1','2001','1','1','1.00','2','2','10','ddd','20200101','10:40:10'
*/
Declare @AssMonth varchar(50);
Declare @prvAssMonth varchar(50);

SELECT @AssMonth = SUBSTRING ( CONVERT(varchar(4), @date,12) ,3 , 2)  + CONVERT(varchar(2), @date,12)

Select @prvAssMonth=SUBSTRING ( CONVERT(varchar(4), DATEADD(month, -1, @date),12) ,3 , 2)  + CONVERT(varchar(2), DATEADD(month, -1, @date),12)

--print @AssMonth
--Print @prvAssMonth

Declare @TableName varchar(50);
Declare @prevTablename varchar(50);
select @TableName='AR'+@AssMonth;
select @prevTablename='AR'+@prvAssMonth;
declare @query varchar(100);
declare @query1 varchar(100);
declare @query2 varchar(100);
declare @query3 varchar(100);
declare @query4 varchar(100);
declare @query5 varchar(100);
declare @query6 varchar(100);
IF Not EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES
           WHERE TABLE_NAME = @TableName)
BEGIN
set @query='Select * into '+@TableName+' from '+@prevTablename+'';
exec (@query)

set @query1='delete  from '+@TableName+'';
exec(@query1)
end

set @query2='insert into '+@TableName+' (TRUCK_NO,RSTNO,MEMO_NO,DEST,MALDHANI,LF,SERIES,SHOP,NO,ID,
			COMD,VR,UM,UMCONV'
			
set @query3=',NAG,QTY,AMT,DT,	TIM,MANDI,	RSTDATE	,RSTTIME) values (Trim('''+@Truck_No+'''), Trim('''+@RSTNo+''') ,'''+@Memo_No+''''


set @query4=','''+@Dest+''','''+@Maldhani+''','''+@LF+''','''+@Series+''','''+@Shop+''','''+@NO+''','''+@ID+''','''+@COMD+''','''+@VR+''','''+@UM+''','''+@UMCONV+''','''+@NAG+''','''+@QTY+''','''+@AMT+''',''' + CONVERT(VARCHAR(10),GETDATE(), 112) + ''''
set @query5=',''' + CONVERT(VARCHAR(10),GETDATE(), 8) + ''' ,'''+@Mandi+''',''' + CONVERT(VARCHAR(10),@RSTDATE, 112) + ''',''' + CONVERT(VARCHAR(10),@RSTTIME, 8) + ''')'
set @query6=' SELECT SCOPE_IDENTITY() '
print @query2+@query3+@query4+@query5+@query6
exec (@query2+@query3+@query4+@query5+@query6)
end

