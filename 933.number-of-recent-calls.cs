/*
 * @lc app=leetcode id=933 lang=csharp
 *
 * [933] Number of Recent Calls
 */

// @lc code=start
public class RecentCounter {
    //在這一題內，RecentCounter()會在腳本開始運行時，直接初始化，並且呼叫Ping(t)。
    //簡而言之，就是把近3000毫秒內[t-3000, t]，ping call的次數，回傳
    public RecentCounter()
    {
        
    }
    //設置queue
    Queue<int> num_Queue = new Queue<int>();
    public int Ping(int t)
    {
        //先加入t，然後queue長度大於0，且queue頂端值小於t-3000的話，就把queue頂端值排出
        num_Queue.Enqueue(t);
        while (num_Queue.Count > 0 && num_Queue.Peek() < t-3000)
        {
            num_Queue.Dequeue();
        }
        //判斷完成後，回傳queue內符合在[t-3000毫秒,t毫秒]的t有幾個
        return num_Queue.Count;
    }

}

/*
 * Your RecentCounter object will be instantiated and called as such:
 * RecentCounter obj = new RecentCounter();
 * int param_1 = obj.Ping(t);
 */
// @lc code=end

