<template>
  <div>
    <h2>Professors List</h2>
    <div class="d-flex justify-content-between align-items-center mb-3">
      <a class="btn btn-primary" href="/professor/create">Add new Professor</a>
    </div>
    <div class="table-responsive">
      <table class="table table-striped table-hover">
        <thead>
          <tr>
            <th>Id</th>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Phone Number</th>
            <th>Date of Birth</th>
            <th>Email</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="professor in professors" :key="professor.id">
            <td>{{ professor.id }}</td>
            <td>{{ professor.user.firstName }}</td>
            <td>{{ professor.user.lastName }}</td>
            <td>{{ professor.user.phoneNumber }}</td>
            <td>{{ professor.user.dateOfBirth }}</td>
            <td>{{ professor.user.email }}</td>
            <td>
              <button class="btn btn-secondary" @click="editProfessor(professor.id)">Edit</button>
            </td>
            <td>
              <button class="btn btn-danger" @click="deleteProfessor(professor.id)">Delete</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <add-professor v-if="showProfessorForm" @close="showProfessorForm = false" />
  </div>
</template>

<script>

import axios from 'axios';
let baseUrl = "https://localhost:7122/api/";

export default {
    name: 'ProfessorsList',
    data() {
        return {
        professors: [],
        students: []
      }
    },

    mounted() {
    this.getProfessors();
    },

    methods: {
      getProfessors() {
        axios.get(baseUrl + "professors")
          .then(response => {
            this.professors = response.data
          })
          .catch(error => {
            console.log(error)
          })
      },
      deleteProfessor(id) {
        axios.delete(baseUrl + 'professors/' + id)
            .then(() => {
            const index = this.professors.findIndex(professor => professor.id === id);
            if (index > -1) {
                this.professors.splice(index, 1);
            }
            })
            .catch(error => {
            console.log(error)
            })
      },
      editProfessor(id) {
        this.$router.push({ name:  'ProfessorEdit', params: { id: id } });
}
    }
}
</script>

<style scoped>
@import "~bootstrap/dist/css/bootstrap.min.css";
</style>