<template>
  Inspire
</template>

<script>
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { imagesService } from '../services/ImagesService.js';
import { onMounted } from 'vue';

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

    }
  }
}
</script>

<style scoped lang="scss"></style>
