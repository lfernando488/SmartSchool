import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlunosComponent } from './Alunos/Alunos.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { PerfilComponent } from './perfil/perfil.component';
import { ProfessoresComponent } from './Professores/Professores.component';

const routes: Routes = [
  {path : '', redirectTo : 'dashboard', pathMatch : 'full'},
  {path : 'dashboard', component : DashboardComponent},
  {path : 'perfil', component : PerfilComponent},
  {path : 'professores', component : ProfessoresComponent},
  {path : 'alunos', component : AlunosComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
exports: [RouterModule]
})
export class AppRoutingModule { }
