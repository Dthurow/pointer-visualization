1 using System;
2 using System.Runtime.InteropServices;
3 using System.Reflection;
4
5 namespace example1
6 {
7    class Program
8    {
9        public static blah testMethod(blah input)
10        {
11          input = new blah();
12          input.X = 1;
13          return input;
14        }
15        static unsafe void Main(string[] args)
16        {
17          blah start = new blah();
18
19          TypedReference tr = __makeref(start);
20          IntPtr ptr = **((IntPtr**) &tr);
21          Console.WriteLine("pointer abuse version " + ptr.ToString());
22
23          Console.WriteLine("Before func call X is: '" + start.X + "'");
24          start = testMethod(start);
25
26          TypedReference tr1 = __makeref(start);
27          IntPtr ptr1 = **((IntPtr**) &tr);
28          Console.WriteLine("pointer abuse version " + ptr1.ToString());
29              
30          Console.WriteLine("After func call X is: '" + start.X + "'");
31        }
32
33    }
34    public class blah
35    {
36      public int X;
37      public blah()
38      {
39        this.X = 10;
40      }
41    }
42 }