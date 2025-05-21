/*
 * @lc app=leetcode id=841 lang=csharp
 *
 * [841] Keys and Rooms
 */

// @lc code=start
public class Solution {
    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        //Graph DFS   61% 32%
        //如果長度為0，代表沒房間，不需要鑰使。可以回頭找其他房間
        //設置HadhSet，每一個數值都只會有1個數量
        //設置DFS方法，把rooms、當前鑰使 0 、和hashset作為參數丟進去做判斷
    
        HashSet<int> visited = new HashSet<int>();
        dfs(rooms, 0, visited);
        //跑完後，如果拜訪過的房間數，跟實際房間數相同，回傳true。不相同的話，回傳false
        return visited.Count == rooms.Count;
    }
    public void dfs(IList<IList<int>> rooms, int current, HashSet<int> Visited)
    {
        //有當前鑰使的房間，放進hashset，代表我們拜訪過了
        Visited.Add(current);

        //訪問當前房間有哪一些鑰使
        foreach(var key in rooms[current])
        {
            //當遇到沒拿過的鑰使
            if(!Visited.Contains(key))
            {
                //就深入遞迴，讓dfs呼叫自己dsf，把rooms、沒拿過的鑰使、和拜訪過的房間hashset
                dfs(rooms, key, Visited);
            }
        }
    }
}
// @lc code=end

