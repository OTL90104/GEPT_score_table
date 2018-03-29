using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPT_score_table
{
    class Program
    {

        public struct Elementary
        {
            public int id;
            public int listening;
            public int reading;
        }
        static void Main(string[] args)
        {
            bool start = true;
            //start == true--->執行程式
            //start == false--->結束程式

            String start_menu = "0";
            //進入各選單，或-1離開程式

            String function_out = "a";
            //function_out==-1-->離開各項功能

            Elementary[] elementary = new Elementary[1];
            //建立一個elementary結構的陣列

            //<主程式開始>
            while (start)
            {
                Console.WriteLine("");
                Console.WriteLine("\t      主選單");
                Console.WriteLine("\t-------------------");
                Console.WriteLine("\t 1：\t輸入成績");
                Console.WriteLine("\t 2：\t統計資料");
                Console.WriteLine("\t 3：\t修改資料");
                Console.WriteLine("\t-1：\t結束程式");                
                start_menu = Console.ReadLine(); 

                #region 功能一：輸入成績
                if (start_menu == "1")
                {
                    start_menu = "0";
                    function_out = "0";
                    while (function_out != "-1")
                    {
                        Console.Clear();

                        //<輸入成績的程式>
                        for (int i = 0; function_out != "-1"; i++)
                        {
                            while (function_out != "-1")
                            {
                                Console.WriteLine("");
                                Console.WriteLine($"請輸入第{i + 1}位學生的聽力分數：(0~120，或輸入-1離開)");
                                elementary[i].listening = int.Parse(Console.ReadLine());
                                if (elementary[i].listening == -1)
                                {
                                    Console.Clear();
                                    function_out = "-1";
                                    start_menu = "0";
                                }
                                else if (elementary[i].listening < 0 || elementary[i].listening > 120)
                                {
                                    Console.WriteLine("===聽力成績輸入錯誤===");
                                }
                                else
                                {
                                    break;
                                }
                            }

                            while (function_out != "-1")
                            {
                                Console.WriteLine($"請輸入第{i + 1}位學生的閱讀分數：(0~120，或輸入-1離開)");
                                elementary[i].reading = int.Parse(Console.ReadLine());
                                if (elementary[i].reading == -1)
                                {
                                    Console.Clear();
                                    function_out = "-1";
                                    start_menu = "0";
                                }
                                else if (elementary[i].reading < 0 || elementary[i].reading > 120)
                                {
                                    Console.WriteLine("===閱讀成績輸入錯誤===");
                                }
                                else
                                {
                                    elementary[i].id = (i + 1);
                                    Console.Clear();
                                    break;
                                }
                            }
                            //如果聽力閱讀都輸入正確，陣列才會多出一格。(所以離開前一定會多出一格裝-1)
                            if (function_out != "-1")
                            {
                                Array.Resize(ref elementary, elementary.Length + 1);
                            }
                        }
                    }
                }
                #endregion
                #region 功能二：資料統計
                else if (start_menu == "2")
                {
                    start_menu = "0";
                    function_out = "0";
                    Console.Clear();
                    String temp;
                    while (function_out != "-1")
                    {
                        temp = "0";
                        //<列印成績的程式 >                       
                        Console.WriteLine("");
                        Console.WriteLine("\t學生編號\t聽力成績\t閱讀成績\t總成績\t");
                        for (int i = 0; i < elementary.Length - 1; i++)
                        {
                            Console.WriteLine("\t---------------------------------------------------------");
                            Console.WriteLine($"\t{elementary[i].id}\t\t{elementary[i].listening}\t\t{elementary[i].reading}\t\t{elementary[i].listening + elementary[i].reading}\t");
                        }
                        //elementary.Length - 1是因為離開會多一格為了輸入-1

                        Console.WriteLine("\n輸入-1離開");
                        temp = Console.ReadLine();
                        if (temp == "-1")
                        {
                            Console.Clear();
                            function_out = "-1";
                            start_menu = "0";
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("母湯喔~要輸入-1才給你離開~");
                            function_out = "a";
                        }
                    }
                }
                #endregion
                #region 功能三：修改成績
                else if (start_menu == "3")
                {
                    start_menu = "0";
                    function_out = "0";
                    int num = 0;

                    while (function_out != "-1")
                    {
                        Console.Clear();

                        //<修改成績的程式>
                        while (function_out != "-1")
                        {
                            int tempNum = 0;
                            while (function_out != "-1")
                            {
                                Console.WriteLine("");
                                Console.WriteLine("請問你要修改第幾號學生的資料? (或-1離開)");
                                num = int.Parse(Console.ReadLine());
                                if (num == -1)
                                {
                                    Console.Clear();
                                    function_out = "-1";
                                    start_menu = "0";
                                }
                                else if (num >= elementary.Length)
                                {
                                    Console.WriteLine("===查無此資料===");
                                }
                                else
                                {
                                    Console.Clear();
                                    break;
                                }
                            }
                            while (function_out != "-1")
                            {
                                Console.WriteLine($"第{num}位學生的聽力成績改為： (或-1離開)");
                                tempNum = int.Parse(Console.ReadLine());
                                if (tempNum == -1)
                                {
                                    Console.Clear();
                                    function_out = "-1";
                                    start_menu = "0";
                                }
                                else if (tempNum < 0 || tempNum > 120)
                                {
                                    Console.WriteLine("===聽力成績輸入錯誤===");
                                }
                                else
                                {
                                    elementary[num - 1].listening = tempNum;
                                    tempNum = 0;
                                    break;
                                }
                            }
                            while (function_out != "-1")
                            {
                                Console.WriteLine($"第{num}位學生的閱讀成績改為： (或-1離開)");
                                tempNum = int.Parse(Console.ReadLine());
                                if (tempNum == -1)
                                {
                                    Console.Clear();
                                    function_out = "-1";
                                    start_menu = "0";
                                }
                                else if (tempNum < 0 || tempNum > 120)
                                {
                                    Console.WriteLine("===閱讀成績輸入錯誤===");
                                }
                                else
                                {
                                    elementary[num - 1].reading = tempNum;
                                    tempNum = 0;
                                    Console.Clear();
                                    break;
                                }
                            }
                        }
                    }
                }
                #endregion
                #region 結束程式
                else if (start_menu == "-1")
                {
                    start = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("母湯喔~要輸入-1才給你離開~");
                }
                #endregion
            }
            Console.WriteLine("");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

