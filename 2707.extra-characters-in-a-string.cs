/*
 * @lc app=leetcode id=2707 lang=csharp
 *
 * [2707] Extra Characters in a String
 */

// @lc code=start
public class Solution {
    public int MinExtraChar(string s, string[] dictionary)
    {
        //DP
        //HashSet<string> words = new HashSet<string>();
        //foreach (string word in dictionary)
        //{
        //    words.Add(word);
        //}
        HashSet<string> words = dictionary.ToHashSet();
        int n = s.Length;
        int[] dp = new int[n + 1];
        
        for (int i = 0; i < n; i++)
        {
            dp[i + 1] = dp[i] + 1;

            for (int j = 0; j <= i; j++)
            {
                if (words.Contains(s.Substring(j, i - j + 1)))
                {
                    dp[i + 1] = Math.Min(dp[i + 1], dp[j]);
                }
            }
        }
        return dp[n];

    }
}
//https://youtu.be/ONstwO1cD7c?si=oNkO6Ll_CzKpxTAy
//https://leetcode.cn/problems/extra-characters-in-a-string/solutions/2596898/2707-zi-fu-chuan-zhong-de-e-wai-zi-fu-by-7oms/
///Enumerable.ToHashSet 方法
///https://learn.microsoft.com/zh-tw/dotnet/api/system.linq.enumerable.tohashset?view=net-8.0
// @lc code=end

