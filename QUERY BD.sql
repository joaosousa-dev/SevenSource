CREATE DATABASE LOCADORASEVENCAR;
GO

USE LOCADORASEVENCAR;

CREATE TABLE TELEFONE(
IDTELEFONE INT IDENTITY PRIMARY KEY NOT NULL,
TELFIXO VARCHAR(13),
TELMOVEL VARCHAR(13),
IDFUN INT NULL,
IDCLIENTE INT NULL,
FOREIGN KEY (IDCLIENTE) REFERENCES CLIENTE(IDCLIENTE),
FOREIGN KEY (IDFUN) REFERENCES FUNCIONARIO(IDFUN)
);

CREATE TABLE ENDERECO(
IDENDERECO INT PRIMARY KEY IDENTITY,
RUA VARCHAR(20),
NUMERO NUMERIC(5),
CIDADE VARCHAR(20),
BAIRRO VARCHAR(20),
ESTADO VARCHAR(2),
CEP NUMERIC(8),
IDCLIENTE INT,
IDFUN INT,
FOREIGN KEY (IDCLIENTE) REFERENCES CLIENTE(IDCLIENTE),
FOREIGN KEY (IDFUN) REFERENCES FUNCIONARIO(IDFUN)
);

CREATE TABLE CARGO(
IDCARGO INT IDENTITY PRIMARY KEY,
NIVEL NUMERIC(1)
);

CREATE TABLE FUNCIONARIO(
IDFUN INT IDENTITY PRIMARY KEY,
LOGINFUN VARCHAR(20) NOT NULL,
SENHAFUN VARCHAR(100) NOT NULL,
NOMEFUN VARCHAR(100) NOT NULL,
CPFFUN VARCHAR(11) NOT NULL,
IDCARGO INT,
FOREIGN KEY (IDCARGO) REFERENCES CARGO(IDCARGO)
);
alter table FUNCIONARIO alter COLUMN CPFFUN varchar(11);

CREATE TABLE CLIENTE(
IDCLIENTE INT IDENTITY PRIMARY KEY,
NOMECLIENTE VARCHAR(100),
EMAILCLIENTE VARCHAR(100),
SENHACLIENTE VARCHAR(100),
CNHCLIENTE VARCHAR(11),
CPFCLIENTE VARCHAR(11)
);
alter table CLIENTE alter COLUMN CNHCLIENTE varchar(11);
alter table CLIENTE alter COLUMN CPFCLIENTE varchar(11);

CREATE TABLE MODELO(
IDMODELO INT IDENTITY PRIMARY KEY,
NOMEMODELO VARCHAR(15),
ANOMODELO NUMERIC(4),
IDMARCA INT,
IDCATEGORIA INT,
FOREIGN KEY (IDMARCA) REFERENCES MARCA(IDMARCA),
FOREIGN KEY (IDCATEGORIA) REFERENCES CATEGORIA(IDCATEGORIA)
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
PLACA VARCHAR(8) UNIQUE,
CAMBIO CHAR(1),
IDMODELO INT ,
IDMARCA INT,
IDMANUTENCAO INT 
FOREIGN KEY (IDMODELO) REFERENCES MODELO(IDMODELO),
FOREIGN KEY (IDMANUTENCAO) REFERENCES MANUTENCAO(IDMANUTENCAO)
);

CREATE TABLE PAGAMENTO(
IDPAGAMENTO INT IDENTITY PRIMARY KEY,
TIPOPAGAMENTO VARCHAR(50)
);

CREATE TABLE LOCACAO(
IDLOCACAO INT PRIMARY KEY IDENTITY,
IDVEICULO INT,
IDCLIENTE INT,
IDFUN INT,
RETIRADA DATE NOT NULL,
PRAZOENTREGA DATE NOT NULL,
IDPAGAMENTO INT,
FOREIGN KEY (IDPAGAMENTO) REFERENCES PAGAMENTO(IDPAGAMENTO),
FOREIGN KEY (IDVEICULO) REFERENCES VEICULO(IDVEICULO),
FOREIGN KEY (IDCLIENTE) REFERENCES CLIENTE(IDCLIENTE),
FOREIGN KEY (IDFUN) REFERENCES FUNCIONARIO(IDFUN),
);

CREATE TABLE DEVOLUCAO(
IDDEVOLUCAO INT PRIMARY KEY IDENTITY,
DATADEVOLUCAO DATE ,
IDLOCACAO INT,
FOREIGN KEY (IDLOCACAO) REFERENCES LOCACAO(IDLOCACAO)
);