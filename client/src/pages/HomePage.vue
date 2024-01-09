<template>
  <div class="container-fluid">
    <section class="row">
      <div class="col-12 p-0">

        <img class="img-fluid" :src="images.imgUrl" alt="image url">
        <!-- <p class="author-title fs-4 text-light"> Image by: {{ images.author }}</p> -->
        <p class="content-title fs-3 text-light"> {{ quotes.content }}</p>
        <p class="quote-author fs-5 text-light">- {{ quotes.author }}</p>
        <p class="text-white text-center timer-content" id="demo"></p>
      </div>
    </section>
    <section class="row">
      <div class="todo-section">
        <form @submit.prevent="createToDo()">
          <div class="mb-3 col-4 d-flex ">
            <label for="description" class="form-label"></label>
            <textarea v-model="editable.description" text-break type="text" class="form-control" id="description" rows="2"
              maxlength="1000" required placeholder="Create a ToDo..."></textarea>
            <button role="button" type="submit" class="btn btn-outline-dark bg-light m-2"><i
                class="mdi mdi-plus"></i></button>
          </div>
          <!-- <div class="mb-3">
            <label class="me-2" for="completed">Completed</label>
            <input v-model="editable.completed" type="checkbox" class="form-check-input" id="completed">
          </div> -->

        </form>

      </div>
    </section>
    <section class="row todo-list bg-light">
      <div v-for="  toDo   in   toDos  " :key="toDo.id" class="col-12">

        <span class="">
          {{ toDo.description }}
          <input @click="updateToDo(toDo.id)" v-model="editable.completed" type="checkbox" class="form-check-input">
          <i @click="destroyToDo(toDo.id)" class="mdi mdi-close fs-5"></i>
        </span>
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
import { computed, onMounted, ref } from 'vue';
import { AppState } from '../AppState.js';

export default {
  setup() {
    const editable = ref({})
    // const editable2 = ref({})
    onMounted(() => {
      getImages()
      getQuotes()
      getToDos()
    })
    async function getImages() {
      try {
        // document.body.style.backgroundImage = `url(${AppState.images?.imgUrl})`
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
    async function getToDos() {
      try {
        await toDosService.getToDos()
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
      editable,
      images: computed(() => AppState.images),
      quotes: computed(() => AppState.quotes),
      toDos: computed(() => AppState.toDos),
      async createToDo() {
        try {
          const toDoData = editable.value
          await toDosService.createToDo(toDoData)
          Pop.success('To Do Created!')
          editable.value = {}
        } catch (error) {
          logger.error(error)
          Pop.error(error)

        }
      },
      async destroyToDo(toDoId) {
        try {
          const wantstoDestroy = await Pop.confirm('Are you sure you want to destroy this ToDo? ');
          if (!wantstoDestroy) {
            return;
          }
          await toDosService.destroyToDo(toDoId);
        } catch (error) {
          logger.error(error)
          Pop.error(error)

        }
      },
      async updateToDo(toDoId) {
        try {
          const toDoData = editable.value
          await toDosService.updateToDo(toDoId, toDoData);
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

.quote-author {
  position: absolute;
  bottom: 50px;
  left: 50%;
  opacity: 0;
  visibility: hidden;
  font-family: 'Pinyon Script', cursive;
}

.content-title:hover+.quote-author {
  opacity: 1;
  visibility: visible;
}

.content-title {
  position: absolute;
  bottom: 80px;
  left: 15%;
  cursor: help;
  font-family: 'Pinyon Script', cursive;
}

.timer-content {
  position: absolute;
  top: 110px;
  left: 600px;
  font-size: 60px;
  font-family: Georgia, 'Times New Roman', Times, serif;
}

.todo-section {
  position: absolute;
  bottom: 400px;
}

.todo-list {
  position: absolute;
  // bottom: 200px;
  top: 320px;
  border-radius: 7px;
  width: 33%;
  padding: 2px;
  margin-left: 2px;

}
</style>
