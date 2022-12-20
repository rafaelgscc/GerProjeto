/*------------------------------------------------------------*/
/*   Esquema para a criação do banco de dados da aplicação    */
/*                        DBGERPROJETO                        */
/*------------------------------------------------------------*/

/*------------------------------------------------------------*/
/*                     Exclusão de Triggers                   */
/*------------------------------------------------------------*/

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('FK_TB_ITENS_PROJETO1') AND sysstat & 0xf = 11)
ALTER TABLE [TB_PROCESSOS]
DROP CONSTRAINT [FK_TB_ITENS_PROJETO1]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_LOGIN_GROUP_RULE') AND sysstat & 0xf = 11)
ALTER TABLE [TB_LOGIN_RULE]
DROP CONSTRAINT [TB_LOGIN_GROUP_RULE]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_LOGIN_GROUP_USER') AND sysstat & 0xf = 11)
ALTER TABLE [TB_LOGIN_USER]
DROP CONSTRAINT [TB_LOGIN_GROUP_USER]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('FK_TB_PROCESSOS') AND sysstat & 0xf = 11)
ALTER TABLE [TB_HIST_EXECUCAO_ATIVIDADE]
DROP CONSTRAINT [FK_TB_PROCESSOS]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('FK_TB_PROJETO') AND sysstat & 0xf = 11)
ALTER TABLE [TB_ITENS_PROJETO]
DROP CONSTRAINT [FK_TB_PROJETO]
GO

/*------------------------------------------------------------*/
/*                     Exclusão de Views                      */
/*------------------------------------------------------------*/

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('VW_HISTORICO_ATIVIDADE') AND sysstat & 0xf = 2)
DROP VIEW [VW_HISTORICO_ATIVIDADE]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('VW_PROJETO_ACAO') AND sysstat & 0xf = 2)
DROP VIEW [VW_PROJETO_ACAO]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('VW_PROJETO_GRAFICO') AND sysstat & 0xf = 2)
DROP VIEW [VW_PROJETO_GRAFICO]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('VW_RELATORIO_COMPLETO') AND sysstat & 0xf = 2)
DROP VIEW [VW_RELATORIO_COMPLETO]
GO

/*------------------------------------------------------------*/
/*                     Exclusão de tabelas                    */
/*------------------------------------------------------------*/

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_CAD_PREVIO') AND sysstat & 0xf = 3)
DROP TABLE [TB_CAD_PREVIO]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_COORDENACAO') AND sysstat & 0xf = 3)
DROP TABLE [TB_COORDENACAO]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_DIRETORIA') AND sysstat & 0xf = 3)
DROP TABLE [TB_DIRETORIA]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_HIST_EXECUCAO_ATIVIDADE') AND sysstat & 0xf = 3)
DROP TABLE [TB_HIST_EXECUCAO_ATIVIDADE]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_ITENS_PROJETO') AND sysstat & 0xf = 3)
DROP TABLE [TB_ITENS_PROJETO]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_LOG') AND sysstat & 0xf = 3)
DROP TABLE [TB_LOG]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_LOGIN_GROUP') AND sysstat & 0xf = 3)
DROP TABLE [TB_LOGIN_GROUP]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_LOGIN_RULE') AND sysstat & 0xf = 3)
DROP TABLE [TB_LOGIN_RULE]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_LOGIN_USER') AND sysstat & 0xf = 3)
DROP TABLE [TB_LOGIN_USER]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_PARAMETRO') AND sysstat & 0xf = 3)
DROP TABLE [TB_PARAMETRO]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_PROCESSOS') AND sysstat & 0xf = 3)
DROP TABLE [TB_PROCESSOS]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_PROJETO') AND sysstat & 0xf = 3)
DROP TABLE [TB_PROJETO]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_RESPONSAVEL') AND sysstat & 0xf = 3)
DROP TABLE [TB_RESPONSAVEL]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_SETORIAL') AND sysstat & 0xf = 3)
DROP TABLE [TB_SETORIAL]
GO

/*------------------------------------------------------------*/
/*                     Criação das tabelas                    */
/*------------------------------------------------------------*/

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*      TB_CAD_PREVIO      */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_CAD_PREVIO](
	[LOGIN_GROUP_NAME]                     varchar (60)         NOT NULL,
	[LOGIN_USER_NAME]                      varchar (60)         NOT NULL,
	[LOGIN_USER_LOGIN]                     varchar (40)         NOT NULL,
	[LOGIN_USER_EMAIL]                     varchar (60)         NULL,
	[LOGIN_USER_PHONE]                     varchar (15)         NULL,
	[LOGIN_USER_OBS]                       text                 NOT NULL
		CONSTRAINT [PK_TB_CAD_PREVIO] PRIMARY KEY CLUSTERED
		(
			[LOGIN_USER_LOGIN]
		) WITH FILLFACTOR = 90
)
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*       TB_COORDENACAO       */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_COORDENACAO](
	[codigo]                               bigint               IDENTITY(1,1) NOT NULL,
	[siglaDiretoria]                       varchar (10)         NOT NULL,
	[siglaCoordenacao]                     varchar (10)         NOT NULL,
	[nomeCoordenacao]                      varchar (100)        NOT NULL,
	[nomeCoordenador]                      varchar (100)        NULL,
	[usuarioCadastro]                      varchar (50)         NOT NULL,
	[dataCadastro]                         date                 NOT NULL
		CONSTRAINT [PK_TB_COORDENACAO] PRIMARY KEY CLUSTERED
		(
			[codigo]
		) WITH FILLFACTOR = 90
)
GO

 CREATE UNIQUE INDEX [NK_TB_COORDENACAO1] ON [TB_COORDENACAO]
	([siglaDiretoria],[siglaCoordenacao])
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*      TB_DIRETORIA      */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_DIRETORIA](
	[codigo]                               bigint               IDENTITY(1,1) NOT NULL,
	[siglaDiretoria]                       varchar (10)         NULL,
	[nomeDiretoria]                        varchar (100)        NOT NULL,
	[nomeDiretor]                          varchar (100)        NULL,
	[usuarioCadastro]                      varchar (50)         NOT NULL,
	[dataCadastro]                         date                 NOT NULL
		CONSTRAINT [PK_TB_DIRETORIA] PRIMARY KEY CLUSTERED
		(
			[codigo]
		) WITH FILLFACTOR = 90
)
GO

 CREATE UNIQUE INDEX [NK_TB_DIRETORIA1] ON [TB_DIRETORIA]
	([siglaDiretoria])
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*             TB_HIST_EXECUCAO_ATIVIDADE             */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_HIST_EXECUCAO_ATIVIDADE](
	[projeto]                              bigint               DEFAULT 0 NOT NULL,
	[itemProjeto]                          int                  DEFAULT 1 NOT NULL,
	[itemProcesso]                         int                  DEFAULT 1 NOT NULL,
	[dataLancamento]                       date                 NOT NULL,
	[justificativa]                        smallint             DEFAULT 0 NOT NULL,
	[percentualExecutado]                  decimal (5,2)        DEFAULT 0 NULL,
	[observacao]                           text                 NULL,
	[usuarioCadastro]                      varchar (50)         NOT NULL,
	[dataCadastro]                         date                 NOT NULL
		CONSTRAINT [PK_TB_HIST_EXECUCAO_ATIVIDADE] PRIMARY KEY CLUSTERED
		(
			[projeto],[itemProjeto],[itemProcesso],[dataLancamento],[justificativa]
		) WITH FILLFACTOR = 90
)
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*        TB_ITENS_PROJETO        */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_ITENS_PROJETO](
	[projeto]                              bigint               DEFAULT 0 NOT NULL,
	[itemProjeto]                          int                  DEFAULT 1 NOT NULL,
	[nomeAcao]                             varchar (255)        NOT NULL,
	[inicioPrevisto]                       date                 NULL,
	[terminoPrevisto]                      date                 NULL,
	[terminoRealizado]                     date                 NULL,
	[nomeSobrenome]                        varchar (50)         NOT NULL,
	[responsavelSubstituto]                varchar (50)         NULL,
	[observacao]                           text                 NULL,
	[usuarioCadastro]                      varchar (50)         NOT NULL,
	[dataCadastro]                         date                 NOT NULL,
	[siglaCoordenacao]                     varchar (10)         NOT NULL,
	[siglaSetorial]                        varchar (10)         NULL,
	[percentualExecutado]                  decimal (5,2)        DEFAULT 0 NULL,
	[statusAcao]                           varchar (15)         NULL,
	[inicioRealizado]                      date                 NULL,
	[custoAcao]                            decimal (13,2)       DEFAULT 0 NULL,
	[DiasPrevistos]                        smallint             DEFAULT 0 NULL,
	[DiasRealizados]                       smallint             DEFAULT 0 NULL,
	[situacao]                             varchar (20)         DEFAULT 'A INICIAR' NULL
		CONSTRAINT [PK_TB_ITENS_PROJETO] PRIMARY KEY CLUSTERED
		(
			[projeto],[itemProjeto]
		) WITH FILLFACTOR = 90
)
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*   TB_LOG   */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_LOG](
	[id]                                   bigint               IDENTITY(1,1) NOT NULL,
	[dataLog]                              datetime             NOT NULL,
	[modulo]                               varchar (50)         NOT NULL,
	[operacao]                             varchar (20)         NOT NULL,
	[observacao]                           text                 NOT NULL,
	[usuarioCadastro]                      varchar (50)         NOT NULL,
	[siglaCoordenacao]                     varchar (10)         NOT NULL
		CONSTRAINT [PK_TB_LOG] PRIMARY KEY CLUSTERED
		(
			[id]
		) WITH FILLFACTOR = 90
)
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*       TB_LOGIN_GROUP       */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_LOGIN_GROUP](
	[LOGIN_GROUP_NAME]                     varchar (60)         NOT NULL,
	[LOGIN_GROUP_IS_ADMIN]                 bit                  NOT NULL
		CONSTRAINT [LOGIN_GROUP_PK] PRIMARY KEY CLUSTERED
		(
			[LOGIN_GROUP_NAME]
		) WITH FILLFACTOR = 90
)
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*      TB_LOGIN_RULE      */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_LOGIN_RULE](
	[LOGIN_RULE_PROJECT]                   varchar (8)          NOT NULL,
	[LOGIN_GROUP_NAME]                     varchar (60)         NOT NULL,
	[LOGIN_RULE_OBJECT]                    varchar (100)        NOT NULL,
	[LOGIN_RULE_PERMISSIONS]               varchar (100)        NOT NULL
		CONSTRAINT [LOGIN_RULE_PK] PRIMARY KEY CLUSTERED
		(
			[LOGIN_RULE_PROJECT],[LOGIN_GROUP_NAME],[LOGIN_RULE_OBJECT]
		) WITH FILLFACTOR = 90
)
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*      TB_LOGIN_USER      */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_LOGIN_USER](
	[LOGIN_GROUP_NAME]                     varchar (60)         NOT NULL,
	[LOGIN_USER_LOGIN]                     varchar (40)         NOT NULL,
	[LOGIN_USER_PASSWORD]                  varchar (40)         NOT NULL,
	[LOGIN_USER_NAME]                      varchar (60)         NOT NULL,
	[LOGIN_USER_OBS]                       text                 NOT NULL,
	[LOGIN_USER_EMAIL]                     varchar (60)         NULL,
	[LOGIN_USER_PHONE]                     varchar (15)         NULL,
	[LOGIN_USER_COORDENACAO]               varchar (10)         NULL
		CONSTRAINT [LOGIN_USER_PK] PRIMARY KEY CLUSTERED
		(
			[LOGIN_USER_LOGIN]
		) WITH FILLFACTOR = 90
)
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*      TB_PARAMETRO      */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_PARAMETRO](
	[HDEmail]                              varchar (40)         NULL,
	[HDNome]                               varchar (40)         NULL,
	[HDPorta]                              int                  DEFAULT 0 NULL,
	[HDSMTP]                               varchar (40)         NULL,
	[HDSSL]                                varchar (40)         NULL,
	[HDExpiraSenha]                        smallint             DEFAULT 0 NULL,
	[HD_Atualizacao]                       datetime             NULL
)
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*      TB_PROCESSOS      */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_PROCESSOS](
	[projeto]                              bigint               DEFAULT 0 NOT NULL,
	[itemProjeto]                          int                  DEFAULT 1 NOT NULL,
	[itemProcesso]                         int                  DEFAULT 1 NOT NULL,
	[nomeProcesso]                         varchar (255)        NOT NULL,
	[inicioPrevisto]                       date                 NULL,
	[inicioRealizado]                      date                 NULL,
	[terminoPrevisto]                      date                 NULL,
	[terminoRealizado]                     date                 NULL,
	[siglaCoordenacao]                     varchar (10)         NOT NULL,
	[siglaSetorial]                        varchar (10)         NULL,
	[DiasPrevistos]                        smallint             DEFAULT 0 NULL,
	[DiasRealizados]                       smallint             DEFAULT 0 NULL,
	[nomeSobrenome]                        varchar (50)         NOT NULL,
	[responsavelSubstituto]                varchar (50)         NULL,
	[dataCadastro]                         date                 NOT NULL,
	[usuarioCadastro]                      varchar (50)         NOT NULL,
	[percentualExecutado]                  decimal (5,2)        DEFAULT 0 NULL,
	[situacao]                             varchar (20)         DEFAULT 'A INICIAR' NULL,
	[situacaoProjeto]                      varchar (14)         NULL
		CONSTRAINT [PK_TB_PROCESSOS] PRIMARY KEY CLUSTERED
		(
			[projeto],[itemProjeto],[itemProcesso]
		) WITH FILLFACTOR = 90
)
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*     TB_PROJETO     */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_PROJETO](
	[codigo]                               bigint               IDENTITY(1,1) NOT NULL,
	[nomeProjeto]                          varchar (255)        NOT NULL,
	[Diretriz]                             varchar (3)          NOT NULL,
	[statusProjeto]                        varchar (10)         NOT NULL,
	[usuarioCadastro]                      varchar (50)         NOT NULL,
	[dataCadastro]                         date                 NOT NULL,
	[terminoRealizado]                     date                 NULL,
	[DiasDeProjeto]                        bigint               DEFAULT 0 NULL,
	[percentualExecutado]                  decimal (5,2)        DEFAULT 0 NULL,
	[inicioPrevisto]                       date                 NULL,
	[terminoPrevisto]                      date                 NULL,
	[custoProjeto]                         decimal (13,2)       DEFAULT 0 NULL,
	[nivelProjeto]                         varchar (1)          NOT NULL,
	[siglaDiretoria]                       varchar (10)         NOT NULL,
	[siglaCoordenacao]                     varchar (10)         NOT NULL,
	[siglaSetorial]                        varchar (10)         NULL,
	[situacao]                             varchar (20)         DEFAULT 'A INICIAR' NULL,
	[anoProjeto]                           smallint             DEFAULT 0 NULL
		CONSTRAINT [PK_TB_PROJETO] PRIMARY KEY CLUSTERED
		(
			[codigo]
		) WITH FILLFACTOR = 90
)
GO

 CREATE UNIQUE INDEX [NK_TB_PROJETO1] ON [TB_PROJETO]
	([nomeProjeto])
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*       TB_RESPONSAVEL       */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_RESPONSAVEL](
	[codigo]                               bigint               IDENTITY(1,1) NOT NULL,
	[nomeResponsavel]                      varchar (100)        NOT NULL,
	[nomeSobrenome]                        varchar (50)         NOT NULL,
	[ramalResponsavel]                     varchar (10)         NULL,
	[contatoResponsavel]                   varchar (15)         NULL,
	[salaResponsavel]                      varchar (10)         NULL,
	[usuarioCadastro]                      varchar (50)         NOT NULL,
	[dataCadastro]                         date                 NOT NULL,
	[siglaDiretoria]                       varchar (10)         NOT NULL,
	[siglaCoordenacao]                     varchar (10)         NULL,
	[siglaSetorial]                        varchar (10)         NULL
		CONSTRAINT [PK_TB_RESPONSAVEL] PRIMARY KEY CLUSTERED
		(
			[codigo]
		) WITH FILLFACTOR = 90
)
GO

 CREATE INDEX [NK_TB_RESPONSAVEL1] ON [TB_RESPONSAVEL]
	([nomeResponsavel])
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*     TB_SETORIAL     */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_SETORIAL](
	[codigo]                               bigint               IDENTITY(1,1) NOT NULL,
	[siglaDiretoria]                       varchar (10)         NOT NULL,
	[siglaCoordenacao]                     varchar (10)         NOT NULL,
	[siglaSetorial]                        varchar (10)         NOT NULL,
	[nomeSetorial]                         varchar (100)        NOT NULL,
	[usuarioCadastro]                      varchar (50)         NOT NULL,
	[dataCadastro]                         date                 NOT NULL
		CONSTRAINT [PK_TB_SETORIAL] PRIMARY KEY CLUSTERED
		(
			[codigo]
		) WITH FILLFACTOR = 90
)
GO

 CREATE UNIQUE INDEX [NK_TB_SETORIAL1] ON [TB_SETORIAL]
	([siglaDiretoria],[siglaCoordenacao],[siglaSetorial])
GO

/*------------------------------------------------------------*/
/*                      Criação de VIEW                      */
/*       VW_PROJETO_ACAO       */
/*------------------------------------------------------------*/

 CREATE VIEW [VW_PROJETO_ACAO]AS(
SELECT B.siglaCoordenacao 
      ,A.diretriz
      ,A.nomeProjeto 
	  ,A.nivelProjeto
   ,B.Projeto
   ,B.itemProjeto
   ,B.nomeAcao 
   ,B.inicioPrevisto
   ,B.terminoPrevisto 
   ,B.terminoRealizado
   ,B.percentualExecutado
   ,B.statusAcao
   ,A.statusProjeto 
   ,B.nomeSobrenome
   ,B.responsavelSubstituto
   ,B.observacao
  FROM TB_PROJETO A
  INNER JOIN TB_ITENS_PROJETO B ON A.codigo = B.projeto AND A.nivelProjeto = 'E'
)
GO

/*------------------------------------------------------------*/
/*                      Criação de VIEW                      */
/*         VW_PROJETO_GRAFICO         */
/*------------------------------------------------------------*/

 CREATE VIEW [VW_PROJETO_GRAFICO]AS(
SELECT A.codigo,A.nomeProjeto,A.siglaCoordenacao, A.nivelProjeto, AVG(B.percentualExecutado) as percentualExecutado

  FROM TB_PROJETO A
  INNER JOIN TB_ITENS_PROJETO B ON A.codigo = B.projeto
  --WHERE B.dataConclusao = null
  GROUP BY A.nomeProjeto,A.codigo,A.siglaCoordenacao,A.nivelProjeto
)
GO

/*------------------------------------------------------------*/
/*                      Criação de VIEW                      */
/*          VW_RELATORIO_COMPLETO          */
/*------------------------------------------------------------*/

 CREATE VIEW [VW_RELATORIO_COMPLETO]AS(
SELECT A.[codigo]
      ,A.[nomeProjeto] as 'Diretriz / Meta'
      ,A.[Diretriz] as 'É Diretriz?'
      ,A.[statusProjeto] as Status
      ,A.[terminoRealizado] as 'Data de Conclusão'
      ,A.[DiasDeProjeto] as 'Qtde Dias Meta'
      ,A.[percentualExecutado] as '% Meta'
      ,A.[inicioPrevisto] as 'Inicio Previsto Meta'
      ,A.[terminoPrevisto] as 'Término Previsto Meta'
      ,A.[nivelProjeto] as 'Nível'
      ,A.[siglaDiretoria] as 'Diretoria'
      ,A.[siglaCoordenacao] as 'Coordenação Geral'
      ,A.[situacao] as 'Situação Meta'
	  ,B.[projeto]
      ,B.[itemProjeto] as 'Número Ação'
      ,B.[nomeAcao] as 'Ação'
      ,B.[inicioPrevisto] as 'Início Previsto Ação'
      ,B.[terminoPrevisto] as 'Término Previsto Ação'
      ,B.[inicioRealizado] as 'Início Realizado Ação'
      ,B.[terminoRealizado]  as 'Término Realizado Ação'
      ,B.[percentualExecutado] as '% Ação'
      ,B.[statusAcao] as 'Status Ação'
      ,B.[DiasPrevistos] as 'Qtde Dias Previsto Ação'
      ,B.[situacao] as 'Situação Ação'
	  ,C.[itemProcesso] as 'Número Atividade'
      ,C.[nomeProcesso] as 'Atividade'
      ,C.[inicioPrevisto] as 'Início Previsto'
      ,C.[terminoPrevisto] as 'Término Previsto'
      ,C.[inicioRealizado] as 'Inicio Realizado'
      ,C.[terminoRealizado] as 'Término Realizado'
      ,C.[siglaSetorial] as 'Coordenação Setorial'
      ,C.[DiasPrevistos] as 'Qtde Dias Previstos'
      ,C.[DiasRealizados] as 'Qtde Dias Realizados'
      ,C.[nomeSobrenome] as 'Responsável'
      ,C.[responsavelSubstituto] as 'Substituto'
      ,C.[percentualExecutado] as '% Atividade'
      ,C.[situacao] as 'Situação Atividade'
  FROM TB_PROJETO A
  INNER JOIN TB_ITENS_PROJETO B ON A.codigo = B.projeto
  INNER JOIN TB_PROCESSOS C ON A.CODIGO = C.projeto and B.itemProjeto = C.itemProjeto
)
GO

/*------------------------------------------------------------*/
/*                      Criação de VIEW                      */
/*           VW_HISTORICO_ATIVIDADE           */
/*------------------------------------------------------------*/

 CREATE VIEW [VW_HISTORICO_ATIVIDADE]AS(
select [TB_PROCESSOS].[projeto], [TB_PROCESSOS].[itemProjeto], [TB_PROCESSOS].[itemProcesso], [TB_PROCESSOS].[nomeProcesso], [TB_HIST_EXECUCAO_ATIVIDADE].[dataLancamento], [TB_HIST_EXECUCAO_ATIVIDADE].[justificativa], [TB_HIST_EXECUCAO_ATIVIDADE].[percentualExecutado], [TB_HIST_EXECUCAO_ATIVIDADE].[observacao], [TB_HIST_EXECUCAO_ATIVIDADE].[usuarioCadastro], [TB_HIST_EXECUCAO_ATIVIDADE].[dataCadastro]
 from [TB_PROCESSOS], [TB_HIST_EXECUCAO_ATIVIDADE]
  
)
GO

ALTER TABLE [TB_PROCESSOS] ADD CONSTRAINT [FK_TB_ITENS_PROJETO1]
	FOREIGN KEY
		([projeto],[itemProjeto])
	REFERENCES [TB_ITENS_PROJETO]
		([projeto],[itemProjeto])
	ON DELETE CASCADE
	ON UPDATE CASCADE
GO

ALTER TABLE [TB_LOGIN_RULE] ADD CONSTRAINT [TB_LOGIN_GROUP_RULE]
	FOREIGN KEY
		([LOGIN_GROUP_NAME])
	REFERENCES [TB_LOGIN_GROUP]
		([LOGIN_GROUP_NAME])
	ON DELETE CASCADE
GO

ALTER TABLE [TB_LOGIN_USER] ADD CONSTRAINT [TB_LOGIN_GROUP_USER]
	FOREIGN KEY
		([LOGIN_GROUP_NAME])
	REFERENCES [TB_LOGIN_GROUP]
		([LOGIN_GROUP_NAME])
	ON DELETE CASCADE
GO

ALTER TABLE [TB_HIST_EXECUCAO_ATIVIDADE] ADD CONSTRAINT [FK_TB_PROCESSOS]
	FOREIGN KEY
		([projeto],[itemProjeto],[itemProcesso])
	REFERENCES [TB_PROCESSOS]
		([projeto],[itemProjeto],[itemProcesso])
	ON DELETE CASCADE
	ON UPDATE CASCADE
GO

ALTER TABLE [TB_ITENS_PROJETO] ADD CONSTRAINT [FK_TB_PROJETO]
	FOREIGN KEY
		([projeto])
	REFERENCES [TB_PROJETO]
		([codigo])
	ON DELETE CASCADE
	ON UPDATE CASCADE
GO

