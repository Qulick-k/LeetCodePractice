/*
 * @lc app=leetcode id=1768 lang=csharp
 *
 * [1768] Merge Strings Alternately
 */

// @lc code=start
public class Solution {
    //長字串多出來的字數，要接在組合字串後面
    //使用StringBuilder，動態串聯字串
    //當輸入的2個字串長度，都超過本地整數，就開始組合字串
    //其中1個字串長度跟另外1個字串長度不同時，且超過相對應的本地整數，就將剩下的字串放進組合字串的後排
    public string MergeAlternately (string word1, string word2)
    {
        StringBuilder merged = new StringBuilder();
        int num1 = 0;
        int num2 = 0;

        while(num1 < word1.Length && num2 < word2.Length)
        {
            merged.Append(word1[num1]).Append(word2[num2]);
            num1++;
            num2++;
        }

        while(num1 < word1.Length)
        {
            merged.Append(word1[num1]);
            num1 = num1 + 1;
        }
        while(num2 < word2.Length)
        {
            merged.Append(word2[num2]);
            num2 = num2 + 1;
        }

        return merged.ToString();
    }
}
// @lc code=end

