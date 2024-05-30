-- B
CREATE TABLE PROPRIETARI (
    CodF char(20) NOT NULL PRIMARY KEY,
    Nome varchar(16),
    Residenza varchar(32)
);

CREATE TABLE ASSICURAZIONI (
    CodAss char(20) NOT NULL PRIMARY KEY,
    Nome varchar(16),
    Sede varchar(32)
);

CREATE TABLE SINISTRO (
    CodS char(32) NOT NULL PRIMARY KEY,
    Localita varchar(32),
    Data int
);

CREATE TABLE AUTO(
    Targa char(7) NOT NULL PRIMARY KEY,
    Marca varchar(20),
    Cilindrata int,
    Potenza int,
    CodF char(20),
    FOREIGN KEY (CodF) REFERENCES PROPRIETARI(CodF),
    CodAss char(20),
    FOREIGN KEY (CodAss) REFERENCES ASSICURAZIONI(CodAss)
);

CREATE TABLE AUTOCOINVOLTE(
    CodS char(32),
    FOREIGN KEY (CodS) REFERENCES SINISTRO(CodS),
    Targa char(7), 
    FOREIGN KEY (Targa) REFERENCES AUTO(Targa),
    ImportoDelDanno int
);

-- Dati
INSERT INTO PROPRIETARI VALUES ("TDSTMS", "TOMMASO", "VICENZA");
INSERT INTO PROPRIETARI VALUES ("RSSMRI", "MARIO", "CALTANISETTA");
INSERT INTO PROPRIETARI VALUES ("RSSFRC", "FRANCESCO", "PADOVA");

INSERT INTO ASSICURAZIONI VALUES ("AAA", "ASSICURA", "PADOVA");
INSERT INTO ASSICURAZIONI VALUES ("123", "SARA", "VICENZA");
INSERT INTO ASSICURAZIONI VALUES ("321", "SARA", "VICENZA");

INSERT INTO SINISTRO VALUES ("X123", "CREAZZO", 200102);
INSERT INTO SINISTRO VALUES ("X321", "ALTAVILLA", 200103);
INSERT INTO SINISTRO VALUES ("X456", "VALMARANA", 200102);

INSERT INTO AUTO VALUES ("AA000BB", "FIAT", 3000, 150, "TDSTMS", "AAA");
INSERT INTO AUTO VALUES ("BB000CC", "LAMBORGHINI", 8000, 500, "RSSMRI", "123");
INSERT INTO AUTO VALUES ("CC000DD", "FERRARI", 6000, 600, "RSSFRC", "321");

INSERT INTO AUTOCOINVOLTE VALUES ("X123", "AA000BB", 1000);
INSERT INTO AUTOCOINVOLTE VALUES ("X321", "BB000CC", 3000);
INSERT INTO AUTOCOINVOLTE VALUES ("X456", "CC000DD", 6000);

-- C
-- 1
SELECT Targa, Marca
FROM AUTO
WHERE Cilindrata > 2000 OR Potenza > 120;

-- 2
SELECT P.Nome, A.Targa
FROM AUTO A
INNER JOIN PROPRIETARI P ON (A.CodF = P.CodF)
WHERE Cilindrata > 200 OR Potenza > 120;

-- 3
SELECT A.Targa, P.Nome
FROM AUTO A
INNER JOIN PROPRIETARI P ON (A.CodF = P.CodF)
INNER JOIN ASSICURAZIONI S ON (A.CodAss = S.CodAss)
WHERE (Cilindrata > 2000 OR Potenza > 120) AND S.Nome = "Sara";

-- 4
SELECT A.Targa, P.Nome
FROM AUTO A
INNER JOIN PROPRIETARI P ON (A.CodF = P.CodF)
INNER JOIN ASSICURAZIONI S ON (A.CodAss = S.CodAss)
INNER JOIN AUTOCOINVOLTE AC ON (AC.Targa = A.Targa)
INNER JOIN SINISTRO SI ON (SI.CodS = AC.CodS)
WHERE S.Nome = "Sara" AND SI.Data = 200102;

-- 5
SELECT Nome, Sede, COUNT(CodAss) AS NUMERO
FROM ASSICURAZIONI
GROUP BY Nome;

-- 6
SELECT A.Targa, COUNT(AC.CodS) AS NUMSINISTRI FROM AUTO A
INNER JOIN AUTOCOINVOLTE AC ON (AC.Targa = A.Targa)
WHERE A.Marca = "Fiat"
GROUP BY A.Targa;

-- 7
SELECT A.Targa, S.Nome, SUM(AC.ImportoDelDanno) AS SOMMA
FROM AUTO A INNER JOIN AUTOCOINVOLTE AC ON (AC.Targa = A.Targa)
INNER JOIN ASSICURAZIONI S ON (A.CodAss = S.CodAss)
GROUP BY A.Targa HAVING COUNT(AC.CodS) > 1;
