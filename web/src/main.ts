import './../node_modules/@fortawesome/fontawesome-free/css/all.min.css';
import './../node_modules/@fortawesome/fontawesome-free/js/all.min.js';
import './../node_modules/materialize-css/dist/css/materialize.min.css';
import * as M from './../node_modules/materialize-css/dist/js/materialize';

import App from './App.svelte';
import 'whatwg-fetch' // fetch polyfill for IE 11

const app = new App({
	target: document.body,
	props: {
	}
});

M.AutoInit();

export default app;