<template>
    <div class="professor-form">
      <h2>Add New Professor</h2>
      <form @submit.prevent="createProfessor">
        <div class="form-group">
          <div class="row">
            <div class="col">
              <label for="first_name">First Name:</label>
              <input type="text" id="first_name" v-model="newProfessor.user.firstName" required />
            </div>
            <div class="col">
              <label for="last_name">Last Name:</label>
              <input type="text" id="last_name" v-model="newProfessor.user.lastName" required />
            </div>
          </div>
        </div>
        <div class="form-group">
          <div class="row">
            <div class="col">
              <label for="email">Email:</label>
              <input type="email" id="email" v-model="newProfessor.user.email" required />
            </div>
            <div class="col">
              <label for="phone">Phone Number:</label>
              <input type="text" id="phone" v-model="newProfessor.user.phoneNumber" required />
            </div>
          </div>
        </div>
        <div class="form-group">
          <div class="row">
            <div class="col">
              <label for="password">Password:</label>
              <input type="password" id="password" v-model="newProfessor.user.password" required />
            </div>
            <div class="col">
              <label for="dob">Date of Birth:</label>
              <input type="date" id="dob" v-model="newProfessor.user.dateOfBirth" required />
            </div>
          </div>
        </div>
        <div class="form-group">
          <button type="submit">Add Professor</button>
        </div>
      </form>
    </div>
  </template>
  
  <script>
  import axios from 'axios';
  
  export default {
    data() {
      return {
        newProfessor: {
          user: {
            firstName: '',
            lastName: '',
            email: '',
            phoneNumber: '',
            password: '',
            dateOfBirth: ''
          }
        }
      };
    },
    methods: {
      createProfessor() {
        axios.post('https://localhost:7122/api/professors', this.newProfessor)
          .then(response => {
            console.log(response.data);
            this.newProfessor.user.firstName = '';
            this.newProfessor.user.lastName = '';
            this.newProfessor.user.phoneNumber = '';
            this.newProfessor.user.dateOfBirth = '';
            this.newProfessor.user.email = '';
            this.newProfessor.user.password = '';

            this.$router.push({name : 'Professor'});
          })
          .catch(error => {
            console.log(error);
          });
      }
    }
  };
  </script>
  
  <style scoped>
  .professor-form {
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