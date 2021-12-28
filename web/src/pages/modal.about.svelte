<script lang="ts">
  import { createEventDispatcher } from 'svelte';
  import { fade } from 'svelte/transition';
  const closeDispatch = createEventDispatcher();
  
  const close = () => {
    closeDispatch('close-about-modal');
  }

  let aboutModalVisible = true;
</script>
<div>
  {#if aboutModalVisible}
  <div class="backdrop1">
    <br class="normal" />  
    <div class="modal1" transition:fade >
      <div class="row">
        <div class="col l2 m2 s2"></div>
        <div class="col l8 m8 s8">
          <h5>Kode Pos Indonesia</h5>
          </div>
        <div class="col l2 m2 s2">
          <span class="btn btn-floating transparent waves-effect waves-light z-depth-1 tooltipped" data-tooltip="Click to close" on:click="{close}">
            <i class="fas fa-times-circle"></i>
          </span>
        </div>
      </div>
      <div class="row">
        <div class="modalbody">
          <hr />Wilayah administratif Indonesia dengan kode pos berdasarkan Permendagri No.137 Tahun 2017.
              Source code on <a href="https://github.com/erlange/Kodepos-Wilayah-Indonesia">Github</a>
            <hr />
            <p>
              &copy;-2021 <a href="https://github.com/erlange">Eri Airlangga</a> 
            </p>
            <button class="btn-large z-depth-3 indigo darken-1 waves-effect waves-light tooltipped" data-tooltip="Click to close" on:click="{close}"><i class="fas fa-times-circle"></i>&nbsp;Close</button>
        </div>
      </div>
    </div>
  </div>
{/if}
</div>

<style>
  .normal {
    line-height: 1rem;
  }
  .fa-times-circle {
    font-weight: 900;
    font-size: 2rem;
    vertical-align:middle;
  }
  .backdrop1 {
    top: 0px;
    left: 0px;
    width: 100%;
    height: 100%;
    position: fixed;
    background-color: rgba(0,0,0,.8);
    z-index: 100;
  }

  /* do not rename to modal or it interferes with Materialize-CSS modals  */
  .modal1 {
    padding: 0.2rem 2rem .5rem 2rem;
    border-radius: 5rem .5rem 5rem 5rem;
    max-width: 400px;
    margin: 5% auto;
    text-align: center;
    background-color: rgba(29, 35, 155, 1);
    color: #fff;
    line-height: normal;
    z-index: 200;
  }

  h5 {
    font-weight:600;
  }

  p {
    font-weight:400;
    font-size: 1.25rem;
  }

  a {
    color: #fbff00;
    text-decoration: none;
  }
  a:hover {
    color: #00a30e;
  }
  button {
    font-weight: 600;
    font-size: 1.5rem;
  }

</style>