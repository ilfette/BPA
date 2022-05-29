INSERT INTO ATTENDANCE (id,Student_Id,	Lr_Ln_Id)
SELECT ROW_NUMBER() over ( order by s.Id, lrln.Id) , s.Id, lrln.Id FROM
lection_lectors lrln CROSS JOIN students s