<script lang="ts">
  import { fade, fly, slide, scale} from 'svelte/transition';
  import type {Wilayah} from './model.svelte';
  import { createEventDispatcher } from "svelte";

  const dispatch = createEventDispatcher();

  const searchGmaps = (input: string)  => {
    window.open('https://google.com/maps/search/' + input);
  }

  const rowClick = (input: string) => {
    dispatch('rowClick', input);
  }

  export let data = [] as Wilayah[];

</script>

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
    {#each data as w, ix (w.id) }
      <!-- <tr class="{(ix % 2 == 0 ? 'odd' : 'even')}" transition:scale on:click="{() => searchGmaps(w.desa + ' ' + w.keca + ' ' + w.kabu)}"> -->
      <tr class="{(ix % 2 == 0 ? 'odd' : 'even')}" transition:scale on:click="{() => rowClick(w.desa + ' ' + w.keca + ' ' + w.kabu)}">
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
