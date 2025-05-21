/*
 * @lc app=leetcode id=440 lang=csharp
 *
 * [440] K-th Smallest in Lexicographical Order
 */

// @lc code=start
public class Solution {
    public int FindKthNumber(int n, int k)
    {
        // 
        int cur = 1;
        int i = 1;

        while (i < k)
        {
            int steps = _Count(cur, n);
            if ( i + steps <= k)
            {
                cur = cur + 1;
                i += steps;
            }
            else
            {
                cur *=10;
                i += 1;
            }
        }
        return cur;


    }
        public int _Count(long _cur, int n)    
        {
            int res = 0;
            long nei = _cur + 1;
            while (_cur <= n)
            {
                res += (int)(Math.Min(nei, n + 1) - _cur);
                _cur *= 10;
                nei *= 10;
            }
            return res;
        }
}
// @lc code=end

