export interface MetaInformation{
    name: string
    caption?: string
    type?: string
    isRequire?: boolean
    maxLen?:number
}

export interface DataWithMeta<T>{
    entity: T
    meta: MetaInformation[]
}
