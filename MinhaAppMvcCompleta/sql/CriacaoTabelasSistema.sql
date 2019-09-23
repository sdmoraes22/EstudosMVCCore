CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `Fornecedores` (
    `Id` char(36) NOT NULL,
    `Nome` varchar(200) NOT NULL,
    `Documento` varchar(14) NOT NULL,
    `TipoFornecedor` int NOT NULL,
    `Ativo` bit NOT NULL,
    CONSTRAINT `PK_Fornecedores` PRIMARY KEY (`Id`)
);

CREATE TABLE `Enderecos` (
    `Id` char(36) NOT NULL,
    `FornecedorId` char(36) NOT NULL,
    `Logradouro` varchar(100) NOT NULL,
    `Numero` varchar(50) NOT NULL,
    `Complemento` varchar(250) NOT NULL,
    `Cep` varchar(8) NOT NULL,
    `Bairro` varchar(100) NOT NULL,
    `Cidade` varchar(100) NULL,
    `Estado` varchar(50) NOT NULL,
    CONSTRAINT `PK_Enderecos` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Enderecos_Fornecedores_FornecedorId` FOREIGN KEY (`FornecedorId`) REFERENCES `Fornecedores` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Produtos` (
    `Id` char(36) NOT NULL,
    `FornecedorId` char(36) NOT NULL,
    `Nome` varchar(200) NOT NULL,
    `Descricao` varchar(1000) NOT NULL,
    `Imagem` varchar(100) NOT NULL,
    `Valor` decimal(65, 30) NOT NULL,
    `DataCadastro` datetime(6) NOT NULL,
    `Ativo` bit NOT NULL,
    CONSTRAINT `PK_Produtos` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Produtos_Fornecedores_FornecedorId` FOREIGN KEY (`FornecedorId`) REFERENCES `Fornecedores` (`Id`) ON DELETE RESTRICT
);

CREATE UNIQUE INDEX `IX_Enderecos_FornecedorId` ON `Enderecos` (`FornecedorId`);

CREATE INDEX `IX_Produtos_FornecedorId` ON `Produtos` (`FornecedorId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20190910145513_Initial', '2.2.6-servicing-10079');