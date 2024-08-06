# blazor-aspnet-crud
Aplicação web full stack para gerenciar clientes e seus contatos, utilizando C# no backend, Blazor no frontend, e Docker para conteinerização.

### Script de Criação do Banco de Dados
```sql
-- Criar o banco de dados
CREATE DATABASE gestao_contatos;

-- Conectar ao banco de dados
\c gestao_contatos

-- Criar a sequência para a tabela cliente
CREATE SEQUENCE cliente_id_seq;

-- Criar a tabela cliente
CREATE TABLE public.cliente (
    id_cliente int4 DEFAULT nextval('cliente_id_seq'::regclass) NOT NULL,
    cli_nome varchar(100) NOT NULL,
    cli_cnpj varchar(14) NOT NULL,
    cli_data_fundacao date NOT NULL,
    cli_ativo bool NOT NULL,
    CONSTRAINT "Cliente_cli_cnpj_key" UNIQUE (cli_cnpj),
    CONSTRAINT "Cliente_pkey" PRIMARY KEY (id_cliente)
);

-- Criar a sequência para a tabela contato
CREATE SEQUENCE contato_id_seq;

-- Criar a tabela contato
CREATE TABLE public.contato (
    id_contato int4 DEFAULT nextval('contato_id_seq'::regclass) NOT NULL,
    id_cliente int4 NULL,
    cont_nome varchar(100) NOT NULL,
    cont_email varchar(100) NOT NULL,
    cont_telefone varchar(20) NULL,
    cont_cargo varchar(50) NULL,
    CONSTRAINT contato_pkey PRIMARY KEY (id_contato)
);

-- Adicionar a chave estrangeira na tabela contato
ALTER TABLE public.contato
ADD CONSTRAINT contato_id_cliente_fkey
FOREIGN KEY (id_cliente) REFERENCES public.cliente(id_cliente)
ON DELETE CASCADE;
```

### Instruções para Iniciar o Projeto FE

Rodar o comando abaixo no diretório blazor-aspnet-cru/ClientApp
```
dotnet watch run
```

### Instruções para Iniciar o Projeto BE

Rodar o comando abaixo no diretório blazor-aspnet-cru/Server
```
dotnet watch run
```