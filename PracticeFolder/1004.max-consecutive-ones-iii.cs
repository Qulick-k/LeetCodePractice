/*
 * @lc app=leetcode id=1004 lang=csharp
 *
 * [1004] Max Consecutive Ones III
 */

// @lc code=start
public class Solution {
    public int LongestOnes(int[] nums, int k)
    {
        /*
        使用Slide Window一一掃描哪個翻k次0成1的子陣列中的1數量最多
        */

        //當遇到 1 時，window就可以延伸，也就是int i繼續++
        //當遇到 0 時，如果 k 值大於 0 代表可以繼續延伸目前的 window，如果 k值小於 0 代表需要調整 window size
        int left = 0;
        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] == 0)  
            {
                k--;
            }        
            // 在用完 k 之後，才開始移動 left 往右移動(left + 1) 
            // 如果左邊界有遇到 0 時，把 k + 1        
            //Console.WriteLine(k);            
            if(k < 0 && nums[left++] == 0)  //nums[left++] == 0，代表先判斷nums[left]是否為0，再把left++;   
            {
                k++;                
                /*
                if(k < 0 && nums[left++] == 0)在&&的列式，等同下面列式，當k小於0時，left做完判斷就得+1
                if(nums[left] == 0) //如果nums[left]是0，left++左邊界往右移動，跟k++
                {
                    left++; 
                    k++;
                }
                else    //如果nums[left]是1，left++，左邊界往右移動
                {
                    left++;
                }
                */                
            }                 
            Console.WriteLine(k);  
        }
        return nums.Length-left;
    }
}
// @lc code=end

/*
        //自己的解法，beat 5%/67%
        int temp_num = 0;       //暫時計數器
        int k_temp_num = 0;     //K的次數用了幾次
        int Max_num = 0;        //最大的1數量值
        int i = 0;  //基礎掃描陣列的起始值
        int j = 0;  //每當一個Window掃描完後，就接著下一個index開始掃描
        while(i < nums.Length)  //當i不等於陣列長度
        {
            if(k_temp_num == k && nums[i] == 0)//當K的次數用完了，並且用完K次數後的下一個nums[i]為0
            {
                k_temp_num = 0; //則重置K的使用次數
                temp_num = 0;   //重置暫時計數器
                j++;            //windows計數器+1
                i = j;          //index 從 j的數值重新開始掃描
            }   
            else  //當K的次數沒用完，或者用完K次數後的下一個nums[i]為非0
            {
                if(nums[i] == 1)    //當nums[i]為1，暫時計數器+1
                {
                    temp_num ++;
                }
                else if(nums[i] == 0)   //當nums[i]為0，把0翻成1，暫時計數器+1，使用k的次數+1
                {
                    k_temp_num ++;
                    temp_num ++;
                }
                i++; // index+1
                Max_num = Math.Max(Max_num, temp_num); //比較最大的計數器和目前的計數器，哪個比較大，大的重新賦予給Max_num
            }                     
        } 
        return Max_num; //回傳最大值
*/