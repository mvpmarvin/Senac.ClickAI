# Regras de negócio

## Objetivo
Definir o comportamento funcional do ClickAI.

## Regras

| ID | Regra |
| --- | --- |
| BR-01 | A aplicação inicia desligada. |
| BR-02 | O estado só alterna pelo botão de controle, inclusive quando acionado por ENTER ou ESPAÇO. |
| BR-03 | O intervalo entre ticks é fixo em 3 segundos. |
| BR-04 | Ligar o clicker apenas inicia o timer; o primeiro clique acontece no primeiro tick. |
| BR-05 | Cada tick ligado envia exatamente um clique esquerdo no centro da área transparente. |
| BR-06 | Ticks com o clicker desligado não executam ações. |
| BR-07 | O usuário pode desligar o clicker a qualquer momento. |
| BR-08 | Qualquer falha durante o posicionamento ou envio interrompe a execução e exibe uma mensagem de falha. |
| BR-09 | O botão ligado é exibido em verde e o alvo pisca em vermelho após uma ação. |
| BR-10 | O botão de fechar encerra a aplicação. |

## Critérios de aceite
- O foco alterna entre os dois botões pela tecla TAB.
- O botão de controle informa seu estado para tecnologias assistivas.
- O ponteiro é reposicionado antes do envio do clique.
- Nenhuma ação é realizada enquanto o estado estiver desligado.
