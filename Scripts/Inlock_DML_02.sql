USE inlock_games_tarde;
GO

INSERT INTO ESTUDIOS(nomeEstudio)
VALUES ('Blizzard'), ('Rockstar Studios'), ('Square Enix')
GO

INSERT INTO JOGOS(nomeJogo, dataLancamento, descri��o, idEstudio,valor)
VALUES 
('Diablo 3','15/05/2012', '� um jogo que cont�m bastantea��o e � viciante, seja voc� um novato ou um f�.', 1, 99.00), 
('Red Dead Redemption II', '26/10/2018', 'jogo eletr�nico de a��o-aventura western',2, 120.00);


INSERT INTO TIPOS_USUARIO (titulo)
VALUES ('ADMINISTRADOR'), ('CLIENTE')

INSERT INTO USUARIOS (idTipoUsuario, email, senha)
VALUES (1, 'admin@admin.com', 'admin'), (2, 'cliente@cliente.com', 'cliente') 