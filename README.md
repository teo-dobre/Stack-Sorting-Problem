This is a problem I had trouble with in a programming test.

Description

There are three stacks: A, B and C, that hold crates of different weights. The goal is to sort all of the crates inside the A stack, in descending order of weight (heaviest at the bottom). There are no resctrictions such as you cannot put heavier crates on top of lighter crates.

For the original problem, I only got the Solve() method declaration with its parameters. The entire solution must be implemented inside the Solve() method, which is why I did not segment my implementation into different methods. The method must return an array of string that depict the moves needed to be made in order to sort the crates. The format of the strings is the following:

"A B" -> this string signifies moving the top crate in the A stack on top of the B stack. Parsing through the array of strings in this format should result in the sorted A stack.

Solution

