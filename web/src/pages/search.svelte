<script lang="ts">
  export let searchValue: string;

</script>

<form action="post">
  <input type="search" class="search-box browser-default" placeholder="Cari daerah" bind:value="{searchValue}" />
  <button class="search-button" on:click>
    <i class="fa fa-search"></i>
  </button>
</form>

<style>
  .search-button {
    margin-left: -40px;
    border: 0 none transparent;
    cursor: pointer;
  }
  input.search-box {
    text-indent: 5%;
    width: 100%;
    border-radius: 10px;
    border: 3px solid #0d47a1;
  }
  ::-webkit-input-placeholder { /* Chrome/Opera/Safari */
    color: #707070;
  }
  ::-moz-placeholder { /* Firefox 19+ */
    color: #707070;
  }
  :-ms-input-placeholder { /* IE 10+ */
    color: #707070;
  }
  :-moz-placeholder { /* Firefox 18- */
    color: #707070;
  }  

</style>