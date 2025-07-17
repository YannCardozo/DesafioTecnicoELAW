import Database from 'better-sqlite3';
import { v4 as uuidv4 } from 'uuid';


export interface NovoProcesso {
    id?: string;
    NumeroProcesso: string;
    Origem: string;
    Comarca_Regional: string;
    Competencia: string;
    NomeParte: string;
    CriadoEm?: string;
}

const db = new Database('processos.db');

// Cria a tabela se não existir
db.exec(`
  CREATE TABLE IF NOT EXISTS processos (
    id               TEXT    PRIMARY KEY,
    NumeroProcesso   TEXT    NOT NULL,
    Origem           TEXT,
    Comarca_Regional TEXT,
    Competencia      TEXT,
    NomeParte        TEXT,
    CriadoEm         DATETIME NOT NULL
  );
`);

const stmt = db.prepare(`
  INSERT INTO processos (
    id, NumeroProcesso, Origem, Comarca_Regional,
    Competencia, NomeParte, CriadoEm
  ) VALUES (
    @id, @NumeroProcesso, @Origem, @Comarca_Regional,
    @Competencia, @NomeParte, @CriadoEm
  );
`);

export function salvar(lista: NovoProcesso[]) {
    const rows = lista.map(p => ({
        id: p.id ?? uuidv4(),
        NumeroProcesso: p.NumeroProcesso,
        Origem: p.Origem,
        Comarca_Regional: p.Comarca_Regional,
        Competencia: p.Competencia,
        NomeParte: p.NomeParte,
        CriadoEm: p.CriadoEm ?? new Date().toISOString()
    }));

    const trx = db.transaction((arr: NovoProcesso[]) => {
        for (const r of arr) stmt.run(r);
    });

    trx(rows);
    console.log(`SQLite ► inseridos ${rows.length} processos`);
}
