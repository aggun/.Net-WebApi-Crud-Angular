import { Component, OnInit, Input } from '@angular/core';
import { DepartmentService } from '../../services/department.service';
import { DepartmentRequest } from '../../model/departmentRequest';

@Component({
  selector: 'app-add-edit-department',
  templateUrl: './add-edit-department.component.html'
})
export class AddEditDepartmentComponent implements OnInit {

  constructor(private service: DepartmentService) { }

  @Input() depart: any;
  Id = 0;
  DepartmentCode = 0;
  DepartmentName = "";
  departmentRequest: DepartmentRequest = new DepartmentRequest();
  ngOnInit(): void {

    this.DepartmentCode = this.depart.departmentCode;
    this.DepartmentName = this.depart.departmentName;
    this.Id = this.depart.id;
  }

  addDepartment() {
    this.departmentRequest.departmentCode = this.DepartmentCode;
    this.departmentRequest.departmentName = this.DepartmentName

    this.service.addDepartment(this.departmentRequest).subscribe(res => {
      alert(res.toString());
    });
  }

  updateDepartment() {
    this.departmentRequest.departmentCode = this.DepartmentCode;
    this.departmentRequest.departmentName = this.DepartmentName
    this.departmentRequest.id = this.Id;
    this.service.updateDepartment(this.departmentRequest).subscribe(res => {
      alert(res.toString());
    });
  }
}