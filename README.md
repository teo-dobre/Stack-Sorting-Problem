This is a problem I had trouble with in a programming test.

## Description

There are three stacks: A, B and C, that hold crates of different weights. The goal is to sort all of the crates inside the A stack, in descending order of weight (heaviest at the bottom). There are no resctrictions such as you cannot put heavier crates on top of lighter crates. I will simulate the moves I will make on the stacks outside the Solve() method inside these lists, as to keep track of the state of the stacks throughout.

For the original problem, I only got the Solve() method declaration with its parameters. The entire solution must be implemented inside the Solve() method, which is why I did not segment my implementation into different methods. The method must return an array of string that depict the moves needed to be made in order to sort the crates. The format of the strings is the following:

"A B" -> this string signifies moving the top crate in the A stack on top of the B stack. Parsing through the array of strings in this format should result in the sorted A stack.

## Solution

The first step I take is to create lists for the input arrays of the stacks, as they are easier to work with. I did not turn them into stacks as I needed to parse through them and save the index of the heaviest crate.

I then move all the crates from the A stack into the B stack, in order to have it free for the heaviest crate among all of them.

Next, I will search for the heaviest crate inside both the B and C stacks. Depending on which one contains the heavier crate, the following step is to move all of the crates that are on top of it onto the other stack, and then move it onto the A stack. I repeat this until both the B and C stacks contain no more crates. This will result in the final list of moves that will sort all the crates inside the A stack.

## Result

