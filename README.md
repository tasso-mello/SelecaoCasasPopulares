# Seleção Casas Populares
## Web API .NET 6 SELEÇÃO CASAS POPULARES
<p align="center">Com o objetivo de listar famílias aptas para ganhar uma casa popular</p>
<h1 align="center">🔗 C#</h1>
<p align="center">🚀 Api com swagger para que o usuário possa consumir alguns métodos</p>

# 📁 Acesso ao projeto

**Você pode <a href="https://github.com/tasso-mello/SelecaoCasasPopulares">acessar o código do projeto inicial</a> ou <a href="https://github.com/tasso-mello/SelecaoCasasPopulares/archive/refs/heads/master.zip">baixá-lo</a>**

# 🛠️ Abrir e rodar o projeto

**Após baixar o projeto, abra o arquivo <b>*.sln</b> em Visual Studio 2022**

<ul>
	<li>Antes de executar o projeto, certifique se o .NET 6 está instalado na máquina;</li>
	<li>Antes de executar o projeto, certifique se há uma instância do SQL instalada na máquina;</li>
	<li>Crie uma base de dados com o nome "CasaPopular" em sua instância <i>localhost</i>;</li>
	<li>Após isso, abra o <b>Package Manager Console</b>, selecione o Projeto padrão: <b>repository.casa.popular</b>;</li>
	<li>execute o comando <b>update-database</b>;</li>
	<li>Após isso, execute o projeto <b>api.casa.popular</b></li>
</ul>

**O Navegador será aberto no swagger**
![image](https://user-images.githubusercontent.com/73311950/206090084-b4dd1a23-c51e-4fa8-a87b-7fc81c78c258.png)

**Após executar o projeto, haverá 3 controladores disponíveis**

<ul>
	<li>Familia (com paginação);</li>
	<li>Pessoa (com paginação);</li>
	<li>SelecaoFamilias (sem paginação)</li>
</ul>

![image](https://user-images.githubusercontent.com/73311950/206090905-bd60455e-d5bd-4590-9713-e1428950990d.png)

**Alguns dados serão incluídos de forma aleatória em sua base de dados local**
<ul>
	<li>Para listar um registro específico, use o sem rota definida</li>
	<li>Para listar registros com paginação, use o <b>take</b></li>
	<li>Para filtrar registros com paginação, use o <b>filter</b> passando o parâmetro {filter}</li>
</ul>

**Exemplo retorno com paginação**

![image](https://user-images.githubusercontent.com/73311950/206091667-82b84e3d-3be6-4805-bf85-f7b402888c27.png)

<ul>
	<li>Nome do objeto de retorno:[resultado]</li>
	<li>nextpage: parametro para próxima página</li>
	<li>previouspage: parametro para página anterior</li>
	<li>pages: numero total de páginas</li>
	<li>totalregisters: número total de registros</li>
</ul>
