/*
 * @lc app=leetcode id=901 lang=csharp
 *
 * [901] Online Stock Span

 Write a class StockSpanner which collects daily price quotes for some stock, and returns the span of that stock's price for the current day.

The span of the stock's price today is defined as the maximum number of consecutive days (starting from today and going backwards) for which the price of the stock was less than or equal to today's price.

For example, if the price of a stock over the next 7 days were [100, 80, 60, 70, 60, 75, 85], then the stock spans would be [1, 1, 1, 2, 1, 4, 6].

 

Example 1:

Input: ["StockSpanner","next","next","next","next","next","next","next"], [[],[100],[80],[60],[70],[60],[75],[85]]
Output: [null,1,1,1,2,1,4,6]
Explanation: 
First, S = StockSpanner() is initialized.  Then:
S.next(100) is called and returns 1,
S.next(80) is called and returns 1,
S.next(60) is called and returns 1,
S.next(70) is called and returns 2,
S.next(60) is called and returns 1,
S.next(75) is called and returns 4,
S.next(85) is called and returns 6.

Note that (for example) S.next(75) returned 4, because the last 4 prices
(including today's price of 75) were less than or equal to today's price.
 

Note:

Calls to StockSpanner.next(int price) will have 1 <= price <= 10^5.
There will be at most 10000 calls to StockSpanner.next per test case.
There will be at most 150000 calls to StockSpanner.next across all test cases.
The total time limit for this problem has been reduced by 75% for C++, and 50% for all other languages.
 */
public class StockSpanner {

    private List<int> list;
        private List<int> day;
        public StockSpanner()
        {
            list = new List<int>();
            day = new List<int>();
        }

        public int Next(int price)
        {
            //list.Add(price);

            //if (list.Count == 1)
            //{
            //    day.Add(1);
            //    return 1;
            //}
            //else
            //{
            //    int res = 1;
            //    if (price > list[list.Count - 2])
            //    {
            //        res += day[day.Count - 1];

            //        int pre = list.Count - 1 - res;
            //        if (pre >= 0 && price > list[pre])
            //            res += day[pre];
            //    }
            //    day.Add(res);
            //    return res;
            //}


            list.Add(price);
            int len = list.Count;
            int ret = 1;
            while (len - ret - 1 >= 0 && price >= list[len - ret - 1])
            {
                ret = ret + day[len - ret - 1];
            }
            day.Add(ret);
            return ret;
        }
}

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */


//  √ Accepted
//   √ 99/99 cases passed (452 ms)
//   √ Your runtime beats 45 % of csharp submissions
//   √ Your memory usage beats 65.63 % of csharp submissions (49.3 MB)

