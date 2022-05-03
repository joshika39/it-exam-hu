SELECT uj.datum, uj.hely AS helyezes,
	regi.hely-uj.hely AS helyvaltozas,
	uj.pont AS ujpontszam,
	uj.pont-regi.pont AS pontszamvaltozas
FROM 8seged AS uj, 8seged AS regi
WHERE uj.ranglistaid=regi.ranglistaid+1
ORDER BY uj.datum;
