/*
 * @lc app=leetcode id=207 lang=csharp
 *
 * [207] Course Schedule
 *
 * https://leetcode.com/problems/course-schedule/description/
 *
 * algorithms
 * Medium (37.27%)
 * Total Accepted:    203.7K
 * Total Submissions: 545.5K
 * Testcase Example:  '2\n[[1,0]]'
 *
 * There are a total of n courses you have to take, labeled from 0 to n-1.
 * 
 * Some courses may have prerequisites, for example to take course 0 you have
 * to first take course 1, which is expressed as a pair: [0,1]
 * 
 * Given the total number of courses and a list of prerequisite pairs, is it
 * possible for you to finish all courses?
 * 
 * Example 1:
 * 
 * 
 * Input: 2, [[1,0]] 
 * Output: true
 * Explanation: There are a total of 2 courses to take. 
 * To take course 1 you should have finished course 0. So it is possible.
 * 
 * Example 2:
 * 
 * 
 * Input: 2, [[1,0],[0,1]]
 * Output: false
 * Explanation: There are a total of 2 courses to take. 
 * To take course 1 you should have finished course 0, and to take course 0 you
 * should
 * also have finished course 1. So it is impossible.
 * 
 * 
 * Note:
 * 
 * 
 * The input prerequisites is a graph represented by a list of edges, not
 * adjacency matrices. Read more about how a graph is represented.
 * You may assume that there are no duplicate edges in the input
 * prerequisites.
 * 
 * 
 */
public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        List<int>[] dics = new List<int>[numCourses];
        foreach (var prerequisite in prerequisites)
        {
            if(dics[prerequisite[0]] == null)
                dics[prerequisite[0]] = new List<int>();
            dics[prerequisite[0]].Add(prerequisite[1]);
        }


        int[] course = new int[numCourses];
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < numCourses; i++)
        {
            if(course[i] != 0)
                continue;

            stack.Clear();
            stack.Push(i);

            while (stack.Count > 0)
            {
                var c = stack.Peek();
                if (dics[c] == null)
                {
                    course[c] = 1;
                    stack.Pop();
                    continue;
                }

                bool add = false;
                foreach (var n in dics[c])
                {
                    if(course[n] == 1)
                        continue;

                    if (stack.Contains(n))
                        return false;

                    stack.Push(n);
                    add = true;
                }

                if (!add)
                {
                    while (stack.Count > 0)
                    {
                        var a = stack.Pop();
                        course[a] = 1;
                    }
                }
            }
        }

        return true;
    }
}

// √ Accepted
//   √ 42/42 cases passed (128 ms)
//   √ Your runtime beats 84.26 % of csharp submissions
//   √ Your memory usage beats 89.47 % of csharp submissions (27.5 MB)

