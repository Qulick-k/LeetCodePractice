/*
 * @lc app=leetcode id=2419 lang=csharp
 *
 * [2419] Longest Subarray With Maximum Bitwise AND
 */

// @lc code=start
public class Solution {
    public int LongestSubarray(int[] nums)
    {
        //急轉彎陣列題
        //設定結果、設定暫時子集合長度
        int result = 0;
        int size = 0;
        //設定暫時最大數值
        int cur_max = 0;

        //拜訪nums陣列內所有數值
        foreach(int value in nums)
        {   
            //假如數值等同於最大值
            if(value > cur_max)
            {   
                //重新設定暫時最大值
                cur_max = value;
                //設定子集合長度為1
                size = 1;
                //重置result，之前的result的數值都是比目前數值還小的數值，所以捨棄他的result
                result = 0;
            }
            else if ( value == cur_max)
            {   
                //如果相同的話，就把子集合長度+1
                size++;
            }
            else
            {
                //只要數值比上一個最大數值還小，那就把子集合長度歸零
                size = 0;
            }
            //比較結果和暫時子集合長度，取最長值
            result = Math.Max(result, size);
        }
        //回傳結果
        return result;    
    }
}
// @lc code=end

/* //急轉彎陣列題
        //設定結果、設定暫時子集合長度
        int result = 0;
        int size = 0;
        //設定陣列內最大數值
        int max = nums.Max();

        //拜訪nums陣列內所有數值
        foreach(int value in nums)
        {   
            //假如數值等同於最大值
            if(value == max)
            {   
                //增加子集合長度
                size++;
            }
            else
            {   
                //不同的話，就把子集合長度歸零
                size = 0;
            }
            //比較結果和暫時子集合長度，取最長值
            result = Math.Max(result, size);
        }
        //回傳結果
        return result; 
*/