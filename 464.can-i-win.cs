/*
 * @lc app=leetcode id=464 lang=csharp
 *
 * [464] Can I Win

 In the "100 game," two players take turns adding, to a running total, any integer from 1..10. The player who first causes the running total to reach or exceed 100 wins.

What if we change the game so that players cannot re-use integers?

For example, two players might take turns drawing from a common pool of numbers of 1..15 without replacement until they reach a total >= 100.

Given an integer maxChoosableInteger and another integer desiredTotal, determine if the first player to move can force a win, assuming both players play optimally.

You can always assume that maxChoosableInteger will not be larger than 20 and desiredTotal will not be larger than 300.

Example

Input:
maxChoosableInteger = 10
desiredTotal = 11

Output:
false

Explanation:
No matter which integer the first player choose, the first player will lose.
The first player can choose an integer from 1 up to 10.
If the first player choose 1, the second player can only choose integers from 2 up to 10.
The second player will win by choosing 10 and get a total = 11, which is >= desiredTotal.
Same with other integers chosen by the first player, the second player will always win.
 */
public class Solution {
        public bool CanIWin(int maxChoosableInteger, int desiredTotal)
        {
            if (maxChoosableInteger >= desiredTotal)
                return true;

            if ((1 + maxChoosableInteger) * maxChoosableInteger / 2 < desiredTotal)
                return false;

            // return CanWin_1(maxChoosableInteger, desiredTotal, 0, 0, 0);

            Dictionary<int, bool> dic = new Dictionary<int, bool>();
            return CanWin(maxChoosableInteger, desiredTotal, 0, 0, dic);
        }

        private bool CanWin(int maxChoosableInteger, int desiredTotal, int state, int sum, Dictionary<int, bool> dic)
        {
            if(dic.ContainsKey(state))
                return dic[state];

            for (int i = 0; i < maxChoosableInteger; i++)
            {
                if((state & (1 << i)) > 0)
                    continue;

                int newState = state | (1 << i);
                // 选取当前值后，直接能赢
                // 选取当前值后，对方不能取胜，则当前玩家能赢
                if(sum + i + 1 >= desiredTotal || !CanWin(maxChoosableInteger, desiredTotal, newState, sum+i+1, dic))
                {
                    dic[state] = true;
                    return true;
                }
            }
            dic[state] = false;
            return false;
        }

        private bool CanWin_1(int maxChoosableInteger, int desiredTotal, int state, int sum, int player)
        {
            for (int i = 0; i < maxChoosableInteger; i++)
            {
                if((state & (1 << i)) > 0)
                    continue;

                sum += i + 1;

                if (sum >= desiredTotal)
                    return player == 0;

                if (CanWin_1(maxChoosableInteger, desiredTotal, state + (1<< i), sum, (player + 1) % 2))
                    return true;

                sum -= (i + 1);
            }

            return false;
        }

        // for (int i = 1; i <= maxNumber; ++i) {
        //     if (state & (1 << (i - 1))) {  // already used
        //         continue;
        //     }
            
        //     auto new_state = (state | (1 << (i - 1)));
        //     // 选取当前值后，直接能赢
        //     // 选取当前值后，对方不能取胜，则当前玩家能赢
        //     if (sum + i >= total || !helper(new_state, maxNumber, sum + i, total)) {
        //         memo_[state] = true;
        //         return true;
        //     }
        // }
        
        // memo_[state] = false;
        // return false;

}


// √ Accepted
//   √ 54/54 cases passed (96 ms)
//   √ Your runtime beats 93.94 % of csharp submissions
//   √ Your memory usage beats 75 % of csharp submissions (25.2 MB)

