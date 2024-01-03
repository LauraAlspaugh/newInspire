<template>
  <div class="container-fluid">
    <section class="row">
      <div class="col-12">

        <img class="img-fluid" :src="images.imgUrl" alt="image url">
        <p class="author-title fs-4 text-light"> Image by: {{ images.author }}</p>
        <p> {{ quotes.content }}</p>
      </div>
    </section>
  </div>
</template>

<script>
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { imagesService } from '../services/ImagesService.js';
import { quotesService } from '../services/QuotesService.js';
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
    return {
      images: computed(() => AppState.images),
      quotes: computed(() => AppState.quotes)
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
</style>
