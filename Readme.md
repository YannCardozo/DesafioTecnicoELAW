# DESAFIO TÉCNICO ELAW DESENVOLVEDOR PLENO

Explicações Técnicas:

# Tecnologias e Pacotes Adotados

Foi utilizado a ORM Entity FrameWork Core, pela facilidade de gerar as tabelas pela baixa COMPLEXIDADE da modelagem do caso de uso adotado no desafio técnico
O projeto foi feito em consoleAPP pela não exigência de um front para exibir algo, tendo o RabbitMQ para visualizar as filas e os elementos a serem entrados na mensageria, foi dispensado uso de UI.
O RabbitMQ foi utilizado no DOCKER pela facilidade de utilização do mesmo e na preferencia pela utilização do docker sempre que possível.
O projeto foi feito em 5 Camadas, sendo:

# Arqutitetura

General    ( Camada de Models, divididas em DTOS e DAOS => DAO são as entidades fidedignas ao banco contendo seus IDS. DTOS são Models que transportam os dados, tanto do front quanto do back por algum motivo. )
InfraData  ( Camada de Persistencia, manipulação e tudo relacionado a banco de dados )
Mensageria ( Camada responsável por manter a service que alimenta a fila de mensageria do RABBITMQ )
Parte1     ( Camada onde referencia, infra data e Mensageria para poder consumir todos os seus conteudos e executar normalmente ) , Iniciando o código apagando TODOS OS REGISTROS do banco em produção para evitar qualquer tipo de problema na avaliação do teste.
Parte2     ( Camada com o TypeScript contendo o src com as classes Db.ts e o Woker.ts , o DB faz a conexão ao banco do sqlite, cria o arquivo DB => processos.db )
Ao executar o Worker.ts ele olha na porta que o rabbitmq estiver configurado por mensagens novos_processos disponíveis. Caso tenham, ele vai processar elas todas e fazer os respectivos inserts no sqlite.


A requisicao http é feita na pasta Utilitários dentro de General, onde no header da requisição pegamos o recaptcha-token que é visivel no inspecionar elemento do site do desafio técnico.
O Payload utilizado na consulta do site do TJRJ,  é mantido IDENTICO no corpo da requisição http para obtermos o retorno da api do TJRJ.

OBS1: Caso você não inclua na requisicao http que está vindo de um navegador a requisicao, ela fica tentando e encerra conforme a política do timeout que voce estipula ( adotei por 1 min , pois ela dura em média 10 segundos )
OBS2: InfraData por ter dependencia de General, não é referenciado novamente no Parte1 para não dar referencia circular.
OBS3: Foram tentadas manter todos os nomes dos atributos de forma o mais fidedigna possível, inclusive personagensResumido no retorno da api.
OBS4: O nome do Objeto é usado como NovoProcesso ao invés de Processo. Por conta de Processo já ter sido utilizado anteriormente.
OBS5: Foi Optado criar o InfraDependencies em Parte1 , por conta do console app não possuir a estrutura de um program.cs comum de uma aplicação WEB, descartando a injeção de dependencia diretamente e optando pela inversão de dependencia.




# Instruções de Utilização PROJETO:

# PARTE1:

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






# PARTE2:


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



# Migrations

Comandos que usem migration será necessário especificar o context desejável para tal. Pois são 2 contexts diferentes e é necessário especificar no cli.

Para adicionar migration

Add migration

Especificar qual o context que quer adicionar a migration.

Add-Migration SubindoNovosProcessosAgora -Context NovoProcessoContext -Project InfraData -StartupProject Parte1

Para atualizar o banco. Apontar para qual context quer e utilizar o comando ( alterando o context ... )

Update-Database -Context NovoProcessoContext -StartupProject Parte1


