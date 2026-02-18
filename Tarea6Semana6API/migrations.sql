CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

START TRANSACTION;
INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20260218021046_inicial', '10.0.3');

CREATE TABLE `Usuarios` (
    `id` int NOT NULL AUTO_INCREMENT,
    `Nombres` longtext NOT NULL,
    `Email` longtext NOT NULL,
    `Contrasenia` longtext NOT NULL,
    PRIMARY KEY (`id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20260218025536_NuevaMigracion', '10.0.3');

COMMIT;

