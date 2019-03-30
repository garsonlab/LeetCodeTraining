/*
 * @lc app=leetcode id=278 lang=csharp
 *
 * [278] First Bad Version
 *
 * https://leetcode.com/problems/first-bad-version/description/
 *
 * algorithms
 * Easy (29.21%)
 * Total Accepted:    210.3K
 * Total Submissions: 717.8K
 * Testcase Example:  '5\n4'
 *
 * You are a product manager and currently leading a team to develop a new
 * product. Unfortunately, the latest version of your product fails the quality
 * check. Since each version is developed based on the previous version, all
 * the versions after a bad version are also bad.
 * 
 * Suppose you have n versions [1, 2, ..., n] and you want to find out the
 * first bad one, which causes all the following ones to be bad.
 * 
 * You are given an API bool isBadVersion(version) which will return whether
 * version is bad. Implement a function to find the first bad version. You
 * should minimize the number of calls to the API.
 * 
 * Example:
 * 
 * 
 * Given n = 5, and version = 4 is the first bad version.
 * 
 * call isBadVersion(3) -> false
 * call isBadVersion(5) -> true
 * call isBadVersion(4) -> true
 * 
 * Then 4 is the first bad version. 
 * 
 */
/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl {
    public int FirstBadVersion(int n) {
        if (n <= 1)
            return n;

        int start = 1;
        int end = n;

        while (start != end)
        {
            int mid = (start + 1) / 2 + end / 2;
            if (IsBadVersion(mid))
            {
                if (end == mid)
                {
                    if (end == 1)
                        return 1;
                    if (IsBadVersion(end - 1))
                    {
                        end = end - 1;
                    }
                    else
                    {
                        return end;
                    }
                }
                else
                    end = mid;
            }
            else
            {
                start = mid + 1;
            }

        }

        return start;
    }
}


// √ Accepted
//   √ 22/22 cases passed (36 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 41.67 % of csharp submissions (12.8 MB)


