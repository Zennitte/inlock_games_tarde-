USE inlock_games_tarde;
GO

INSERT INTO ESTUDIO(nomeEstudio)
VALUES ('Blizzard'), ('Rockstar Studios'), ('Square Enix')
GO

INSERT INTO JOGO(nomeJogo, dataLancamento, descrição, idEstudio,valor)
VALUES 
('Diablo 3','15/05/2012', 'é um jogo que contém bastanteação e é viciante, seja você um novato ou um fã.', 1, 99.00), 
('Red Dead Redemption II', '26/10/2018', 'jogo eletrônico de ação-aventura western',2, 120.00);


INSERT INTO TIPO_USUARIO (titulo)
VALUES ('ADMINISTRADOR'), ('CLIENTE')

INSERT INTO USUARIO (idTipoUsuario, email, senha)
VALUES (1, 'admin@admin.com', 'admin'), (2, 'cliente@cliente.com', 'cliente') 