/*
 * @lc app=leetcode id=386 lang=csharp
 *
 * [386] Lexicographical Numbers

 Given an integer n, return 1 - n in lexicographical order.

For example, given 13, return: [1,10,11,12,13,2,3,4,5,6,7,8,9].

Please optimize your algorithm to use less time and space. The input size may be as large as 5,000,000.
 */
public class Solution {
    public IList<int> LexicalOrder(int n) {
        List<int> list = new List<int>();
        for (int i = 1; i < 10; i++)//排序第一位从1开始
        {
            GetOrder(list, n, i);
        }
        return list;
    }

    private void GetOrder(List<int> list, int n, int target) {
        if(target > n)
            return;
        
        list.Add(target);
        for (int i = 0; i < 10; i++)
        {
            GetOrder(list, n, target*10+i);
        }
    }
}
// √ Accepted
//   √ 26/26 cases passed (236 ms)
//   √ Your runtime beats 88.1 % of csharp submissions
//   √ Your memory usage beats 60 % of csharp submissions (30.3 MB)

