DROP TABLE IF EXISTS house_rules;
DROP TABLE IF EXISTS bonus;
DROP TABLE IF EXISTS playergames;
DROP TABLE IF EXISTS tournaments;
DROP TABLE IF EXISTS players;
DROP TABLE IF EXISTS games;

create table players (
    Id serial primary Key,
    PlayerName varchar(150)
);

create table games (
    Id serial primary Key,
    GameName varchar(150)
);

create table house_rules (
    Id serial primary Key,
    rule varchar,
    gameid INT,
    CONSTRAINT fk_game
        FOREIGN KEY(gameid) 
        REFERENCES games(id)
);

create table tournaments (
    Id serial primary Key,
    tournamentname varchar(150),
    winner INT,
    CONSTRAINT fk_player
        FOREIGN KEY(winner) 
        REFERENCES players(id)
);

create table bonus (
    Id serial primary Key,
    tournamentid INT,
    playerid INT,
    points INT,
    CONSTRAINT fk_bonus_player
        FOREIGN KEY(playerid) 
        REFERENCES players(id),
    CONSTRAINT fk_bonus_tournament
        FOREIGN KEY(tournamentid) 
        REFERENCES tournaments(id)
);

create table playergames(
    Id serial primary Key,
    playerid int,
    gameid int,
    score int,
    win BOOLEAN,
    tournamentid INT,
    CONSTRAINT fk_pg_player
        FOREIGN KEY(playerid) 
        REFERENCES players(id),
    CONSTRAINT fk_pg_game
        FOREIGN KEY(gameid) 
        REFERENCES games(id)
);