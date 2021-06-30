<script lang="ts">
  export let searchValue: string;

</script>

<form action="post">
  <input type="search" class="search browser-default" placeholder="Cari daerah" bind:value="{searchValue}" />
  <button class="search-button" on:click>
    <i class="fa fa-search"></i>
  </button>
</form>

<style>
  .search-button {
    margin-left: -40px;
    border: 0 none;
    cursor: pointer;
  }

</style>