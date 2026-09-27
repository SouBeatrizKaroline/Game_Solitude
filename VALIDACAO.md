# Roteiro de validação

## Verificação realizada

- Compilação dos seis scripts de execução contra as bibliotecas Unity da distribuição original: passou.
- A compilação foi feita fora do Editor; não verifica importação de cenas, renderização ou física em execução.
- Os arquivos .meta dos scripts existentes foram preservados.

## Testes incluídos, pendentes de execução no Unity

No Unity 2021.3.16f1, abra Window > General > Test Runner e execute EditMode:

1. Dano atualiza autoestima, intensidade e tempo sem precisar de uma barra ou luz associada.
2. Dano letal limita autoestima a zero e interrompe o tempo.
3. Dano negativo não cura.
4. Pausa bloqueia dano; continuar reativa o tempo e permite dano.
5. Valores acima do máximo são limitados a 30.

## Teste manual antes de distribuir uma nova build

- Iniciar pelo menu e mover com A/D e setas.
- Pular no chão; encostar em paredes no ar sem ganhar um salto extra.
- Pular logo após sair da borda e pressionar espaço pouco antes de aterrissar.
- Coletar um coração: apenas uma contagem e recuperação limitada ao máximo.
- Encostar nos inimigos: receber dano e respeitar o intervalo de proteção.
- Pausar: tempo, movimento e animações ficam congelados; continuar retoma a partida.
- Alternar para outra janela: jogo fica pausado até continuar.
- Deixar o tempo acabar: tela de derrota, sem movimento ou coleta posterior.
- Reiniciar pela derrota e pela pausa: tempo volta a correr e a fase recarrega.
- Voltar ao menu, iniciar outra vez e alcançar o final.
- Conferir a interface em diferentes resoluções e ausência de erros no Console.

## Patrulha opcional

KeeperController não está associado aos prefabs/cenas originais. Para testá-lo, configure
um objeto com o componente, dois pontos A/B distintos e uma referência de skin.
Verifique vários trajetos completos nos dois sentidos; os pontos são capturados no início.
Não adicione simultaneamente outra animação que controle a posição desse objeto.
