<template>
   <div>
    <router-link to="/">Home</router-link>
    |
    <router-link to="/professor">Professors</router-link>
    |
    <router-link to="/student">Students</router-link>
    |
    <router-link to="/subject">Subjects</router-link>
    |
    <router-link to="/grade">Grades</router-link>
    <router-view/>
  </div>
</template>

<script>
export default {
name: 'headerList'
}
</script>

<style>

</style>