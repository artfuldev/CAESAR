# The Chess Pieces - Covered
In our last journal entry, we got to know about the chess pieces, and how they are related to moves, and
how there are two players, black and white, who have their own sets of pieces that they are only allowed
to move from one square to another on the board.

## Pieces
We created an *IPiece* interface, a *Piece* abstract class, and 6 derived classes from *Piece*, each of
which represent a single piece type. Since pieces vary by move, and moves can only be made by players,
we had to create an infrastructure with IMove and IPlayer interfaces too. We started genetrating moves
too. This was covered in an *add-pieces* branch and was pulled in
[Pull Request #23](https://github.com/kenshinthebattosai/CAESAR/pull/23).

### Unit Tests
We then identified that [Unit Tests were missing for Piece](https://github.com/kenshinthebattosai/CAESAR/issues/24)
and subsequently fixed the problem in [Pull Request #31](https://github.com/kenshinthebattosai/CAESAR/pull/31).

### Refactoring Move Generation
We had a SOLID look at the pieces, and identified that the Piece classes were handling more than one
responsibility. As we have seen, it is very easy to overload a class with responsibilities and not
notice it. In this case, Piece classes not only represented the pieces, but also were responsible to
generate their next moves on the board. [This was an extra responsibility](https://github.com/kenshinthebattosai/CAESAR/issues/25)
and had to be moved out to other classes. We fixed this in [Pull Request #32](https://github.com/kenshinthebattosai/CAESAR/issues/32).

### Continuous Integration and Code Coverage
While working on refactoring move generation, it was identified that
[the solution did not follow DNX projects structure](https://github.com/kenshinthebattosai/CAESAR/issues/26)
and we [fixed that](https://github.com/kenshinthebattosai/CAESAR/commit/7ddf6cec982b4e768d0006c9075e8c3ffe7e0d6a).
By now we had two modules, a considerable amount of files, and some unit tests. This was the time to
start adding continuous integration and code coverage so that as our project becomes more complex, we
would have a better idea of our code coverage and build status. We picked AppVeyor for CI (as it
supported DNX projects) and CodeCov for code coverage. I found them via the Github Integrations
directory.

### Improving Code Coverage
With Codecov and AppVeyor integration, we identified that we had a
[measly code coverage](https://github.com/kenshinthebattosai/CAESAR/issues/30) of 35% and subsequently
fixed that in [Pull Request #36](https://github.com/kenshinthebattosai/CAESAR/pull/36), with some
refactoring.


## Next Steps
Now that we have gained some knowledge about the chess pieces, and their moves, it is time to incorporate
this knowledge into our chess engine. We will write the pieces and moves (of what we know so far), test
our implementation for what we know, look out for best practices, have a SOLID look, and then try to move
on to the next part our journey, the rules of chess.

## Further Information
* [Chess Piece](https://en.wikipedia.org/wiki/Chess_piece)
* [King](https://en.wikipedia.org/wiki/King_(chess))
* [Queen](https://en.wikipedia.org/wiki/Queen_(chess))
* [Rook](https://en.wikipedia.org/wiki/Rook_(chess))
* [Bishop](https://en.wikipedia.org/wiki/Bishop_(chess))
* [Knight](https://en.wikipedia.org/wiki/Knight_(chess))
* [Pawn](https://en.wikipedia.org/wiki/Pawn_(chess))
* [Castling](https://en.wikipedia.org/wiki/Castling)
* [Rules of Chess](https://en.wikipedia.org/wiki/Rules_of_chess)