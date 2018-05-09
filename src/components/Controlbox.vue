<template>
	<div style="display:inline-block">
		<div style="width:600px;text-align:center;">
			<button v-on:click="prevLine">&lt;</button>
			<button v-on:click="nextLine">&gt;</button>
		</div>
		<div style="width:600px;text-align:center;">
			<button v-on:click="resetLine">Reset</button>
		</div>
	</div>
</template>

<script>
	export default {
  name: 'controlbox',
  data () {
    return {
    }
  },
	methods:{
		nextLine : function (){
			console.log("triggered");
			this.$emit('nextLine');
		},
		prevLine: function (){
			this.$emit('prevLine');
		},
		resetLine: function (){
			this.$emit('resetLine');
		}

	}
}

</script>

<style scoped>
	button{
		border:none;
		background-color:#adadad;
		margin:3px;
		padding:10px;
		cursor: pointer;
	}
	button:hover{
		background-color:#818181;
	}

</style>