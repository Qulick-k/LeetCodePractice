/*
 * @lc app=leetcode id=2220 lang=csharp
 *
 * [2220] Minimum Bit Flips to Convert Number
 */

// @lc code=start
public class Solution {
    public int MinBitFlips(int start, int goal)
    {
        //使用位元運算
        //假設start=10==1010，goal=7==0111
        //XOR後就等於1101
        //設置翻轉次數
        int xor = start ^ goal;
        int result = 0;

        //只要XOR大於0
        while (xor > 0)
        {
            //當XOR的最後一位數AND 1以後等於1，就代表需要翻轉
            //第一輪 110'1' & 1 == 1 符合
            //第二輪  11'0' & 1 == 1 不符合
            //第三輪   1'1' & 1 == 1 符合
            //第四輪    '1' & 1 == 1 符合
            if ( (xor & 1) == 1 )
            {
                result++;
            }
            //只用整個位元數往右移
            xor = xor >> 1;
        }

        return result;
    }
}
// @lc code=end

/*右移運算子
https://learn.microsoft.com/zh-tw/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators
*/