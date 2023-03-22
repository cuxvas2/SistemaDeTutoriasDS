
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/18/2023 23:56:36
-- Generated from EDMX file: C:\Users\Acer\source\repos\SistemaDeGestionDeTutorias\DataAccess\EntityDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SistemaDeGestionDeTutorias];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TutoriasAcademicasPeriodoEscolar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TutoriasAcademicasSet] DROP CONSTRAINT [FK_TutoriasAcademicasPeriodoEscolar];
GO
IF OBJECT_ID(N'[dbo].[FK_ProblematicaAcademicaComentariosProblematicas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ComentariosProblematicasSet] DROP CONSTRAINT [FK_ProblematicaAcademicaComentariosProblematicas];
GO
IF OBJECT_ID(N'[dbo].[FK_ProblematicaAcademicaExperienciaEducativa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProblematicaAcademicaSet] DROP CONSTRAINT [FK_ProblematicaAcademicaExperienciaEducativa];
GO
IF OBJECT_ID(N'[dbo].[FK_ProgramaEducativoEstudiante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EstudianteSet] DROP CONSTRAINT [FK_ProgramaEducativoEstudiante];
GO
IF OBJECT_ID(N'[dbo].[FK_TutoriasAcademicasProblematicaAcademica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProblematicaAcademicaSet] DROP CONSTRAINT [FK_TutoriasAcademicasProblematicaAcademica];
GO
IF OBJECT_ID(N'[dbo].[FK_PeriodoEscolarProgramaEducativo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProgramaEducativoSet] DROP CONSTRAINT [FK_PeriodoEscolarProgramaEducativo];
GO
IF OBJECT_ID(N'[dbo].[FK_TutoriasAcademicasAsistencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AsistenciaSet] DROP CONSTRAINT [FK_TutoriasAcademicasAsistencia];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfesorEstudiante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EstudianteSet] DROP CONSTRAINT [FK_ProfesorEstudiante];
GO
IF OBJECT_ID(N'[dbo].[FK_ProgramaEducativoExperienciaEducativa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExperienciaEducativaSet] DROP CONSTRAINT [FK_ProgramaEducativoExperienciaEducativa];
GO
IF OBJECT_ID(N'[dbo].[FK_AsistenciaEstudiante_Asistencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AsistenciaEstudiante] DROP CONSTRAINT [FK_AsistenciaEstudiante_Asistencia];
GO
IF OBJECT_ID(N'[dbo].[FK_AsistenciaEstudiante_Estudiante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AsistenciaEstudiante] DROP CONSTRAINT [FK_AsistenciaEstudiante_Estudiante];
GO
IF OBJECT_ID(N'[dbo].[FK_ExperienciaEducativaProfesor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExperienciaEducativaSet] DROP CONSTRAINT [FK_ExperienciaEducativaProfesor];
GO
IF OBJECT_ID(N'[dbo].[FK_ProgramaEducativoProfesor_ProgramaEducativo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProgramaEducativoProfesor] DROP CONSTRAINT [FK_ProgramaEducativoProfesor_ProgramaEducativo];
GO
IF OBJECT_ID(N'[dbo].[FK_ProgramaEducativoProfesor_Profesor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProgramaEducativoProfesor] DROP CONSTRAINT [FK_ProgramaEducativoProfesor_Profesor];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[EstudianteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstudianteSet];
GO
IF OBJECT_ID(N'[dbo].[ProfesorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProfesorSet];
GO
IF OBJECT_ID(N'[dbo].[ExperienciaEducativaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExperienciaEducativaSet];
GO
IF OBJECT_ID(N'[dbo].[ProblematicaAcademicaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProblematicaAcademicaSet];
GO
IF OBJECT_ID(N'[dbo].[ComentariosProblematicasSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ComentariosProblematicasSet];
GO
IF OBJECT_ID(N'[dbo].[TutoriasAcademicasSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TutoriasAcademicasSet];
GO
IF OBJECT_ID(N'[dbo].[PeriodoEscolarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PeriodoEscolarSet];
GO
IF OBJECT_ID(N'[dbo].[AsistenciaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AsistenciaSet];
GO
IF OBJECT_ID(N'[dbo].[ProgramaEducativoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProgramaEducativoSet];
GO
IF OBJECT_ID(N'[dbo].[AdministradorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdministradorSet];
GO
IF OBJECT_ID(N'[dbo].[AsistenciaEstudiante]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AsistenciaEstudiante];
GO
IF OBJECT_ID(N'[dbo].[ProgramaEducativoProfesor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProgramaEducativoProfesor];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'EstudianteSet'
CREATE TABLE [dbo].[EstudianteSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Matricula] nvarchar(max)  NOT NULL,
    [Nombres] nvarchar(max)  NOT NULL,
    [ApellidoPaterno] nvarchar(max)  NOT NULL,
    [ApellidoMaterno] nvarchar(max)  NOT NULL,
    [CorreoPersonal] nvarchar(max)  NOT NULL,
    [CorreoInstitucional] nvarchar(max)  NOT NULL,
    [ProgramaEducativo_Id] int  NOT NULL,
    [Tutor_Id] int  NOT NULL
);
GO

-- Creating table 'ProfesorSet'
CREATE TABLE [dbo].[ProfesorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NumeroDePersonal] nvarchar(max)  NOT NULL,
    [Nombres] nvarchar(max)  NOT NULL,
    [ApellidoPaterno] nvarchar(max)  NOT NULL,
    [ApellidoMaterno] nvarchar(max)  NOT NULL,
    [CorreoPersonal] nvarchar(max)  NOT NULL,
    [CorreoInstitucional] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [EsTutor] nvarchar(max)  NOT NULL,
    [EsCoordinador] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ExperienciaEducativaSet'
CREATE TABLE [dbo].[ExperienciaEducativaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nrc] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [ProgramaEducativo_Id] int  NOT NULL,
    [Profesor_Id] int  NOT NULL
);
GO

-- Creating table 'ProblematicaAcademicaSet'
CREATE TABLE [dbo].[ProblematicaAcademicaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titulo] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [NumeroIncidencias] smallint  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [ExperienciaEducativa_Id] int  NOT NULL,
    [TutoriasAcademicas_Id] int  NOT NULL
);
GO

-- Creating table 'ComentariosProblematicasSet'
CREATE TABLE [dbo].[ComentariosProblematicasSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [ProblematicaAcademica_Id] int  NOT NULL
);
GO

-- Creating table 'TutoriasAcademicasSet'
CREATE TABLE [dbo].[TutoriasAcademicasSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NumeroDeSesion] smallint  NOT NULL,
    [FechaInicio] datetime  NOT NULL,
    [FechaTermino] datetime  NOT NULL,
    [FechaEntrega] datetime  NOT NULL,
    [PeriodoEscolar_Id] int  NOT NULL
);
GO

-- Creating table 'PeriodoEscolarSet'
CREATE TABLE [dbo].[PeriodoEscolarSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FechaInicio] datetime  NOT NULL,
    [FechaTermino] datetime  NOT NULL
);
GO

-- Creating table 'AsistenciaSet'
CREATE TABLE [dbo].[AsistenciaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Presente] bit  NOT NULL,
    [TutoriasAcademicas_Id] int  NOT NULL
);
GO

-- Creating table 'ProgramaEducativoSet'
CREATE TABLE [dbo].[ProgramaEducativoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [PeriodoEscolar_Id] int  NOT NULL
);
GO

-- Creating table 'AdministradorSet'
CREATE TABLE [dbo].[AdministradorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Usuario] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AsistenciaEstudiante'
CREATE TABLE [dbo].[AsistenciaEstudiante] (
    [Asistencia_Id] int  NOT NULL,
    [Estudiante_Id] int  NOT NULL
);
GO

-- Creating table 'ProgramaEducativoProfesor'
CREATE TABLE [dbo].[ProgramaEducativoProfesor] (
    [ProgramaEducativo_Id] int  NOT NULL,
    [Profesor_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'EstudianteSet'
ALTER TABLE [dbo].[EstudianteSet]
ADD CONSTRAINT [PK_EstudianteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProfesorSet'
ALTER TABLE [dbo].[ProfesorSet]
ADD CONSTRAINT [PK_ProfesorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ExperienciaEducativaSet'
ALTER TABLE [dbo].[ExperienciaEducativaSet]
ADD CONSTRAINT [PK_ExperienciaEducativaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProblematicaAcademicaSet'
ALTER TABLE [dbo].[ProblematicaAcademicaSet]
ADD CONSTRAINT [PK_ProblematicaAcademicaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ComentariosProblematicasSet'
ALTER TABLE [dbo].[ComentariosProblematicasSet]
ADD CONSTRAINT [PK_ComentariosProblematicasSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TutoriasAcademicasSet'
ALTER TABLE [dbo].[TutoriasAcademicasSet]
ADD CONSTRAINT [PK_TutoriasAcademicasSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PeriodoEscolarSet'
ALTER TABLE [dbo].[PeriodoEscolarSet]
ADD CONSTRAINT [PK_PeriodoEscolarSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AsistenciaSet'
ALTER TABLE [dbo].[AsistenciaSet]
ADD CONSTRAINT [PK_AsistenciaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProgramaEducativoSet'
ALTER TABLE [dbo].[ProgramaEducativoSet]
ADD CONSTRAINT [PK_ProgramaEducativoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AdministradorSet'
ALTER TABLE [dbo].[AdministradorSet]
ADD CONSTRAINT [PK_AdministradorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Asistencia_Id], [Estudiante_Id] in table 'AsistenciaEstudiante'
ALTER TABLE [dbo].[AsistenciaEstudiante]
ADD CONSTRAINT [PK_AsistenciaEstudiante]
    PRIMARY KEY CLUSTERED ([Asistencia_Id], [Estudiante_Id] ASC);
GO

-- Creating primary key on [ProgramaEducativo_Id], [Profesor_Id] in table 'ProgramaEducativoProfesor'
ALTER TABLE [dbo].[ProgramaEducativoProfesor]
ADD CONSTRAINT [PK_ProgramaEducativoProfesor]
    PRIMARY KEY CLUSTERED ([ProgramaEducativo_Id], [Profesor_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PeriodoEscolar_Id] in table 'TutoriasAcademicasSet'
ALTER TABLE [dbo].[TutoriasAcademicasSet]
ADD CONSTRAINT [FK_TutoriasAcademicasPeriodoEscolar]
    FOREIGN KEY ([PeriodoEscolar_Id])
    REFERENCES [dbo].[PeriodoEscolarSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TutoriasAcademicasPeriodoEscolar'
CREATE INDEX [IX_FK_TutoriasAcademicasPeriodoEscolar]
ON [dbo].[TutoriasAcademicasSet]
    ([PeriodoEscolar_Id]);
GO

-- Creating foreign key on [ProblematicaAcademica_Id] in table 'ComentariosProblematicasSet'
ALTER TABLE [dbo].[ComentariosProblematicasSet]
ADD CONSTRAINT [FK_ProblematicaAcademicaComentariosProblematicas]
    FOREIGN KEY ([ProblematicaAcademica_Id])
    REFERENCES [dbo].[ProblematicaAcademicaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProblematicaAcademicaComentariosProblematicas'
CREATE INDEX [IX_FK_ProblematicaAcademicaComentariosProblematicas]
ON [dbo].[ComentariosProblematicasSet]
    ([ProblematicaAcademica_Id]);
GO

-- Creating foreign key on [ExperienciaEducativa_Id] in table 'ProblematicaAcademicaSet'
ALTER TABLE [dbo].[ProblematicaAcademicaSet]
ADD CONSTRAINT [FK_ProblematicaAcademicaExperienciaEducativa]
    FOREIGN KEY ([ExperienciaEducativa_Id])
    REFERENCES [dbo].[ExperienciaEducativaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProblematicaAcademicaExperienciaEducativa'
CREATE INDEX [IX_FK_ProblematicaAcademicaExperienciaEducativa]
ON [dbo].[ProblematicaAcademicaSet]
    ([ExperienciaEducativa_Id]);
GO

-- Creating foreign key on [ProgramaEducativo_Id] in table 'EstudianteSet'
ALTER TABLE [dbo].[EstudianteSet]
ADD CONSTRAINT [FK_ProgramaEducativoEstudiante]
    FOREIGN KEY ([ProgramaEducativo_Id])
    REFERENCES [dbo].[ProgramaEducativoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProgramaEducativoEstudiante'
CREATE INDEX [IX_FK_ProgramaEducativoEstudiante]
ON [dbo].[EstudianteSet]
    ([ProgramaEducativo_Id]);
GO

-- Creating foreign key on [TutoriasAcademicas_Id] in table 'ProblematicaAcademicaSet'
ALTER TABLE [dbo].[ProblematicaAcademicaSet]
ADD CONSTRAINT [FK_TutoriasAcademicasProblematicaAcademica]
    FOREIGN KEY ([TutoriasAcademicas_Id])
    REFERENCES [dbo].[TutoriasAcademicasSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TutoriasAcademicasProblematicaAcademica'
CREATE INDEX [IX_FK_TutoriasAcademicasProblematicaAcademica]
ON [dbo].[ProblematicaAcademicaSet]
    ([TutoriasAcademicas_Id]);
GO

-- Creating foreign key on [PeriodoEscolar_Id] in table 'ProgramaEducativoSet'
ALTER TABLE [dbo].[ProgramaEducativoSet]
ADD CONSTRAINT [FK_PeriodoEscolarProgramaEducativo]
    FOREIGN KEY ([PeriodoEscolar_Id])
    REFERENCES [dbo].[PeriodoEscolarSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PeriodoEscolarProgramaEducativo'
CREATE INDEX [IX_FK_PeriodoEscolarProgramaEducativo]
ON [dbo].[ProgramaEducativoSet]
    ([PeriodoEscolar_Id]);
GO

-- Creating foreign key on [TutoriasAcademicas_Id] in table 'AsistenciaSet'
ALTER TABLE [dbo].[AsistenciaSet]
ADD CONSTRAINT [FK_TutoriasAcademicasAsistencia]
    FOREIGN KEY ([TutoriasAcademicas_Id])
    REFERENCES [dbo].[TutoriasAcademicasSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TutoriasAcademicasAsistencia'
CREATE INDEX [IX_FK_TutoriasAcademicasAsistencia]
ON [dbo].[AsistenciaSet]
    ([TutoriasAcademicas_Id]);
GO

-- Creating foreign key on [Tutor_Id] in table 'EstudianteSet'
ALTER TABLE [dbo].[EstudianteSet]
ADD CONSTRAINT [FK_ProfesorEstudiante]
    FOREIGN KEY ([Tutor_Id])
    REFERENCES [dbo].[ProfesorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfesorEstudiante'
CREATE INDEX [IX_FK_ProfesorEstudiante]
ON [dbo].[EstudianteSet]
    ([Tutor_Id]);
GO

-- Creating foreign key on [ProgramaEducativo_Id] in table 'ExperienciaEducativaSet'
ALTER TABLE [dbo].[ExperienciaEducativaSet]
ADD CONSTRAINT [FK_ProgramaEducativoExperienciaEducativa]
    FOREIGN KEY ([ProgramaEducativo_Id])
    REFERENCES [dbo].[ProgramaEducativoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProgramaEducativoExperienciaEducativa'
CREATE INDEX [IX_FK_ProgramaEducativoExperienciaEducativa]
ON [dbo].[ExperienciaEducativaSet]
    ([ProgramaEducativo_Id]);
GO

-- Creating foreign key on [Asistencia_Id] in table 'AsistenciaEstudiante'
ALTER TABLE [dbo].[AsistenciaEstudiante]
ADD CONSTRAINT [FK_AsistenciaEstudiante_Asistencia]
    FOREIGN KEY ([Asistencia_Id])
    REFERENCES [dbo].[AsistenciaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Estudiante_Id] in table 'AsistenciaEstudiante'
ALTER TABLE [dbo].[AsistenciaEstudiante]
ADD CONSTRAINT [FK_AsistenciaEstudiante_Estudiante]
    FOREIGN KEY ([Estudiante_Id])
    REFERENCES [dbo].[EstudianteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AsistenciaEstudiante_Estudiante'
CREATE INDEX [IX_FK_AsistenciaEstudiante_Estudiante]
ON [dbo].[AsistenciaEstudiante]
    ([Estudiante_Id]);
GO

-- Creating foreign key on [Profesor_Id] in table 'ExperienciaEducativaSet'
ALTER TABLE [dbo].[ExperienciaEducativaSet]
ADD CONSTRAINT [FK_ExperienciaEducativaProfesor]
    FOREIGN KEY ([Profesor_Id])
    REFERENCES [dbo].[ProfesorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExperienciaEducativaProfesor'
CREATE INDEX [IX_FK_ExperienciaEducativaProfesor]
ON [dbo].[ExperienciaEducativaSet]
    ([Profesor_Id]);
GO

-- Creating foreign key on [ProgramaEducativo_Id] in table 'ProgramaEducativoProfesor'
ALTER TABLE [dbo].[ProgramaEducativoProfesor]
ADD CONSTRAINT [FK_ProgramaEducativoProfesor_ProgramaEducativo]
    FOREIGN KEY ([ProgramaEducativo_Id])
    REFERENCES [dbo].[ProgramaEducativoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Profesor_Id] in table 'ProgramaEducativoProfesor'
ALTER TABLE [dbo].[ProgramaEducativoProfesor]
ADD CONSTRAINT [FK_ProgramaEducativoProfesor_Profesor]
    FOREIGN KEY ([Profesor_Id])
    REFERENCES [dbo].[ProfesorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProgramaEducativoProfesor_Profesor'
CREATE INDEX [IX_FK_ProgramaEducativoProfesor_Profesor]
ON [dbo].[ProgramaEducativoProfesor]
    ([Profesor_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------