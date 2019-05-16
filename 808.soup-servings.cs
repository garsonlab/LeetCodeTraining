/*
 * @lc app=leetcode id=808 lang=csharp
 *
 * [808] Soup Servings

 There are two types of soup: type A and type B. Initially we have N ml of each type of soup. There are four kinds of operations:

Serve 100 ml of soup A and 0 ml of soup B
Serve 75 ml of soup A and 25 ml of soup B
Serve 50 ml of soup A and 50 ml of soup B
Serve 25 ml of soup A and 75 ml of soup B
When we serve some soup, we give it to someone and we no longer have it.  Each turn, we will choose from the four operations with equal probability 0.25. If the remaining volume of soup is not enough to complete the operation, we will serve as much as we can.  We stop once we no longer have some quantity of both types of soup.

Note that we do not have the operation where all 100 ml's of soup B are used first.  

Return the probability that soup A will be empty first, plus half the probability that A and B become empty at the same time.

 

Example:
Input: N = 50
Output: 0.625
Explanation: 
If we choose the first two operations, A will become empty first. For the third operation, A and B will become empty at the same time. For the fourth operation, B will become empty first. So the total probability of A becoming empty first plus half the probability that A and B become empty at the same time, is 0.25 * (1 + 1 + 0.5 + 0) = 0.625.
Notes:

0 <= N <= 10^9. 
Answers within 10^-6 of the true value will be accepted as correct.
 */
public class Solution {
    public double SoupServings(int N) {
        int n = (int)Math.Ceiling(N / 25.0);//不足25当25
        double[,] memo = new double[200, 200];
        return N >= 4800 ? 1.0 : f(n, n, memo); //经过严格计算我们知道当N >= 4800之后，返回的概率值与1的差距就小于10 ^ 6了
    }
    double f(int a, int b, double[,] memo)
    {
        if (a <= 0 && b <= 0)
        {
            return 0.5;
        }
        if (a <= 0)
        {
            return 1;
        }
        if (b <= 0)
        {
            return 0;
        }
        if (memo[a,b] > 0)
        {
            return memo[a,b];
        }
        memo[a,b] = 0.25 * (f(a - 4, b, memo) + f(a - 3, b - 1, memo) + f(a - 2, b - 2, memo) + f(a - 1, b - 3, memo));
        return memo[a,b];
    }
}

// 如果我们定义f(a, b)表示有a毫升的A和b毫升的B时符合条件的概率，那么容易知道递推公式就是：f(a, b) = 0.25 * (f(a - 4, b) + f(a - 3, b - 1) + f(a - 2, b - 2) + f(a - 1, b - 3))，其中平凡条件是：

// 当a < 0 && b < 0时，f(a, b) = 0.5，表示A和B同时用完；

// 当a <= 0 && b > 0时，f(a, b) = 1.0，表示A先用完；

// 当a > 0 && b<= 0时，f(a, b) = 0.0，表示B先用完。

// 所以当遇到这三种情况的时候，我们直接返回对应的平凡值
// --------------------- 
// 作者：魔豆Magicbean 
// 来源：CSDN 
// 原文：https://blog.csdn.net/magicbean2/article/details/79851345 
// 版权声明：本文为博主原创文章，转载请附上博文链接！
// √ Accepted
//   √ 41/41 cases passed (48 ms)
//   √ Your runtime beats 66.67 % of csharp submissions
//   √ Your memory usage beats 20 % of csharp submissions (25.5 MB)
