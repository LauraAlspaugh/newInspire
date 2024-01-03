<template>
  <div class="container-fluid">
    <section class="row">
      <div class="col-12 p-0">

        <img class="img-fluid" :src="images.imgUrl" alt="image url">
        <p class="author-title fs-4 text-light"> Image by: {{ images.author }}</p>
        <p class="content-title fs-4 text-light"> {{ quotes.content }}</p>
        <p class="fs-1 text-white text-center timer-content" id="demo"></p>
      </div>
    </section>
  </div>
</template>

<script>
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { imagesService } from '../services/ImagesService.js';
import { quotesService } from '../services/QuotesService.js';
import { toDosService } from '../services/ToDosService.js';
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';

export default {
  setup() {
    onMounted(() => {
      getImages()
      getQuotes()
    })
    async function getImages() {
      try {
        await imagesService.getImages()
      } catch (error) {
        logger.error(error)
        Pop.error(error)

      }
    }
    async function getQuotes() {
      try {
        await quotesService.getQuotes()
      } catch (error) {
        logger.error(error)
        Pop.error(error)
      }
    }
    function myTimer() {
      const date = new Date();
      document.getElementById("demo").innerHTML = date.toLocaleTimeString();
    }
    setInterval(myTimer, 1000);
    return {
      images: computed(() => AppState.images),
      quotes: computed(() => AppState.quotes),
      async createToDo() {
        try {
          await toDosService.createToDo()
        } catch (error) {
          logger.error(error)
          Pop.error(error)

        }
      }
    }
  }
}
</script>

<style scoped lang="scss">
img {
  position: relative;
  object-fit: cover;
  position: center;
  width: 220dvh;
  height: 90dvh;
}

.author-title {
  position: absolute;
  bottom: 20px;
  left: 60px;

}

.content-title {
  position: absolute;
  top: 130px;
  left: 80px;
}

.timer-content {
  position: absolute;
  bottom: 80px;
  left: 600px;
}
</style>
