# Plano de Ação: Plugin de Integração Jellyfin e Does The Dog Die?

## Objetivo do Projeto

Criar um plugin para o Jellyfin que integra a API do "Does The Dog Die?" para automaticamente aplicar tags em mídias que contenham "triggers" (gatilhos emocionais) específicos. O objetivo é permitir o bloqueio dessas mídias para perfis de usuário específicos (ex: esposa) e sinalizar o conteúdo para outros perfis (ex: seu).

---

## Fase 1: Pesquisa e Preparação

1.  **Obter Chave da API (Sua Tarefa):**
    *   [ ] Registrar-se no site [doesthedogdie.com](https://www.doesthedogdie.com) para obter uma chave de API (API Key). Esta chave é essencial para que o plugin possa fazer consultas.
API KEY: 2d08cde1fd6eae10d6cf9e58e2078faa
2.  **Preparar o Ambiente de Desenvolvimento:**
    *   [ ] Instalar o **.NET 8.0 SDK**, que é a plataforma necessária para desenvolver plugins para o Jellyfin.
    *   [ ] Confirmar que um editor de código, como o Visual Studio Code, está instalado.

---

## Fase 2: Desenvolvimento do Plugin (Estrutura)

1.  **Criar o Esqueleto do Plugin:**
    *   [ ] Usar o template oficial do Jellyfin para criar a estrutura inicial do projeto do plugin em C#.
    *   Comando: `dotnet new -i /path/to/templatefolder` (após baixar o template)
    *   Comando: `dotnet new Jellyfin-plugin -name DoesTheDogDie`

2.  **Implementar a Configuração do Plugin:**
    *   [ ] Desenvolver uma página de configuração dentro do painel do Jellyfin.
    *   [ ] Criar um campo para que você possa inserir e salvar sua chave da API do "Does The Dog Die?".
    *   [ ] Criar um campo de texto ou lista para você adicionar os "triggers" específicos que deseja bloquear (ex: `sexual assault`, `animal cruelty`, etc.).

---

## Fase 3: Lógica Principal e Integração

1.  **Criar uma Tarefa Agendada:**
    *   [ ] Implementar uma tarefa que roda periodicamente (ex: a cada 24 horas) para escanear a biblioteca de filmes do Jellyfin.

2.  **Integração com a API:**
    *   [ ] Para cada filme na biblioteca, extrair uma informação de identificação (ID do IMDb, título, ano).
    *   [ ] Escrever o código para chamar a API do "Does The Dog Die?" com a informação do filme.
    *   [ ] Processar a resposta JSON da API para extrair a lista de "triggers" e os votos dos usuários para cada um.

3.  **Lógica de Tagging:**
    *   [ ] Comparar os "triggers" retornados pela API com a sua lista de "triggers" sensíveis.
    *   [ ] Se um filme contiver um ou mais dos seus "triggers", o plugin deverá aplicar uma tag específica no Jellyfin (ex: `DTDD-Bloqueado`).

---

## Fase 4: Filtros e Interface

1.  **Configurar o Bloqueio de Perfil:**
    *   [ ] Usar o sistema de Controle Parental do Jellyfin para configurar o perfil da sua esposa.
    *   [ ] Criar uma regra para "Bloquear itens com a tag" e adicionar a tag `DTDD-Bloqueado`. Isso fará com que os filmes marcados desapareçam do perfil dela.

2.  **Sinalização no seu Perfil (Opcional, mas recomendado):**
    *   [ ] Investigar como customizar a interface do Jellyfin para exibir um aviso visual no seu perfil. A tag já estará visível, mas podemos explorar formas de torná-la mais evidente.

---
