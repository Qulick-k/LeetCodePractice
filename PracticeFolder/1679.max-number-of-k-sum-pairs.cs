/*
 * @lc app=leetcode id=1679 lang=csharp
 *
 * [1679] Max Number of K-Sum Pairs
 */

// @lc code=start
public class Solution {
    public int MaxOperations(int[] nums, int k)
    {
        
        //如果陣列內有2個數字加起來等於k值，就把組合數+1
        //可以把陣列內的數字先排序，再處理
        //使用雙指針
        Array.Sort(nums); //先排序陣列
        int left = 0;     //左指針
        int right = nums.Length - 1;  //右指針
        int counter = 0;    //配對組合數

        while (left < right)//雙指針還沒碰在一起時
        {
            if (nums[left] + nums[right] == k) //如果找到配對數值
            {
                left++; //左指針往右走
                right--; //右指針往左走
                counter++;  //配對數+1
            }
            else if (nums[left] + nums[right] < k) //當加起來小於K
            {
                left++; //左指針往右走
            }
            else    //當加起來大於k
            {   
                right--; //右指針往左走
            }
        }
        return counter; //回傳配對組合數
    }
}
// @lc code=end

        //另外一種解法是雜湊表(Hash Table)
        //追蹤每一種數字，出現的次數，在C#可以使用Dictionary，去派訪數組來找到是否存在另一個數字使其和等於K
        
        /*
        Dictionary<int, int> dict = new Dictionary<int,int>();  //設置字典表
        int count = 0;  //設置計數器
        foreach(int num in nums)//拜訪input的陣列
        {   
            int target = k - num;   //num + target = k，所以target = k - num
            //如果字典表中有target，而且target在字典被記錄的總數大於0，就把target在字典表的紀錄次數-1，然後計數器+1
            if(dict.ContainsKey(target) && dict[target]>0)
            {
                Console.WriteLine(dict);
                dict[target]--;
                Console.WriteLine(dict[target]);
                count++;
            }
            else //如果字典表中沒有target
            {
                //如果陣列值num，已經出現在字典表中，那就把那個num在字典表中紀錄的次數+1
                if(dict.ContainsKey(num))
                {                    
                    dict[num]++;                    
                }
                //如果陣列值num，沒在字典表出現過，那就把那個num在字典表中紀錄的次數設為1
                else
                {
                    dict[num] = 1;
                }
            }
        }        
        return count;        
        */