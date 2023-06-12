<template>
    <div>
      <h2>Add New Subject</h2>
      <form @submit.prevent="submitForm">
        <div class="form-group">
          <div class="row">
            <div class="col">
                <label for="name">Name:</label>
                <input type="text" class="form-control" id="name" v-model="subject.name" required>
            </div>
            <div class="col">
                <label for="professorId">Professor ID:</label>
                <select class="form-control" id="subject" v-model="subject.professorFullName" required>
                  <option v-for="professor in professors" :key="professor.user.firstName + ' ' + professor.user.lastName">
                      {{professor.user.firstName + " " + professor.user.lastName}}
                  </option>
                </select>
            </div>
          </div>
        </div>
        <button type="submit" class="btn btn-primary">Submit</button>
      </form>
    </div>
  </template>
  
  <script>
import axios from 'axios';
  
  let baseUrl = "https://localhost:7122/api/";
  
  export default {
    name: 'AddSubject',
    data() {
      return {
        subject: {
          name: '',
          professorId: ''
        },
        professors: []
      }
    },

    mounted() {
      this.getProfessors();
    },

    methods: {
      submitForm() {
        this.professors = this.professors.filter(x => x.user.firstName + " " + x.user.lastName == this.subject.professorFullName)
        this.subject.professorId = this.professors[0].id;
        axios.post(baseUrl + 'subjects', this.subject)
          .then(() => {
            this.$router.push({name : 'SubjectsList'})
          })
          .catch(error => {
            console.log(error)
          })
      },
      getProfessors(){
        axios.get(baseUrl + 'Professors')
          .then(response => {
            this.professors = response.data
            console.log(response.data)
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