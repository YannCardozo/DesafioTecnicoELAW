"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const amqplib_1 = __importDefault(require("amqplib"));
const Db_1 = require("./Db");
const QUEUE = 'novos_processos';
const RABBIT = 'amqp://guest:guest@localhost:5672';
async function start() {
    const conn = await amqplib_1.default.connect(RABBIT);
    const ch = await conn.createChannel();
    await ch.assertQueue(QUEUE, { durable: true });
    ch.prefetch(1);
    console.log(`[*] Aguardando mensagens em ${QUEUE}`);
    ch.consume(QUEUE, (msg) => {
        if (!msg) {
            return;
        }
        try {
            const processos = JSON.parse(msg.content.toString());
            (0, Db_1.salvar)(processos);
            ch.ack(msg);
        }
        catch (err) {
            console.error('Falha ►', err);
            ch.nack(msg, false, true);
        }
    }, { noAck: false });
}
start().catch(err => {
    console.error('Erro fatal:', err);
    process.exit(1);
});
//# sourceMappingURL=Worker.js.map