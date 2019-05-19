CREATE TABLE [dbo].[Ogrenci] (
    [No]       INT        NOT NULL,
    [Password]       NCHAR (10) NOT NULL,
    [Ödeme]    DATE NOT NULL,
    CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED ([No] ASC)
);

