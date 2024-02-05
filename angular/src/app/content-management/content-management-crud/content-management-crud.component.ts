import { Component, ViewEncapsulation } from '@angular/core';
import {ContentManagementService} from "@proxy/content-management-system/controllers";
import type {ContentManagementDto} from "@proxy/content-management-system/services/dtos";
import {ActivatedRoute, Router} from "@angular/router";
import {PageAlertService} from "@abp/ng.theme.shared";
import {DomSanitizer, SafeHtml} from '@angular/platform-browser'

@Component({
  selector: 'app-content-management-crud',
  templateUrl: './content-management-crud.component.html',
  styleUrl: './content-management-crud.component.scss',
  encapsulation: ViewEncapsulation.None
})
export class ContentManagementComponent {

  private _service: ContentManagementService;
  public html: string;
  public htmlRender: SafeHtml;
  title: string;
  id: string;
  showEditor: boolean = false;

  constructor(_service : ContentManagementService, private route: ActivatedRoute,
              private alertService: PageAlertService, private router: Router,
              private sanitizer: DomSanitizer) {
    this._service = _service;
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
    if(this.id != null)
    {
      this.getById();
    }
    else{
      this.showEditor = true;
    }
  }

  getById()
  {
    this._service.getCMSContentById(this.id).subscribe((res : ContentManagementDto) => {
      this.html = res.content;
      this.title = res.title;
      this.htmlRender = this.sanitizer.bypassSecurityTrustHtml(res.content);
    });
  }

  save() : void{
    let model: ContentManagementDto = {
      content: this.html,
      title: this.title
    };
    if(this.id != null) model.id = this.id;
    this._service.insertOrUpdateCMSContentByModel(model).subscribe((res : ContentManagementDto) =>
    {
      this.showSuccess();
      setTimeout(() => {
        this.router.navigate(['/content-management/list'])
        this.alertService.remove(0);
      }, 2000)
    });
  }

  showSuccess() {
    this.alertService.show({
      type: 'success',
      message:
        'Release created with Success!',
      title: 'Release created',
    });
  }

  back() {
    this.router.navigate(['/content-management/list'])
  }

  edit(){
    this.showEditor = true;
  }
}
