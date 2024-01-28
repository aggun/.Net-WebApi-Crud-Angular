export class EmployeeRequest {
    id: number = 0;
    registrationNumber: string = "";
    firstName: string = "";
    lastName: string = "";
    terminationDate!: Date | null;
    mainAddress: string = "";
    gender: string = "";
    mobilePhone: string = "";
    homePhone: string = "";
    departmentCode: number = 0;
}