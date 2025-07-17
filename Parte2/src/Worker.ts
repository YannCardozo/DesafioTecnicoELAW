import amqp, { ConsumeMessage } from 'amqplib';
import { salvar, NovoProcesso } from './Db';

const QUEUE = 'novos_processos';
const RABBIT = 'amqp://guest:guest@localhost:5672';

async function start() {
    const conn = await amqp.connect(RABBIT);
    const ch = await conn.createChannel();

    await ch.assertQueue(QUEUE, { durable: true });
    ch.prefetch(1);

    console.log(`[*] Aguardando mensagens em ${QUEUE}`);

    ch.consume(
        QUEUE,
        (msg: ConsumeMessage | null) => {
            if (!msg) return;

            try {
                const lista = JSON.parse(msg.content.toString()) as NovoProcesso[];
                salvar(lista);
                ch.ack(msg);
            } catch (err) {
                console.error('Falha ►', err);
                ch.nack(msg, false, true);
            }
        },
        { noAck: false }
    );
}

start().catch(err => {
    console.error('Erro fatal:', err);
    process.exit(1);
});
