#INSTRUÇÕES DE USO


#PARTE1:

O RabbitMQ esta sendo consumido em DOCKER

antes de iniciar o projeto instancie o RABBITMQ no DOCKER

docker run -d --name rabbit \
  -p 5672:5672 -p 15672:15672 \
  rabbitmq:3-management

-ter instalado o .net 9

Abra o projeto em Parte1 pelo Parte1.sln

-Compile
-Recompile
-Limpe a solução

Após abrir o projeto e proceder com as instruções, execute o parte1.

ele executará apagando todos os registros do banco sqlserver da parte 1 ( esta em produção no monsterasp.net )






#PARTE2:


Antes de rodar a Parte 2 caso deseje verificar o rabbitmq ele estará aberto corretamente aqui:

http://localhost:15672/

mudar de diretório indo para DesafioTecnicoELAW/Parte2


Banco optado para a parte 2 foi o SQLITE disponível para download aqui:

https://sqlitebrowser.org/dl/

Necessário ter o Node.js >= v22.13.0
Necessário ter o NPM >= 11.0.0

Abrir o cmd,

rodar: 

-npm install

-npm run dev



Após isso no final do código será exibido essa mensagem para você:

[*] Aguardando mensagens em novos_processos

SQLite ► inseridos 10 processos

abra o arquivo processos.db utilizando o sqlitedbbrower e estará populado corretamente com os dados.





Bonus: 
( Migrations, não é necessário executar nenhum COMANDO de migration, todo o ambiente já está preparado. )



#Migrations

Comandos que usem migration será necessário especificar o context desejável para tal. Pois são 2 contexts diferentes e é necessário especificar no cli.

Para adicionar migration

Add migration

Especificar qual o context que quer adicionar a migration.

Add-Migration SubindoNovosProcessosAgora -Context NovoProcessoContext -Project InfraData -StartupProject Parte1

Para atualizar o banco. Apontar para qual context quer e utilizar o comando ( alterando o context ... )

Update-Database -Context NovoProcessoContext -StartupProject Parte1


