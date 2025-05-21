/*
 * @lc app=leetcode id=11 lang=csharp
 *
 * [11] Container With Most Water
 */

// @lc code=start
public class Solution {
    public int MaxArea(int[] height)
    {
        /*
        給定一個整數陣列 height，長度為 n。有 n 條垂直線，第 i 條線的兩個端點是 (i, 0) 和 (i, height[i])。
        找到兩條線，與 x 軸形成一個容器，使得容器盛水最多。
        返回容器可以盛載的最大水量。
        注意：容器不能傾斜。
        */
        //解題概念跟自己第一次成功的爛扣一樣，使用雙指針
        
        int current = 0; //當前最大水量
        int left = 0;    //左指針
        int right = height.Length - 1; //右指針
        while (left < height.Length) //只要左指針小於右指針
        {
            int area = (right - left) * Math.Min(height[left], height[right]); //求出兩條線的距離，然後跟比較短的線乘
            current = Math.Max(current, area); //比較當前水量跟暫存的數值，挑最大的來更新當前水量
            if (height[left] <= height[right]) //如果左指針的線長，比右指針的線短或是相同
            {
                left++;         //左指針往前進
            }
            else
            {
                right--;        //反之，右指針就往後退
            }
        }
        return current;         //回傳當前最大水量
    }
}
// @lc code=end

/*
        //自己想的爛扣，使用雙指針，比大小的部分，可以用Math.Max或是Math.Min來比，不用使用if判斷
        //88%/8%
        int num = height.Length; //放陣列的長度
        int Container = 0; //放容器的大小
        int temp = 0;      //暫存器，用來跟容器比大小
        int left = 0;      //左邊的指針
        int right = num - 1;  //右邊的指針

        while (left < right)  //只要左指針沒超過右指針
        {
            
            if (height[left] <= height[right])   //如果右指針的數值大於等於左指針的數值
            {
                temp = height[left] * (Math.Abs(right - left));     //暫存器，存入左指針*左指針與右指針的距離
                left++; //然後左指針往前進
            }
            else// if (height[left] > height[right])  如果右指針的數值小於左指針的數值
            {
                temp = height[right] * (Math.Abs(right - left)); //暫存器，存入右指針*右指針與左指針的距離
                right--; //接著右指針往後退
            }           
            if (temp > Container) //要是暫存器的數值>容器內的數值
            {
                Container = temp;    //容器內的數值，更新為暫存器的數值
            }                                                                       
        }
        return Container; //跑完迴圈後，回傳容器內數值
*/