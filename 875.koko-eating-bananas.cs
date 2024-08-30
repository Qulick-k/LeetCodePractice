/*
 * @lc app=leetcode id=875 lang=csharp
 *
 * [875] Koko Eating Bananas
 */

// @lc code=start
public class Solution {
    public int MinEatingSpeed(int[] piles, int h)
    {
        //使用Binary Search
        //Array.Sort(piles);
        //int right = piles[piles.Length - 1];
        int left = 1;
        int right = piles.Max();

        //當左方數值等於右方數值，跳出迴圈
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            
            //假設吃完全部香蕉花費時間大於限制的時間，代表要吃快一點
            if ( eat(piles, mid) > h )
            {
                left = mid + 1;
            }
            else 
            {
                //吃完全部香蕉花費時間小於限制的時間，代表可以再吃慢一點
                //而且mid不一定是最優解，所以不能把上界改成mid-1，而是直接以mid作為上界
                right = mid ;
            }    
        }

        return left;
        
        int eat(int[] pile, int k)
        {
            int hour = 0;
            for (int i = 0; i < pile.Length; i++)
            {
                //如果目前的i堆的香蕉數，除於當前每小時吃k根，餘0的話，代表花整數小時即可吃完i堆的香蕉
                if (pile[i] % k == 0)
                {
                    hour = hour + pile[i]/k;
                }
                else //餘1的話，代表可能要花'1小時半'這種非整數小時的時間才能吃完i堆的香蕉，因此要再多加1小時
                {
                    hour = hour + pile[i]/k + 1;
                }
            }
            //回傳以每小時吃k根香蕉的速度，會花幾小時
            return hour;
        }
        /*上面這個方法，相當於在while迴圈放
            double hour = 0;

            foreach (int pile in piles) {
                hour = hour + Math.Ceiling((double)pile/mid);
            }
        */
        /*
        while (left < right)
        {
            int mid = left + (right - left) / 2;
           
            //假設吃完全部香蕉花費時間大於限制的時間，代表要吃快一點
            if ( eat(piles, mid) > h )
            {
                left = mid + 1;
            }
            else 
            {
                //吃完全部香蕉花費時間小於限制的時間，代表可以再吃慢一點
                //而且mid不一定是最優解，所以不能把上界改成mid-1，而是直接以mid作為上界
                right = mid ;
            }    
        }

        int eat(int[] pile, int k)
        {
            int hour = 0;
            for (int i = 0; i < pile.Length; i++)
            {
                //如果目前的i堆的香蕉數，除於當前每小時吃k根，餘0的話，代表花整數小時即可吃完i堆的香蕉
                if (pile[i] % k == 0)
                {
                    hour = hour + pile[i]/k;
                }
                else //餘1的話，代表可能要花'1小時半'這種非整數小時的時間才能吃完i堆的香蕉，因此要再多加1小時
                {
                    hour = hour + pile[i]/k + 1;
                }
            }
            //回傳以每小時吃k根香蕉的速度，會花幾小時
            return hour;
        }
        上面這個方法，相當於在while迴圈放
            double hour = 0;

            foreach (int pile in piles) {
                hour = hour + Math.Ceiling((double)pile/mid);
            }
        */
    }
}
// @lc code=end

/* Math.Ceiling()**方法:傳回大於或等於指定數字的最小整數值。
https://learn.microsoft.com/zh-tw/dotnet/api/system.math.ceiling?view=net-8.0
*/