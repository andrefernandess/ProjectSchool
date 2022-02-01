<template>
  <div>
    <Titulo texto="Alunos" />
    <div>
      <input type="text" placeholder="RA do Aluno" v-model="ra">
      <input type="text" placeholder="Nome do Aluno" v-model="name">
      <input type="text" placeholder="CPF do Aluno" v-model="cpf">
      <input type="text" placeholder="Email do Aluno" v-model="email">
      <button class="btn btnInput" @click="addAluno()">Adicionar</button>
    </div>
    <table>
      <thead>
        <th>RA</th>
        <th>Nome</th>
        <th>CPF</th>
        <th>EMAIL</th>
        <th>Opcoes</th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="(aluno, index) in alunos" :key="index">
          <td>{{aluno.ra}}</td>
          <td>{{aluno.name}}</td>
          <td>{{aluno.cpf}}</td>
          <td>{{aluno.email}}</td>
          <td>
            <button class="btn btn_danger" @click="remover(aluno)">Remover</button>
          </td>
        </tr>
      </tbody>
      <tfoot  v-else>
        Nenhum dado encontrado
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from './_share/Titulo'
var urlApi = "http://localhost:5000/api";

export default {
  components: {
    Titulo
  },
  data() {
    return {
      titulo: 'Aluno',
      name: '',
      ra: '',
      cpf: '',
      email: '',
      alunos: []
    }
  },
  created() {
      let link = urlApi+"/students";
      this.$http.get(link)
        .then(res => res.json())
        .then(alunos => this.alunos = alunos);

        console.log(this.alunos)
  },
  props: {},
  methods: {
    addAluno() {
      let _aluno = {
        Id: 0,
        Ra: '',
        Name: this.Name,
        Cpf: '',
        Email: ''
      };

      this.$http.post(urlApi+"/students", _aluno)
        .then(res => res.json())
        .then(aluno => {
          this.alunos.push(aluno);
          this.nome = "";
        console.log(aluno);
      })

    },
    remover(aluno) {
      let indice = this.alunos.indexOf(aluno);
      this.alunos.splice(indice,1);
    }
  },
}
</script>

<style scoped>
  input {
    width: 20%;
    border: 1;
    padding: 2px;
    font-size: 1.3em;
    color: black;
    display: inline;
    margin: 5px;
  }
  .btnInput {
    width: 120px;
    border: 0px;
    padding: 5px;
    font-size: 1.3em;
    background-color: rgb(116, 115, 115);
  }
  .btnInput:hover {
    text-shadow: 1px 1px 1px black;
  }
</style>
