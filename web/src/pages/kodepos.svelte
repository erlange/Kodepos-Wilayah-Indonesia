<script lang="ts">
  import Detail from './detail.svelte'
  import SearchBox from './search.svelte'
  import Pager from './pager.svelte'
  import {getData} from './util.svelte';
  import type {Wilayah} from './model.svelte';
  import { onMount } from "svelte";

  let wilayahs = [] as Wilayah[];
  let pagedWilayahs = [] as Wilayah[][];
  let rowPerPage = 20;
  let currentPage = 0;
  let searchText = '';
  let searchBox;

  const page = (rows: Wilayah[], filter = '') => {
    let filteredRows = rows; 
    if (filter.length > 0) {
        filteredRows = rows.filter(f => f.prop.toLowerCase().includes(filter.toLowerCase().trim())
        || f.kabu.toLowerCase().includes(filter.toLowerCase().trim())
        || f.keca.toLowerCase().includes(filter.toLowerCase().trim())
        || f.desa.toLowerCase().includes(filter.toLowerCase().trim())
        || f.id.toLowerCase().includes(filter.toLowerCase().trim())
        || f.kode.toLowerCase().includes(filter.toLowerCase().trim())
      );
    }
    const pages = Math.ceil(filteredRows.length / rowPerPage);
    const pagedRows = Array.from({length: pages}, (_, ix): Wilayah[] => {
      const start = ix * rowPerPage;
      return filteredRows.slice(start, start + rowPerPage);
    });
    pagedWilayahs = [...pagedRows];
  }

  const gotoPage = (event: Event, n: number) => {
    event.preventDefault();
    if(n >= 0 && n < pagedWilayahs.length) {
      currentPage = n;
    }
  }

  const setFilter = (event: Event) => {
    event.preventDefault();
    currentPage = 0;
    gotoPage(event, currentPage);
    page(wilayahs, searchText); 
    console.log(event);
  }
  
  onMount(() => {
    getData().then(result => {
      wilayahs = result;
      page(wilayahs, searchText); 
    });
    
  });

  const searchGmaps = (input: string)  => {
    window.open('https://google.com/maps/search/' + input);
  }

  $: currentWilayahs = pagedWilayahs.length > 0 ? pagedWilayahs[currentPage] : [];
  
</script>
<div>
    <div class="row">
      <div class="col l5 m5 s5">
        <div class="row">
          <SearchBox bind:searchValue={searchText} on:click={setFilter}></SearchBox>
        </div>
      </div>
  
      <div class="col l7 m7 s7">
        <div class="right">
          <Pager value={currentPage + 1} 
          on:first={(e) => gotoPage(e, 0)}
          on:previous={(e) => gotoPage(e, currentPage - 1)}
          on:next={(e) => gotoPage(e, currentPage + 1)}
          on:last={(e) => gotoPage(e, pagedWilayahs.length - 1)}
          on:setPage={(e) => gotoPage(e, e.detail - 1) }
          />
        </div>
      </div>
    </div>

    <div class="row">
      {#if wilayahs.length > 0}
        {#if pagedWilayahs.length > 0}
          Halaman {currentPage + 1} dari {pagedWilayahs.length}
        {:else}
          Tidak ada data.
        {/if}
      {:else}
        Memuat...
      {/if}
      <div class="col l12 m12 s12" style="overflow:auto">
        <Detail data={currentWilayahs} />
      </div>
    </div>
</div>

<style>
  div.row {
    margin-top: 5px;
    margin-bottom: 5px;
  }
</style>
