/*
 * @lc app=leetcode id=2215 lang=csharp
 *
 * [2215] Find the Difference of Two Arrays
 */

// @lc code=start
public class Solution {
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
    {
        //範例為Input: nums1 = [1,2,3], nums2 = [2,4,6]
        //Output: [[1,3],[4,6]]
        //只要nums1在nums2內找到重複數值，就在nums1陣列內把那數值排除
        //nums2也同樣做法，在nums1內找到重複數值，就在nums2陣列內把那數值排除
        //在C#可以使用HashSet，設置set1和set2，分別放nums1和nums2
        HashSet<int> set1 = new HashSet<int>(nums1);
        HashSet<int> set2 = new HashSet<int>(nums2);

        //之後set1使用ExceptWith()把指定集合nums2的所有元素，從set1物件中移除，所以當ExceptWith()在nums2找到2，就會把set1的2也刪掉
        //反之set2使用ExceptWith()把nums1的所有元素，從set2物件中移除，所以當ExceptWith()在nums1找到2，就會把set2的2也刪掉
        set1.ExceptWith(nums2);
        set2.ExceptWith(nums1);
        //最後重新實例化result
        //IList<IList<int>> result = new List<IList<int>>();
        IList<IList<int>> result = new List<IList<int>>();

        //接著把轉成List的set1和set2丟進result，再回傳result
        result.Add(set1.ToList());
        result.Add(set2.ToList());
        return result;
    }
}
// @lc code=end

/*
HashSet的文件
https://learn.microsoft.com/zh-tw/dotnet/api/system.collections.generic.hashset-1?view=net-8.0
HashSet的方法ExceptWith()介紹文件
https://learn.microsoft.com/zh-tw/dotnet/api/system.collections.generic.hashset-1.exceptwith?view=net-8.0#system-collections-generic-hashset-1-exceptwith(system-collections-generic-ienumerable((-0)))
*/