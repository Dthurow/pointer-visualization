<template>
<div style="display:inline-block;vertical-align:top;border:1px solid black;margin-top:20px;padding:20px;width:535px;">

<div id="stack">
Stack
<hr/>
<div class="memoryLine" v-for="(item, index) in stack">
  <span v-bind:class="{odd : (index % 2 !== 0), even : (index % 2 === 0)}" class="addressline">{{item.addr}}</span>
  <span v-bind:class="{odd : (index % 2 !== 0), even : (index % 2 === 0)}" class="addressName">{{item.varName}}</span>
  <span v-bind:class="{odd : (index % 2 !== 0), even : (index % 2 === 0)}" class="addressValue">{{item.value}}</span>

</div>

</div>
<svg width="40" height="100">
<!-- <path d="M0,50 L40,65" style="stroke:#757575; stroke-width: 1.25px; fill: none;"/> -->
    
</svg>


<div id="heap">
Heap
<hr/>
<div style="vertical-align:bottom;" class="memoryLine" v-for="(item, index) in heap">
  <span v-bind:class="{odd : (index % 2 !== 0), even : (index % 2 === 0)}" class="addressline">{{item.addr}}</span>
  <span v-bind:class="{odd : (index % 2 !== 0), even : (index % 2 === 0)}" class="addressName">{{item.varName}}</span>
  <span v-bind:class="{odd : (index % 2 !== 0), even : (index % 2 === 0)}" class="addressValue">{{item.value}}</span>
</div>



</div>

</div>
</template>

<script>


export default {
  name: 'memorybox',
  props: ['stack', 'heap'],
  data () {
    return {
    }
  },
	methods:{
	}
}
</script>

<style scoped>

#stack, #heap{
display:inline-block;
width:200px;
vertical-align: top;
}



span{
  display:inline-block;
}

.memoryLine{
  width:100%;
}


.even.addressline{
  background-color:#8EB9A8;
  width:15%;
}
.even.addressName{
  background-color:#FEFBD0;
  width:40%;
}
.even.addressValue{
  background-color:#FDCFB7;
  width:40%;
}



.odd.addressline{
  background-color:#dfbe99;
  width:15%;
}
.odd.addressName{
  background-color:#9dc3c2;
  width:40%;
}
.odd.addressValue{
  background-color:darksalmon;
  width:40%;
}

</style>
