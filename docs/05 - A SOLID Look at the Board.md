# A SOLID Look at the Board

Now that we have come so far with some knowledge, some ideas, interface and class definitions, and unit
tests, it's time to have a review. Having timely reviews after every module of code we implement, helps
us maintain our track and scope. Our initial designs may sometimes need revision even though they fit
the job. It is merely to realign the solution to our requirements, in case our implementation suffers
from any unintentional deviation from scope.

So far, we have implemented a chess board using what we know: Ranks, Files, Squares, and ways to
reference them. We have implemented unit tests to make sure the code works as we intend it to. But our
scope includes building a good software architecture with SOLID principles and coding best practices.
Now that we have completed a module (Board Representation) with what we know, we are about to review
the implementation. As we will have few classes and integrations between modules, reviewing at these
intervals will save a lot of time going forward.


## What is SOLID?

In computer programming, SOLID is a mnemonic acronym for the five basic principles of object-oriented
programming and design. The principles, when applied together, intend to make it more likely that a
programmer will create a system that is easy to maintain and extend over time. The principles of SOLID
are guidelines that can be applied while working on software to remove code smells by causing the
programmer to refactor the software's source code until it is both legible and extensible. It is part of
an overall strategy of agile and adaptive programming.

Initial|Stands for|Concept
-------|----------|-------
S|SRP|Single Responsibility Principle
O|OCP|Open/Closed Principle
L|LSP|Liskov Substitution Principle
I|ISP|Interface Segregation Principle
D|DIP|Dependency Inversion Principle

>**Single Responsibility Principle**
>a class should have only a single responsibility (i.e. only one potential change in the software's specification should be able to affect the specification of the class)

>**Open/Closed Principle**
>software entities ... should be open for extension, but closed for modification.

>**Liskov Substitution Principle**
>objects in a program should be replaceable with instances of their subtypes without altering the correctness of that program.

>**Interface Segregation Principle**
>many client-specific interfaces are better than one general-purpose interface.

>**Dependency Inversion Principle**
>one should 'Depend upon Abstractions. Do not depend upon concretions.'

I would recommend getting familiar with these principles for anyone developing any piece of code, but
you can also just follow along and have a fun ride as we will be discussing these a lot at different
times throughout oour journey.

Source: [Wikipedia](https://en.wikipedia.org/wiki/SOLID_(object-oriented_design))

## Is our Board Representation SOLID?
If we can examine the module we just completed, we can see that there are 4 interfaces and 4
implementations that encapsulate our requirement and knowledge. To these we can apply SOLID tests to see
just how SOLID a module we have built so far.

### Square : ISquare
Principle|Followed?|Comments
---------|------|--------
S|No|The single responsibility of an ISquare/Square is to represent a square on the chessboard. While ISquare follows SRP, the Square class doesn't. Its lightness is defined on construction, but the ranks and files to which it belongs, along with the name, are calculated from by the Square class using the Board reference that is passed. These are separate responsibilities and must be moved outside the Square class.
O|Yes|ISquare/Square is open for extension, but closed for modficiation.
L|Yes|ISquare/Square is immutable, so we have satisfied LSP.
I|Yes|We have provided ISquare to IFile, IRank and IBoard clients, with consistency and minimum necessary information
D|Yes|We have used abstractions like interfaces IRank, IFile and IBoard, over concretions like classes in our properties.

### Rank : IRank
Principle|Followed?|Comments
---------|------|--------
S|No|The single responsibility of an IRank/Rank is to represent a rank on the chessboard. But in our implmentation the Rank class determines the ISquares it holds. Determining the squares for this rank to hold is a separate responsibility and must be moved out of the Rank class.
O|Yes|IRank/Rank is open for extension, but closed for modification.
L|Yes|IRank/Rank is immutable, so we have satisfied LSP.
I|Yes|We have provided IRank to ISquare and IBoard clients, with consistency and minimum necessary information
D|Yes|We have used an abstraction, the interface ISquare, over concretions.

### File : IFile
Principle|Followed?|Comments
---------|------|--------
S|No|The single responsibility of an IFile/File is to represent a rank on the chessboard. But in our implmentation the File class determines the ISquares it holds. Determining the squares for this file to hold is a separate responsibility and must be moved out of the File class.
O|Yes|IFile/File is open for extension, but closed for modification.
L|Yes|IFile/File is immutable, so we have satisfied LSP.
I|Yes|We have provided IFile to ISquare and IBoard clients, with consistency and minimum necessary information
D|Yes|We have used an abstraction, the interface ISquare, over concretions.

### Board : IBoard
Principle|Followed?|Comments
---------|------|--------
S|Yes|The single responsibility of an IBoard/Board is to represent a chessboard in its entirety. It provides us with capapbilities to query the board for squares, files, and ranks, as we need them.
O|Yes|IBoard/Board is open for extension, but closed for modficiation.
L|Yes|IBoard/Board is immutable, so we have satisfied LSP.
I|Yes|We have provided IBoard to IFile, IRank and ISquare clients, with consistency and minimum necessary information
D|Yes|We have used abstractions like interfaces IRank, IFile and ISquare, over concretions like classes in our properties.


## What do we do now?
So, we have learned that we missed a few things. We overloaded the File, Rank and Square classes with
responsibilties, without even realizing it. This is why a review helps. Now that we know that we have
some problems, it's time to fix them and move ahead.

As we were reviewing the SOLID application to our model, I just noticed that we haven't gotten through
with all of our requirements just yet. While it is true that once we test Board, we have 8 ranks, 8
files and 64 squares, it isn't apparent in the IBoard interface. We should fix this. This will require
a decent amount of refactoring, but our goal is to get it right, so on we go. In the next journal entry
we will list the changes the current module has to go through, discuss ways, and pick the best and start
coding.


## Further Information

* [SOLID Principles](https://en.wikipedia.org/wiki/SOLID_(object-oriented_design))
* [Single Responsibility Principle](https://en.wikipedia.org/wiki/Single_responsibility_principle)
* [Open/Closed Principle](https://en.wikipedia.org/wiki/Open/closed_principle)
* [Liskov Substitution Principle](https://en.wikipedia.org/wiki/Liskov_substitution_principle)
* [Interface Segregation Principle](https://en.wikipedia.org/wiki/Interface_segregation_principle)
* [Dependency Inversion Principle](https://en.wikipedia.org/wiki/Dependency_inversion_principle)