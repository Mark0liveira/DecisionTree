import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {ContentManagementComponent} from "./content-management-crud/content-management-crud.component";
import {ComponentManagementListComponent} from "./content-management-list/content-management-list.component";

const routes: Routes = [
  { path: 'crud', component: ContentManagementComponent },
  { path: 'crud/:id', component: ContentManagementComponent },
  { path: 'list', component: ComponentManagementListComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ContentManagementRoutingModule {}
