/*
 * @lc app=leetcode id=2901 lang=csharp
 *
 * [2901] Longest Unequal Adjacent Groups Subsequence II
 */

// @lc code=start
public class Solution
{
    public IList<string> GetWordsInLongestSubsequence(string[] words, int[] groups)
    {
        //use brute dp
        // 3 Requirement
        //兩個word帶的groups數值，必須各不相同
        //兩個word的字元長度，必須相同
        //兩個word的漢明距離，必須為1  ex:bab跟cab，他們只有第一個字元不同剩下都為ab，所以漢明距離為1
        int n = words.Length;
        int[] dp = new int[n]; //dp[i] = length of longest valid subsequence ending at i
        int[] prev = new int[n]; //prev[i] index of previous word in the sequence
        Array.Fill(dp, 1);   //assigns value 1 to each element of the dp array
        Array.Fill(prev, -1);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (groups[i] != groups[j] && //符合group值不同
                    words[i].Length == words[j].Length && //符合字串長度相同                    
                    HammingDistance(words[i], words[j]) == 1) //符合漢明距離為1
                {
                    if (dp[j] + 1 > dp[i])
                    {
                        dp[i] = dp[j] + 1;
                        prev[i] = j;
                    }
                }
            }
        }

        //找最大dp value
        int maxLength = 0;
        int endIndex = 0;
        for (int i = 0; i < n; i++)
        {
            if (dp[i] > maxLength)
            {
                maxLength = dp[i];
                endIndex = i;
            }
        }

        //重新把字串塞回序列
        List<string> res = new List<string>();
        while (endIndex != -1)
        {
            res.Add(words[endIndex]);
            endIndex = prev[endIndex];
        }
        res.Reverse();        
        return res;
    }

    int HammingDistance(string word_I, string word_J) //compute the HammingDistance
    {
        int count = 0;
        for (int i = 0; i < word_I.Length; i++)
        {
            if (word_I[i] != word_J[i]) count++;
        }
        return count;
    }
}
// @lc code=end

