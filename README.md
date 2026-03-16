# Snake Game - Desenvolvimento em C#

Projeto acadêmico de um jogo clássico Snake (cobrinha) desenvolvido em C# (Console Application), focado em lógica de programação, manipulação de matrizes e persistência de dados.

## 🛠️ Arquitetura do Sistema

O software foi estruturado em classes para separar as responsabilidades do jogo:

### 1. Classe Cobra (Entidade)
* **Gerenciamento de Coordenadas:** Utiliza arrays para rastrear a posição de cada segmento da cobra.
* **Lógica de Movimentação:** Atualiza a cabeça baseada na entrada do usuário e desloca os segmentos do corpo sequencialmente.
* **Crescimento:** Gerencia a expansão da cobra ao consumir alimentos.

### 2. Classe Tabuleiro (Engine do Jogo)
* **Renderização:** Gerencia uma matriz bidimensional para desenhar o campo, a cobra e a comida no console.
* **Sistema de Colisões:** Valida se a cobra atingiu as bordas do cenário ou o próprio corpo, acionando o fim de jogo.
* **Geração de Itens:** Algoritmo para spawn aleatório de comida em posições não ocupadas pela cobra.
* **Input Handling:** Captura comandos do teclado (Setas ou WASD) com controle de direção oposta (evita que a cobra "volte para trás").

### 3. Classe Jogador (Dados)
* **Gerenciamento de Score:** Rastreia a pontuação em tempo real.
* **Persistência (I/O):** Grava o histórico de pontuações em um arquivo externo (`scores.txt`) utilizando `StreamWriter`.

## 🚀 Especificações Técnicas
* **Linguagem:** C# (.NET)
* **Conceitos:** Matrizes (int[,]), IO de arquivos, Threads (Thread.Sleep para controle de FPS) e Orientação a Objetos.

---
Desenvolvido por Eduardo Cezar
