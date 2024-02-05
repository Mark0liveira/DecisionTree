import { Component } from '@angular/core';
import {ContentManagementService} from "@proxy/content-management-system/controllers";
import {ContentManagementDto} from "@proxy/content-management-system/services/dtos";
import {Router} from "@angular/router"

@Component({
  selector: 'app-content-management-list',
  templateUrl: 'content-management-list.component.html',
  styleUrl: 'content-management-list.component.scss'
})
export class ComponentManagementListComponent {

  public datas : ContentManagementDto;
  constructor(private service : ContentManagementService, private router: Router) {
  }
  ngOnInit(): void {
    this.getAll();
  }

  getAll(){
    this.service.getAll().subscribe(result => {
      this.datas = result;
    });
  }

  edit(id : string): void{
    this.router.navigate([`/content-management/crud/${id}`]);
  }

  create(): void{
    this.router.navigate(["/content-management/crud"]);
  }
}
