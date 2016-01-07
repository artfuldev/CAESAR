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

## Considerations
In the path we took, we made some architectural and design decisions. For example, we made an IPiece
interface. This is in line with our SOLID goals. But did we really need separate classes for each piece?
Why did we have an IMovesGenerator interface? By implementing in the way that we did, we accomplished
the following:

##### We created a testable, mockable Piece
Piece is abstract, and we can test the functionalities of Piece by simply writing our own implementation
of Piece. It can be called mocking.
##### We made Pieces SOLID
Piece and every other derived class represents one single piece or a specific piece. In the entire
module, we are exposing only IPiece to the ISquare and IPlayer interfaces. This essentially means we've
written SOLID code.
##### We made testable, mockable MovesGenerators whose implementation can be easily changed without affecting the rest of the pieces 
By injecting an instance of IMovesGenerator into the Piece, we made it easier to change the implementation
of the MovesGenerator we pass to a piece, without affecting the rest of the pieces. We have separate
implementations of IMovesGenerator for each Piece type. So if we need to change the move generation of
one piece type, we could just add a new or modify the exisiting MovesGenerator for the piece type,
with zero effect on any other part of the program. We could test the new move generator in isolation
using unit tests before we inject them into the required Piece.

It is very important for all code to be testable in isolation, so that new implementations can be tested
before being deployed. By making almost all constructors injection based, we can easily have mock
implementations of the interfaces in our tests.

#### Related Discussions
* [Does the Board really follow Single Responsibility Principle?](https://github.com/kenshinthebattosai/CAESAR/issues/16)
* [Comments missing in files](https://github.com/kenshinthebattosai/CAESAR/issues/18)
* [Should the Board be immutable?](https://github.com/kenshinthebattosai/CAESAR/issues/22)
* [Should IMovesGenerator be renamed to IMoveGenerator?](https://github.com/kenshinthebattosai/CAESAR/issues/37)


## Next Steps
Now that we have implemented the Board and Pieces, time to head on to the interesting area of chess
rules. These rules will form the backbone of our chess engine, and we should be very careful about them.
While examining the rules, we'll get to implement the special moves which we've left out from earlier,
as implementing special moves requires a more thorough understanding of the game. As usual, we'll
take a closer look as we proceed to build.

## Further Information
* [Rules of Chess](https://en.wikipedia.org/wiki/Rules_of_chess)