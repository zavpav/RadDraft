import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { DxFormComponent } from 'devextreme-angular';
import { environment } from 'src/environments/environment';

interface RadEdit{
    // ИД
    id: number

    // Полное наименование
    fullName: string

    // ИНН организации
    inn: string

    // КПП организации
    kpp: string

    // КБК
    kbk: string

    // Дата создания
    onDate: Date

    // Дата закрытия организации (null если ещё активна)
    toDate?: Date
}

interface MetaInformation{
  name: string
  caption?: string
  type?: string
  isRequire?: boolean
  maxLen?:number
}

interface DataWithMeta<T>{
  entity: T
  meta: MetaInformation[]
}


@Component({
  selector: 'app-spr-rad-edit',
  templateUrl: './spr-rad-edit.component.html',
  styleUrls: ['./spr-rad-edit.component.scss']
})
export class SprRadEditComponent implements OnInit {
  @ViewChild(DxFormComponent, { static: false }) myform!: DxFormComponent;
  
  @ViewChild("saveButton") saveButton: any;

  constructor(
        private activatedRoute: ActivatedRoute,
        private http: HttpClient) {
    this.entity = {} as RadEdit
    this.meta = undefined
    const fn = (e: any) => this.customizationFormItemInternal(e)
    this.customizationFormItem = fn
    this.hasError = false
  }

  // Обёрка через стрелочную функцию, потому что если напрямую функцию пихать, она this теряет совсем.
  customizationFormItem : any
  customizationFormItemInternal(editorItem: any){
    if (!editorItem.dataField)
      return

    const metaInfo = this.meta?.find(x => x.name.toLowerCase() == editorItem.dataField.toLowerCase());
    if (metaInfo){
      if (metaInfo.type == "date"){
        editorItem.editorType="dxDateBox"
        editorItem.editorOptions = { dataType:'date', displayFormat: 'dd.MM.yyyy', width: '150px' }
      }
      if (metaInfo.caption){
        editorItem.label = { text: metaInfo.caption }
      }
      if (metaInfo.isRequire){
        if (!editorItem.validationRules){
          editorItem.validationRules = []
        }

        editorItem.validationRules.push({type: "required", message: "Поле обязательно"})
      }
    }
    console.log(editorItem)

  }

  isReadOnly: boolean = false

  entityId!: number;
  entity: RadEdit;
  meta?: MetaInformation[]

  hasError: boolean

  onSubmit(f: NgForm) {
    console.log(f.value);  
    console.log(f.valid);  
  }

  onFormSubmit($event: any){

    this.myform.formData
    const isValid = this.myform.instance.validate()
    if (!isValid.isValid){
      console.log("Сохранение. Форма содержит ошибки")
      $event.returnValue = false
      return
    }

    this.http.post(environment.mainEndpoint + "SprRad/Entity", this.entity)
    .subscribe(x => {
      console.log("Saved")
    })
    //this.http.get(environment.mainEndpoint + "SprRad/Entity", {params: {id: this.entityId, withMeta: true}})

    console.log($event)


    $event.returnValue = false
  }



  dataChanged($event: any){
    const isValid = this.myform.instance.validate()
    this.hasError = !isValid.isValid
    // const s = this.saveButton
    // this.saveButton._setOption("disabled", this.hasError)
    // Не получается заблочить кнопку Сохранить
    console.log("dataChanged " + this.hasError)
  }

  validationForm($event: any){
    console.log(arguments)
  }

  ngOnInit(): void {
    console.log("ngOnInit")
    this.entityId = this.activatedRoute.snapshot.params["id"]
    this.http.get(environment.mainEndpoint + "SprRad/Entity", {params: {id: this.entityId, withMeta: true}})
      .subscribe((e:any) => {
        console.log("init in ngInit")
        this.entity = e.result.entity
        this.meta = e.result.meta
      });
      
    this.isReadOnly = false
  }
}
