CREATE TABLE Usuarios (
    Id_Usuarios     NUMBER          NOT NULL,
    Nombre          VARCHAR2(250)   NOT NULL,
    Apellido        VARCHAR2(250)   NULL,
    Rut             VARCHAR2(9)     NULL,
    Email           VARCHAR2(250)   NULL,
    Direccion       VARCHAR2(250)   NULL,
    Nombre_usuario  VARCHAR2(250)   NULL,
    Contrasena      VARCHAR2(250)   NULL,
    Telefono        NUMBER          NULL,
    Estado          NUMBER         NULL
);

CREATE TABLE Compras (
    Id_Compras          NUMBER          NOT NULL,
    Precio              NUMBER          NOT NULL,
    Cantidad            NUMBER          NULL,
    Forma_de_pago       VARCHAR2(10)    NULL,
    Envio               VARCHAR2(10)    NULL,
    Usuarios_Id_Usuario NUMBER          NOT NULL
);

CREATE TABLE Det_compras (
    Id_Det_compras       NUMBER          NOT NULL,
    Compras_Id_Compra    NUMBER          NOT NULL
);

CREATE TABLE Productos (
    Id_Productos                NUMBER          NOT NULL,
    Valor                       NUMBER          NULL,
    Stock                       NUMBER          NULL,
    Tipo                        VARCHAR2(10)    NULL,
    Servicios                   VARCHAR2(10)    NULL,
    Det_compras_Id_Det_compra   NUMBER          NOT NULL
);

CREATE TABLE Tipo_productos (
    Id_Tipo                 NUMBER          NOT NULL,
    Interior                VARCHAR2(250)   NULL,
    Exterior                VARCHAR2(250)   NULL,
    Sustratos               VARCHAR2(250)   NULL,
    Productos_Id_Producto   NUMBER          NOT NULL
);

CREATE TABLE Servicios (
    Id_Servicios                NUMBER          NOT NULL,
    Jardineria                  VARCHAR2(250)   NULL,
    Asesorias                   VARCHAR2(250)   NULL,
    Det_compras_Id_Det_compra   NUMBER          NOT NULL
);

--Claves Primarias--
ALTER TABLE Usuarios ADD CONSTRAINT Usuarios_PK PRIMARY KEY (Id_Usuarios);
ALTER TABLE Compras ADD CONSTRAINT Compras_PK PRIMARY KEY (Id_Compras);
ALTER TABLE Det_compras ADD CONSTRAINT Det_compras_PK PRIMARY KEY (Id_Det_compras);
ALTER TABLE Productos ADD CONSTRAINT Productos_PK PRIMARY KEY (Id_Productos);
ALTER TABLE Tipo_productos ADD CONSTRAINT Tipo_productos_PK PRIMARY KEY (Id_Tipo);
ALTER TABLE Servicios ADD CONSTRAINT Servicios_PK PRIMARY KEY (Id_Servicios);

--Claves Foraneas--
ALTER TABLE Compras ADD CONSTRAINT Compras_Usuarios_FK FOREIGN KEY (Usuarios_Id_Usuario) REFERENCES Usuarios (Id_Usuarios);
ALTER TABLE Det_compras ADD CONSTRAINT Det_compras_Compras_FK FOREIGN KEY (Compras_Id_Compra) REFERENCES Compras (Id_Compras);
ALTER TABLE Servicios ADD CONSTRAINT Servicios_Det_Compras_FK FOREIGN KEY (Det_compras_Id_Det_compra) REFERENCES Servicios (Id_Servicios);
ALTER TABLE Productos ADD CONSTRAINT Productos_Det_Compras_FK FOREIGN KEY (Det_compras_Id_Det_compra) REFERENCES Productos(Id_Productos);
ALTER TABLE Tipo_productos ADD CONSTRAINT Tipo_productos_Productos_FK FOREIGN KEY (Productos_Id_Producto) REFERENCES Tipo_productos(Id_Tipo);

--Formato Fecha--
ALTER SESSION SET NLS_DATE_FORMAT = 'DD/MM/YY';

--Insert--
INSERT INTO Usuarios VALUES (1,'Joel','Gutierrez',18085471,'jgutiale@gmail.com','pasaje 123','jgutiale','asdf123',1,1);
INSERT INTO Usuarios VALUES (2,'Cesar','Maureria',18123456,'ces.mau@gmail.com','calle 123','cesarito','qwerty',1,1);
INSERT INTO Usuarios VALUES (3,'Miguel','Rodriguez',18987654,'hola@gmail.com','avenida 123','miguelito','asdf123',1,1);
INSERT INTO Compras VALUES(1,111,1,'Debito','Envio1',1);
INSERT INTO Compras VALUES(2,112,2,'Credito','Envio2',1);
INSERT INTO Compras VALUES(3,111,1,'Debito','Envio2',1);
INSERT INTO Det_compras VALUES(1,1);
INSERT INTO Det_compras VALUES(2,1);
INSERT INTO Productos VALUES(1,1000,100,'Interio','Jardineria',1);
INSERT INTO Productos VALUES(2,2000,100,'Exterior','Asesoria',1);
INSERT INTO Tipo_productos VALUES(1,'','','',1);
INSERT INTO Tipo_productos VALUES(2,'','','',1);
INSERT INTO Servicios VALUES(1,'Jardineria','1',1);
INSERT INTO Servicios VALUES(2,'Asesorias','2',1);