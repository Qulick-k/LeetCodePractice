/*
 * @lc app=leetcode id=2336 lang=csharp
 *
 * [2336] Smallest Number in Infinite Set
 */

// @lc code=start
public class SmallestInfiniteSet {
    //設置PriorityQueue排序，和Hashset紀錄整數是否存在
    PriorityQueue<int, int> Priority_queue = null; 
    HashSet<int> Priority_HashSet = null; 
    int current = 0;
    public SmallestInfiniteSet()
    {
        //初始化Priority_queue和Priority_HashSet，接著賦予1~1000整數給他們
        Priority_queue = new PriorityQueue<int, int>();
        Priority_HashSet = new HashSet<int>();
        current = 1;
    }
    
    public int PopSmallest()
    {
        //把Priority_queue最小的整數提出來，在Priority_HashSet把最小整數刪掉，再回傳最小整數
        if (Priority_queue.Count > 0)
        {
            int Smallest = Priority_queue.Dequeue();
            Priority_HashSet.Remove(Smallest);
            return Smallest;
        }
        return current ++;
    }
    
    public void AddBack(int num)
    {
        //如果當前整數大於num，代表num這個數值在之前就被丟出集合了，並且Priority_HashSet沒有相同的整數num，所以可以讓整數num加回去
        if ( num < current && Priority_HashSet.Add(num) )
        {
            Priority_queue.Enqueue(num, num);
        }
    }
}

/**
 * Your SmallestInfiniteSet object will be instantiated and called as such:
 * SmallestInfiniteSet obj = new SmallestInfiniteSet();
 * int param_1 = obj.PopSmallest();
 * obj.AddBack(num);
 */
// @lc code=end

/* 
    //設置PriorityQueue排序，和Hashset紀錄整數是否存在
    PriorityQueue<int, int> Priority_queue = null; 
    HashSet<int> Priority_HashSet = null; 
    public SmallestInfiniteSet()
    {
        //初始化Priority_queue和Priority_HashSet，接著賦予1~1000整數給他們
        Priority_queue = new PriorityQueue<int, int>();
        Priority_HashSet = new HashSet<int>();
        for (int i = 1; i <= 1000; i++)
        {
            Priority_queue.Enqueue(i, i);
            Priority_HashSet.Add(i);
        }
    }
    
    public int PopSmallest()
    {
        //把Priority_queue最小的整數提出來，在Priority_HashSet把最小整數刪掉，再回傳最小整數
        int Smallest = Priority_queue.Dequeue();
        Priority_HashSet.Remove(Smallest);
        return Smallest;
    }
    
    public void AddBack(int num)
    {
        //如果Priority_HashSet沒有相同的整數num，那就讓整數num加回去Priority_queue和Priority_HashSet
        if ( !Priority_HashSet.Contains(num) )
        {
            Priority_queue.Enqueue(num, num);
            Priority_HashSet.Add(num);
        }
    }
*/