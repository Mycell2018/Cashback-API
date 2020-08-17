# Cashback-API
BACK-END 
Requisitos back-end: 
•	Rota para cadastrar um novo revendedor(a) exigindo no mínimo nome completo, CPF, e- mail e senha; 
•	Rota para validar um login de um revendedor(a); 
•	Rota para cadastrar uma nova compra exigindo no mínimo código, valor, data e CPF do 
•	revendedor(a). Todos os cadastros são salvos com o status “Em validação” exceto quando o CPF do revendedor(a) for 153.509.460-56, neste caso o status é salvo como “Aprovado”; 
•	Rota para listar as compras cadastradas retornando código, valor, data, % de cashback aplicado para esta compra, valor de cashback para esta compra e status; 
•	Rota para exibir o acumulado de cashback até o momento, essa rota irá consumir essa informação de uma API externa disponibilizada pelo Boticário. 
API externa GET: https://mdaqk8ek5j.execute-api......
headers { token: '***************************' } 
Premissas do caso de uso: 
•	Os critérios de bonificação são:
	o	Para até 1.000 reais em compras, o revendedor(a) receberá 10% de cashback do valor vendido no período de um mês;
	o	Entre 1.000 e 1.500 reais em compras, o revendedor(a) receberá 15% de cashback do valor vendido no período de um mês;
	o	Acima de 1.500 reais em compras, o revendedor(a) receberá 20% de cashback do valor vendido no período de um mês. 

======================================================================================================================
Desenvolvido API básica, .NET CORE, MySql, EntityFramework e implementação do swagger para documentação e testes.

EndPoint: https://localhost:3000/docs

Aguardo Retorno. Obrigado pela oportunidade.

Marcel Garcia
11 951445009
3fautomacao@gmail.com
