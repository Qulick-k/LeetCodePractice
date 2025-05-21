/*
 * @lc app=leetcode id=136 lang=csharp
 *
 * [136] Single Number
 */

// @lc code=start
public class Solution {
    public int SingleNumber(int[] nums)
    {
        //使用位元運算
        //設置一個整數，來進行XOR邏輯判斷
        int XOR = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            //假設是[5,9,8,9,5]
            //0 ^ 5 == 5
            //5 ^ 9 == 14
            //14 ^ 8 == 22
            //22 ^ 9 == 13
            //13 ^ 5 == 8
            XOR = XOR ^ nums[i];
        }

        return XOR;
    }
}
// @lc code=end

/*
        Console.WriteLine(true ^ true);    // output: False
        Console.WriteLine(true ^ false);   // output: True
        Console.WriteLine(false ^ true);   // output: True
        Console.WriteLine(false ^ false);  // output: False
*/
/*
 [5,5,9,8,9]
//0 ^ 5 == 5
//5 ^ 5 == 0
//0 ^ 9 == 9
//9 ^ 8 == 17
//17 ^ 9 == 8
*/