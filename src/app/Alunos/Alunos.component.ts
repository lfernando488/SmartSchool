import { Component, OnInit } from '@angular/core';
import { Aluno } from './../models/aluno';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.css']
})
export class AlunosComponent implements OnInit {

  titulo = "Alunos";
  public alunoSelecionado!: Aluno | undefined;

  alunos = [
    {id: 1, nome: "Ana", sobrenome: 'Silva', telefone: '+55 (11) 9 1234-5678'},
    {id: 2, nome: "Jão", sobrenome: 'Peres', telefone: '+55 (11) 9 1234-5678'},
    {id: 3, nome: "Chico", sobrenome: 'Ferreira', telefone: '+55 (11) 9 1234-5678'},
    {id: 4, nome: "Pedrin", sobrenome: 'Souza', telefone: '+55 (11) 9 1234-5678'},
    {id: 5, nome: "Zé", sobrenome: 'Alves', telefone: '+55 (11) 9 1234-5678'},
    {id: 6, nome: "Rita", sobrenome: 'Oliveira', telefone: '+55 (11) 9 1234-5678'},
    {id: 7, nome: "Ana", sobrenome: 'Santos', telefone: '+55 (11) 9 1234-5678'},
    {id: 8, nome: "Artu", sobrenome: 'Costa', telefone: '+55 (11) 9 1234-5678'},
    {id: 9, nome: "Bebel", sobrenome: 'Fernandes', telefone: '+55 (11) 9 1234-5678'},
    {id: 10, nome: "Buiu", sobrenome: 'Carvalho', telefone: '+55 (11) 9 1234-5678'},
    {id: 11, nome: "Glaucia", sobrenome: 'Vieira', telefone: '+55 (11) 9 1234-5678'},
    {id: 12, nome: "Marta", sobrenome: 'Albuquerque', telefone: '+55 (11) 9 1234-5678'}
  ]

  constructor() { }

  ngOnInit(): void {
  }

  public alunoSelect(aluno: Aluno){
    this.alunoSelecionado = aluno;
  }

  public voltar (){
    this.alunoSelecionado = undefined;
  }

}
