<template>
  <div class="table-responsive">
        <h2>Students List</h2>
        <div class="d-flex justify-content-between align-items-center mb-3">
          <a class="btn btn-primary" href="/student/create">Add new Student</a>
        </div>
        <table class="table table-striped table-hover">
          <thead>
            <tr>
              <th>Id</th>
              <th>Registration Id</th>
              <th>First Name</th>
              <th>Last Name</th>
              <th>Phone Number</th>
              <th>Date of Birth</th>
              <th>Email</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="student in students" :key="student.id">
              <td>{{ student.id }}</td>
              <td>{{ student.registrationId }}</td>
              <td>{{ student.user.firstName }}</td>
              <td>{{ student.user.lastName }}</td>
              <td>{{ student.user.phoneNumber }}</td>
              <td>{{ student.user.dateOfBirth }}</td>
              <td>{{ student.user.email }}</td>
              <td>
                <button class="btn btn-secondary" @click="editStudent(student.id)">Edit</button>
              </td>
              <td>
                <button class="btn btn-danger" @click="deleteStudent(student.id)">Delete</button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
</template>

<script>

import axios from 'axios';
let baseUrl = "https://localhost:7122/api/";

export default {
name: 'studentsList',
    data (){
        return{
            students: []
        }
    },

    mounted() {
    this.getStudents();
    },

    methods: {
        getStudents() {
        axios.get(baseUrl + "students")
          .then(response => {
            this.students = response.data
          })
            .catch(error => {
            console.log(error)
          })
        },
        deleteStudent(id) {
            axios.delete(baseUrl + 'students/' + id)
            .then(() => {
            const index = this.students.findIndex(student => student.id === id);
            if (index > -1) {
                this.students.splice(index, 1);
            }
            })
            .catch(error => {
            console.log(error)
            })
        },
        editStudent(id){
          this.$router.push({name : 'StudentEdit', params: {id : id}})
        }
    }
}
</script>

<style scoped>
@import "~bootstrap/dist/css/bootstrap.min.css";
</style>