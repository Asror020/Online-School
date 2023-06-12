<template>
    <div>
      <h2>Grades List</h2>
      <div class="d-flex justify-content-between align-items-center mb-3">
        <a class="btn btn-primary" href="/grade/create">Add new Grade</a>
      </div>
      <div class="table-responsive">
        <table class="table table-striped table-hover">
          <thead>
            <tr>
              <th>Id</th>
              <th>Student Name</th>
              <th>Score</th>
              <th>Subject</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="grade in grades" :key="grade.id">
              <td>{{ grade.id }}</td>
              <td>{{ grade.studentFullName }}</td>
              <td>{{ grade.score }}</td>
              <td>{{ grade.subjectName }}</td>
              <td>
                <button class="btn btn-secondary" @click="editGrade(grade.id)">Edit</button>
              </td>
              <td>
                <button class="btn btn-danger" @click="deleteGrade(grade.id)">Delete</button>
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
    name: 'GradesList',
    data() {
      return {
        grades: [],
        subjects: []
      }
    },
    mounted() {
      this.getGrades();
      this.getSubjects();
    },
    methods: {
      getGrades() {
        axios.get(baseUrl + "grades")
          .then(response => {
            this.grades = response.data;
          })
          .catch(error => {
            console.log(error);
          });
      },
      deleteGrade(id) {
        axios.delete(baseUrl + 'grades/' + id)
          .then(() => {
            const index = this.grades.findIndex(grade => grade.id === id);
            if (index > -1) {
              this.grades.splice(index, 1);
            }
          })
          .catch(error => {
            console.log(error);
          });
      },
      editGrade(id) {
        this.$router.push({ name: 'GradeEdit', params: { id: id } });
      },
      getSubjects() {
        axios.get(baseUrl + "subjects")
          .then(response => {
            this.subjects = response.data;
          })
          .catch(error => {
            console.log(error);
          });
      },
      getSubjectNameById(id) {
        const subject = this.subjects.find(subject => subject.id === id);
        return subject ? subject.name : "";
      }
    }
  }
  </script>
  
  <style scoped>
  @import "~bootstrap/dist/css/bootstrap.min.css";
  </style>