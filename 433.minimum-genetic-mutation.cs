/*
 * @lc app=leetcode id=433 lang=csharp
 *
 * [433] Minimum Genetic Mutation

 A gene string can be represented by an 8-character long string, with choices from "A", "C", "G", "T".

Suppose we need to investigate about a mutation (mutation from "start" to "end"), where ONE mutation is defined as ONE single character changed in the gene string.

For example, "AACCGGTT" -> "AACCGGTA" is 1 mutation.

Also, there is a given gene "bank", which records all the valid gene mutations. A gene must be in the bank to make it a valid gene string.

Now, given 3 things - start, end, bank, your task is to determine what is the minimum number of mutations needed to mutate from "start" to "end". If there is no such a mutation, return -1.

Note:

Starting point is assumed to be valid, so it might not be included in the bank.
If multiple mutations are needed, all mutations during in the sequence must be valid.
You may assume start and end string is not the same.
 

Example 1:

start: "AACCGGTT"
end:   "AACCGGTA"
bank: ["AACCGGTA"]

return: 1
 

Example 2:

start: "AACCGGTT"
end:   "AAACGGTA"
bank: ["AACCGGTA", "AACCGCTA", "AAACGGTA"]

return: 2
 

Example 3:

start: "AAAAACCC"
end:   "AACCCCCC"
bank: ["AAAACCCC", "AAACCCCC", "AACCCCCC"]

return: 3
 */
public class Solution {
    public int MinMutation(string start, string end, string[] bank) {
        Queue<int> queue = new Queue<int>();
        int[] visited = new int[bank.Length];
        
        queue.Enqueue(-1);

        while (queue.Count > 0)
        {
            var idx = queue.Dequeue();
            string str = idx < 0? start : bank[idx];
            int mut = idx < 0? 0 : visited[idx];

            for (int i = 0; i < bank.Length; i++)
            {
                if(visited[i] > 0)
                    continue;
                
                int s = 0;
                for (int j = 0; j < 8; j++)
                {
                    if(str[j] != bank[i][j])
                        s++;
                }

                if(s == 1) {
                    visited[i] = mut+1;
                    queue.Enqueue(i);

                    if(bank[i] == end)
                        return visited[i];
                }
            }
        }

        return -1;
    }
}


// √ Accepted
//   √ 14/14 cases passed (88 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (22 MB)

