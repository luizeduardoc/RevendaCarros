CREATE TABLE veiculos (
    id    SERIAL PRIMARY KEY,
    placa VARCHAR(7) NOT NULL,
    cor   VARCHAR(20) NOT NULL,
    preco NUMERIC(9,2) NOT NULL,
    tipo  NUMERIC(1) NOT NULL
)