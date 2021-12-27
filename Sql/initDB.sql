DROP TABLE IF EXISTS players;
DROP TABLE IF EXISTS games;
DROP TABLE IF EXISTS PlayerGames;

create table players (
    Id serial primary Key,
    PlayerName varchar(150)
)

create table games (
    Id serial primary Key,
    GameName varchar(150)
)

create table PlayerGames(
playerid int,
CONSTRAINT fk_player
      FOREIGN KEY(playerid) 
	  REFERENCES players(id)
)