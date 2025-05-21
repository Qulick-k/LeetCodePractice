/*
 * @lc app=leetcode id=1371 lang=csharp
 *
 * [1371] Find the Longest Substring Containing Vowels in Even Counts
 */

// @lc code=start
public class Solution {
    public int FindTheLongestSubstring(string s)
    {
        //使用位元運算、HashSet、Prefix Sum、bitmask

        //設置vowel的位元Dictionary    
        /*
        00001 - a -> 1
        00010 - e -> 1<<1
        00100 - i -> 1<<2
        01000 - o -> 1<<3
        10000 - u -> 1<<4
        */
        Dictionary<char, int> vowel_bit = new Dictionary<char, int>()
        {
            { 'a', 1 }, { 'e', 1 << 1 }, { 'i', 1 << 2}, { 'o', 1 << 3 }, { 'u', 1 << 4 }
        };

        //設置vowel的HashSet
        HashSet<char> vowelSet = new HashSet<char>
        {
            'a', 'e', 'i', 'o', 'u'
        };

        //設置索引位置
        Dictionary<int, int> position = new Dictionary<int, int>();
        position.Add(0, -1);

        //設置位元遮罩、最大值
        int mask = 0;
        int max = int.MinValue;

        for (int i = 0; i < s.Length; i++)
        {
            if (vowelSet.Contains(s[i]))
            {
                mask = mask ^ vowel_bit[s[i]];
            }

            if (position.ContainsKey(mask) == false)
            {
                //position.Add(mask, i);
                position[mask] = i;
            }

            max = Math.Max(max, i-position[mask]);
        }
        return max;
    }
}
// @lc code=end

//https://youtu.be/tAlQxFvak2U?si=gFFxhVtVMtg29HHJ