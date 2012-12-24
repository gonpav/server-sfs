



-- -----------------------------------------------------------
-- Entity Designer DDL Script for MySQL Server 4.1 and higher
-- -----------------------------------------------------------
-- Date Created: 12/24/2012 16:33:55
-- Generated from EDMX file: C:\dev\server-sfs\PilotProject\PilotProject\SmartFlowSheet.edmx
-- Target version: 3.0.0.0
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------

--    ALTER TABLE `FlowsheetSet` DROP CONSTRAINT `FK_FlowsheetMedic`;

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------
SET foreign_key_checks = 0;
    DROP TABLE IF EXISTS `FlowsheetSet`;
    DROP TABLE IF EXISTS `MedicSet`;
SET foreign_key_checks = 1;

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Flowsheets'

CREATE TABLE `Flowsheets` (
    `Id` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `date` varchar(1000)  NOT NULL,
    `durationHours` varchar(1000)  NOT NULL,
    `startHour` varchar(1000)  NOT NULL,
    `MedicId` int  NOT NULL
);

-- Creating table 'Medics'

CREATE TABLE `Medics` (
    `Id` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `firstName` varchar(1000)  NOT NULL,
    `lastName` varchar(1000)  NOT NULL
);



-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------



-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on `MedicId` in table 'Flowsheets'

ALTER TABLE `Flowsheets`
ADD CONSTRAINT `FK_FlowsheetMedic`
    FOREIGN KEY (`MedicId`)
    REFERENCES `Medics`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FlowsheetMedic'

CREATE INDEX `IX_FK_FlowsheetMedic` 
    ON `Flowsheets`
    (`MedicId`);

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
