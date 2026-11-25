# Stack tecnológica

## Objetivo
Registrar as tecnologias, versões e APIs utilizadas pelo ClickAI.

## Tecnologias

| Tecnologia | Uso |
| --- | --- |
| C# | Linguagem principal. |
| .NET 10 | Runtime e SDK de compilação. |
| Windows Forms | Interface gráfica desktop. |
| xUnit | Testes unitários. |
| `user32.dll` | Posicionamento e simulação do mouse. |

## Plataforma

- Sistema operacional: Windows.
- Tipo de aplicação: desktop local.
- Tipo de saída: `WinExe`.
- Target framework: `net10.0-windows`.
- Interface: alto contraste, controles nativos e navegação por teclado.
- Rede e persistência: não utilizados.

## APIs nativas

- `SetCursorPos`: move o ponteiro para o centro da área de destino.
- `SendInput`: envia os eventos de pressionar e liberar o botão esquerdo.

## Dependências de desenvolvimento

O projeto `Tests/Senac.ClickAI.Tests.csproj` referencia `Microsoft.NET.Test.Sdk`, `xunit` e `xunit.runner.visualstudio`. As versões estão declaradas diretamente no arquivo do projeto de testes.
