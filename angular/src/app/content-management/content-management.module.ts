import {NgModule} from "@angular/core";
import {HttpClientModule} from '@angular/common/http';
import {CoreModule} from "@abp/ng.core";
import {PageModule} from "@abp/ng.components/page";
import {ContentManagementRoutingModule} from "./content-management-routing.module";
import {EditorModule} from "@tinymce/tinymce-angular";
import {BaseThemeSharedModule} from "@abp/ng.theme.shared";
import {ContentManagementComponent} from "./content-management-crud/content-management-crud.component";
import { ComponentManagementListComponent } from "./content-management-list/content-management-list.component";
import {NgbCollapseModule} from "@ng-bootstrap/ng-bootstrap";

@NgModule({
  declarations: [ContentManagementComponent, ComponentManagementListComponent],
  imports: [HttpClientModule, CoreModule, PageModule, ContentManagementRoutingModule,
    EditorModule, BaseThemeSharedModule, NgbCollapseModule],
})
export class ContentManagementModule {
}
