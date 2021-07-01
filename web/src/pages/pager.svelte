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

const onSetPage = (event: Event, newValue: string) => {
  event.preventDefault()
  if ( !isNaN( Number(newValue)) ) {
    newPage = Number(newValue);
    dispatch('setPage', newPage);
  }
}

export let value: number;
let textInput: HTMLInputElement;
export let newPage: number;
</script>

<form action="post" on:submit="{(e) => onSetPage(e, textInput.value.trim())}">
  <span class="b" on:click="{onFirst}"><i class="fas fa-angle-double-left "></i></span>
  <span on:click="{onPrev}"><i class="fas fa-angle-left"></i></span>
  
  <input bind:this={textInput} type="text" class="browser-default pageText" value="{value}"/>
  <span on:click="{onNext}"><i class="fas fa-angle-right"></i></span>
  <span on:click="{onLast}"><i class="fas fa-angle-double-right"></i></span>
  <input type="submit"  />
</form>

<style>
  input[type=submit] {
    display: none;
  }
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
    text-align: right;
    width: 50px;
  }
</style>