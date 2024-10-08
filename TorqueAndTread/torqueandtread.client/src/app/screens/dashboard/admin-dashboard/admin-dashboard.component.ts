import { Component, OnInit, ViewChild } from '@angular/core';
import { LoginAttempt } from '../../../models/loginAttempt';
import { LoginAttemptsService } from '../../../service/login-attempts.service';
import { User } from '../../../models/user';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrl: './admin-dashboard.component.css'
})
export class AdminDashboardComponent implements OnInit {
  displayedColumns=["username","loginAttemptResult","loginMessage","date"]
  successfullAttempts: number = 0;
  unsuccessfullAttempts: number = 0;
  numberForRoles: Record<string, number> = {};
  data:any;
  loginAttempts:LoginAttempt[]=[];
  dataSource=new MatTableDataSource<LoginAttempt>();
  loaded=false;
  @ViewChild(MatPaginator) paginator!: MatPaginator;


  public lineChartColors: any = [
    {
      borderColor: 'blue',
      backgroundColor: 'rgba(0,123,255,0.3)',
    },
    {
      borderColor: 'green',
      backgroundColor: 'rgba(40,167,69,0.3)',
    }
  ];
  public lineChartData: { data: number[], label: string }[] = [
    { data: [], label: 'Successfull' },
    { data: [], label: 'Unsuccessfull' }
  ];
  public lineChartLabels: any[] = [];
  
  get roleNames() {
    return Object.keys(this.numberForRoles).map(n=>{
      return [n];
    });
  }
 
  get roleNumbers() {
    return Object.values(this.numberForRoles);
  }

  get operators(){
    if(!this.data) return 0;
    let x= this.data.userWithRoles.Operator;
    return x?x:0;
  }
  
  get admins(){
    if(!this.data) return 0;
    let x= this.data.userWithRoles.Administrator;
    return x?x:0
  }

  get supervisors(){
    if(!this.data) return 0;
    let x =  this.data.userWithRoles.Supervisor;
    return x?x:0;
  }

  constructor(private loginAttemptsService:LoginAttemptsService){

  }
  ngOnInit(): void {
    let stop=new Date();
    stop.setDate(stop.getDate()+1);
    let start= new Date();
    start.setDate(start.getDate()-30);
    this.loginAttemptsService.getAttemptsForCharts(start, stop).subscribe({
      next:(r)=>{
        console.log(r);this.populateData(r);
        this.data=r;
        this.numberForRoles=r.userWithRoles;
        console.log( this.data.loginGraph.map((item:any) => item.loginAttemptSuccessfull));
        this.lineChartData[0].data = this.data.loginGraph.map((item:any) => item.loginAttemptSuccessfull);
        this.lineChartData[1].data = this.data.loginGraph.map((item:any) => item.loginAttemptUnsuccessfull);
        this.lineChartLabels = this.data.loginGraph.map((item:any ) => new Date(item.loginTime).toLocaleDateString());
      
      }
    });
  }

  populateData(incomingData:any){
    this.successfullAttempts=incomingData.successfull;
    this.unsuccessfullAttempts=incomingData.unsuccessfull;
    this.dataSource.data=incomingData.loginAttempts;
    this.loginAttempts=incomingData.loginAttempts;
    this.dataSource.paginator=this.paginator;
    this.loaded=true;
  }
  export(){
    const today = new Date();
    let csvString = "User,Date,Success,Error\n";
        for (const login of this.loginAttempts) {
          csvString += `${login.username},${login.loginDate.toLocaleString()},${login.loginAttemptResult},${login.loginMessage}\n`;
        }
        const csvFile = new Blob([csvString], { type: 'text/csv' });
        const link = document.createElement('a');
        link.href = window.URL.createObjectURL(csvFile);
        link.download = `TorqueAndThread-report-${today.getFullYear()}_${today.getMonth()}_${today.getDate()}-${today.getHours()}_${today.getMinutes()}`;
        link.click();
  }
}
