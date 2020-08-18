# graff-challenge

### Deploy por [Heroku](https://graff-api.herokuapp.com/swagger/index.html). Acesse para testar online.

<details>
  <summary>Requisitos</summary>
  
  ## Fluxos do sistema
  - Criar um cadastro de produtos de um leilão com os campos Nome e Valor;
  - Criar um cadastro de pessoa (Nome e Idade);
  - Possibilitar a pessoa fazer um lance em um produto;
  - O lance sempre deve ser maior que o maior lance já realizado;
  - Se for menor ou igual, enviar uma mensagem para o usuário dizendo que não possível realizar o lance;
  - Criar uma tela onde mostra todos os lances realizados e seja possível realizar um filtro por nome de pessoa;

  ## Requisitos
  - Deve ser utilizado alguma linguagem/plataforma web (asp.net ou node.js).
  - Script para criação de tabelas em um banco de dados relacional. Ex: sql server, mysql, etc.
  - Uma simulação de uma consulta onde é possível extrair os lances realizados em um produto;

  ## Deve ser entregue
  - Todos os arquivos da solução para que seja possível rodar o projeto local;
  - Scripts para a criação da Base;
  - Pode ser enviado um link do github com o projeto.
</details>

## Notas (leia, por favor)
1. Nem todas as boas práticas foram levadas em conta nesse projeto. O código está legível, a organização do código está boa mas não o suficiente 'para produção'. No final da lista terá uma série de coisas que eu faria se precisasse colocar esse código em produção.
2. Utilizei o EF Core no modelo `code-first` para programação. Isso implica que o banco sera gerado pelo framework. Entretando, para você poder avaliar minha habilidade com SQL, fiz os [Scripts](/Scripts).
3. Caso queira rodar em Docker, é só buildar o Dockerfile presente na pasta da solução. Como estou somente com o Windows (e Docker no Windows não presta), não criei a imagem no DockerHub ou algo assim.
4. Utilizei um approach de Repositórios Genéricos para as três classes do sistema. Ultimamente venho fazendo alguns testes técnicos e sempre a repetição de código nos repositórios é algo que me incomoda muito. Resolvi tentar esse approach para ser mais produtivo.

## Se fosse em produção...
1. Separaria todo o código em projetos: Api, Application, Domain, Infra ou algo parecido.
2. Usaria Dependency Inversion, adicionando interfaces para os serviços e repositórios.
3. Removeria os repositórios genéricos e faria especializados.
4. Utilizaria alguma lib para validação invés de soltar exceptions.
