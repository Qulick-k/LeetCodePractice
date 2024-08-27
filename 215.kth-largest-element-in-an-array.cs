/*
 * @lc app=leetcode id=215 lang=csharp
 *
 * [215] Kth Largest Element in an Array
 */

// @lc code=start
public class Solution {
    public int FindKthLargest(int[] nums, int k)
    {
        //使用Heap / PriorityQueue，利用C#的PriorityQueue呈現MinHeap
        //使用PriorityQueue，放置nums數值，和排序值
        PriorityQueue<int , int> Priority_Queue = new PriorityQueue<int , int>();

        //照著nums陣列長，進for迴圈，每一輪迴圈把nums數值和相對應的排序值，放入Priority_Queue
        for (int i = 0; i < nums.Length; i++)
        {
            Priority_Queue.Enqueue(nums[i], nums[i]);
            
            //假如Priority_Queue的長度大於目標第K大值，就把排序值最小的踢出Priority_Queue
            if ( Priority_Queue.Count > k )
            {
                Priority_Queue.Dequeue();
            }
        }
        //最後回傳Priority_Queue內排序值最小的值，就會是第k大的值
        return Priority_Queue.Peek();
    }
}
// @lc code=end

/*PriorityQueue
https://learn.microsoft.com/zh-tw/dotnet/api/system.collections.generic.priorityqueue-2?view=net-8.0
*/