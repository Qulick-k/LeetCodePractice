/*
 * @lc app=leetcode id=962 lang=csharp
 *
 * [962] Maximum Width Ramp
 */

// @lc code=start
public class Solution {
    public int MaxWidthRamp(int[] nums)
    {
        //使用堆放置最遠的索引值
        Stack<int> stack = new Stack<int>();
        int n = nums.Length;
        //抓最小值的索引值
        //以nums = [6,0,8,2,1,5]為例
        //跑完後，stack內為 = [0,1]
        for (int i = 0; i < n; i++)
        {
            if (stack.Count == 0 || nums[stack.Peek()] > nums[i])
            {
                stack.Push(i);
            }
        }

        int res = 0;
        //從右方索引查看各個value
        for (int i = n - 1; i >= 0; i--)
        {
            //5 >= 0, true, res = max(0, 5 - 1) == 4
            //5 >= 6, false
            //1 >= 6, false
            //2 >= 6, false
            //8 >= 6, true, res = max(4, 2 - 0) == 4
            while (stack.Count > 0 && nums[i] >= nums[stack.Peek()])
            {
                res = Math.Max(res, i - stack.Pop());
            }

            if (stack.Count == 0) break;
        }

        //reutrn res == 4
        return res;
    }
}
/* 時間複雜度 n平方 效能太爛
        int[] maxRight = new int[nums.Length];
        int pre_max = 0;
        
        //找maxright
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            maxRight[i] = Math.Max(nums[i], pre_max);
            pre_max = maxRight[i];
            //Console.WriteLine("i={0}、right={1}",i,maxRight[i]);
        }
        
        int res = 0;
        //找完rightmax，一一跟原陣列比大小
        for (int i = 0; i < nums.Length; i++)
        {
            int right = nums.Length - 1;
            while (nums[i] > maxRight[right])
            {
                right--;
                
            }
            res = Math.Max(res, right - i);
        }
        return res;
*/
/*
        //暴力解，TLE
        int res = 0;

        for (int i = 0; i < nums.Length-1; i++)
        {
            for (int j = i+1; j < nums.Length; j++)
            {
                if (nums[i] <= nums[j])
                {
                    res = Math.Max(res, (j-i));
                }
            }
        }
        return res;
*/
// @lc code=end

