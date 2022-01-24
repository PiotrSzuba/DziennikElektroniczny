import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AttendanceComponent } from './components/attendance/attendance.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { GradesComponent } from './components/grades/grades.component';
import { LoginComponent } from './components/login/login.component';

const routes: Routes = [
  {path: '', component: DashboardComponent},
  {path: 'login', component: LoginComponent},
  {path: 'grades', component: GradesComponent},
  {path: 'attendance', component: AttendanceComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
