Essa Api se refere a uma busca por status de pedidos,

Na mesma existem 5 endpoints

1 - GET onde podemos buscar todos os pedidos
2 - Post onde fazemos a inserção do pedido
3 - GET/id onde buscamos por um id especifico
4 - GET/status buscamos por um status
5 - Get/pedido Busca as porcentagem dos status

Ferramentas utilizadas:

A linguagem utilizada foi o C# onde criamos uma pequena api com o framework .NET Core
Utilizamos o ORM Entity Framework e o banco de dados Sqlite para guardar as requisições envidas pelo Post.

JSON do POST:

{
  "id": 0,
  "status": "string"
}
No Json o id não precisa preencher já que o id vai ser adicionado automaticamente, e o status vai ser onde você vai colocar.

