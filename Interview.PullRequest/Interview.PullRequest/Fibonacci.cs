namespace Interview.PullRequest.Tools
{
    public class Fibonacci
    {
        /// <summary>
        /// Calculates the nth term of the Fibonaci sequence with starting values 0, 1
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static int Caclulate(int i)
        {
            // TODO write unit tests
            if (i == 0 || i == 1)
                return 1;
            else
                return Caclulate(i - 1) + Caclulate(i - 2);
        }
    }
}
