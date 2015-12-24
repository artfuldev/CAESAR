# Testing The Board

In the [last journal entry](03%20-%20The%20Chess%20Board.md), we got to learn about the chess board,
and its many features, including ranks, files, and squares and how to reference them. We then attempted
to construct a representation of the board. We then needed to test it.

Since we are writing a DNX (cross platform .NET) app, the easiest testing framework available right now
is [xUnit.NET](http://xunit.github.io/) which is a robust framework in itself, so we have no problems
choosing it for our testing needs.

It is to be noted that even though the Libararies and the DNX console app targets a variety of platforms
including .NET Framework, the unit tests class library only targets DNX. This is because xUnit.NET for
DNX does not support other platforms, and, going forward, it's better to test against DNX, which evolves
at a faster pace.

## Facts and Theories
xUnit.NET has this wonderful concepts of *facts* and *theories*, which I love. In their own words,

> **Facts** are tests which are always true. They test invariant conditions.

> **Theories** are tests which are only true for a particular set of data.

We will be treating our knowledge as facts and theories as we construct our tests on our representation
so far. The facts and theories will also evolve with our knowledge and understanding, as we go deeper
and uncover more concepts related to the wonderful journey we are are now a part of.


## Test Structure and Inclusions
What we needed to test was that the [Board](../CAESAR/CAESAR.Chess/Implementation/Board.cs) constructed
by us satisfied whatever we knew about the chess board, from the previous journal entry. It mnight seem
like a recap, but one which will serve us well and save us a lot of headaches later. Keep in mind that
we will also need to add proper tests for Squares, Ranks and Files by themselves, even though they will
be constructor and "set" tests.

### Board
- [x] The Board is made up of a total of 8 Files (Fact)
- [x] The *n*th File in a Board is named *x* (Theory) eg., `1`st file is named `a` file
- [x] The Board is made up of a total of 8 Ranks (Fact)
- [x] The *n*th Rank in a Board is numbered *n* (Theory) eg., `1`st rank is numbered as rank `1`
- [x] The Board is made up of a total of 64 Squares (Fact)
- [x] The *n*th Square in a Board is named *x* (Theory) eg., `1`st square is named `a1` square
- [x] The *x* square in a Board is a light square, or a dark square (Theories) eg., `a1` square is dark
- [x] The Board is made up of alternating light and dark squares (Fact)
- [x] The *xn* Square belongs to *x* File and *n* Rank (Theory) eg., `a1` square belongs to `a` file and
rank `1`.

### Square
- [x] A Square cannot be constructed without a reference to a Board (Fact)
- [x] A Square contains a reference to its Board (Fact)
- [x] A Square can be queried for its lightness (and darkness) (Fact)
- [x] A Square cannot be both dark and light at the same time (Fact)
- [x] A Square's string representation is its name ;) (Fact)
- [x] *A Board's Square* (a Square from Board.Squares) can be queried for its File (Fact)
- [x] *A Board's Square* can be queried for its Rank (Fact)
- [x] *A Board's Square* can be queried for its Name (Fact)

### File
- [ ] A File cannot be constructed without a reference to a Board (Fact)
- [ ] A File contains a reference to its Board (Fact)
- [ ] A File cannot be named anything other than from a to h (Theory) 
- [ ] A File can be queried for its name (Fact)
- [ ] A File can be queried for its squares (Fact)
- [ ] A File's string representation is its name ;) (Fact)

### Rank
- [ ] A Rank cannot be constructed without a reference to a Board (Fact)
- [ ] A Rank contains a reference to its Board (Fact)
- [ ] A Rank cannot be numbered anything other than from 1 to 8 (Theory) 
- [ ] A Rank can be queried for its number (Fact)
- [ ] A Rank can be queried for its squares (Fact)
- [ ] A Rank's string representation is its number ;) (Fact)

## Further Information
* [Chessboard](https://en.wikipedia.org/wiki/Chessboard)
* [Board Representation](https://en.wikipedia.org/wiki/Board_representation_(chess))
* [Previous Journal Entry](03%20-%20The%20Chess%20Board.md)