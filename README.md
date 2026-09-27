# Game_Solitude

Cópia independente de [GameDevToolkit2023_Solitude](https://github.com/SouBeatrizKaroline/GameDevToolkit2023_Solitude), com o histórico e os créditos originais preservados.

## Imagens do jogo

Capturas da versão original de Solitude, publicada no [itch.io](https://beatrizkcs.itch.io/solitude). As melhorias desta cópia ainda precisam de novas capturas após a compilação no Unity.

![Solitude — captura de tela 1](https://img.itch.zone/aW1hZ2UvMTg4OTI0Ni8xMTEwMzk1NS5wbmc=/original/pYr4D5.png)

![Solitude — captura de tela 2](https://img.itch.zone/aW1hZ2UvMTg4OTI0Ni8xMTEwNTY5Ny5wbmc=/original/38dvad.png)

![Solitude — captura de tela 3](https://img.itch.zone/aW1hZ2UvMTg4OTI0Ni8xMTEwNTY5OC5wbmc=/original/KsSie4.png)

![Solitude — captura de tela 4](https://img.itch.zone/aW1hZ2UvMTg4OTI0Ni8xMTEwNTcwMy5wbmc=/original/RxO9fb.png)

## Melhorias desta versão

- Movimento aplicado no ciclo da física e detecção do chão por contatos reais, evitando considerar paredes ou o próprio personagem como chão.
- Tolerância de 0,12 s para pular ao sair de uma borda e para registrar um salto pouco antes de aterrissar.
- Pausa com Esc, pausa ao perder o foco da janela, reinício e retorno ao menu.
- Fim de partida quando a autoestima chega a zero, com opção de tentar novamente.
- Proteção de 1 segundo contra danos repetidos e coleta de corações sem contagem duplicada.
- Indicador de autoestima, corações coletados e controles.
- Luz e barra limitadas ao intervalo de 0 a 30, com atualização imediata após danos e coleta.
- Correção do script de patrulha KeeperController: retorno ao ponto A, referências opcionais e pontos fixos no mundo. Esse script não está associado aos prefabs/cenas originais; a correção fica disponível para configurar novas patrulhas.
- Cinco testes de regressão para autoestima, limites, dano e pausa.

## Abrir e jogar a versão melhorada

1. Instale o Unity Editor **2021.3.16f1** pelo Unity Hub.
2. No Hub, adicione a pasta **Solitude**, que contém Assets, Packages e ProjectSettings.
3. Aguarde a importação dos recursos.
4. Abra **Assets/Scenes/Menu.unity** e clique em Play.
5. Use **A/D ou setas** para mover, **Espaço** para pular e **Esc** para pausar. Na pausa ou derrota, **R** reinicia.

O objetivo e as artes originais foram preservados. Os corações recuperam autoestima; alcançar a saída leva ao final.

## Gerar o executável atualizado

Em File > Build Settings, mantenha as cenas nesta ordem: Menu, SampleScene e final.
Escolha PC, Mac & Linux Standalone e gere a versão Windows em uma pasta nova, como Builds/Game_Solitude.

**Solitude.exe, Solitude.zip e Solitude_Data na raiz são a distribuição original. Eles não contêm as melhorias de código deste repositório.** Para jogá-las, use o Editor ou gere uma nova build.

## Validação

Os seis scripts de execução foram compilados com sucesso usando as bibliotecas Unity incluídas na distribuição original. Isso verifica a compilação C#, mas não substitui executar o projeto no Unity.

O Unity Editor não estava instalado no ambiente de preparação. Portanto, os testes Unity, a jogabilidade e a geração de uma nova build ainda precisam ser executados.

Abra Window > General > Test Runner > EditMode > Run All para executar os cinco testes incluídos.
Consulte [VALIDACAO.md](VALIDACAO.md) para o roteiro de teste manual.

---

# Game Dev Toolkit

> Solitude

Projeto desenvolvido durante a Game Dev Toolkit

[🔗 Clique aqui para acessar no itch.io](https://beatrizkcs.itch.io/solitude)

## Sobre o Projeto

Solitude é um jogo que fala sobre amor próprio e o momento após um término de um namoro de longos anos.

Sol é uma personagem que estava muito esperançosa para após 7 longos anos de namoro, receber o tão sonhado pedido de casamento, mas no dia do seu aniversário de namoro, está percebe que ali era uma despedida, um termino. Com isto ela fica arrasada. Como reaprender a viver sozinha? 

 Agora é reparar seu coração, autoestima e amor próprio.

#### Personagens

![preview](https://img.itch.zone/aW1nLzExMTA0OTQxLnBuZw==/original/DdSRqM.png)

### Tutorial

Transforme sua solidão em solitude, através da recuperação do seu amor próprio (corações). Mas tente fazer com que isto não cause danos a sua autoestima (diminuição na barra de autoestima), e o deixe ainda mais deprimido (Ficando com menos luz). Recupere os corações antes do tempo acabar. Ao receber danos, a barra de autoestima diminuirá e o personagem ficará perderá luz.

### Criadores

![preview](https://img.itch.zone/aW1nLzExMTA0NTkxLnBuZw==/original/MAsmpn.png)

#### Oxente, Noobs!

## 🛠 Tecnologias

- Unity
- C#
- ASP.NET
- HLSL
- ShaderLab
- Git
- GitHub
- Figma

## 💙 Contato

ebeatrizkcs@gmail.com
