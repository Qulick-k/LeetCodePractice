/*
 * @lc app=leetcode id=3 lang=csharp
 *
 * [3] Longest Substring Without Repeating Characters
 */

// @lc code=start
public class Solution {
    public int LengthOfLongestSubstring(string s)
    {
        //使用Sliding Window，20分鐘內搞定
        
        //設置dic紀錄目前出現的字元還有該字元所在的索引值
        //設置左指標
        //設置子字串長度
        //執行for迴圈訪問s字串，右指標從索引0開始
            //如果右指標的字元不在dic內，那就紀錄該字元，以及右指標的索引值
            //如果右指標的字元已存在於dic內
                //那就查看是否左指標的索引值，比dic內右指標的字元記錄下來的索引值還小，如果左指標比目標索引值還小，那麼左指標往該目前索引值移動，並+1
                //更新目前的dic內，該字元的索引值為目前的右指標
            //比較目前的子字串長度有沒有比，更新後的右指標減掉左指標+1的長度還長，有的話就更新最大值
        //回傳子字串長度
        Dictionary<char, int> cur_char = new Dictionary<char, int>(); 
        int left = 0;   
        int Length = 0; 
        
        for (int right = 0; right < s.Length; right++)
        {
            if (cur_char.ContainsKey(s[right]) == false)
            {
                cur_char[s[right]] = right;
            }
            else //如果目前的字串已經存在於dic內的話，就把left往右cur_set[s[right]]的索引+1移動，並且更新目前字串的索引值到dic上
            {
                if (left <= cur_char[s[right]])
                {
                    //如果left比目標索引值還右邊，那left不用動
                    //否則就往右移動
                    left = cur_char[s[right]] + 1;
                }     
                cur_char[s[right]] = right;
            }
            Length = Math.Max(Length, right - left + 1);
        }
        return Length;
    }
}
// @lc code=end

