import { Component, Input, OnInit } from '@angular/core';
import { EmployeeService } from '../../services/employee.service';
import { DepartmentService } from '../../services/department.service';
import { EmployeeRequest } from '../../model/employeeRequest';

@Component({
  selector: 'app-add-edit-employee',
  templateUrl: './add-edit-employee.component.html'
})
export class AddEditEmployeeComponent {

  constructor(private employeeService: EmployeeService,
    private departmentService: DepartmentService) { }

  @Input() emp: any;
  EmployeeId = "";
  RegistrationNumber = "";
  Registration = "";
  FirstName = "";
  LastName = "";
  HireDate = "";
  TerminationDate = "";
  MainAddress = "";
  Gender = "";
  MobilePhone = "";
  HomePhone = "";
  Department = 0;
  DepartmentList: any = [];
  genderList: string[] = ['male', 'female'];
  employeeRequest: EmployeeRequest = new EmployeeRequest();

  ngOnInit(): void {
    this.loadEmployeeList();
  }

  loadEmployeeList() {

    this.departmentService.getDepartmentList().subscribe((data: any) => {
      this.DepartmentList = data;

      if (this.emp.departmentCode > 0) {
        this.RegistrationNumber = this.emp.registrationNumber;
        this.FirstName = this.emp.firstName;
        this.LastName = this.emp.lastName;
        this.Department = this.emp.departmentCode;
        this.genderList = this.emp.gender;
        this.HireDate = this.emp.HireDate;
        this.HomePhone = this.emp.homePhone;
        this.MainAddress=this.emp.mainAddress;
        this.MobilePhone=this.emp.mobilePhone;
      }
    });
  }

  addEmployee() {
    this.setRequest();
    this.employeeService.addEmployee(this.employeeRequest).subscribe(res => {
      alert(res.toString());
    });
  }

  updateEmployee() {
    this.employeeService.updateEmployee(this.employeeRequest).subscribe(res => {
      alert(res.toString());
    });
  }

  setRequest() {
    this.employeeRequest.firstName = this.FirstName;
    this.employeeRequest.lastName = this.LastName;
    this.employeeRequest.registrationNumber = this.RegistrationNumber;
    this.employeeRequest.terminationDate = new Date(this.TerminationDate);
    this.employeeRequest.mainAddress = this.MainAddress;
    this.employeeRequest.homePhone = this.HomePhone;
    this.employeeRequest.mobilePhone = this.MobilePhone;
    this.employeeRequest.departmentCode = this.Department;
    this.employeeRequest.gender = this.Gender;
  }
}
