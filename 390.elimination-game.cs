/*
 * @lc app=leetcode id=390 lang=csharp
 *
 * [390] Elimination Game

 There is a list of sorted integers from 1 to n. Starting from left to right, remove the first number and every other number afterward until you reach the end of the list.

Repeat the previous step again, but this time from right to left, remove the right most number and every other number from the remaining numbers.

We keep repeating the steps again, alternating left to right and right to left, until a single number remains.

Find the last number that remains starting with a list of length n.

Example:

Input:
n = 9,
1 2 3 4 5 6 7 8 9
2 4 6 8
2 6
6

Output:
6
 */
public class Solution {
    public int LastRemaining(int n) {
        return n == 1? 1 : 2*Remaining(n/2);
    }

    private int Remaining(int n) {
        if(n == 1)
            return 1;
        return n%2==1? 2*LastRemaining(n/2) : 2*LastRemaining(n/2)-1;
    }
}

// 题目要求一开始从左删，然后再从右删，如此往复……我们这里先构造一个辅助函数R，表示把1..n这些数一开始是从右开始删再从左开始删如此往复，最后剩下的数，用R(n)来表示。 有了辅助函数R，我们发现当第一次从左到右删一遍之后剩下的都是2 4 6..这些偶数。如果我们把这些偶数全部除以2，那么这些数就变成了1 2 3..。此时我们对1 2 3...这k个数运用R(k)，就能得到从右开始删，最后剩下的那个数。而这个值是我们通过除以2得来的，因此最终的结果是2*R(n/2)

// 那怎么来求R(n)呢？其实也一样，不过要分情况讨论：

// 如果n是奇数：1 2 3 4 5 6 7，从右开始删，最后剩下的全是偶数 2 4 6。此时把所有偶数再除以2又变成123了，此时刚好又要从左开始删，这不就是原问题的相同子问题吗？所以R(7)=2*last_remaining(7/2)
// 如果n是偶数：1 2 3 4 5 6，从右开始删，最后剩下全是奇数 1 3 5。此时没法直接除以2构造成123..这样的情况，但是我们可以把每个数先加1再除以2，得到(1+1)/2, (3+1)/2, (5+1)/2 => 1,2,3，此时又变成原问题的相同子问题了。只不过，当我们求得last_remaining(3)时，这个数是原数+1 再/2得到，所以R(n) = 2*last_remaining(n/2) -1 所以：


// √ Accepted
//   √ 3377/3377 cases passed (48 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (13.4 MB)

