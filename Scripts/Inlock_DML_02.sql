USE inlock_games_tarde;
GO

INSERT INTO ESTUDIOS(nomeEstudio)
VALUES ('Blizzard'), ('Rockstar Studios'), ('Square Enix')
GO

INSERT INTO JOGOS(nomeJogo, dataLancamento, descrição, idEstudio,valor)
VALUES 
('Diablo 3','15/05/2012', 'é um jogo que contém bastanteação e é viciante, seja você um novato ou um fã.', 1, 99.00), 
('Red Dead Redemption II', '26/10/2018', 'jogo eletrônico de ação-aventura western',2, 120.00);


INSERT INTO TIPOS_USUARIO (titulo)
VALUES ('ADMINISTRADOR'), ('CLIENTE')

INSERT INTO USUARIOS (idTipoUsuario, email, senha)
VALUES (1, 'admin@admin.com', 'admin'), (2, 'cliente@cliente.com', 'cliente') 