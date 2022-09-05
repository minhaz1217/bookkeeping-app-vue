import type { ReconciliationType } from "../enums/ReconciliationType";

export class ReconciliationData{
    Id : string;
    ReconciliationId : string;
    Name : string;
    Value : number;
    Type : ReconciliationType;
    constructor(data : any){
        this.Id = data?.Id;
        this.ReconciliationId = data?.ReconciliationId;
        this.Name = data?.Name;
        this.Value = data?.Value;
        this.Type = data?.Type;
    }
}
