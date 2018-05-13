<template>
<div>
 <codebox :sourcecode="sourceCode" :linetohighlight="currentCodeLine" ></codebox>
  <memorybox :stack="stack" :heap="heap"></memorybox>
<controlbox v-on:resetline="resetLine" v-on:nextline="nextLine" v-on:prevline="prevLine"></controlbox>
</div>
</template>

<script>
  import axios from 'axios'
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

      axios.get('/examples/example1.cs')
         .then(function (response) {
           console.log('hi');
           console.log(response.data );
          this.sourceCode = response.data;
            console.log('hello');
        
         }.bind(this))
         .catch(function (error) {
           console.log(error);
         });       

         axios.get('/examples/example1.json')
         .then(function (response) {
           console.log(response.data );
           var results = response.data;
           this.codeLinePath = results.codePath;
           this.heapVersions = results.heapVersions;
           this.stackVersions = results.stackVersions;

         }.bind(this))
         .catch(function (error) {
           console.log(error);
         });



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
