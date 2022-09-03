import { MonthWiseData } from "./MonthWiseData";

export class YearWiseCalculatedData {
    Year : string;
    MonthlyDatas: MonthWiseData[];

    CumulativeIncomes: number[];
    CumulativeCosts: number[];
    CumulativeFinalResults: number[];

    constructor(data: any) {
        this.Year = data?.Year;
        this.MonthlyDatas = data?.MonthlyDatas?.map((month: any) => new MonthWiseData(month));

        this.CumulativeIncomes = new Array<number>;
        this.CumulativeCosts = new Array<number>;
        this.CumulativeFinalResults = new Array<number>;
        
        let incomeSum = 0;
        let costSum = 0;
        let finalResultSum = 0;
        let result = 0;
        this.MonthlyDatas?.forEach((month) => {
            incomeSum += month.Income;
            costSum += month.Cost;
            finalResultSum += month.FinalResult;
            result = month.Income - month.Cost;
            
            this.CumulativeIncomes.push(incomeSum);
            this.CumulativeCosts.push(costSum);
            this.CumulativeFinalResults.push(finalResultSum);
        });
    }
}