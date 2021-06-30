<script lang="ts">
  import { fade, fly, slide, scale} from 'svelte/transition';
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
    gotoPage(event, 0);
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
      <div class="col l6 m6 s6">
        <div class="row">
          <SearchBox bind:searchValue={searchText} on:click={setFilter}></SearchBox>
        </div>
      </div>
  
      <div class="col l6 m6 s6">
        <div class="right">
          <Pager value={currentPage + 1} 
          on:first={(e) => gotoPage(e, 0)}
          on:previous={(e) => gotoPage(e, currentPage - 1)}
          on:next={(e) => gotoPage(e, currentPage + 1)}
          on:last={(e) => gotoPage(e, pagedWilayahs.length - 1)}
          />
        </div>
      </div>
    </div>

    <div class="row">
      <div class="col l12 m12 s12" style="overflow:auto">
        <table class="tblProp" cellpadding="0" cellspacing="0">
          <thead>
            <tr>
              <th>Kode</th>
              <th>Propinsi</th>
              <th>Kabupaten/Kotamadya</th>
              <th>Kecamatan</th>
              <th>Kelurahan/Desa</th>
              <th>Kode Pos</th>
            </tr>
          </thead>
          <tbody>
            {#each currentWilayahs as w, ix (w.id) }
              <tr class="{(ix % 2 == 0 ? 'odd' : 'even')}"  in:scale out:fly on:click="{() => searchGmaps(w.desa + ' ' + w.keca + ' ' + w.kabu)}">
                <td>{ w.id }</td>
                <td>{ w.prop }</td>
                <td>{ w.kabu }</td>
                <td>{ w.keca }</td>
                <td>{ w.desa }</td>
                <td>{ w.kode }</td>
              </tr>
            {/each}
          </tbody>
        </table>
  
      </div>
    </div>
</div>

<style>
  table.tblProp {
    text-align: left;
    color: #fff;
    border: none;
    margin-left: -10px;
  }
  table.tblProp tr th {
    text-align: center;
    background-color: #002f7d ;
    padding: .4rem 1rem .4rem 1rem;
    cursor: default;
  }
  table.tblProp tr td {
    padding: .4rem 1rem .4rem 1rem;
    cursor: pointer;
  }

  tr.odd{
    background-color: #1565c0 ;
  }
  tr.even{
    background-color: #0d47a1 ;
  }
  tr:hover{
    background-color: #bc2d00  ;
  }
</style>