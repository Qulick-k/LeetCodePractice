/*
 * @lc app=leetcode id=1684 lang=csharp
 *
 * [1684] Count the Number of Consistent Strings
 */

// @lc code=start
public class Solution {
    public int CountConsistentStrings(string allowed, string[] words)
    {
        //使用hashset，把能用的字元放進HashSet
        HashSet<char> allow_set = new HashSet<char>();
        foreach(char c in allowed)
        {
            allow_set.Add(c);
        }
        
        //設置整數"result"，給予陣列的長度
        int result = words.Length;
        //訪問words陣列內的字串
        foreach(string w in words)
        {   
            //訪問字串內的字元
            foreach(char c in w)
            {   
                //只要HashSet找不到字元，result就直接-1，並且跳出當前foreach迴圈
                if(allow_set.Contains(c) == false)
                {
                    result--;
                    break;
                }
            }
        }
        return result;
    }
}
// @lc code=end

