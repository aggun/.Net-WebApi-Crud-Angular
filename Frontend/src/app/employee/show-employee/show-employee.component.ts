import { Component } from '@angular/core';
import { EmployeeService } from '../../services/employee.service';

@Component({
  selector: 'app-show-employee',
  templateUrl: './show-employee.component.html'
})
export class ShowEmployeeComponent {

  constructor(private service: EmployeeService) { }

  EmployeeList: any = [];
  ModalTitle = "";
  ActivateAddEditEmpComp: boolean = false;
  emp: any;

  ngOnInit(): void {
    this.refreshEmpList();
  }

  addClick() {
    this.emp = {
      id: "0",
      EmployeeName: "",
      Department: "",
      DateOfJoining: "",
    }
    this.ModalTitle = "Add Employee";
    this.ActivateAddEditEmpComp = true;
  }

  editClick(item: any) {
    this.emp = item;
    this.ModalTitle = "Edit Employee";
    this.ActivateAddEditEmpComp = true;
  }

  deleteClick(item: any) {
    if (confirm('Are you sure??')) {
      this.service.deleteEmployee(item.id).subscribe(data => {
        alert(data.toString());
        this.refreshEmpList();
      }
      )
    }
  }

  closeClick() {
    this.ActivateAddEditEmpComp = false;
    this.refreshEmpList();
  }

  refreshEmpList() {
    this.service.getEmployeeList().subscribe(data => {
      this.EmployeeList = data;
    });
  }
}
