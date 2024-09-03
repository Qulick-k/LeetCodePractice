/*
 * @lc app=leetcode id=714 lang=csharp
 *
 * [714] Best Time to Buy and Sell Stock with Transaction Fee
 */

// @lc code=start
public class Solution {
    public int MaxProfit(int[] prices, int fee)
    {
        //使用多維動態規劃
        //考慮兩種狀態
        //1. 買了股票，現金流花掉(股票+手續費)
        //2. 賣了股票，現金流增加( 買過的股票所花的負債額度 + 漲價過後的市值)
        int hold = -prices[0] - fee;
        int nothold = 0;

        for (int i = 0; i < prices.Length; i++)
        {
            nothold = Math.Max( nothold, hold + prices[i]);
            hold = Math.Max( hold, nothold - prices[i] - fee );
        }
        return nothold;
    }
}
// @lc code=end

/*圖說影片參考
https://youtu.be/OVsAAgy6awk?si=bQI0V9drGClAPA6b
*/