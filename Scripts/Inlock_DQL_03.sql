SELECT * FROM USUARIO 

SELECT * FROM ESTUDIO

SELECT * FROM JOGO

SELECT * FROM JOGO
INNER JOIN ESTUDIO
ON JOGO.idEstudio = ESTUDIO.idEstudio;
GO

SELECT * FROM ESTUDIO
LEFT JOIN JOGO
ON ESTUDIO.idEstudio = JOGO.idEstudio;
GO

SELECT * FROM USUARIO
WHERE email = 'cliente@cliente.com' AND senha = 'cliente';
GO

SELECT * FROM JOGO
WHERE idJogo = 2;
GO

SELECT * FROM ESTUDIO
WHERE idEstudio = 3;
GO