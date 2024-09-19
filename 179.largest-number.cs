/*
 * @lc app=leetcode id=179 lang=csharp
 *
 * [179] Largest Number
 */

// @lc code=start
public class Solution {
    public class CustomComparer : IComparer<string>
    {
        //如果"後+前"比"前+後"還大的話，會回傳1，將back排到front物件之前
        public int Compare(string front, string back)
        {
            string FrontBack = front + back;
            string BackFront = back + front;
            return BackFront.CompareTo(FrontBack);
        }
    }
    public string LargestNumber(int[] nums)
    {
        //使用貪婪、Array、Sorting、String
        //此題核心解法為比較每筆i索引數字轉成字串後與下一個i+1索引的數字轉成字串，互相結合後，比較看看是[i]字串+[i+1]字串，還是[i+1]字串+[i]字串大。
        //此題用到C#中較多方法、介面，需使用Select()、lambda、Array.Sort()的多載IComparer、額外創建一個類別CustomComparer、string的CompareTo()、StringBuilder
        
        //先把nums陣列內的整數，使用Select先一個個轉換成字串後，再把整個字串轉成Array放進strNums陣列內
        
        //初始化CustomComparer類別，命名為CC
            //在LargestNumber方法外，另外創建CustomComparer類別，並新增IComparer<string>介面
                //設置Compare方法，參數為前字串、後字串
                    //比較"前字串+後字串" 和 "後字串+前字串"，誰比較大
                    //如果"後字串+前字串" 比較大，則回傳1，使得後字串排到前字串前面
                    //反之"前字串+後字串" 比較大，則回傳-1，使得後字串排到前字串後面

        //將使用Array.Sort將strNums陣列，利用CC進行排序
        
        //如果strNums陣列第一個字串為"0"的話，降冪排序後的第一個字串還是"0"，代表這陣列最大值為0，直接回傳"0"
        //設置StringBuilder命名為LargestNumber
        //訪問strNums陣列內所有字串
            //一個接著一個加進LargestNumber
        //回傳LargestNumber，記得ToString()轉成字串

        ///有沒有先排序nums，不影響，因為使用CustomComparer後，一定能完整排序
        ///Array.Sort(nums);
        //Array.Reverse(nums);
        string[] strNums = nums.Select(num => num.ToString()).ToArray();

        CustomComparer CC = new CustomComparer();
        Array.Sort(strNums, CC);

        if (strNums[0] == "0")
        {
            return "0";
        }

        StringBuilder LargestNumber = new StringBuilder();
        foreach (var strNum in strNums)
        {
            LargestNumber.Append(strNum);
        }
        
        return LargestNumber.ToString();
    }
}
/// Select方法
///https://learn.microsoft.com/zh-tw/dotnet/api/system.linq.enumerable.select?view=net-8.0
///IComparer 介面
///https://learn.microsoft.com/zh-tw/dotnet/api/system.collections.icomparer?view=net-8.0
///String.CompareTo 方法
///https://learn.microsoft.com/zh-tw/dotnet/api/system.string.compareto?view=net-8.0
///Sort<T>(T[], IComparer<T>)
///https://learn.microsoft.com/zh-tw/dotnet/api/system.array.sort?view=net-8.0#system-array-sort-1(-0()-system-collections-generic-icomparer((-0)))
///【C#】使用IComparable自定義Class排序
///https://teafatesanya.blog.fc2.com/blog-entry-99.html
///Lambda
///https://medium.com/@newpage0720/%E5%B0%8Dc-%E7%9A%84-lambda-%E7%9A%84%E7%90%86%E8%A7%A3-438e6de01305
/*  for (int i = 0; i < strNums.Length -1; i++)
        {
            for (int j = 0; j < strNums.Length - 1 - i; j++)
            {        
                //比較前+後、後+前 
                //string front = nums[j].ToString() + nums[j + 1].ToString();
                //string back = nums[j + 1].ToString() + nums[j].ToString();
                //int int_front = int.Parse(front);
                //int int_back = int.Parse(back);

                //if (int_front < int_back)
                //{
                //    int temp = nums[j];
                //    nums[j] = nums[j + 1];
                //    nums[j + 1] = temp;
                //}
            }
        }*/
// @lc code=end

