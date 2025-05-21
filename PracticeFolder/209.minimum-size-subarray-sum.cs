/*
 * @lc app=leetcode id=209 lang=csharp
 *
 * [209] Minimum Size Subarray Sum
 */

// @lc code=start
public class Solution {
    public int MinSubArrayLen(int target, int[] nums)
    {
        //Sliding Window
        //設置min來大小數量，預設數量為整數最大值、設置左指標、(右指標交給for迴圈設置)、設置總和sum來跟target比大小

        //設置for迴圈，以右指標為0起頭
            //總和加上nums[右指標]
            //如果總和大於target，且左指標沒超過右指標的話，就進入while迴圈
                //右指標 減掉 左指標，再+1就會等於這集合內有幾個數字
                //與min比大小，最小的數值，重更新到min內
                //總和 減掉 nums[左指標]，看看被減掉過的總和，會不會還是比target大
                //左指標往右移動一格
        //如果min等於整數最大值的話，代表nums陣列內所有整數加起來都不足target，則將min賦予為0。不等於整數最大值的話，就直接回傳min本身的數值。

        int min = int.MaxValue;
        int left = 0;
        int sum = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            sum += nums[right];
            while (left <= right && sum >= target)
            {
                min = Math.Min(min, right - left + 1);
                sum -= nums[left];
                left+=1;
            }
        }
        return min == int.MaxValue ? 0 : min;
    }
    //https://youtu.be/jp15K7dTCHc?si=5DzADC44YIbk_WVd 中文
    //https://youtu.be/aYqYMIqZx5s?si=R7A3Zlz9IF7Qv4lA 英文
}
// @lc code=end
/* 60 83
        int sum = 0;
        //int count = 0;
        int min = int.MaxValue;
        int left = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            sum = sum + nums[right];
            while (left <= right && sum >= target)
            {                
                //count = right - left + 1;
                min = Math.Min(min, right - left + 1);
                sum = sum - nums[left];
                left = left + 1;
            }
        }
        return min == int.MaxValue ? 0 : min;
*/
/*//Sliding Window TLE 20/21 testCase target = 7、nums = [8]        
        int sum = 0;
        int count = 0;
        int min = int.MaxValue;
        if (nums.Length == 1 && nums[0] > target) return 1;
        for (int left = 0; left < nums.Length; left++)
        {
            sum = 0;
            for (int right = left; right < nums.Length; right++)
            {
                sum = sum + nums[right];
                if ( sum >= target )
                {
                    count = right - left + 1;
                    min = Math.Min(min, count);
                    break;
                }
            }
        }
        return min == int.MaxValue ? 0 : min;
*/