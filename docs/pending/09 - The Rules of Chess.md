# The Rules of Chess
As we previously discussed, Chess is a game played by two people on a chessboard, with sixteen pieces
(of six types) for each player. Each type of piece moves in a distinct way. The goal of the game is to
*checkmate*, that is, to threaten the opponent's king with inevitable capture. Games do not necessarily
end with checkmate – players can *resign* if they believe they will lose. In addition, there are several
ways that a game can end in a *draw*.

Besides the basic movement of the pieces, rules also govern the equipment used, the time control, the
conduct and ethics of players, accommodations for physically challenged players, the recording of moves
using chess notation, as well as provide procedures for resolving irregularities which can occur during a
game.

We will be ignoring a few aspects like conduct and ethics of players, but will embed the rules of chess
into our engine, as this effectively forms the backbone of our analysis engine.

## Initial Setup
In [Journal Entry 07 - The Chess Pieces](07%20-%20The%20Chess%20Pieces.md), we covered the initial
setup of the chess pieces on the board.

## Gameplay
The player controlling the white pieces is named "White"; the player controlling the black pieces is
named "Black". White moves first, then players alternate moves. Making a move is *required*; it is not
legal to skip a move. Play continues until a king is checkmated, a player resigns, or a draw is declared,
as explained below. In addition, if the game is being played under a time control, players who exceed
their time limit lose the game.

Which player plays white is determined by a vareity of factors, usually external to the players, so we
need not worry about choosing a side to play for now. Our engine should be able to analyse just as
effectively for both sides.

### Moves
In chess, there are basic moves, capture moves, and special moves.

#### Basic Moves
We covered the basic and capture moves in
[Journal Entry 07 - The Chess Pieces](07%20-%20The%20Chess%20Pieces.md#pieces-and-moves).

#### Castling
Castling is a special move able to be performed by the king, in conjuction with a rook. It consists of 
moving the king two squares towards a rook, then placing the rook on the other side of the king, adjacent
to it. Castling is only permissible if all of the following conditions hold:

* The king and rook involved in castling must not have previously moved;
* There must be no pieces between the king and the rook;
* The king may not currently be in check, nor may the king pass through or end up in a square that is under attack by an enemy piece (though the rook is permitted to be under attack and to pass over an attacked square);
* The king and the rook must be on the same rank

#### En Passant
When a pawn advances two squares from its original square and ends the turn adjacent to a pawn of the
opponent's on the same rank, it may be captured by that pawn of the opponent's, as if it had moved only
one square forward. This capture is only legal on the opponent's next move immediately following the
first pawn's advance.

The diagrams below demonstrate an instance of this: if the white pawn moves from a2 to a4, the black pawn
on b4 can capture it en passant, moving from b4 to a3 while the white pawn on a4 is removed from the
board.

![En Passant](../media/moves/en-passant.png)
> Image Source: https://en.wikipedia.org/wiki/File:Ajedrez_captura_al_paso_del_peon.png

#### Pawn Promotion
If a player advances a pawn to its eighth rank, the pawn is then promoted (converted) to a queen, rook,
bishop, or knight of the same color at the choice of the player (a queen is usually chosen). The choice
is not limited to previously captured pieces. Hence it is theoretically possible for a player to have up
to nine queens or up to ten rooks, bishops, or knights if all of their pawns are promoted.

### Check
A king is *in check* when it is under attack by at least one enemy piece. A piece unable to move because
it would place its own king in check (it is pinned against its own king) may still deliver check to the
opposing player.

A player may not make any move which places or leaves his king in check. The possible ways to get out of
check are:

* Move the king to a square where it is not threatened.
* Capture the threatening piece (possibly with the king).
* Block the check by placing a piece between the king and the opponent's threatening piece.

If it is not possible to get out of check, the king is checkmated and the game is over.

## Recording Moves
From [Journal Entry 03 - The Chess Board](03%20-%20The%20Chess%20Board.md) and
[Journal Entry 07 - The Chess Pieces](07%20-%20The%20Chess%20Pieces.md), we understood how to refer to
squares, ranks and files on the chessboard. The white king starts the game on square e1. The black knight
on b8 can move to a6 or c6.

Moves can be recorded using chess notation. Currently Algebraic Notation seems to be most common. However
our engine should be able to make use of other formats if required. Having a record of moves allows us
replay games or make and unamke moves for analysis. We will dig deeper into this in a while.

## Legality
Any move that is not allowed in chess, according to the rules of chess, is called an illegal move.
If an illegal move is made, it must be taken back as soon as possible and the board should be reset to
the position before the illegal move was made.

Our engine should be able to spot the opponent's illegal moves, and should also never try to play an
illegal move by itself.

## End-Game
The game can primarily end by one of the players winning, or both of them *drawing* with each other.

### Checkmate
If a player's king is placed in check and there is no legal move that player can make to escape check,
then the king is said to be checkmated, the game ends, and that player loses. Unlike other pieces, the
king is never actually captured or removed from the board because checkmate ends the game.

### Resignation
Either player may resign at any time and their opponent wins the game. This normally happens when the
player believes he or she is very likely to lose the game. A player may resign by saying it verbally or
by indicating it on their scoresheet in any of three ways:

1. by writing "resigns",
2. by circling the result of the game, or 
3. by writing "1–0" if Black resigns or "0–1" if White resigns

Tipping over the king also indicates resignation, but it is not frequently used (and should be
distinguished from accidentally knocking the king over). Stopping both clocks is not an indication of
resigning, since clocks can be stopped to call the arbiter. An offer of a handshake is not necessarily a
resignation either, since one player could think they are agreeing to a draw.

For us, as a chess analysis engine, resignation is just going to be an option to output ;)

### Draw

#### Stalemate

### Time-Based (Flag Fall)

> Source for the majority of the material: [Wikipedia](https://en.wikipedia.org/wiki/Rules_of_chess)

## Further Information

* [Rules of Chess](https://en.wikipedia.org/wiki/Rules_of_chess)
* [Castling](https://en.wikipedia.org/wiki/Castling)
* [En Passant](https://en.wikipedia.org/wiki/En_passant)
* [Promotion](https://en.wikipedia.org/wiki/Promotion_(chess))
* [Check](https://en.wikipedia.org/wiki/Check_(chess))
* [Checkmate](https://en.wikipedia.org/wiki/Checkmate)
* [Chess Notation](https://en.wikipedia.org/wiki/Chess_notation)
* [Algebraic Chess Notation](https://en.wikipedia.org/wiki/Algebraic_chess_notation)
