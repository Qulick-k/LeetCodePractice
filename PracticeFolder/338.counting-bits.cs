/*
 * @lc app=leetcode id=338 lang=csharp
 *
 * [338] Counting Bits
 */

// @lc code=start
public class Solution {
    public int[] CountBits(int n)
    {
        //使用Bit Manipulation(位元運算) 
        int[] result = new int[n+1];
        for (int i = 0; i <= n; i++)
        {
            //要算i轉成2進制有幾個1，只要看當下i的上一個次方，再加上i除於2的餘數即可
            result[i] = result[i/2] + i%2;
        }
        return result;
    }
}
// @lc code=end

