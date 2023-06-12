<template>
    <div class="">
    <h2>Edit Student</h2>
    <form @submit.prevent="updateStudent">
      <div class="form-group">
        <div class="row">
          <div class="col">
            <label for="firstName">First Name:</label>
            <input type="text" class="form-control" id="firstName" v-model="Student.user.firstName">
          </div>
          <div class="col">
            <label for="lastName">Last Name:</label>
            <input type="text" class="form-control" id="lastName" v-model="Student.user.lastName">
          </div>
        </div>
      </div>
      <div class="form-group">
        <div class="row">
          <div class="col">
            <label for="phoneNumber">Phone Number:</label>
            <input type="text" class="form-control" id="phoneNumber" v-model="Student.user.phoneNumber">
          </div>
          <div class="col">
            <label for="dateOfBirth">Date of Birth:</label>
            <input type="date" class="form-control" id="dateOfBirth" v-model="Student.user.dateOfBirth">
          </div>
        </div>
      </div>
      <div class="form-group">
        <div class="row">
          <div class="col">
            <label for="email">Email:</label>
            <input type="email" class="form-control" id="email" v-model="Student.user.email">
          </div>
          <div class="col">
            <label for="registrationId">Registration Id:</label>
            <input type="text" class="form-control" id="registrationId" v-model="Student.registrationId">
          </div>
        </div>
      </div>
      <div>
        <button type="submit" class="btn btn-primary">Update</button>
      </div>
    </form>
  </div>
</template>
  <script>
import axios from 'axios';
import { useRoute } from 'vue-router';
  
  let baseUrl = "https://localhost:7122/api/";

  export default {
    name: 'StudentEdit',

    props: {
        id: {
        type: Number,
        required: true,
        },
    },
    data() {
      return {
        Student: {
          registrationId: '',
            user: {
                firstName: '',
                lastName: '',
                email: '',
                phoneNumber: '',
                password: '',
                dateOfBirth: ''
            }
        },
        route: useRoute()
      }
    },
    
    mounted() {
      this.getStudent();
    },
    methods: {
      getStudent() {
        axios.get(baseUrl + 'Students/' + this.route.params.id)
          .then(response => {
            this.Student = response.data;
            console.log(response.data)
          })
          .catch(error => {
            console.log(error)
          })
      },
      updateStudent() {
        console.log(this.route.params.id),
        console.log(this.Student),
        axios.put(baseUrl + 'Students/' + this.route.params.id, this.Student)
          .then(() => {
            this.$router.push({name : 'Student'});
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
  .Student-form {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    margin-top: 50px;
  }
  .form-group {
    margin-bottom: 15px;
  }
  .row {
    display: flex;
    flex-wrap: wrap;
    margin-right: -15px;
    margin-left: -15px;
  }
  .col {
    flex: 1;
    padding-right: 15px;
    padding-left: 15px;
  }
  label {
    font-weight: bold;
    margin-bottom: 5px;
  }
  input[type='text'],
  input[type='email'],
  input[type='password'],
  input[type='date'] {
    width: 100%;
    padding: 10px;
    border: 1px solid #ccc;
    border-radius: 5px;
    font-size: 16px;
  }
  button[type='submit'] {
    padding: 10px 20px;
    border: none;
    border-radius: 5px;
    background-color: #6a64f1;
    color: #fff;
    font-size: 16px;
    cursor: pointer;
  }
  button[type='submit']:hover {
    background-color: #544de2;
  }
  </style>