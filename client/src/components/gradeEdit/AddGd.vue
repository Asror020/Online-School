<template>
    <div>
      <h2>Create New Grade</h2>
      <form @submit.prevent="saveGrade">
        <div class="form-group">
          <label for="name">Student Name:</label>
          <select class="form-control" id="subject" v-model="grade.studentFullName" required>
            <option v-for="student in students" :key="student.user.firstName + ' ' + student.user.lastName">
                {{student.user.firstName + " " + student.user.lastName}}
            </option>
          </select>
        </div>
        <div class="form-group">
          <label for="score">Score:</label>
          <input type="number" class="form-control" id="score" v-model="grade.score" required>
        </div>
        <div class="form-group">
          <label for="subject">Subject:</label>
          <select class="form-control" id="subject" v-model="grade.subjectName" required>
            <option v-for="subject in subjects" :key="subject.Name">{{ subject.name }}</option>
          </select>
        </div>
        <button type="submit" class="btn btn-primary">Save</button>
        <button type="button" class="btn btn-secondary" @click="$router.go(-1)">Cancel</button>
      </form>
    </div>
  </template>
  
  <script>
  import axios from 'axios';
  
  let baseUrl = "https://localhost:7122/api/";
  
  export default {
    name: 'CreateGrade',
    data() {
      return {
        grade: {
          studentFullName: '',
          score: 0,
          subjectName: ''
        },
        subjects: [],
        students: []
      }
    },
    mounted() {
      this.getSubjects();
      this.getStudents();
    },
    methods: {
      getSubjects() {
        axios.get(baseUrl + "subjects")
          .then(response => {
            this.subjects = response.data;
          })
          .catch(error => {
            console.log(error);
          });
      },
      getStudents() {
        axios.get(baseUrl + "students")
          .then(response => {
            this.students = response.data;
            console.log(response.data)
          })
          .catch(error => {
            console.log(error);
          });
      },
      saveGrade() {
        this.students = this.students.filter(x => x.user.firstName + " " + x.user.lastName == this.grade.studentFullName)
        this.grade.studentId = this.students[0].id;
        axios.post(baseUrl + "grades", this.grade)
          .then(() => {
            this.$router.push({ name: 'GradesList' });
          })
          .catch(error => {
            console.log(error);
          });
      }
    }
  }
  </script>
  
  <style scoped>
  @import "~bootstrap/dist/css/bootstrap.min.css";
  </style>