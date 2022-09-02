<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import Header from './components/Header.vue'
import Sidebar from './components/Sidebar.vue'

</script>

<template>
  <Header />
  <div class="container-fluid">  
    <div class="row">
      <Sidebar />
      <main class="col-md-9 ms-sm-auto col-lg-10 px-md-4">
        <RouterView />
      </main>
    </div>
  </div>
</template>

<style scoped>
</style>
