/*
 * @lc app=leetcode id=724 lang=csharp
 *
 * [724] Find Pivot Index
 */

// @lc code=start
public class Solution {
    public int PivotIndex(int[] nums)
    {
        /*
        分成ABC部分，A總和代表左邊，B索引代表中間，C總和代表右邊
        以B為0開始跑迴圈，隨著B的增加，A總和會增加，C總和會減少
        如果到特定B時，A總和等於C總和，則回傳B值
        跑完迴圈沒回傳B值，代表沒找到支點index，所以直接回傳-1
        */
        //直接算出C總和，就可以更好算。 76% 60%
        int leftsum = 0; 
        int rightsum = nums.Sum();
        for (int i = 0; i < nums.Length; i++)
        {
            rightsum = rightsum - nums[i];
            if (leftsum == rightsum)
            {
                return i;
            }
            leftsum = leftsum + nums[i];
        }
        return -1;
    }
}
// @lc code=end

/*
        //自己寫的 5% 87%
        int leftsum = 0;
        int rightsum = 0;

        for (int i = 0; i < nums.Length; i++)  //i 為B部分
        {
            leftsum = 0;
            rightsum = 0;
            for(int j = 0; j < i; j++)  //左邊 A部分
            {
                leftsum = leftsum + nums[j];
            }
            for(int x = i+1; x < nums.Length; x++) //右邊 C部分
            {

                rightsum = rightsum + nums[x];
            }
            if(leftsum == rightsum)
            {
                return i;
            }
        }
        return -1; //迴圈跑完代表沒找到支點index，所以直接回傳-1
*/