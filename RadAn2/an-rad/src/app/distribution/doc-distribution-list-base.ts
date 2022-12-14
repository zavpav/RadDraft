import { ActionInfo, ColumnInfo } from "../shared/list-grid/list-grid.component"

export class DocDistributionListBase {
    id!: number
    docNum!: string
    approveDt!: string
    createDt!: string
    docStatusName!: string
    descr!: string
    userId!: number
    topFullSprKey!: string
    actions!: ActionInfo[]
}

export function defaultColumnList() : ColumnInfo[] {
    return [
      { caption: "Операция", dataField: "actions", width: 50 },
      { caption: "id", dataField: "id", dataType:"number" },
      { caption: "Номер документа", dataField:"docNum",        dataType: "string", width: 100},
      { caption: "Дата документа",  dataField: "approveDt",    dataType: "date",   width: 100, format:"dd.MM.yyyy"},
      { caption: "Статус",          dataField: "docStatus",    dataType: "string", width: 100},
      { caption: "Примечание",      dataField: "descr",        dataType: "string"},
      { caption: "Уровень",         dataField: "topFullSprKey", dataType: "string"},
      // { caption: "Пользователь",    dataField: "userName",     dataType: "string", width: 180},
    ]
  }


export interface DocDistributionDocBase {
  id: number
  docNum: string
  approveDt: string
  createDt: Date
  docStatusName: string
  descr: string
  userId: number
  topFullSprKey: string
}

export interface DocDistributionRowBase{
  fullSprKey: string
  smBa1:  number
  smBa2:  number
  smBa3:  number
  smLbo1: number
  smLbo2: number
  smLbo3: number
  smPof:  number
}
