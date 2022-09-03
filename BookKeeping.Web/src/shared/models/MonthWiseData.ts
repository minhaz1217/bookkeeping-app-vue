import type { MonthType } from "../enums/MonthType";
import { ReconciliationData } from "./ReconciliationData";

export class MonthWiseData {
    Month: MonthType;
    Income: number;
    Cost: number;
    Result : number;
    Incomes: ReconciliationData[];
    Expenses: ReconciliationData[];
    ReconciliationResult : number;

    FinalResult : number;
    constructor(data: any) {
        this.Income = data?.Income;
        this.Cost = data?.Cost;
        // parseInt(data?.Month) 
        this.Month = data?.Month;
        this.Incomes = data?.Incomes?.map((income: any) => new ReconciliationData(income));
        this.Expenses = data?.Expenses?.map((expense: any) => new ReconciliationData(expense));
        this.Result = this.Income - this.Cost;
        
        this.ReconciliationResult = 0;
        this.FinalResult = 0;

        this.calculate();
    }

    calculate(){
        this.ReconciliationResult = 0;
        this.FinalResult = 0;
        
        this.Incomes.forEach( (income) => this.ReconciliationResult += income.Value );
        this.Expenses.forEach( (expense) => this.ReconciliationResult -= expense.Value );
        
        this.FinalResult = this.ReconciliationResult + this.Result;
    }
}