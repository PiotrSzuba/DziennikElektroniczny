import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { HeaderInterceptor } from './interceptors/header.interceptor';
import { LoginComponent } from './components/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { NavbarComponent } from './components/navbar/navbar.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GradesComponent } from './components/grades/grades.component';
import { AttendanceComponent } from './components/attendance/attendance.component';
import { MessagesComponent } from './components/messages/messages.component';
import { MatTabsModule } from '@angular/material/tabs';
import { MatExpansionModule } from '@angular/material/expansion';
import { MessagesDisplayComponent } from './components/messages/messages-display/messages-display.component';
import { SendMessageComponent } from './components/messages/send-message/send-message.component';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatChipsModule } from '@angular/material/chips';
import { EventsComponent } from './components/events/events.component';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import {MatCardModule} from '@angular/material/card';
import { DatePipe } from '@angular/common'
import {MatGridListModule} from '@angular/material/grid-list';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import { MatCheckboxModule} from '@angular/material/checkbox';
import { AdminPanelComponent } from './components/admin-panel/admin-panel.component';
import { CreatePersonDialogComponent } from './components/admin-panel/create-person-dialog/create-person-dialog.component';
import {MatDialogModule} from '@angular/material/dialog';
import { GradesParentViewComponent } from './components/grades/grades-parent-view/grades-parent-view.component';
import { GradesStudentViewComponent } from './components/grades/grades-student-view/grades-student-view.component';
import { GradesTeacherViewComponent } from './components/grades/grades-teacher-view/grades-teacher-view.component';
import { GradesSubjectViewComponent } from './components/grades/grades-subject-view/grades-subject-view.component';
import { AddGradeModalComponent } from './components/grades/grades-subject-view/add-grade-modal/add-grade-modal.component';
import { MatSelectModule } from '@angular/material/select';
import { DeleteModifyGradeModalComponent } from './components/grades/grades-subject-view/delete-modify-grade-modal/delete-modify-grade-modal.component';
import { NotesComponent } from './components/notes/notes.component';
import { CreateSubjectDialogComponent } from './components/admin-panel/create-subject-dialog/create-subject-dialog.component';
import { CreateClassroomDialogComponent } from './components/admin-panel/create-classroom-dialog/create-classroom-dialog.component';
import { CreateStudentGroupDialogComponent } from './components/admin-panel/create-student-group-dialog/create-student-group-dialog.component';
import { AttendanceParentViewComponent } from './components/attendance/attendance-parent-view/attendance-parent-view.component';
import { AttendanceStudentViewComponent } from './components/attendance/attendance-student-view/attendance-student-view.component';
import { AttendanceTeacherViewComponent } from './components/attendance/attendance-teacher-view/attendance-teacher-view.component';
import { AttendanceSubjectViewComponent } from './components/attendance/attendance-subject-view/attendance-subject-view.component';
import { AttendanceLessonViewComponent } from './components/attendance/attendance-lesson-view/attendance-lesson-view.component';
import {MatTableModule} from '@angular/material/table';
import { AddLessonComponent } from './components/lesson/add-lesson/add-lesson.component';
import { ModifyDeleteLessonComponent } from './components/lesson/modify-delete-lesson/modify-delete-lesson.component';
import { AddNoteComponent } from './components/notes/add-note/add-note.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DashboardComponent,
    NavbarComponent,
    GradesComponent,
    AttendanceComponent,
    MessagesComponent,
    MessagesDisplayComponent,
    SendMessageComponent,
    EventsComponent,
    AdminPanelComponent,
    CreatePersonDialogComponent,
    GradesParentViewComponent,
    GradesStudentViewComponent,
    GradesTeacherViewComponent,
    GradesSubjectViewComponent,
    AddGradeModalComponent,
    DeleteModifyGradeModalComponent,
    CreateSubjectDialogComponent,
    CreateClassroomDialogComponent,
    CreateStudentGroupDialogComponent,
    AttendanceParentViewComponent,
    AttendanceStudentViewComponent,
    AttendanceTeacherViewComponent,
    AttendanceSubjectViewComponent,
    AttendanceLessonViewComponent,
    AddLessonComponent,
    ModifyDeleteLessonComponent,
    AddNoteComponent,
    NotesComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatToolbarModule,
    FormsModule,
    MatTabsModule,
    MatExpansionModule,
    MatAutocompleteModule,
    ReactiveFormsModule,
    MatChipsModule,
    MatCardModule,
    MatGridListModule,
    MatDatepickerModule,
    MatNativeDateModule,
    ReactiveFormsModule,
    MatButtonToggleModule,
    MatCheckboxModule,
    MatDialogModule,
    MatSelectModule,
    MatCheckboxModule,
    MatTableModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: HeaderInterceptor, multi: true },DatePipe,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
