# The Chess Pieces

In our last journal entry, we aligned our board representation (constructed with what we know) with our
goals for this project and made the module more SOLID. Now that the board is complete, we move on to
other important things. Let's start with the pieces. I hope you remember the board from our [Board
journal entry](03%20-%20The%20Chess%20Board.md). With the chess pieces placed on the board in the
starting position, it looks a bit like this:

![Starting Position](../media/starting-position.png)

Now that we know how to reference the squares, ranks and files on the board, it is going to be easy for
us to talk about the pieces. At first glance, we can make the following observations:

* The chess pieces occupy (are placed in) squares on the chess board.
* A single piece occupies a single square.
* Some squares are blank, i.e., some squares are not occupied by any piece.
* There are a total of 32 chess pieces.
* 16 of them are white, the other 16 are black.
* There are 6 unique pieces
    1. The ones in the ranks 2 and 7
    2. The ones in the squares a1,h1,a8, and h8
    3. The ones in the squares b1,g1,b8, and g8
    4. The ones in the squares c1,f1,c8, and f8
    5. The ones in the squares d1 and d8
    6. The ones in the squares e1 and e8
* The pieces are in two sets, one in black and one in white, and are arranged symmetrically on the board.

There are two sets of pieces, one in black and one in white, one set for each *player*. Chess is a
2-player game, that is, it is played by two players. This starting position is how a game is started.
From this position, the players move their pieces on the board in order to play. One of them uses the
white pieces to play, and the other uses the black pieces. Playing is done by moving pieces from one
square on the chessboard to another. Knowing that much about players, moves and the game is enough for 
the moment, let us concentrate on the pieces themselves.

![Unique Pieces](../media/pieces/chess-pieces-all.png)

As we noted earlier, there are 6 unique chess pieces. Let us identify and name them. This is important,
because in chess, each piece moves differently, and being able to refer them by name has its advantages
while discussing / learning chess moves and rules. The pieces also have a notation which is a single
character to identify them. It is written in upper case for denoting a white piece and in lower case for
denoting a black piece (neat, eh?).

White Piece|Black Piece|Name|Notation White|Notation Black|
-----------|-----------|----|--------------|--------------|
![White King](../media/pieces/king-white.png)|![Black King](../media/pieces/king-black.png)|King|K|k|
![White Queen](../media/pieces/queen-white.png)|![Black Queen](../media/pieces/queen-black.png)|Queen|Q|q|
![White Rook](../media/pieces/rook-white.png)|![Black Rook](../media/pieces/rook-black.png)|Rook|R|r|
![White Bishop](../media/pieces/bishop-white.png)|![Black Bishop](../media/pieces/bishop-black.png)|Bishop|B|b|
![White Knight](../media/pieces/knight-white.png)|![Black Knight](../media/pieces/knight-black.png)|Knight|N|n|
![White Pawn](../media/pieces/pawn-white.png)|![Black Pawn](../media/pieces/pawn-black.png)|Pawn|P|p|

Pooling what we know so far, we can roughly see the characteristics of what we could call the Piece class:

* A single piece can occupy a single square on the chess board
* A piece has a name which denotes its type
* A piece has a colour which denotes its side (of play)
* A piece has a notation which is derived from both the name and the colour
* A piece can be moved from one square to another (by the player)

## Further Information
* [Chess Piece](https://en.wikipedia.org/wiki/Chess_piece)
* [King](https://en.wikipedia.org/wiki/King_(chess))
* [Queen](https://en.wikipedia.org/wiki/Queen_(chess))
* [Rook](https://en.wikipedia.org/wiki/Rook_(chess))
* [Bishop](https://en.wikipedia.org/wiki/Bishop_(chess))
* [Knight](https://en.wikipedia.org/wiki/Knight_(chess))
* [Pawn](https://en.wikipedia.org/wiki/Pawn_(chess))