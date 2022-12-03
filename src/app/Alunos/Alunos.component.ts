import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Aluno } from './../models/aluno';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.css']
})
export class AlunosComponent implements OnInit {

  titulo = "Alunos";
  public alunoSelecionado!: Aluno | undefined;
  public textSimple!: string;
  public alunoForm!: FormGroup;
  modalRef?: BsModalRef;

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

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  constructor(private fb : FormBuilder, private modalService: BsModalService) {
    this.createForm();
   }

  ngOnInit(): void {
  }

  createForm(){
    this.alunoForm = this.fb.group({
      nome : ['', Validators.required],
      sobrenome : ['', Validators.required],
      telefone : ['', Validators.required]
    });
  }

  alunoSubmit(){
    console.log(this.alunoForm.value);
  }

  public alunoSelect(aluno: Aluno){
    this.alunoSelecionado = aluno;
    this.alunoForm.patchValue(aluno);
  }

  public voltar (){
    this.alunoSelecionado = undefined;
  }

}
