<template>
  <div class="container-fluid">
    <section class="row">
      <div class="col-12">

        <img class="img-fluid" :src="images.imgUrl" alt="image url">
      </div>
    </section>
  </div>
</template>

<script>
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { imagesService } from '../services/ImagesService.js';
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';

export default {
  setup() {
    onMounted(() => {
      getImages()
    })
    async function getImages() {
      try {
        await imagesService.getImages()
      } catch (error) {
        logger.error(error)
        Pop.error(error)

      }
    }
    return {
      images: computed(() => AppState.images)
    }
  }
}
</script>

<style scoped lang="scss"></style>
