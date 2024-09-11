// import { Component, OnInit } from '@angular/core';
// import { User } from '../models/user.model';
// import { SessionService } from '../session.service';
// import { Role } from '../models/role.model';
// import { HttpClient } from '@angular/common/http';
// import { NotificationService } from '../notification.service';
 
// @Component({
//   selector: 'app-admin-dashboard',
//   templateUrl: './admin-dashboard.component.html',
//   styleUrl: './admin-dashboard.component.css'
// })
// export class AdminDashboardComponent implements OnInit {
//   totalLoginAttempts: number = 0;
//   totalFailedLoginAttempts: number = 0;
//   totalLoginsForToday: number = 0;
//   lastYearLogins: number[] = [];
//   lastYearMonths: string[] = [];
//   allUsers: User[] = [];
//   activeUsers: number = 0;
//   inactiveUsers: number = 0;
 
//   numberForRoles: Record<string, number> = {};
 
//   constructor(private http: HttpClient, private sessionService: SessionService, private notifService: NotificationService) { }
 
//   ngOnInit() {
 
//     this.sessionService.retrieve<number[]>('total-logins', '/api/auth/logins/number').subscribe(data => this.totalLoginAttempts = data[0]);
//     this.sessionService.retrieve<number[]>('total-failed-logins', '/api/auth/logins/number', { params: { isFailed: true } }).subscribe(data => this.totalFailedLoginAttempts = data[0]);
//     const today = new Date();
//     this.sessionService.retrieve<number[]>('total-logins-today', '/api/auth/logins/number',
//       {
//         params:
//         {
//           since: new Date(today.getFullYear(), today.getMonth(), today.getDate(), 0).toUTCString()
//         }
//       }).subscribe(data => this.totalLoginsForToday = data[0]);
 
//     this.sessionService.retrieve<number[]>('logins-last-year', '/api/auth/logins/number',
//       {
//         params:
//         {
//           since: new Date(today.getFullYear() - 1, today.getMonth(), today.getDate()).toUTCString(),
//           perMonth: true
//         }
//       }).subscribe(data => {
//         this.lastYearLogins = data;
//       });
 
//     this.lastYearMonths = [];
//     for (let i = 11; i >= 0; i--) {
//       const date = new Date(today.getFullYear(), today.getMonth() - i);
//       this.lastYearMonths.push(date.toLocaleString('default', { month: 'long' }));
//     }
 
//     this.sessionService.retrieve<User[]>('users', '/api/User').subscribe(data => {
//       this.allUsers = data;
//       this.activeUsers = data.filter(u => u.active).length;
//       this.inactiveUsers = data.length - this.activeUsers;
//     });
//     this.sessionService.retrieve<Role[]>('roles', '/api/Role').subscribe(roles => {
//       for (const role of roles) {
//         this.sessionService.retrieve<number>(`roles-${role.id}`, `/api/Role/users/${role.id}`).subscribe(num => {
//           this.numberForRoles[role.name] = num;
//         })
//       }
//     })
//   }
 
//   generateReport() {
//     this.notifService.info('Generating report');
//     type LoginResult = {
//       id: number;
//       error: string;
//       isSuccess: boolean;
//       createdByName: string;
//       createdOn: Date;
//     };
//     const today = new Date();
//     this.http.get<LoginResult[]>('/api/auth/logins',
//       {
//         params:
//         {
//           since: new Date(today.getFullYear() - 1, today.getMonth(), today.getDate()).toUTCString()
//         }
//       }).subscribe(data => {
//         let csvString = "User,Date,Success,Error\n";
//         for (const login of data) {
//           csvString += `${login.createdByName},${login.createdOn.toLocaleString()},${login.isSuccess},${login.error ?? ''}\n`;
//         }
//         const csvFile = new Blob([csvString], { type: 'text/csv' });
//         const link = document.createElement('a');
//         link.href = window.URL.createObjectURL(csvFile);
//         link.download = `OvenMaster-report-${today.getFullYear()}_${today.getMonth()}_${today.getDate()}-${today.getHours()}_${today.getMinutes()}`;
//         link.click();
//         this.notifService.success('Report generated');
//       });
//   }
 
//   get roleNames() {
//     return Object.keys(this.numberForRoles);
//   }
 
//   get roleNumbers() {
//     return Object.values(this.numberForRoles);
//   }
// }