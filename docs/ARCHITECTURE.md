# Arquitetura

## Objetivo
Descrever a organização do ClickAI e as responsabilidades de cada camada.

## Escopo
Aplicação desktop Windows local, sem servidor, banco de dados ou comunicação de rede.

## Componentes

| Componente | Responsabilidade |
| --- | --- |
| `ClickAI` | Janela, controles, pintura do alvo, timer e mensagens ao usuário. |
| `ClickerController` | Estado do clicker e regra de executar uma ação por tick quando ligado. |
| `MouseClickService` | Integração com `SetCursorPos` e `SendInput`. |
| `IClickAction` | Abstração que desacopla o núcleo da API do Windows e permite testes. |
| `Tests` | Testes unitários das regras determinísticas do núcleo. |

## Fluxo principal
1. A aplicação inicia desligada e centralizada.
2. O usuário alterna o botão por clique, ENTER ou ESPAÇO.
3. Ao ligar, o timer é iniciado, sem clique imediato.
4. Cada tick calcula o centro do alvo e executa o clique esquerdo.
5. Uma falha interrompe o timer, desliga o controlador e informa o usuário.

## Decisões
- WinForms é usado por ser nativo, simples e adequado ao uso local em Windows.
- `TransparencyKey` cria a área vazada; a cruz é desenhada com cor diferente da chave.
- A lógica de estado não conhece WinForms, permitindo testes unitários sem janela.

## Qualidade
As dependências são direcionadas para dentro: a UI depende do controlador e da abstração de ação, enquanto o controlador não depende da UI. A aplicação não captura o mouse nem interfere fora dos ticks programados.
