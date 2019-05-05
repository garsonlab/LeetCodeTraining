/*
 * @lc app=leetcode id=470 lang=csharp
 *
 * [470] Implement Rand10() Using Rand7()

 Given a function rand7 which generates a uniform random integer in the range 1 to 7, write a function rand10 which generates a uniform random integer in the range 1 to 10.

Do NOT use system's Math.random().

 

Example 1:

Input: 1
Output: [7]
Example 2:

Input: 2
Output: [8,4]
Example 3:

Input: 3
Output: [8,1,10]
 

Note:

rand7 is predefined.
Each testcase has one argument: n, the number of times that rand10 is called.
 

Follow up:

What is the expected value for the number of calls to rand7() function?
Could you minimize the number of calls to rand7()?
 */
/**
 * The Rand7() API is already defined in the parent class SolBase.
 * public int Rand7();
 * @return a random integer in the range 1 to 7
 */
public class Solution : SolBase {
    public int Rand10() {
        // if (Rand7() <= 5)
        //     return Rand7();
        // return 7 + (Rand7() - 1) / 2;

        int a=Rand7(), b=Rand7();
        if(a>4&&b<4)
            return Rand10();
        else
            return (a+b)%10+1;
    }
}

// √ Accepted
//   √ 10/10 cases passed (260 ms)
//   √ Your runtime beats 45.45 % of csharp submissions
//   √ Your memory usage beats 75 % of csharp submissions (27.3 MB)

