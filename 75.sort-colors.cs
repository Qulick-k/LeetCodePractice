/*
 * @lc app=leetcode id=75 lang=csharp
 *
 * [75] Sort Colors
 */

// @lc code=start
public class Solution {
    public void SortColors(int[] nums)
    {
        int n = nums.Length;
        int zero = 0;
        int one = 0;
        int two = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == 0)
            {
                zero++;
            }
            else if (nums[i] == 1)
            {
                one++;
            }
            else if (nums[i] == 2)
            {
                two++;
            }
        }

        for (int i = 0; i < zero; i++)
        {
            nums[i] = 0;
        }
        for (int i = zero; i < zero + one; i++)
        {
            nums[i] = 1;
        }
        for (int i = zero + one; i < zero + one + two; i++)
        {
            nums[i] = 2;
        }
        
        //return nums;
    }
}
// @lc code=end

