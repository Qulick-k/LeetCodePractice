/*
 * @lc app=leetcode id=283 lang=csharp
 *
 * [283] Move Zeroes
 */

// @lc code=start
public class Solution {
    public void MoveZeroes(int[] nums)
    {
        //以下方法是，把非0的數值，全部搬到前面
        
        int n = 0; //設置n，來記錄換了幾次非0的數值。

        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] != 0)  //判斷nums[i]值是不是非0值，如果是0的話就跳過，不管當下的nums[i]
            {
                (nums[n], nums[i]) = (nums[i], nums[n]); //就把nums[i]值跟nums[n]對調
                n++; //增加交換了幾次非0數值的次數
            }            
        }
                
    }
}
// @lc code=end
/*
以下方法是直觀的把陣列轉換成串列，然後把前面的0刪掉，然後在把0重新加入到串列後面，再把串列轉換成陣列

        int n = nums.Length;     //設置nums陣列的長度
        List<int> list = new List<int>(); //設置一個list
        for (int i = 0; i < n; i++)  //把nums內的數值，個別放進list
        {
            list.Add(nums[i]);
        }
        
        var slow = 0;  //設置slow算整體進度
        var fast = 0;  //設置fast算list進度
        
        while(slow < n)  //當slow小於n的長度
        {
            fast = 0;    //fast回歸於0

            while(fast < n )    //當fast小於n
            {
                if(list[fast] == 0)  //判斷list[fast]的值有沒有等於0
                {
                    list.RemoveAt(fast);    //等於0的話，就移除list[fast]的值      
                    list.Add(0);        //再把0，加到list後方
                    break; //跳出while(fast < n )迴圈
                }
                else
                {
                    fast++; //不等於0的話，fast++，繼續判斷list內的下一個值
                }                 
            }
            slow++; //slow每掃描一次，就slow++，進度往前
        }
        
        int[] temp = list.ToArray();  //把list內的值，轉成array temp
        for (int i = 0; i < temp.Length; i++)  //把temp的值，個別把nums的值，一一替換掉
        {
            nums[i] = temp[i];
            Console.WriteLine(nums[i]);
        } 
*/