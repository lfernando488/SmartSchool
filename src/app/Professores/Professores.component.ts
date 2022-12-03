import { Component, OnInit } from '@angular/core';
import { Professor } from './../models/professor';

@Component({
  selector: 'app-Professores',
  templateUrl: './Professores.component.html',
  styleUrls: ['./Professores.component.css']
})
export class ProfessoresComponent implements OnInit {

  titulo = "Professores"
  public professorSelecionado!: Professor | undefined;;

  professores = [
    {id: 1, nome : "Carlo", disciplina : 'Matemática'},
    {id: 2, nome : "Zéfa", disciplina : 'Física'},
    {id: 3, nome : "Tonin", disciplina : 'Quimica'},
    {id: 4, nome : "Cida", disciplina : 'Geografia'},
  ]

  constructor() { }

  ngOnInit() {
  }

  public alunoSelect(professor: Professor){
    this.professorSelecionado = professor;
  }

  public voltar(){
    this.professorSelecionado = undefined;
  }

}
