/*
 * @lc app=leetcode id=5 lang=csharp
 *
 * [5] Longest Palindromic Substring
 */

// @lc code=start
public class Solution
{
    public string LongestPalindrome(string s)
    {
        int start = 0;
        int maxlen = 1;

        for (int i = 0; i < s.Length; i++)
        {
            //以奇數為中心展開
            FindPalidrome(s, i, i, ref start, ref maxlen);
            //以偶數為中心展開
            FindPalidrome(s, i, i + 1, ref start, ref maxlen);
        }
        return s.Substring(start, maxlen);
    }

    //找迴文，並且更新迴文起始字元的指標，以及最長迴文長度
    void FindPalidrome(string s, int left, int right, ref int start, ref int maxlen)
    {
        //可以從"hello"的第2個指標的l為中心為例，跑跑看這個判斷式
        while (left >= 0 && right < s.Length && (s[left] == s[right]))
        {
            left--;
            right++;
        }

        //子字串長度只有"l"一個，所以left = 1, right = 3的情況下，兩者相減時還需多減一個1
        int temp_len = right - left - 1;  
        if (temp_len > maxlen)
        {
            start = left + 1;
            maxlen = temp_len;
        }
    }
}
// @lc code=end

