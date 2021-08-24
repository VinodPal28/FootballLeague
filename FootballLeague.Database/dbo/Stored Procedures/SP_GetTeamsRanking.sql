CREATE procedure SP_GetTeamsRanking
AS
BEGIN

	DECLARE @rank VARCHAR(50)

	SELECT teams.Name, GP, score_for GF, score_against GA, score_for - score_against GD, W, L, D, (W * 3) + D AS Pts
	  FROM  Teams
		INNER JOIN
		  (SELECT team, sum(score1) score_for
			 FROM
			   (SELECT team1 AS team, score1
				  FROM Matches
				UNION ALL
				SELECT team2, score2
				  FROM Matches
			   ) qq
			 GROUP BY team
		   ) q1
		   ON teams.Name = q1.team
		INNER JOIN
		  (SELECT team1 AS team, sum(score2) score_against
			 FROM
			   (SELECT team1, score2
				  FROM Matches
				UNION ALL
				SELECT team2, score1
				  FROM Matches
			   ) qq
			GROUP BY team1
		 ) q2
		 ON teams.Name = q2.team
	   INNER JOIN
		 (SELECT team1 AS team, count(CASE WHEN result = 1 THEN result END) w, count(CASE WHEN result = 0 THEN result END) d, count(CASE WHEN result = -1 THEN result END) l
		   FROM
			 (SELECT team1, CASE WHEN score1 > score2 THEN 1 WHEN score1 = score2 THEN 0 ELSE -1 END result
				FROM Matches
			  UNION ALL
			  SELECT team2, CASE WHEN score2 > score1 THEN 1 WHEN score2 = score1 THEN 0 ELSE -1 END result
				FROM Matches
			 ) qq
		   GROUP BY team1
		 ) q3
		 ON teams.Name = q3.team
	   INNER JOIN
		 (SELECT team, count(*) gp
		   FROM 
			(SELECT team1 AS team
			   FROM Matches
			 UNION ALL
			 SELECT team2 AS team
			   FROM Matches
			) qq
		   GROUP BY team
		 ) q4
		 ON teams.Name = q4.team
	   ORDER BY pts DESC
END