/*
 * @lc app=leetcode id=238 lang=csharp
 *
 * [238] Product of Array Except Self
 */

// @lc code=start
/*
題目翻譯
給定一個整數陣列 nums，返回一個陣列 answer，其中 answer[i] 等於 nums 中所有元素的乘積，除了 nums[i] 本身。

nums 的任何前綴或後綴的乘積保證在 32 位整數範圍內。

你必須寫一個時間複雜度為 O(n) 且不使用除法運算的算法。

範例 1：
輸入：nums = [1,2,3,4]
輸出：[24,12,8,6]

範例 2：
輸入：nums = [-1,1,0,-3,3]
輸出：[0,0,9,0,0]

一般腦袋想過的解法是使用巢狀迴圈，找i==j的值來略過計算。
又或者是全部都計算一遍，然後個別用除法除掉i==j的值
但題目不准使用除法，所以必須想第3種解法
*/
public class Solution {
    public int[] ProductExceptSelf(int[] nums)
    {
        int n = nums.Length;   //設定長度
        int[] res = new int[n];  //設定長度n給新的陣列

        int left_sum = 1; //首先從nums前面乘過去
        for (int i = 0; i < n; i++)
        {
            res[i] = left_sum;  //每一輪，把前側的數值賦予給Res[i]

            left_sum *= nums[i]; //再把前側數值乘上當前的nums[i]
            
            //如果input 是 [1,2,3,4]，跑完迴圈後的res[]會是[1,1,2,6]
        }

        int right_sum = 1;  //再來從nums後面乘過去
        for (int i = n - 1; i >= 0; i--)  //迴圈的i值，用減回去的方式
        {
            res[i] *= right_sum;  //每一輪把當前的res[i] 乘上 後側的數值

            right_sum *= nums[i];  //再把後側數值乘上當前的nums[i]

            //如果input 是 [1,2,3,4]，跑迴圈的當下res[]會從res[3]往前算到res[0]
            //也就是
            //res[3] = res[3] * 1 == 6 * 1  ，然後後側數值right_sum = right_sum * nums[3] = 1 * 4
            //res[2] = res[2] * 4 == 2 * 4 ，然後後側數值right_sum = right_sum * nums[2] = 4 * 3
            //res[1] = res[1] *12 == 1 *12 ，然後後側數值right_sum = right_sum * nums[1] = 12 * 2
            //res[0] = res[0] *24 == 1 *24 ，然後後側數值right_sum = right_sum * nums[0] = 24 * 1
            //因此res[]為[24,12,8,6]
        }
        
        return res; //最後回傳回去
    }
}
// @lc code=end

/*
廢棄CODE，只通過18/24
        int[] result = new int[nums.Length];              
        int[] temp_array = new int[nums.Length];       
        int temp_num = 1; //設置暫時整數
        
        
       

        for(int i = 0; i < nums.Length; i++)
        {
            for(int z = 0; z < nums.Length; z++)  //重新初始化陣列成input值
            {
                temp_array[z] = nums[z];   
                             
            }

            for(int j = 0; j < nums.Length; j++) //跑串列迴圈，如果當串列值j時跟輸入值i不相同的話，就繼續乘積下去
            {
                if(j != i)
                {
                    temp_num = temp_num * temp_array[j];                    
                }
                
                Console.WriteLine(temp_array[j]);
            }
            result[i] = temp_num;
            temp_num = 1;
        }

        return result;
*/
