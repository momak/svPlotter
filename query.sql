DECLARE @rpt as nvarchar(10) = 'FA_1SR'

SELECT	CASE 
			WHEN RIGHT(Stavka,1) = '*' THEN LEFT(Stavka, LEN(stavka)-1)
			ELSE Stavka
		END as Stavka,
		podIzvor,
		Izvor,
		Znak,
		Kod
FROM	dbo.tblVrski1
WHERE	rpt = @rpt
ORDER BY 
		Stavka,
		podIzvor,
		Kod

SELECT	CASE 
			WHEN RIGHT(Stavka,1) = '*' THEN LEFT(Stavka, LEN(stavka)-1)
			ELSE Stavka
		END as Stavka,
		podIzvor,
		Izvor,
		Znak,
		Kod
FROM	dbo.tblVrski1
WHERE	rpt = @rpt
ORDER BY 
		Stavka,
		podIzvor,
		Kod
FOR XML PATH('Vrska'), ROOT('Vrski');