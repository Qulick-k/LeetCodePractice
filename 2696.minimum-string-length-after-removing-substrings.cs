/*
 * @lc app=leetcode id=2696 lang=csharp
 *
 * [2696] Minimum String Length After Removing Substrings
 */

// @lc code=start
public class Solution {
    public int MinLength(string s)
    {
        Stack<char> stack = new Stack<char>();

        for (int i = 0; i < s.Length; i++)
        {
            //紀錄當前字元
            char cur_c = s[i];

            //如果堆為空，直接push進去，continue
            if (stack.Count == 0)
            {
                stack.Push(s[i]);
                continue;
            }            
            
            //堆的PEEK是A且當前字元為B，或是堆的PEEK是C且當前字元為D
            //就Pop掉堆的PEEK值
            //否則把當前字元，PUSH進堆
            if ( (stack.Peek() == 'A' && cur_c == 'B') || (stack.Peek() == 'C' && cur_c == 'D') )
            {
                stack.Pop();
            }
            else
            {
                stack.Push(cur_c);
            }
        }
        return stack.Count;
    }
}
// @lc code=end

