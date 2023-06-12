<template>
    <div>
      <h2>Subjects List</h2>
      <div class="d-flex justify-content-between align-items-center mb-3">
        <a class="btn btn-primary" href="/subject/create">Add new Subject</a>
      </div>
      <div class="table-responsive">
        <table class="table table-striped table-hover">
          <thead>
            <tr>
              <th>Id</th>
              <th>Name</th>
              <th>Professor Name</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="subject in subjects" :key="subject.id">
              <td>{{ subject.id }}</td>
              <td>{{ subject.name }}</td>
              <td>{{ subject.professorFullName }}</td>
              <td>
                <button class="btn btn-secondary" @click="editSubject(subject.id)">Edit</button>
              </td>
              <td>
                <button class="btn btn-danger" @click="deleteSubject(subject.id)">Delete</button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </template>
  
  <script>
  import axios from 'axios';
  
  let baseUrl = "https://localhost:7122/api/";
  
  export default {
    name: 'SubjectsList',
    data() {
      return {
        subjects: [],
      }
    },

    mounted() {
      this.getSubjects();
    },

    methods: {
      getSubjects() {
        axios.get(baseUrl + "subjects")
          .then(response => {
            this.subjects = response.data;
          })
          .catch(error => {
            console.log(error)
          })
      },
      deleteSubject(id) {
        axios.delete(baseUrl + 'subjects/' + id)
            .then(() => {
              const index = this.subjects.findIndex(subject => subject.id === id);
              if (index > -1) {
                this.subjects.splice(index, 1);
              }
            })
            .catch(error => {
              console.log(error)
            })
      },
      editSubject(id) {
        this.$router.push({ name: 'SubjectEdit', params: { id: id } });
      }
    }
  }
  </script>
  
  <style scoped>
  @import "~bootstrap/dist/css/bootstrap.min.css";
  </style>