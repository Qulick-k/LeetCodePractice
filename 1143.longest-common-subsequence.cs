/*
 * @lc app=leetcode id=1143 lang=csharp
 *
 * [1143] Longest Common Subsequence
 */

// @lc code=start
public class Solution {
    public int LongestCommonSubsequence(string text1, string text2)
    {
        //使用多維動態規劃
        //使用Bottom Up，由右下回算到左上的動態規劃
        //記得設置比text1、text2多長1個單位的陣列
        int[,] dp = new int[text1.Length + 1, text2.Length + 1];
        
        
        for (int i = text1.Length - 1; i >=0; i--)
        {
            for (int j = text2.Length - 1; j >= 0 ; j--)
            {
                if ( text1[i] == text2[j]) 
                {
                    dp[i, j] = 1 + dp[i+1, j+1]; //再第一輪比較時，一定會比較到比text1、text2多1單位。也是為何要把dp陣列長度多增加1的緣故
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i+1, j], dp[i, j+1]);
                }
            }
        }
        return dp[0, 0];
    }
}
// @lc code=end

