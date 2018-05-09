<template>
<div>
 <codebox :sourcecode="sourceCode" :linetohighlight="currentCodeLine" ></codebox>
  <memorybox :stack="stack" :heap="heap"></memorybox>
<controlbox v-on:resetline="resetLine" v-on:nextline="nextLine" v-on:prevline="prevLine"></controlbox>
</div>
</template>

<script>
export default {
  name: 'app',
 data () {
    return {
      currentPlaceInCodePath : 0,

      stackVersions: [],
      heapVersions: [],
       codeLinePath: [],
       sourceCode: ''

    }
  },
  created () {
    // fetch the data when the view is created and the data is
    // already being observed
    this.fetchData()
  },
  computed: {
    // a computed getter
    stack : function () {
      if (this.stackVersions.length > this.currentPlaceInCodePath){
        return this.stackVersions[this.currentPlaceInCodePath];
      }
      else{
         return this.stackVersions[this.stackVersions.length - 1];
      }
    },
    heap : function () {
      if (this.heapVersions.length > this.currentPlaceInCodePath){
        return this.heapVersions[this.currentPlaceInCodePath];
      }
      else{
         return this.heapVersions[this.heapVersions.length - 1];
      }
    },
    currentCodeLine : function (){
      return this.codeLinePath[this.currentPlaceInCodePath];
    }
  },
  methods:{
    fetchData: function (){
      this.sourceCode = `1 using System;
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
      `;

      var results = JSON.parse(`{
  "codePath": [ 17, 36, 37, 38, 39, 40, 19 ],
  "stackVersions" : [  
        [ ],
        [ 
          {"addr": 100, "varName": "start", "value": "address 1"}
        ],
        [ 
          {"addr": 100, "varName": "start", "value": "address 1"}
        ],
        [ 
          {"addr": 100, "varName": "start", "value": "address 1"}
        ],
        [ 
          {"addr": 100, "varName": "start", "value": "address 1"}
        ],
        [ 
          {"addr": 100, "varName": "start", "value": "address 1"}
        ],
        [ 
          {"addr": 99, "varName": "input", "value": "address 1"},
          {"addr": 100, "varName": "start", "value": "address 1"}
        ],
        [ 
          {"addr": 99, "varName": "input", "value": "address 1"},
          {"addr": 100, "varName": "start", "value": "address 1"}
        ]
       ],
      "heapVersions": [ 
        [  ],
        [ {"addr": 1, "varName": "", "value": "X = 10"}
        ],
        [ {"addr": 1, "varName": "", "value": "X = 5"}
        ],
        [ {"addr": 1, "varName": "", "value": "X = 5"}
        ],
        [ {"addr": 1, "varName": "", "value": "X = 5"}
        ],
        [ {"addr": 1, "varName": "", "value": "X = 5"}
        ],
        [ {"addr": 1, "varName": "", "value": "X = 5"}
        ],
        [ {"addr": 1, "varName": "", "value": "X = something else"}
        ]
       ]

}
                               `);
        console.log(results);
        this.codeLinePath = results.codePath;
        this.heapVersions = results.heapVersions;
        this.stackVersions = results.stackVersions;
       // axios.get('/static/Example1/code.cs')
       //  .then(function (response) {
       //    console.log(response.data );
       //    this.sourceCode = response.data;
       //  }.bind(this))
       //  .catch(function (error) {
       //    console.log(error);
       //  });

       //  axios.get('/static/Example1/stateinfo.json')
       //  .then(function (response) {
       //    console.log(response.data );
       //    var results = response.data;
       //    this.codeLinePath = results.codePath;
       //    this.heapVersions = results.heapVersions;
       //    this.stackVersions = results.stackVersions;

       //  }.bind(this))
       //  .catch(function (error) {
       //    console.log(error);
       //  });



    },
    nextLine: function(){
      console.log('nextline');
        if (this.currentPlaceInCodePath < this.codeLinePath.length-1){
          this.currentPlaceInCodePath++;
        }
    },
    prevLine: function (){
      console.log('prevLine');
        if (this.currentPlaceInCodePath > 0){
          this.currentPlaceInCodePath--;
        }
    },
    resetLine : function(){
      this.currentPlaceInCodePath = 0;
    }


  }
}
</script>


<style>

</style>
