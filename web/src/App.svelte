<script lang="ts">
	import {Route, Router, Link}from 'svelte-navigator';
	import Kodepos from './pages/kodepos.svelte';
	import AboutModalComponent from './pages/modal.about.svelte';

	let aboutModalVisible = false;
	let title = 'Kode Pos Indonesia';

</script>
<svelte:head>
  <title>{title}</title>
</svelte:head>

<Router basepath="/Kodepos-Wilayah-Indonesia" primary={false}>
	
<div  class="row">
	{#if aboutModalVisible}
		<AboutModalComponent on:close-about-modal={() => aboutModalVisible = false}></AboutModalComponent>
	{/if}

	<nav>
		<div class="nav-wrapper indigo">
			<!-- <a href="#!" class="brand-logo">Logo</a> -->
			<div class="col xl1 l1 m1"></div>
			<div class="col xl4 l4 m4"><Link class="hide-on-sm" to="/"><h5>{title}</h5></Link></div>
			<div class="col xl6 l6 m6">
				
				<ul class="right">
					<li>
						<span class="about" data-tooltip="About"  on:click="{() => aboutModalVisible = true}">
							<i class="fas fa-question-circle" style="font-size:1.5rem;"></i>
						</span>
					</li>
					<li>
						<a href="https://github.com/erlange/Kodepos-Wilayah-Indonesia" data-tooltip="Go to Github page">
							<i class="fab fa-github" style="font-size:1.5rem;"></i>
						</a>
					</li>
				</ul>
		</div>
		<div class="col l1 m1"></div>
		</div>
	</nav>
</div>


<main class="row">
	<div class="col xl1 l1 m1 s0 xs0"></div>
		<div class="col xl10 l10 m10 s12 xs12">
			<Route path="/" primary={false}>
				<Kodepos></Kodepos>
			</Route>
		<div class="col xl1 l1 m1 s0 xs0"></div>
	</div>
	</main>
</Router>

<style>
	.about {
		cursor: pointer;
	}
</style>