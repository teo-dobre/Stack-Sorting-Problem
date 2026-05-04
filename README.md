This is a problem I had trouble with in a programming test.

## Description

This problem involves three stacks, A, B, and C, which store crates with different weights. The objective is to move all crates into stack A, sorted in descending order (heaviest at the bottom, lightest at the top).

The only allowed operation is moving the top crate from one stack to another. There are no restrictions on placement (i.e., heavier crates can be placed on top of lighter ones).

The Solve() method receives three arrays representing the initial state of the stacks and must return a sequence of moves. Each move is represented as a string in the following format:

'''
"A B"
'''

This indicates moving the top crate from stack A to stack B. Applying all returned moves sequentially should result in stack A being correctly sorted.

For testing and validation purposes, I simulate the execution of these moves outside the Solve() method to track the state of the stacks after each operation.

Due to the constraints of the original problem, the entire implementation is contained within the Solve() method.

## Solution

The first step is to convert the input arrays into lists, allowing indexed access when searching for the heaviest crate.

Next, all crates from stack A are moved to stack B, freeing stack A to be rebuilt in sorted order.

The algorithm then repeatedly identifies the heaviest crate across stacks B and C. Once found, any crates above it are moved to the auxiliary stack to expose it. The heaviest crate is then moved to stack A.

This process is repeated until both B and C are empty. Since the largest remaining crate is always moved next, stack A is built in descending order.

## Result

The algorithm correctly sorts the crates into stack A across all tested scenarios, including edge cases such as empty stacks and duplicate values.

The current approach is focused on minimizing the overall number of moves between the three stacks, as opposed to algorithm efficiency.

One identified improvement is avoiding unnecessary operations when stack A is already sorted and contains all crates (as seen in Test 2). Adding an early check for this condition would eliminate redundant moves and improve efficiency.
