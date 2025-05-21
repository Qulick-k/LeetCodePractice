/*
 * @lc app=leetcode id=731 lang=csharp
 *
 * [731] My Calendar II
 */

// @lc code=start
public class MyCalendarTwo {
    List<int[]> nonOverlapping, overlapping;
    public MyCalendarTwo() {
        nonOverlapping  = new();
        overlapping = new();       
    }
    
    public bool Book(int start, int end) {
        // check for Triple booking
        foreach(var interval in overlapping)                // O(n)
            // new interval start is smaller than existing interval end
            // & new interval end is greater than existing interval start
            if(start < interval[1] && end > interval[0])
                return false;
        // Add the overlapped part to 'overlapping' list
        foreach(var interval in nonOverlapping)             // O(n)
            // new interval start is smaller than existing interval end
            // & new interval end is greater than existing interval start
            if(start < interval[1] && end > interval[0])
                overlapping.Add([Math.Max(start,interval[0]),Math.Min(end,interval[1])]);
        
        // also remeber to add new event to nonOverlapping list
        nonOverlapping.Add([start,end]);
        return true;
    }
}

/**
 * Your MyCalendarTwo object will be instantiated and called as such:
 * MyCalendarTwo obj = new MyCalendarTwo();
 * bool param_1 = obj.Book(start,end);
 */
// @lc code=end

