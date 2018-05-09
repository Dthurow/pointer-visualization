import Vue from 'vue'
import App from './App.vue'
import codebox from './components/Codebox.vue'
import memorybox from './components/Memorybox.vue'
import controlbox from './components/Controlbox.vue'
import VueHighlightJS from 'vue-highlightjs';
import 'highlight.js/styles/vs2015.css';

Vue.use(VueHighlightJS);
Vue.component('codebox', codebox);
Vue.component('memorybox', memorybox);
Vue.component('controlbox', controlbox);

new Vue({
  el: '#app',
  render: h => h(App)
})
