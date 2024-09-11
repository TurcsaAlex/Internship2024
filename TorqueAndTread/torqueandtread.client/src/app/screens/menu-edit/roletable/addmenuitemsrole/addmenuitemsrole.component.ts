import { Component, inject,  Input, OnInit } from '@angular/core';
import { Role } from '../../../../models/role';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { RoleService } from '../../../../service/role.service';

@Component({
  selector: 'app-addmenuitemsrole',
  templateUrl: './addmenuitemsrole.component.html',
  styleUrl: './addmenuitemsrole.component.css'
})
export class AddmenuitemsroleComponent implements OnInit {
  @Input() roleIds: number[] = [];
  
  roles: Role[] = [];
  selectedRole: Role | null = null;
  activeModal = inject(NgbActiveModal);

  constructor(private roleService: RoleService) {}

  ngOnInit(): void {
    this.roleService.getAll().subscribe({
      next: (roles) => {
        this.roles = roles.filter(r => !this.roleIds.includes(r.roleId));
      },
      error: (err) => {
        console.error('Failed to load roles:', err);
      }
    });
  }
}