<script lang="ts">
  import {onMount} from 'svelte';
  import {generateName} from './pages/random-names'

  export let name;

  onMount(()=>{
    name = generateName();
  });


</script>
<div class='box'>
  Hello {name}

</div>

<style>
  .box {
    border-radius: 0.3rem;
    border: 0.1rem solid #fafa;
    background-color: #c0c0a0;
  }

</style>