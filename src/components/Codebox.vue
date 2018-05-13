<template>
	<div class="codebox" style="display:inline-block;margin-right: 15px;">

Current line is: {{linetohighlight}}<br/>
		<div>
		<svg width="35" height="650" style="vertical-align:top;" >
		 <path id="codeArrow" :transform="arrowTransform"
		       style="fill:#ff0000;fill-opacity:1;stroke:#ff0000;stroke-width:0.265;stroke-linecap:butt;stroke-linejoin:miter;stroke-opacity:1;stroke-miterlimit:4;stroke-dasharray:none"
		       d="m 0,8 h 20 v -10 l 15,15 -15,15 v -10 h -20 Z"/>
		    
		</svg>
			<div style="display:inline-block;vertical-align:top;width:600px;">
		<pre v-highlightjs="sourcecode"><code class="csharp"></code></pre>

			</div>

		</div>
	</div>
</template>

<script>
	export default {
  name: 'codebox',
	props: ['linetohighlight', 'sourcecode'],
  data () {
    return {
    }
  },
	methods:{
	},
	computed: {
		arrowTransform : function (){
			console.log("line to highlight is: " + this.lineToHighlight);
			return 'translate(0,' + (this.lineToHighlight-1) * 15 + ')';
		}

	}
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

	svg{
		display:inline-block;
		//border: 1px solid black;
		margin-top:13px;
	}

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