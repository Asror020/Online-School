<template>
    <div>
      <h2>Edit Subject</h2>
      <form @submit.prevent="submitForm">
        <div class="form-group">
          <label for="name">Name:</label>
          <input type="text" class="form-control" id="name" v-model="subject.name" required>
        </div>
        <div class="form-group">
          <label for="professorId">Professor ID:</label>
          <input type="number" class="form-control" id="professorId" v-model="subject.professorId" required>
        </div>
        <button type="submit" class="btn btn-primary">Save</button>
        <button type="button" class="btn btn-secondary" @click="this.$router.push({name : 'SubjectsList'})">Cancel</button>
      </form>
    </div>
  </template>
  
  <script>
  import axios from 'axios';
import { useRoute } from 'vue-router';
  
  let baseUrl = "https://localhost:7122/api/";
  
  export default {
    name: 'EditSubject',
    props: {
      id: {
        type: Number,
        required: true
      }
    },
    data() {
      return {
        subject: {
          name: '',
          professorId: ''
        },
        route: useRoute()
      }
    },
    mounted() {
      this.getSubject();
    },
    methods: {
      getSubject() {
        axios.get(baseUrl + 'subjects/' + this.route.params.id)
          .then(response => {
            this.subject = response.data;
          })
          .catch(error => {
            console.log(error)
          })
      },
      submitForm() {
        axios.put(baseUrl + 'subjects/' + this.route.params.id, this.subject)
          .then(() => {
            this.$router.push({name : 'SubjectsList'})
          })
          .catch(error => {
            console.log(error)
          })
      }
    }
  }
  </script>
  
  <style scoped>
  @import "~bootstrap/dist/css/bootstrap.min.css";
  </style>