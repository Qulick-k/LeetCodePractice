/*
 * @lc app=leetcode id=7 lang=csharp
 *
 * [7] Reverse Integer
 */

// @lc code=start
public class Solution {
    public int Reverse(int x) {
        int rev = 0;

        //int.MaxValue和int.MinValue分別對應2^31 - 1 和-2^31
        while (x != 0)
        {
            int digit = x % 10;  //取最後一位數字
            x /= 10;             //移除x的最後一位數字

            //正數溢位檢察
            //如果rev 大於 2 147 483 647 / 10 = 2 147 483 64，代表溢位
            //如果rev 等於 2 147 483 64 ， 則額外檢查digit有無大於7，有代表溢位
            if (rev > int.MaxValue / 10 || 
                (rev == int.MaxValue / 10 && digit > 7))
                {
                    return 0;
                }
            
            //負數溢位檢察
            //如果rev 小於 -2 147 483 648 / 10 = -2 147 483 64，代表溢位
            //如果rev 等於 -2 147 483 64 ， 則額外檢查digit有無小於-8，有代表溢位
            if (rev < int.MinValue / 10 ||
                (rev == int.MinValue / 10 && digit < -8))
                {
                    return 0;
                }
            
            //更新反轉後的數字
            rev = rev * 10 + digit;
        }

        //溢位已排除，直接回傳reverse數字
        return rev;
    }
}
// @lc code=end

/*
        bool isNagative = (x < 0);
        x = Math.Abs(x);
        string str_x = x.ToString();

        Stack<char> temp = new Stack<char>();
        StringBuilder SB = new StringBuilder();

        foreach (char c in str_x)
        {
            temp.Push(c);
        }
        
        while (temp.Count != 0)
        {
            SB.Append(temp.Pop());
        }

        string res_str = SB.ToString();
        int res = int.Parse(res_str);
        if ( (-2147483648) <= res && res <= (2147483647) )
        {
            return isNagative ? -res : res;
        }        
        else
        {
            return 0;
        }
*/