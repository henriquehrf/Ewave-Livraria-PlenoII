# Projeto: Ewave-Livraria-Pleno II

Este é um projeto MVP <i>(Minimal Viable Product)</i> da <strong>Livraria ToDo </strong>;

<hr></hr>

<h3>Tabelas e Campos do Sistema</h3>

<ul>
  <li>
    <h4>Usuário</h4>
    <ul>
      <li>Nome</li>
      <li>CPF</li>
      <li>Telefone</li>
      <li>Email</li>
      <li>Endereço</li>
      <li>Instituição de Ensino</li>
      <li>Perfil Usuário (1 - Administrador, 2 - Usuário Comum)</li>
      <li>Login</li>
      <li>Senha</li>
    </ul>
   </li>
</ul>
<ul>
  <li>
    <h4>Instituição de Ensino</h4>
    <ul>
      <li>Nome</li>
      <li>CNPJ</li>
      <li>Telefone</li>
      <li>Endereço</li>
    </ul>
   </li>
</ul>
<ul>
  <li>
    <h4>Livro</h4>
    <ul>
      <li>Título</li>
      <li>Genero</li>
      <li>Sinopse</li>
      <li>Capa</li>
      <li>Disponibilidade</li>
    </ul>
   </li>
</ul>
<ul>
  <li>
    <h4>Empréstimo</h4>
    <ul>
      <li>Usuário</li>
      <li>Livro</li>
      <li>Data Empréstimo</li>
      <li>Data Previsão Devolução</li>
      <li>Data Devolução</li>
      <li>Status (1- Aberto, 2 - Fechado)</li>
    </ul>
   </li>
</ul>

<hr></hr>
<h3>Funcionalidades</h3>
<ul>
  <li>
    O usuário ADMINISTRADOR é responsável pelos cadastros base. Tanto ele, quanto o USUÁRIO COMUM pode fazer a solicitação de empréstimo.
  </li>
    <li>
    O usuário ADMINISTRADOR possui na tela inicial a visualização de todos empréstimos ativos(atualizados a cada 1 minuto), com destaque naqueles que estão em atraso.
  </li>
    <li>
    Ao solicitar empréstimo, o sistema avalia se o usuário não atingiu o limite de 2 empréstimo por usuário e se ele possui alguma suspensão vigente.
    Ao atingir o limite de empréstimo, o usuário fica impossibilitado de emprestar livro, liberando novos empréstimos mediante a devolução.
    Caso a devolução seja em atraso, o usuário ficará suspenso para novos empréstimo por 30 dias.
  </li>
  <li>
   Para solicitar um empréstimo, o usuário OBRIGATORIAMENTE deve está logado no sistema.
  </li>
</ul>

<hr></hr>

<h3>Técnologias/Arquitetura do projeto</h3>

<h4>Back-end</h4>
<ul>
<li>ASP.NET Core 3.1</li>
<li>Entity Framework Core 3.1.6</li>
<li>Flunt Validation 1.0.5</li>
<li>Swagger UI 5.5.0</li>
<li>Sql Server</li>
<li>X Unit 2.4.0</li>
<li>Fluent Assertion 5.10.3</li>
<li>DDD - Domanin Driven Design</li>
<li>Repository Pattern</li>
<li>Mapper by Extension Methods</li>
<li>Notification Pattern</li>
<li>Value Types</li>
<li>Autenticação JWT(JSON Web Tokens)</li>
</ul>

<h4>Front-end</h4>
<ul>
<li>Angular CLI 6.0.8</li>
<li>Node 12.16.3</li>
<li>Angular 6.1.10</li>
<li>Rxjs 6.0.0</li>
<li>Typescript 2.7.2</li>
<li>Webpack 4.8.3</li>
<li>SPA (Single Page Application)</li>
</ul>


<hr></hr>

<h3>Executando o Projeto</h3>

<h4>Back-end</h4>

