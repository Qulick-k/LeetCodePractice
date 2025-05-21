/*
 * @lc app=leetcode id=2542 lang=csharp
 *
 * [2542] Maximum Subsequence Score
 */

// @lc code=start
public class Solution {
    public long MaxScore(int[] nums1, int[] nums2, int k)
    {
        //設置兩組PriorityQueue，queue_Pair這組要把優先順序改成由大排到小
        PriorityQueue<int, int> queue_Pair = new PriorityQueue<int, int>(new IntDescending());
        PriorityQueue<int, int> queue_Reduce = new PriorityQueue<int, int>();


        //把nums1作為一般數值、nums2作為優先順序的數值，放進queue_Pair
        for (int i = 0; i < nums1.Length; i++)
        {
            queue_Pair.Enqueue(nums1[i], nums2[i]);
        }

        //設置nums1的起始總和，以及nums2的最小比較值
        long sum = 0;
        int min = int.MaxValue;

        //以K作為迴圈長度上限，把queue_Pair的一般數值和順序數值都提取成num1、num2
        //最後獲得加了k次的sum，以及第k個最小的min數值
        for (int i = 0; i < k; i++)
        {
            queue_Pair.TryDequeue(out int num1, out int num2);
            sum += num1;
            min = num2;
            //把每一次從queue_Pair提取出來的num1，放進queue_Reduce作為一般數值和順序數值
            queue_Reduce.Enqueue(num1, num1);
        }
        Console.WriteLine(sum);
        Console.WriteLine(min);
        //起始總和乘上nums2的2第k個最小值，作為暫時起始分數score
        //並且把score賦予給maxScore，作為之後分數的大小比較標準
        long score = sum * min;
        long maxScore = score;

        //從k值開始進行迴圈，直到nums1的長度上限。以Test case 1 為例
        //nums1 = [1,3,3,2], nums2 = [2,1,3,4], k = 3 ， i < nums1.Length == 4
        for (int i = k; i < nums1.Length; i++)
        {
            sum -= queue_Reduce.Dequeue();                     // sum = 6 - 1 = 5
            queue_Pair.TryDequeue(out int num1, out int num2); // nums1 = 3 ,nums2 = 1
            sum += num1;                                       // sum = 5 + 3 == 8
            min = num2;                                        // min = 1 
            score = sum * min;                                 // score = 8 * 1 == 8
            maxScore = Math.Max(maxScore, score);              // Math.Max(12, 8) == 12
            queue_Reduce.Enqueue(num1, num1);                  // Enqueue(3, 3)
        }
        //回傳最大值
        return maxScore; 
    }
}
public class IntDescending : IComparer<int>
{        
    public int Compare(int x, int y) => y - x; //用在PriorityQueue，就代表把優先排序數值，改成降冪排序
}

// @lc code=end

/*蓋牌重打
        PriorityQueue<int, int> Queue_Pair = new PriorityQueue<int, int>( new IntDescending());
        PriorityQueue<int, int> Queue_Reduce = new PriorityQueue<int, int>();
        
        for (int i = 0; i < nums1.Length; i++)
        {
            Queue_Pair.Enqueue(nums1[i], nums2[i]);
        }

        long sum = 0;
        int min = int.MaxValue;
        for (int i = 0; i < k; i++)
        {
            Queue_Pair.TryDequeue( out int num1, out int num2);
            sum = sum + num1;
            min = num2;
            Queue_Reduce.Enqueue(num1, num1);
        }
        
        long Score = sum * min;
        long Max = Score;

        for(int i = k; i < nums1.Length; i++)
        {
            sum = sum - Queue_Reduce.Dequeue();
            Queue_Pair.TryDequeue(out int num1, out int num2);
            sum = sum + num1;
            min = num2;
            Score = sum * min;
            Max = Math.Max(Max, Score);
            Queue_Reduce.Enqueue(num1, num1);
        }

        return Max;

public class IntDescending : IComparer<int>
{
    public int Compare(int x, int y) => y - x;
}        
*/

/* PriorityQueue<TElement,TPriority>.Comparer 屬性
https://learn.microsoft.com/zh-tw/dotnet/api/system.collections.generic.priorityqueue-2.comparer?view=net-8.0#system-collections-generic-priorityqueue-2-comparer
https://learn.microsoft.com/zh-tw/dotnet/api/system.collections.generic.comparer-1?view=net-8.0
*/

/* 利用Comparer把PriorityQueue的排序，改成由大到小
PriorityQueue使用CompareR後，TPriority值會從預設的1234...N，變成N...4321
https://stackoverflow.com/questions/71295930/c-sharp-version-of-priorityqueue-for-compare
*/

/* Lambda介紹
https://medium.com/@newpage0720/%E5%B0%8Dc-%E7%9A%84-lambda-%E7%9A%84%E7%90%86%E8%A7%A3-438e6de01305
*/

        ///以test case 1 為例，有無排大小的差別
        ///PriorityQueue<int, int> queue_test1 = new PriorityQueue<int, int>(new IntDescending());
        ///PriorityQueue<int, int> queue_test2 = new PriorityQueue<int, int>();
        ///for (int i = 0; i < nums1.Length; i++)
        ///{
        ///    queue_test1.Enqueue(nums1[i], nums2[i]);
        ///    queue_test2.Enqueue(nums1[i], nums2[i]);
        ///}
        ///for (int i = 0; i < nums1.Length; i++)
        ///{
        ///    queue_test1.TryDequeue( out int nums01, out int nums02);
        ///    queue_test2.TryDequeue( out int nums03, out int nums04);
        ///    Console.WriteLine("這個是nums2:" + nums02); // 4 3 2 1
        ///    Console.WriteLine("這個是nums4:" + nums04); // 1 2 3 4
        ///}*/

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
