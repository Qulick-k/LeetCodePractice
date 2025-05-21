/*
 * @lc app=leetcode id=1590 lang=csharp
 *
 * [1590] Make Sum Divisible by P
 */

// @lc code=start
public class Solution {
    public int MinSubarray(int[] nums, int p)
    {
        //練習Hash Table、Prefix Sum

        //算總和，屬性為long
        long sum = 0;
        foreach(int i in nums)    
        {
            sum += i;
        }
        
        //把總和除於P找到餘數丟給remain
        //如果總和整除P，代表不用刪掉元素，回傳0
        long remain = sum % p;
        if (remain == 0) return 0;

        int res = nums.Length; //設置要刪除的元素數量
        long cur_sum = 0;      //設置當前餘數總和
        Dictionary<long, int > Table = new Dictionary<long, int>(); //設置Hashmap，紀錄在哪個特定餘數，需要刪除多少個元素
        Table[0] = -1;  //設置Hashmap整除時的的刪除元素數量為-1

        for (int i = 0; i < nums.Length; i++)
        {
            // x = cur_sum - remain
            //計算目前的餘數總和
            //計算當前的前綴和的餘數
            cur_sum = (cur_sum + nums[i]) % p;
            long prefix = (cur_sum - remain + p) % p;
            //如果哈希表有前綴和的餘數Key
            //  len = 當前索引值 - 哈希表[前綴和的餘數]紀錄的元素刪除數量
            //  res = 取原本res和len的其中最小值
            if (Table.ContainsKey(prefix))
            {
                int len = i - Table[prefix];
                res = Math.Min(res, len);
            }
            //紀錄目前的餘數總和至哈希表，並將索引值設為value
            Table[cur_sum] = i;
        }
        //如果res數量等同題目陣列長度，就回傳-1；否則回傳res本身數量
        return res == nums.Length ? -1 : res;
    }
}
//參考https://youtu.be/tZXsLAyE0SE?si=GqwDA8SP08RPT7Yo
// @lc code=end

