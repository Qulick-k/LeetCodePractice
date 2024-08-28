/*
 * @lc app=leetcode id=2542 lang=csharp
 *
 * [2542] Maximum Subsequence Score
 */

// @lc code=start
public class Solution {
    public long MaxScore(int[] nums1, int[] nums2, int k)
    {
        // 
            var queue = new PriorityQueue<int, int>(new IntDescending());
            var queue2 = new PriorityQueue<int, int>();


            for (int i = 0; i < nums1.Length; i++)
                queue.Enqueue(nums1[i], nums2[i]);

            long sum = 0L;
            int min = int.MaxValue;

            for (int i = 0; i < k; i++)
            {
                queue.TryDequeue(out int num1, out int num2);
                sum += num1;
                min = num2;
                queue2.Enqueue(num1, num1);
            }

            long score = sum * min;
            long maxScore = score;

            for (int i = k; i < nums1.Length; i++)
            {
                sum -= queue2.Dequeue();
                queue.TryDequeue(out int num1, out int num2);
                sum += num1;
                min = num2;
                score = sum * min;
                maxScore = Math.Max(maxScore, score);
                queue2.Enqueue(num1, num1);
            }

            return maxScore;
    }
}
    public class IntDescending : IComparer<int>
    {        
        public int Compare(int x, int y) => y - x;
    }
// @lc code=end

/* PriorityQueue<TElement,TPriority>.Comparer 屬性
https://learn.microsoft.com/zh-tw/dotnet/api/system.collections.generic.priorityqueue-2.comparer?view=net-8.0#system-collections-generic-priorityqueue-2-comparer
*/

/* 利用Comparer把PriorityQueue的排序，改成由大到小
PriorityQueue使用CompareR後，TPriority值會從預設的1234...N，變成N...4321
https://stackoverflow.com/questions/71295930/c-sharp-version-of-priorityqueue-for-compare
*/

/* Lambda介紹
https://medium.com/@newpage0720/%E5%B0%8Dc-%E7%9A%84-lambda-%E7%9A%84%E7%90%86%E8%A7%A3-438e6de01305
*/

/*      //自己寫的爛扣，失敗 10 /28 cases passed (N/A)
        int Score = 0;
        PriorityQueue<int, int> nums1_queue = new PriorityQueue<int, int>();
        PriorityQueue<int, int> nums2_queue = new PriorityQueue<int, int>();
        int n = nums1.Length;
        int AllStep = nums1.Length;
        for (int i = 0; i < n; i++)
        {        
            nums1_queue.Enqueue(nums1[i], i);
            nums2_queue.Enqueue(nums2[i], i);
        }

        List<int> nums1_out_List = new List<int>();
        List<int> nums2_out_List = new List<int>();

        int sort_Num = 0;

        while (AllStep > 0)
        {
            for (int i = 0; i < k; i++)
            {
                //把k個數值從Queue丟出來給List
                Console.WriteLine("我是Comparer:" + nums1_queue.Comparer);
                nums1_out_List.Add(nums1_queue.Dequeue());
                nums2_out_List.Add(nums2_queue.Dequeue());
                
                nums1_queue.Enqueue(nums1_out_List[i], sort_Num + n); //第一輪 0 + 4、1 + 4、2 + 4>> 第二輪
                nums2_queue.Enqueue(nums2_out_List[i], sort_Num + n);
                sort_Num++;
            }

            int nums1_sum = 0;
            int nums2_Min = int.MaxValue;

            for (int j = 0; j < nums1_out_List.Count; j++)
            {
                nums1_sum = nums1_sum + nums1_out_List[j];
                nums2_Min = Math.Min(nums2_Min, nums2_out_List[j]);
            }            
            Score = Math.Max(Score, nums1_sum*nums2_Min);
            
            nums1_out_List.Clear();
            nums2_out_List.Clear();
            AllStep--;
        }
        

        return Score;
*/
