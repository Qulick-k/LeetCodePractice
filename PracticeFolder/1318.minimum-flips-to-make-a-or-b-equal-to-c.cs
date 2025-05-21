/*
 * @lc app=leetcode id=1318 lang=csharp
 *
 * [1318] Minimum Flips to Make a OR b Equal to c
 */

// @lc code=start
public class Solution {
    public int MinFlips(int a, int b, int c)
    {
        //使用位元運算
        //判斷C、A、B的最後一位是不是1，是就給1，不是就給0
        //判斷A和B的OR是不是跟C的最後一位一樣，不一樣的話就加次數
        //每一次LOOP就用右移運算子排掉最後一位
        int c_Last = 0;
        int a_Last = 0;
        int b_Last = 0;
        int Flips = 0;

        for (int i = 0; i < 32; i++)
        {
            if ( (c & 1) == 1)
            {
                c_Last = 1;
            }
            else
            {
                c_Last = 0;
            }

            if ( (a & 1) == 1)
            {
                a_Last = 1;
            }
            else
            {
                a_Last = 0;
            }

            if ( (b & 1) == 1)
            {
                b_Last = 1;
            }
            else
            {
                b_Last = 0;
            }

            //如果C == 1時，A OR B如果是0的話，代表要翻一個為1。
            if ( c_Last == 1 )
            {
                if ( (a_Last | b_Last) != 1)
                {
                    Flips++;
                }
            }
            else
            {
                //如果C == 0時， A如果是1的話，要翻成0。B 如果是1的話，也要翻成0
                if ( a_Last == 1)
                {
                    Flips++;
                }
                if ( b_Last == 1 )
                {
                    Flips++;
                }
            }
            Console.WriteLine(Flips);
            a = a >> 1;
            b = b >> 1;
            c = c >> 1;
        }

        return Flips;
    }
}
// @lc code=end

/*右移運算子
https://learn.microsoft.com/zh-tw/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators
*/

/*int 的2進制上限到32位數
https://www.cnblogs.com/cnoodle/p/14395996.html
*/