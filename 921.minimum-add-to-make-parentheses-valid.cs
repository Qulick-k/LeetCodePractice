/*
 * @lc app=leetcode id=921 lang=csharp
 *
 * [921] Minimum Add to Make Parentheses Valid
 */

// @lc code=start
public class Solution {
    public int MinAddToMakeValid(string s) 
    {
        ///使用貪婪
        /// ())
        /// )) +1
        /// ) +1 -1 = 0
        ///  +1 -1 -1 = -1 => res = res +1
        
        ///   ()()
        ///   )() +1
        ///   () +1 -1
        ///   ) +1 -1 +1
        ///   +1 -1 +1 -1 = 0
        
        ///   ))(
        ///   )( -1 => res = res + 1; cur = 0;
        ///   (  0 -1 res = res + 1; cur = 0;
        ///   0 + 1 return cur + res;

        /// s = (()))((
        /// (...... 0 +1 =1
        /// ((..... 1 +1 =2
        /// (().... 2 -1 = 1
        /// (())... 1 -1 = 0
        /// (())).. 0 -1 = -1 後面就算有(也無法搬到前面彌補，於是需要額外插入(在最前面 res = res + 1; cur = 0
        /// (()))(. 0 +1 = 1
        /// (()))(( 1 +1 = 2
        /// return res + cur; => return 1 + 2; => return 3;

        int cur = 0;
        int res = 0;

        foreach (char c in s)
        {
            if (c == '(')
            {
                cur += 1;
            }
            else
            {
                cur -= 1;
                if (cur < 0)
                {
                    cur = 0;
                    res += 1;
                }
            }
        }
        return res + cur;
    }
}
// @lc code=end

