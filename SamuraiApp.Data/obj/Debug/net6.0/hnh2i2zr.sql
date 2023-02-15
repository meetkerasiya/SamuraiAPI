IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Samurais] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Samurais] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Quotes] (
    [Id] int NOT NULL IDENTITY,
    [Text] nvarchar(max) NOT NULL,
    [SamuraiId] int NOT NULL,
    CONSTRAINT [PK_Quotes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Quotes_Samurais_SamuraiId] FOREIGN KEY ([SamuraiId]) REFERENCES [Samurais] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Quotes_SamuraiId] ON [Quotes] ([SamuraiId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230213065713_init', N'7.0.2');
GO

COMMIT;
GO

