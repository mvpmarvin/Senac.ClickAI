# Especificações

## Objetivo
Definir os requisitos funcionais, técnicos e de acessibilidade do ClickAI.

## Interface

- Janela quadrada, opaca, de alto contraste e com espaços reduzidos.
- Área quadrada central transparente.
~~- Duas linhas ortogonais centralizadas para indicar o ponto de clique.~~
~~- Cruz branca em repouso e vermelha durante o feedback de clique.~~(Cruz removida por conflitar com o evento do click.)
- Botão de saída com símbolo de fechar.
- Botão de ativação com indicação textual do estado.
- Botão verde quando o clicker estiver ligado.
- Janela centralizada na primeira execução.
- Janela sem redimensionamento livre e com suporte à maximização.

## Acessibilidade e teclado

- Os dois botões podem ser alcançados pela tecla `TAB`.
- `ENTER` e `ESPAÇO` acionam o botão selecionado.
- Os controles possuem nomes e descrições acessíveis.
- O contraste entre o estado ativo, inativo e a área de destino deve permanecer perceptível.

## Execução

- O estado inicial é desligado.
- O intervalo do timer é fixo em 3000 milissegundos.
- Ativar o clicker inicia o timer, sem clique imediato.
- Cada tick ligado realiza um único clique esquerdo.
- O destino é o centro da região transparente em coordenadas de tela.
- `SetCursorPos` posiciona o ponteiro antes de `SendInput` enviar o clique.

## Tratamento de falhas

Falhas de `SetCursorPos`, `SendInput` ou outras exceções ocorridas durante o tick devem desligar o controlador, parar o timer e mostrar uma mensagem modal de erro ao usuário.

## Testes

A suíte unitária cobre o estado inicial, ativação, desativação, execução condicionada ao estado ligado e o intervalo configurado. A integração física com o mouse depende do Windows e não é executada pelos testes unitários.
