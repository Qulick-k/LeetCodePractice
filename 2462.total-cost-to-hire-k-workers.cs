/*
 * @lc app=leetcode id=2462 lang=csharp
 *
 * [2462] Total Cost to Hire K Workers
 */

// @lc code=start
public class Solution {
    public long TotalCost(int[] costs, int k, int candidates)
    {
        //設置前和後PriorityQueue
        PriorityQueue<int, int> pre_Queue = new PriorityQueue<int, int>();
        PriorityQueue<int, int> pos_Queue = new PriorityQueue<int, int>();

        //設置前索引和後索引
        int preIndex = 0;
        int posIndex = costs.Length - 1;
        
        //設置總開銷
        long total = 0;

        //當K大於0，就進迴圈
        while(k > 0)
        {
            //把候選人放進Queue
            //pre_Queue數量不到candidates，且"前索引"還沒比"後索引"大的時候，進迴圈
            while( pre_Queue.Count < candidates && preIndex <= posIndex)
            {
                pre_Queue.Enqueue(costs[preIndex], costs[preIndex]);
                preIndex++;
            }
            //pos_Queue數量不到candidates，且"後索引"還沒比"前索引"小的時候，進迴圈
            while( pos_Queue.Count < candidates && posIndex >= preIndex)
            {
                pos_Queue.Enqueue(costs[posIndex], costs[posIndex]);
                posIndex--;
            }

            //設置前和後的工資費，都先設在最大值
            int preCost = int.MaxValue;
            int posCost = int.MaxValue;

            //如果pre_Queue的長度大於0，把最小值賦予給preCost工資費
            if(pre_Queue.Count > 0)
            {
                preCost = pre_Queue.Peek();
            }
            //如果pos_Queue的長度大於0，把最小值賦予給posCost工資費
            if(pos_Queue.Count > 0)
            {
                posCost = pos_Queue.Peek();
            }

            //如果preCost工資費比posCost工資費便宜，或是相同，那就選擇preCost工資費
            if(preCost <= posCost)
            {
                total = total + pre_Queue.Dequeue();
            }
            else //不然的話選擇posCost工資費
            {
                total = total + pos_Queue.Dequeue();
            }
            //結束這一輪面談
            k = k - 1;
        }
        //回報總工資開銷
        return total;
    }
}
// @lc code=end

