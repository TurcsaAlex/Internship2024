export type UserRole={
    roleId:number;
    roleName:string;
    active:boolean;
    createdOn:string;
    lastUpdatedOn:string;
};

export const mockRoles: UserRole[] = [
{
    roleId: 1,
    roleName: 'Administrator',
    active: true,
    createdOn: '2023-01-15T08:30:00',
    lastUpdatedOn: '2024-07-10T14:20:00'
},
{
    roleId: 2,
    roleName: 'User',
    active: true,
    createdOn: '2023-02-10T10:00:00',
    lastUpdatedOn: '2024-08-01T09:45:00'
},
{
    roleId: 3,
    roleName: 'Manager',
    active: false,
    createdOn: '2022-11-20T13:15:00',
    lastUpdatedOn: '2024-06-25T12:00:00'
},
{
    roleId: 4,
    roleName: 'Guest',
    active: true,
    createdOn: '2024-01-05T07:50:00',
    lastUpdatedOn: '2024-08-15T16:30:00'
}
];
