import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminPanelComponent } from './components/admin-panel/admin-panel.component';
import { AttendanceComponent } from './components/attendance/attendance.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { EventsComponent } from './components/events/events.component';
import { GradesComponent } from './components/grades/grades.component';
import { LoginComponent } from './components/login/login.component';
import { MessagesComponent } from './components/messages/messages.component';
import { MyAccountComponent } from './components/my-account/my-account/my-account.component';
import { NotesComponent } from './components/notes/notes.component';

const routes: Routes = [
  { path: '', component: DashboardComponent },
  { path: 'login', component: LoginComponent },
  { path: 'grades', component: GradesComponent },
  { path: 'attendance', component: AttendanceComponent },
  { path: 'messages', component: MessagesComponent },
  { path: 'events', component: EventsComponent },
  { path: 'admin', component: AdminPanelComponent },
  { path: 'notes', component: NotesComponent },
  { path: 'my-account', component: MyAccountComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
