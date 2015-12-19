#The Chess Board
The Chess Board is a board with an 8x8 grid of alternating light and dark squares. We can have an
image of the board for easier understanding:

![Chess Board](media/chess-board.png)

Since our images follow the blue-white scheme, I thought that would be a nice fit. The blue squares
represent the dark squares while the light grey ones represent the light squares.

In the chess board, we have some unique notations and nomenclature that we must familiarize
ourselves with. The board is made up of alternating *light* and *dark* *square*s, which are the
cells of the gird.

##Ranks and Files
We can see that the rows and columns have numbers and letters next to them, as a notation or a
way to name or reference them. In the chess board, the rows are called *rank*s and the columns
are called *file*s. The ranks are numbered and the files are alphabetized. We can see that are 8
ranks from 1 through 8 and 8 files from a through h.

We can reference them using the numbering and alphabets. As an example, the second *rank* from the
bottom can be referenced as *rank 2* or *2nd rank*. Similarly the second *file* from the right can
be referred to as the *g file*. This is important. We call them rank numbers and file names.

![Chess Board](media/g2-square.png)

##Squares
Just as in a grid or table, rows and columns intersect at cells, the ranks and files of a chessboard
intersect at *square*s. A square can be referred to on a chess board by rederring to the file and
rank to which it belongs. Let's take an example. The square on the board second from bottom and
second from right, belongs to the *g file* and *rank 2*. It is therefore referred to as the *g2
square*.

Try pointing out the *e4*, *d5*, and *b7* squares to get familiar with this reference. To recap, a
square is referred to by combining the file name and the rank number. And the chess board contains 64
squares, ranging from a1 through a8, b1 through b8, and likewise, to h1 through h8.

##Representations
There are several representations of a chess board in computers. But we are going to build our own
representation from scratch with what we know, and keep refining it until we reach a point where it
encompasses everything needed for our requirement. This method will also pave the way to learning
about:

* proper thinking
* sticking to what we know
* avoiding premature optimization
* refactoring big changes without getting caught up, etc.

And the best part is that we will have a lot less hiccups going forward, as we are using SOLID
principles. As we pick on choices, we will investigate what else we could have done, and why we have
chosen/avoided certain design approaches. It is through this that we can understand how good software
and code materializes. And we will do it together.

##Further Information
* [Chessboard](https://en.wikipedia.org/wiki/Chessboard)
* [Board Representation](https://en.wikipedia.org/wiki/Board_representation_(chess))

##Code
We have [added some code](https://github.com/kenshinthebattosai/CAESAR/commit/5634a2873ae4844767d07d996a1a0599d8f96fcf),
following this discussion, based on what we know so far.

Keeping in line with [SOLID principles](), we code against abstractions and not concretions.

Hence we have:

An *[IBoard](../CAESAR/CAESAR.Chess/IBoard.cs)* is made up of *IRank*s, *IFile*s and *ISquare*s.
Its *IRank*s, *IFile*s and *ISquare*s can be obtained by rank numbers or rank indices, file names
or file indices, and square names, respectively.

An *[IRank](../CAESAR/CAESAR.Chess/IRank.cs)* is a *ReadOnlyCollection* of *ISquare*s, belongs to an
*IBoard* in which it is designated a Rank *Number* from `1` to `8`. The selection of squares from the
board that belongs to the rank is decided based on the rank number. All of this is encapsulated by the
*[Rank](../CAESAR/CAESAR.Chess/Implementation/Rank.cs)* class.

An *[IFile](../CAESAR/CAESAR.Chess/IFile.cs)* is also a *ReadOnlyCollection* of *ISquare*s, belongs
to an *IBoard* in which it is designated a *Name* which is made up of a single character from `a` to
`h`. The selection of squares from the board that belongs to the file is decided based on the file
name. All of this is encapsulated by the *[File](../CAESAR/CAESAR.Chess/Implementation/File.cs)*
class.

An *[ISquare](../CAESAR/CAESAR.Chess/ISquare.cs)* is either light or dark, belongs to an *IBoard*, an
*IFile* and an *IRank*. Its name is calculated as the combination of the *IFile*'s name and the
*IRank*'s number. All this is encapsulated by the
*[Square](../CAESAR/CAESAR.Chess/Implementation/Square.cs)* class.

A default *IBoard* construction is present in the
*[Board](../CAESAR/CAESAR.Chess/Implementation/Board.cs)* class, it is the default implementation.
We also print a board using a console application in order to test the board generation.
We will shortly be adding unit tests to test whether the current Board Representation satisfies the
criteria of whatever we have learnt so far. Even though we are fairly sure by listing out just as we
did now, it never hurts to be more sure with actual unit tests. Who knows, we might find out a bug or
two before we even get started, saving some time!
