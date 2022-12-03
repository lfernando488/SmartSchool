import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Professor } from './../models/professor';

@Component({
  selector: 'app-Professores',
  templateUrl: './Professores.component.html',
  styleUrls: ['./Professores.component.css']
})
export class ProfessoresComponent implements OnInit {

  titulo = "Professores"
  public professorSelecionado!: Professor | undefined;
  public textSimple!: string;
  public professorForm!: FormGroup;
  modalRef?: BsModalRef;

  professores = [
    {id: 1, nome : "Carlo", disciplina : 'Matemática'},
    {id: 2, nome : "Zéfa", disciplina : 'Física'},
    {id: 3, nome : "Tonin", disciplina : 'Quimica'},
    {id: 4, nome : "Cida", disciplina : 'Geografia'},
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
    this.professorForm = this.fb.group({
      nome : ['', Validators.required],
      disciplina : ['', Validators.required]
    });
  }

  professorSubmit(){
    console.log(this.professorForm.value);
  }

  public professorSelect(professor: Professor){
    this.professorSelecionado = professor;
    this.professorForm.patchValue(professor);
  }

  public voltar(){
    this.professorSelecionado = undefined;
  }

}
