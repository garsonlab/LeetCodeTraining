/*
 * @lc app=leetcode id=950 lang=csharp
 *
 * [950] Reveal Cards In Increasing Order

 In a deck of cards, every card has a unique integer.  You can order the deck in any order you want.

Initially, all the cards start face down (unrevealed) in one deck.

Now, you do the following steps repeatedly, until all cards are revealed:

Take the top card of the deck, reveal it, and take it out of the deck.
If there are still cards in the deck, put the next top card of the deck at the bottom of the deck.
If there are still unrevealed cards, go back to step 1.  Otherwise, stop.
Return an ordering of the deck that would reveal the cards in increasing order.

The first entry in the answer is considered to be the top of the deck.

 

Example 1:

Input: [17,13,11,2,3,5,7]
Output: [2,13,3,11,5,17,7]
Explanation: 
We get the deck in the order [17,13,11,2,3,5,7] (this order doesn't matter), and reorder it.
After reordering, the deck starts as [2,13,3,11,5,17,7], where 2 is the top of the deck.
We reveal 2, and move 13 to the bottom.  The deck is now [3,11,5,17,7,13].
We reveal 3, and move 11 to the bottom.  The deck is now [5,17,7,13,11].
We reveal 5, and move 17 to the bottom.  The deck is now [7,13,11,17].
We reveal 7, and move 13 to the bottom.  The deck is now [11,17,13].
We reveal 11, and move 17 to the bottom.  The deck is now [13,17].
We reveal 13, and move 17 to the bottom.  The deck is now [17].
We reveal 17.
Since all the cards revealed are in increasing order, the answer is correct.
 

Note:

1 <= A.length <= 1000
1 <= A[i] <= 10^6
A[i] != A[j] for all i != j
 */
public class Solution {
    public int[] DeckRevealedIncreasing(int[] deck)
    {
        Array.Sort(deck);
        Queue<int> queue = new Queue<int>();
        
        int[] ans = new int[deck.Length];
        int idx = 0;
        for (int i = 0; i < deck.Length; i++)
        {
            if (i % 2 == 0)
                ans[i] = deck[idx++];
            else
                queue.Enqueue(i);
        }

        if (queue.Count > 0 && deck.Length % 2 == 1)
        {
            queue.Enqueue(queue.Dequeue());
        }

        while (queue.Count > 0)
        {
            int t = queue.Dequeue();
            ans[t] = deck[idx++];

            if (queue.Count > 0)
            {
                queue.Enqueue(queue.Dequeue());
            }
        }

        return ans;
    }

    public int[] DeckRevealedIncreasing_t2(int[] deck) {
        Array.Sort(deck);
        Queue<int> queue = new Queue<int>();

        for (int i = 0; i < deck.Length; i++)
        {
            queue.Enqueue(deck[deck.Length - i - 1]);
            if (i == deck.Length - 1) break;
            int poll = queue.Dequeue();
            queue.Enqueue(poll);
        }
        int[] a = new int[deck.Length];
        for (int i = a.Length - 1; i >= 0; i--)
        {
            a[i] = queue.Dequeue();
        }

        return a;
    }
}

// √ Accepted
//   √ 32/32 cases passed (264 ms)
//   √ Your runtime beats 48.57 % of csharp submissions
//   √ Your memory usage beats 75 % of csharp submissions (29.7 MB)


// √ Accepted
//   √ 32/32 cases passed (260 ms)
//   √ Your runtime beats 56.19 % of csharp submissions
//   √ Your memory usage beats 43.42 % of csharp submissions (29.8 MB)
