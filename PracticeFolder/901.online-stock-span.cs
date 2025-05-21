/*
 * @lc app=leetcode id=901 lang=csharp
 *
 * [901] Online Stock Span
 */

// @lc code=start
public class StockSpanner {
    //使用Monotonic Stack
    //泛型中的元組內第一個為股價Item1，第二個代表天數Item2
    public Stack<(int, int)> tag = new Stack<(int, int)>();

    public StockSpanner()
    {

    }
    
    public int Next(int price)
    {
        //設置當天日數
        int days = 1;
        //只要stack不為空，並且stack頂端元組的Item1值，小於當天股價時
        while (tag.Count > 0 && tag.Peek().Item1 <= price)
        {
            //就把stack頂端pop出來，並且把元組的Item2值加進Days內，然後在重新跑一次While判斷
            days = days + tag.Pop().Item2;
        }
        //如果Stack為空，或是前面有一天的股價大於今天的股價，就跳出來
        //並且把今天的股價以及天數Push進Stack
        tag.Push((price, days));

        //回傳比今天股價還高的日子，兩者的天數差
        return days;
    }
}

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */
// @lc code=end

/* 元組型別
https://learn.microsoft.com/zh-tw/dotnet/csharp/language-reference/builtin-types/value-tuples
*/