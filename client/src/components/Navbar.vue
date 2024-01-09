<template>
  <nav class="navbar navbar-expand-sm navbar-dark nav-color px-3">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <i class="mdi mdi-forest-outline fs-1 photo-title "><span class="plan-title fs-1 p-0 m-2 text-white"
            title="back to homepage">Inspire
          </span></i>
      </div>
    </router-link>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav me-auto">
        <p class="fs-1 text-white d-flex p-0 m-2 weather-title"> {{ (weather.weather * (9 / 5) +
          32).toFixed(0)
        }}<i class="mdi mdi-temperature-fahrenheit"></i>
        </p>
        <div class="col-12 weather-info">
          <p class="">{{ weather.name }}</p>
          <p class="">{{ weather.wind }}</p>
          <p>{{ weather.humidity }}</p>
        </div>
        <li>
          <!-- <router-link :to="{ name: 'About' }" class="btn text-success lighten-30 selectable text-uppercase">
            About
          </router-link> -->
        </li>
      </ul>
      <!-- LOGIN COMPONENT HERE -->
      <div>
        <button class="btn text-light" @click="toggleTheme"><i class="mdi"
            :class="theme == 'light' ? 'mdi-weather-sunny' : 'mdi-weather-night'"></i></button>
      </div>
      <Login />
    </div>
  </nav>
</template>

<script>
import { computed, onMounted, ref } from 'vue';
import { loadState, saveState } from '../utils/Store.js';
import Login from './Login.vue';
import { imagesService } from '../services/ImagesService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
export default {
  setup() {

    const theme = ref(loadState('theme') || 'light')

    onMounted(() => {
      document.documentElement.setAttribute('data-bs-theme', theme.value)
      getWeather()
    })
    async function getWeather() {
      try {
        await imagesService.getWeather()
      } catch (error) {
        logger.error(error)
        Pop.error(error)

      }
    }

    return {
      theme,
      toggleTheme() {
        theme.value = theme.value == 'light' ? 'dark' : 'light'
        document.documentElement.setAttribute('data-bs-theme', theme.value)
        saveState('theme', theme.value)
      },
      weather: computed(() => AppState.weather)
    }
  },
  components: { Login }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.weather-title:hover+.weather-info {
  opacity: 1;
  visibility: visible;
}

.weather-title {
  cursor: help;
}

.weather-info {
  position: absolute;
  opacity: 0;
  visibility: hidden;
  font-family: 'Pinyon Script', cursive;
}

.nav-color {
  background-color: #BFC9CA;
  /* background: rgba(138, 192, 199, 0.62);
  backdrop-filter: blur(3.6px);
  opacity: 6px; */

}

.photo-title {
  /* font-family: 'Pinyon Script', cursive; */
  font-family: Georgia, 'Times New Roman', Times, serif;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}
</style>
