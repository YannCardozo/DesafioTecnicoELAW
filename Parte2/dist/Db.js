"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.salvar = salvar;
const better_sqlite3_1 = __importDefault(require("better-sqlite3"));
const db = new better_sqlite3_1.default('processos.db');
db.exec(`
  CREATE TABLE IF NOT EXISTS processos (
    id          INTEGER PRIMARY KEY AUTOINCREMENT,
    codProc     TEXT NOT NULL,
    codCnj      TEXT NOT NULL,
    nomeAutor   TEXT,
    nomeReu     TEXT
  )
`);
const stmt = db.prepare('INSERT INTO processos (codProc, codCnj, nomeAutor, nomeReu) VALUES (?,?,?,?)');
function salvar(lista) {
    const trx = db.transaction((arr) => {
        for (const p of arr)
            stmt.run(p.codProc, p.codCnj, p.nomeAutor ?? null, p.nomeReu ?? null);
    });
    trx(lista);
    console.log(`SQLite ► inseridos ${lista.length} processos`);
}
//# sourceMappingURL=Db.js.map