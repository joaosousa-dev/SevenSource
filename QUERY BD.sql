CREATE DATABASE LOCADORASEVENCAR;


USE LOCADORASEVENCAR;

CREATE TABLE TELEFONE(
IDTELEFONE INT IDENTITY PRIMARY KEY NOT NULL,
TELFIXO VARCHAR(15),
TELMOVEL VARCHAR(15),
CPFCLIENTE bigint null,
foreign key (CPFCLIENTE) references CLIENTE(CPFCLIENTE),
);
alter table	TELEFONE alter COLUMN TELFIXO varchar(15);
alter table	TELEFONE alter COLUMN TELMOVEL varchar(15);

CREATE TABLE ENDERECO(
IDENDERECO INT PRIMARY KEY IDENTITY,
RUA VARCHAR(20),
NUMERO NUMERIC(5),
CIDADE VARCHAR(20),
BAIRRO VARCHAR(20),
ESTADO VARCHAR(2),
CEP varchar(9),
);
alter table	ENDERECO alter COLUMN CEP varchar(9);

CREATE TABLE CARGO(
IDCARGO INT IDENTITY PRIMARY KEY,
NIVELCARGO NUMERIC(1),
NOMECARGO VARCHAR(40)
);

CREATE TABLE FUNCIONARIO(
IDFUN INT IDENTITY PRIMARY KEY,
LOGINFUN VARCHAR(20) NOT NULL,
SENHAFUN VARCHAR(100) NOT NULL,
NOMEFUN VARCHAR(100) NOT NULL,
CPFFUN VARCHAR(11) NOT NULL,
IDCARGO INT,
FOREIGN KEY (IDCARGO) REFERENCES CARGO(IDCARGO),
);
alter table FUNCIONARIO alter COLUMN CPFFUN varchar(11);

CREATE TABLE CLIENTE(
CPFCLIENTE bigint primary key,
NOMECLIENTE VARCHAR(100),
EMAILCLIENTE VARCHAR(100),
CNHCLIENTE VARCHAR(11),
IDENDERECO INT,
foreign key (IDENDERECO) references ENDERECO(IDENDERECO)
);

CREATE TABLE MARCA(
IDMARCA INT IDENTITY PRIMARY KEY,
NOMEMARCA VARCHAR(20)
);

CREATE TABLE MANUTENCAO(
IDMANUTENCAO INT IDENTITY PRIMARY KEY,
DSMANUTENCAO TEXT,
);

CREATE TABLE CATEGORIA(
IDCATEGORIA INT PRIMARY KEY IDENTITY,
TIPOCATEGORIA VARCHAR(15),
VALOR_P_DIA DECIMAL(4,2),
DSCATEGORIA TEXT
);

CREATE TABLE VEICULO(
IDVEICULO INT IDENTITY PRIMARY KEY,
MODELO VARCHAR(100),
ANO NUMERIC(4),
PLACA VARCHAR(8) UNIQUE,
CAMBIO CHAR(1),
STATUS_VEICULO VARCHAR(20),
FOTO varchar(500),
IDCATEGORIA INT,
IDMARCA INT,
IDMANUTENCAO INT ,
FOREIGN KEY (IDMARCA) REFERENCES MARCA(IDMARCA),
FOREIGN KEY (IDCATEGORIA) REFERENCES CATEGORIA(IDCATEGORIA),
FOREIGN KEY (IDMANUTENCAO) REFERENCES MANUTENCAO(IDMANUTENCAO)
);
alter table veiculo alter column foto nvarchar(500);

CREATE TABLE PAGAMENTO(
IDPAGAMENTO INT IDENTITY PRIMARY KEY,
TIPOPAGAMENTO VARCHAR(50)
);

CREATE TABLE LOCACAO(
IDLOCACAO INT PRIMARY KEY IDENTITY,
IDVEICULO INT,
CPFCLIENTE BIGINT,
IDFUN INT,
RETIRADA DATE NOT NULL,
PRAZOENTREGA DATE NOT NULL,
IDPAGAMENTO INT,
VALOR FLOAT,
SITUACAOLOCACAO VARCHAR(50),
FOREIGN KEY (IDPAGAMENTO) REFERENCES PAGAMENTO(IDPAGAMENTO),
FOREIGN KEY (IDVEICULO) REFERENCES VEICULO(IDVEICULO),
FOREIGN KEY (CPFCLIENTE) REFERENCES CLIENTE(CPFCLIENTE),
FOREIGN KEY (IDFUN) REFERENCES FUNCIONARIO(IDFUN)
);

CREATE TABLE DEVOLUCAO(
IDDEVOLUCAO INT PRIMARY KEY IDENTITY,
DATADEVOLUCAO DATE ,
IDLOCACAO INT,
FOREIGN KEY (IDLOCACAO) REFERENCES LOCACAO(IDLOCACAO)
);

drop table TELEFONE;
drop table ENDERECO;
drop table cliente;
drop table FUNCIONARIO;
drop table LOCACAO;
drop table DEVOLUCAO;
drop table VEICULO;
drop table marca ;
drop table modelo ;
drop table MANUTENCAO;
drop table CARGO;
drop table CATEGORIA;
drop table PAGAMENTO;
drop database LOCADORASEVENCAR;
drop view vwcliente;

select * from marca;
select * from cliente;

SELECT * FROM TELEFONE as T
INNER JOIN CLIENTE as C
   on T.CPFCLIENTE = C.CPFCLIENTE where T.CPFCLIENTE=1234567896

SELECT * FROM TELEFONE as T
INNER JOIN CLIENTE AS C ON T.CPFCLIENTE = C.CPFCLIENTE
INNER JOIN ENDERECO AS E ON  E.IDENDERECO = C.IDENDERECO;

create view VWCLIENTE as
SELECT E.IDENDERECO,C.NOMECLIENTE,C.EMAILCLIENTE,C.CNHCLIENTE,C.CPFCLIENTE,T.TELFIXO,T.TELMOVEL,E.RUA,E.NUMERO,E.BAIRRO,E.ESTADO,E.CIDADE,E.CEP from CLIENTE as C
left join ENDERECO as E on E.IDENDERECO = C.IDENDERECO
left join TELEFONE as T on T.CPFCLIENTE = C.CPFCLIENTE;

CREATE VIEW VWVEICULO AS
SELECT V.IDVEICULO,M.NOMEMARCA,V.MODELO,V.ANO,V.PLACA,V.CAMBIO,V.STATUS_VEICULO,C.TIPOCATEGORIA,MT.DSMANUTENCAO,MT.IDMANUTENCAO,C.IDCATEGORIA,M.IDMARCA,V.FOTO from VEICULO as V
left join CATEGORIA as C on V.IDCATEGORIA = C.IDCATEGORIA
LEFT JOIN MANUTENCAO AS MT ON MT.IDMANUTENCAO = V.IDMANUTENCAO
left join MARCA as M on V.IDMARCA = M.IDMARCA;

CREATE VIEW  VWFUNCIONARIO AS
SELECT f.idfun,f.nomefun,f.loginfun,f.senhafun,f.idcargo,c.nivelcargo,c.nomecargo from FUNCIONARIO as f
inner join CARGO as C on f.idcargo = C.idcargo
select * from vwfuncionario;


drop view VWVEICULO;

DELETE FROM VEICULO ;

INSERT INTO ENDERECO (RUA,NUMERO,CIDADE,BAIRRO,ESTADO,CEP) VALUES ('PEDRO AMERICO','96','CIDADE','BAIRRO','SP','3696525');
INSERT INTO CLIENTE (cpfcliente,nomecliente,emailcliente,cnhcliente,idendereco where rua='PEDRO AMERICO' AND NUMERO='96' AND CIDADE='CIDADE' BAIRRO='BAIRRO' AND ESTADO='SP' AND CEP='3696525') VALUES(99999999999,'JOSE','JVOLIVEIRA@GMAIL.COM','99999999999');
INSERT INTO MANUTENCAO VALUES ('SEM PROBLEMAS');
insert into funcionario (LOGINFUN,SENHAFUN,NOMEFUN,CPFFUN,idcargo)VALUES ('kleber','123456','klebinho','32132132132',1)
insert into cargo (nivelcargo,nomecargo) values (1,'GERENTE')
SELECT * FROM ENDERECO;

select * from VWVEICULO;