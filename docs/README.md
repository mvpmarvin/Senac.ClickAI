# ClickAI

Aplicação Windows local desenvolvida em C# com .NET 10 e Windows Forms. O ClickAI posiciona o ponteiro no centro da área de destino e envia cliques esquerdos em intervalos fixos de três segundos enquanto estiver ativado.

## Como executar

1. Abra `Senac.ClickAI.slnx` no Visual Studio 2026.
2. Defina `Senac.ClickAI` como projeto de inicialização.
3. Compile e execute a aplicação no Windows.
4. Pressione `TAB` para navegar entre os botões.
5. Pressione `ENTER` ou `ESPAÇO` no botão de controle para ligar ou desligar.

A aplicação inicia desligada. O primeiro clique ocorre somente após o primeiro intervalo de três segundos.

## Comportamento

- A janela possui uma área central transparente com uma cruz indicadora.
- O botão fica verde quando o clicker está ativo.
- A cruz pisca em vermelho após cada clique.
- O botão de fechar encerra a aplicação.
- Falhas ao posicionar o ponteiro ou enviar o clique interrompem o clicker e exibem uma mensagem.

## Estrutura da solução

- `Senac.ClickAI.csproj` — aplicação WinForms.
- `ClickAI.cs` — interface e coordenação do ciclo.
- `ClickerController.cs` — regras de estado e execução por tick.
- `MouseClickService.cs` — integração com `SetCursorPos` e `SendInput`.
- `Tests/` — projeto de testes unitários xUnit.
- `docs/` — documentação detalhada do projeto.

## Documentação

- [Arquitetura](docs/ARCHITECTURE.md)
- [Stack tecnológica](docs/Stack.md)
- [Regras de negócio](docs/Business_Rules.md)
- [Especificações](docs/Specifications.md)

## Testes

Execute os testes com:

```powershell
dotnet test Tests/Senac.ClickAI.Tests.csproj
```

Os testes cobrem o estado inicial, ativação, desativação, execução condicionada ao estado ligado e o intervalo configurado.
