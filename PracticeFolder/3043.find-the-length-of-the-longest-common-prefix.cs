/*
 * @lc app=leetcode id=3043 lang=csharp
 *
 * [3043] Find the Length of the Longest Common Prefix
 */

// @lc code=start
public class Solution {
    public int LongestCommonPrefix(int[] arr1, int[] arr2)
    {
        //使用HashSet
        if (arr1.Length > arr2.Length)     
        {
            int[] temp = arr1;
            arr1 = arr2;
            arr2 = temp;
        }

        HashSet<int> prefix_set = new HashSet<int>();
        foreach (int n in arr1)
        {
            int n_num = n;
            while (n_num > 0 && prefix_set.Contains(n_num) == false)
            {
                prefix_set.Add(n_num);
                n_num = n_num / 10;
            }
        }

        int res = 0;

        foreach (int n in arr2)
        {
            int n_num = n;
            while (n_num > 0 && prefix_set.Contains(n_num) == false)
            {
                n_num = n_num / 10;
            }
            if (n_num != 0)
            {
                res = Math.Max(res, n_num.ToString().Length);
            }
        }
        return res;
    }
}
//https://youtu.be/06dIUJwdHlQ?si=mFFevuyDlLoTQjro
// @lc code=end

/* C++寫法
        if(arr1.size() > arr2.size())
        {
            vector<int> temp = arr1;
            arr1 = arr2;
            arr2 = temp;
        }
        
        unordered_set<int> prefix_set;

        for (int i = 0; i < arr1.size(); i++)
        {
            int n_num = arr1[i];

            while (n_num > 0 && prefix_set.count(n_num) == false)
            {
                prefix_set.insert(n_num);
                n_num = n_num / 10;
            }
        }
        int res = 0;

        for (int i = 0; i < arr2.size(); i++)
        {
            int n_num = arr2[i];

            while (n_num > 0 && prefix_set.count(n_num) == false)
            {
                n_num = n_num / 10;
            }
            
            if (n_num != 0)
            {
                string temp = to_string(n_num);
                int n_num_size = temp.size();
                res = max(res, n_num_size);
            }
        }
        return res;
*/