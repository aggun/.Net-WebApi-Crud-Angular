import { Component, OnInit } from '@angular/core';
import { DepartmentService } from '../../services/department.service';
import { DepartmentResponse } from '../../model/departmentResponsel';

@Component({
  selector: 'app-show-department',
  templateUrl: './show-department.component.html'
})
export class ShowDepartmentComponent implements OnInit {

  constructor(private service: DepartmentService) { }

  ModalTitle = "";
  ActivateAddEditDepartComp: boolean = false;
  depart: any;

  departmentResponse: DepartmentResponse = new DepartmentResponse();
  DepartmentIdFilter = "";
  DepartmentNameFilter = "";
  DepartmentListWithoutFilter: any = [];
  departmentList: any = [];

  ngOnInit(): void {
    this.refreshDepList();
  }

  addClick() {
    this.depart = {
      DepartmentId: "0",
      DepartmentName: ""
    }
    this.ModalTitle = "Add Department";
    this.ActivateAddEditDepartComp = true;
  }

  editClick(item: any) {
    this.depart = item;
    this.ModalTitle = "Edit Department";
    this.ActivateAddEditDepartComp = true;
  }

  deleteClick(item: any) {
    if (confirm('Are you sure??')) {
      this.service.deleteDepartment(item.id).subscribe(data => {
        alert(data.toString());
      })
      this.refreshDepList();
    }
  }

  closeClick() {
    this.ActivateAddEditDepartComp = false;
    this.refreshDepList();
  }


  refreshDepList() {
    this.service.getDepartmentList().subscribe(res => {
      this.departmentList = res;
    });
  }

}