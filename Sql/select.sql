
insert into players (PlayerName)
values ('Avery D')
RETURNING id;

insert into games (gamename)
values ('Yahtzee2')
RETURNING id;

insert into tournaments (tournamentname, winner)
values ('Yahtzee1', 1)
RETURNING id;

insert into playergames (playerid, gameid, score, win, tournamentid)
values (1, 2, 250, true, 1)
RETURNING id;

insert into bonus (tournamentid, playerid, points)
values (1, 1, 100)
RETURNING id;


select 
(sum(pg.score) + (select b.points from bonus b where b.tournamentid = 1)) / count(pg.id) as "average points"
from playergames pg
inner join players p on p.id = pg.playerid
inner join tournaments t on t.id = pg.tournamentid
inner join games g on g.id = pg.gameid 
where p.id = 1
and t.tournamentname = 'things' or t.tournamentname = 'Yahtzee1'

select 
distinct g.GameName
from playergames pg
inner join players p on p.id = pg.playerid
inner join tournaments t on t.id = pg.tournamentid
inner join games g on g.id = pg.gameid 
where p.id = 1
and t.tournamentname = 'things' or t.tournamentname = 'Yahtzee1'

select * from players;
select * from games;
select * from tournaments;
select * from playergames;
select * from bonus;
select * from house_rules;