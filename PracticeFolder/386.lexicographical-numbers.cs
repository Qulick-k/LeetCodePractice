/*
 * @lc app=leetcode id=386 lang=csharp
 *
 * [386] Lexicographical Numbers
 */

// @lc code=start
public class Solution {
    public IList<int> LexicalOrder(int n)
    {
        //    
        List<int> rets = new List<int>{1};
        //rets.Add(1);
        int i = 1;

        while (rets.Count < n)
        {
            if (i*10 <= n)
            {
                i = i * 10;
                rets.Add(i);
            }
            else
            {
                while (i + 1 > n || i % 10 == 9)
                {
                    i = i /10;
                }
                i += 1;
                rets.Add(i);
            }
        }
        return rets;
    }
}
//https://www.youtube.com/live/LyBEiGoFw1w?si=Z5-jADGvIjYU1XnM
// @lc code=end

