/*
 * @lc app=leetcode id=1 lang=csharp
 *
 * [1] Two Sum
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution {
    public int[] TwoSum(int[] nums, int target)
    {
        //         <Key,Value>
        Dictionary<int, int> map = new Dictionary<int, int>(); //使用Dictionary設置Hash Table

        for(int i=0; i<nums.Length; i++)                       //造訪串列內所有數字
        {
            int complement = target - nums[i];                 //總和的數字 減掉當前的數字後，將剩餘的數字放入complement
            if(map.ContainsKey(complement))                    //在Hash Table找找看有沒有符合complement的數字
            {
                return new int[] {map[complement], i};         //如果有符合，就回傳答案
            }

            map[nums[i]] = i;   //不符合的話，把目前的數字nums[i]作為key，index i作為Value暫存起來
        }
        return new int[0];
    }
}
// @lc code=end

