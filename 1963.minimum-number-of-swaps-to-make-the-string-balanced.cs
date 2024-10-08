/*
 * @lc app=leetcode id=1963 lang=csharp
 *
 * [1963] Minimum Number of Swaps to Make the String Balanced
 */

// @lc code=start
public class Solution {
    public int MinSwaps(string s)
    {
        /// ][ => 1
        /// ]][[ => 1
        /// ]]][[[ => []][[] => [][][] => 2
        /// ]]]][[[[ => []]][[[] => [][][] => 2
        /// 5 pairs => 3
        /// 6 pairs => 3
        /// >>>> (n+1) / 2
        int cur = 0;
        int res = 0;

        foreach(char c in s)
        {
            cur += (c == ']' ? 1 : -1);
            res = Math.Max(res, cur);
        }
        return (res + 1) / 2 ;
    }
}
//參考https://youtu.be/3YDBT9ZrfaU?si=gOoMT2L7hO0t8dMK
//參考https://www.youtube.com/live/L7T-7NPgPW0?si=5A2CUXrS1TwUnXOH
// @lc code=end

