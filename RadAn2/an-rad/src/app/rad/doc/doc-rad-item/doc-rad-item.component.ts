import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DxFormComponent } from 'devextreme-angular';
import { DxiConnectionPointComponent } from 'devextreme-angular/ui/nested';
import { Column } from 'devextreme/ui/data_grid';
import { ServerNotifier } from 'src/app/services/ServerNotifier';
import { ColumnInfo } from 'src/app/shared/list-grid/list-grid.component';
import { MetaInformation } from 'src/app/SharedClasses/MetaInformation';
import { environment } from 'src/environments/environment';

interface DocRadEdit{
  docNum: string
  docDt: string
  desc: string
}

interface DocRadRow{
  kbkCode: string
  ondateKbk?: string
  todatekbk?: string
  adbName?: string
  adbInn?: string
  adbKpp?: string
  lawLegalName?: string
  lawNumber?: string
  lawDate?: string
}

@Component({
  selector: 'app-doc-rad-item',
  templateUrl: './doc-rad-item.component.html',
  styleUrls: ['./doc-rad-item.component.scss']
})
export class DocRadItemComponent implements OnInit {

  @ViewChild(DxFormComponent, { static: false }) myform!: DxFormComponent;
  isReadOnly: boolean = false

  entityId!: number;
  entity: DocRadEdit = {} as DocRadEdit
  entityRows!: DocRadRow[]

  meta?: MetaInformation[]
  metaRows?: MetaInformation[]

  hasError: boolean

  getRowsColumns!: ColumnInfo[];

  constructor(private activatedRoute: ActivatedRoute,
    private http: HttpClient,
    private severNotifier: ServerNotifier
    ) {
      this.entity = {} as DocRadEdit
      this.meta = undefined
      const fn = (e: any) => this.customizationFormItemInternal(e)
      this.customizationFormItem = fn
      this.hasError = false
  }



  saveForm(){
    var data : any = {
      doc: this.entity,
      rows: this.entityRows
    }

    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'x-signalr-connection': this.severNotifier.connectionId,
    });

    this.http.post(environment.mainEndpoint + "DocRad/Entity", this.entity, {headers: headers})
    .subscribe((x: any) => {
      console.log("start saving doc with token ", x)
      const messageToken = x.executionId;
      this.severNotifier.signalConnection.on("SendProgress", 
        xx => {
        console.log('saving message with token ', messageToken, xx)
      })
    })

  }

  ngOnInit(): void {
    console.log("ngOnInit")
    this.entityId = this.activatedRoute.snapshot.params["id"]
    this.http.get(environment.mainEndpoint + "DocRad/Entity", {params: {id: this.entityId, withMeta: true}})
      .subscribe((e:any) => {
        
        console.log("init in ngInit")
        
        this.entity = e.result.entity

        this.entityRows = e.result.entity.docRows;
        this.metaRows = Object.values(e.result.meta)[1] as MetaInformation[];
        this.getRowsColumns = [];
        this.metaRows.forEach(mri => {
          const cc = {} as ColumnInfo
          cc.caption = mri.caption ?? "<.>"
          cc.dataField = mri.name.charAt(0).toLowerCase() + mri.name.slice(1)
          cc.dataType  = mri.type ?? "string"
          this.getRowsColumns?.push(cc)
        })



        // Пока должно инициализироваться последним (потом надо бы переделать)
        this.meta = Object.values(e.result.meta)[0] as MetaInformation[];
      });
      
    this.isReadOnly = false
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

  onFormSubmit($event: any){

    this.myform.formData
    const isValid = this.myform.instance.validate()
    if (!isValid.isValid){
      console.log("Сохранение. Форма содержит ошибки")
      $event.returnValue = false
      return
    }

    // this.http.post(environment.mainEndpoint + "SprRad/Entity", this.entity)
    // .subscribe(x => {
    //   console.log("Saved")
    // })
    //this.http.get(environment.mainEndpoint + "SprRad/Entity", {params: {id: this.entityId, withMeta: true}})

    console.log($event)
    $event.returnValue = false
  }  
  
}
