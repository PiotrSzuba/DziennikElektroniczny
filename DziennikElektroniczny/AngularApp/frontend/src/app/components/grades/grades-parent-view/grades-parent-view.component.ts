import { Component, Input, OnInit } from '@angular/core';
import { Parent } from 'src/app/models/Parent';
import { ParentService } from 'src/app/services/parent/parent.service';

@Component({
  selector: 'app-grades-parent-view',
  templateUrl: './grades-parent-view.component.html',
  styleUrls: ['./grades-parent-view.component.scss']
})
export class GradesParentViewComponent implements OnInit {
  @Input() parentId: number = -1;
  parents: Parent[] = [];
  constructor(private parentService: ParentService) {}

  ngOnInit(): void {
    this.parentService.getParents(this.parentId).subscribe(
      response => {
        response.forEach(
          element => this.parents.push(new Parent(element.parentPersonId, element.studentPersonId, element.studentDisplayName))
        )
      }
    );
  }

}
