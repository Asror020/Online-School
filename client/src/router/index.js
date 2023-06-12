import { createRouter, createWebHistory } from 'vue-router'
import Home from '../components/index.vue'
import Porfessor from '../components/professor.vue'
import PorfessorCreate from '../components/professorEdit/AddPf.vue'
import PorfessorEdit from '../components/professorEdit/EditPf.vue'
import Student from '../components/student.vue'
import StudentCreate from '../components/studentEdit/AddSt.vue'
import StudentEdit from '../components/studentEdit/EditSt.vue'
import Subject from '../components/subject.vue'
import SubjectCreate from '../components/subjectEdit/AddSb.vue'
import SubjectEdit from '../components/subjectEdit/EditSb.vue'
import Grade from '../components/grade.vue'
import GradeCreate from '../components/gradeEdit/AddGd.vue'
import GradeEdit from '../components/gradeEdit/EditGd.vue'

const routes = [{
        path: '/',
        name: 'Home',
        component: Home
    },
    {
        path: '/professor',
        name: 'Professor',
        component: Porfessor
    },
    {
        path: '/professor/create',
        name: 'ProfessorCreate',
        component: PorfessorCreate
    },
    {
        path: '/professor/edit/:id',
        name: 'ProfessorEdit',
        component: PorfessorEdit
    },
    {
        path: '/student',
        name: 'Student',
        component: Student
    },
    {
        path: '/student/create',
        name: 'StudentCreate',
        component: StudentCreate
    },
    {
        path: '/student/edit/:id',
        name: 'StudentEdit',
        component: StudentEdit
    },
    {
        path: '/subject',
        name: 'SubjectsList',
        component: Subject
    },
    {
        path: '/subject/create',
        name: 'SubjectCreate',
        component: SubjectCreate
    },
    {
        path: '/subject/edit/:id',
        name: 'SubjectEdit',
        component: SubjectEdit
    },
    {
        path: '/grade',
        name: 'GradesList',
        component: Grade
    },
    {
        path: '/grade/create',
        name: 'GradeCreate',
        component: GradeCreate
    },
    {
        path: '/grade/edit/:id',
        name: 'GradeEdit',
        component: GradeEdit
    },
]

const router = createRouter({
    history: createWebHistory(""),
    routes
})

export default router