

namespace HCLRGame
{
    public class Ob_TestCode
    {
        /// <summary>
        /// 随便写个函数,外面调用
        /// </summary>
        /// <param name="myVal1"></param>
        /// <param name="myVal2"></param>
        /// <returns></returns>
        public static int Func_Add(int myVal1, int myVal2)
        {
            return myVal1 + myVal2;
        }

        /// <summary>
        /// 减法
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        [BPSkip]
        public static int Func_Sub(int v1, int v2)
        {
            return v1 - v2;
        }
    }
}
