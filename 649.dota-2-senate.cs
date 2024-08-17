/*
 * @lc app=leetcode id=649 lang=csharp
 *
 * [649] Dota2 Senate
 */

// @lc code=start
public class Solution {
    public string PredictPartyVictory(string senate) {
        /*
        82% 62%
        */
        //使用queue，把Radiant分到R_queue，Dire分到D_queue
        //把Radiant、Dire分別對應的索引值，各放進R_queue和D_queue
        Queue<int> R_queue = new Queue<int>();
        Queue<int> D_queue = new Queue<int>();
        string result = "";
        int n = senate.Length;

        for (int i = 0; i < senate.Length; i++)
        {
            if (senate[i] == 'R')
            {
                R_queue.Enqueue(i);
            }
            else
            {
                D_queue.Enqueue(i);
            }
        }

        //在有一方無權力前，持續比對雙方queue最前方議員的索引值，比贏的議員加上總人數後，回去自己的queue繼續排隊；比輸的就掰掰
        while (R_queue.Count > 0 && D_queue.Count > 0)
        {
            var R_peek = R_queue.Dequeue();
            var D_peek = D_queue.Dequeue();
            if (R_peek < D_peek)
            {
                R_queue.Enqueue(R_peek + n);
            }
            else
            {
                D_queue.Enqueue(D_peek + n);
            }
        }
        //最後一輪時，誰還有權力，就可以宣判勝利
        if (R_queue.Count > D_queue.Count)
        {
            result = "Radiant";
        }
        else
        {
            result = "Dire";
        }
        return result;
    }
}
// @lc code=end

/*
Queue
https://learn.microsoft.com/zh-tw/dotnet/api/system.collections.generic.queue-1?view=net-8.0
Queue.Enqueue
https://learn.microsoft.com/zh-tw/dotnet/api/system.collections.generic.queue-1.enqueue?view=net-8.0#system-collections-generic-queue-1-enqueue(-0)
Queue.Dequeue
https://learn.microsoft.com/zh-tw/dotnet/api/system.collections.generic.queue-1.dequeue?view=net-8.0#system-collections-generic-queue-1-dequeue
*/