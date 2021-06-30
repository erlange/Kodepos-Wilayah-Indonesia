<script lang="ts">
import { createEventDispatcher } from "svelte";

const dispatch = createEventDispatcher();

const onFirst = (event: Event) => {
  event.preventDefault()
  dispatch('first');
}
const onPrev = (event: Event) => {
  event.preventDefault()
  dispatch('previous');
}
const onNext = (event: Event) => {
  event.preventDefault()
  dispatch('next');
}

const onLast = (event: Event) => {
  event.preventDefault()
  dispatch('last');
}


export let value: number;

</script>

<form action="post">
  <span class="b" on:click="{onFirst}"><i class="fas fa-angle-double-left "></i></span>
  <span on:click="{onPrev}"><i class="fas fa-angle-left"></i></span>
  
  <input type="text" disabled class="browser-default pageText" value="{value}"/>
  <span on:click="{onNext}"><i class="fas fa-angle-right"></i></span>
  <span on:click="{onLast}"><i class="fas fa-angle-double-right"></i></span>
</form>

<style>
  span {
    display: inline-block;
    width: 30px;
    padding-left: 10px;
    cursor: pointer;
    font-size: 1.2em;
    background-color: #303f9f  ;
    color:white;
    border-radius: 2px;
    margin-left: -5px;
  }

  span:hover {
    background-color: #0a6dbd  ;
  }

  .pageText {
    width: 50px;
  }
</style>