import { BACKEND_URL } from "@/constants/appConfig";
import { YearWiseCalculatedData } from "@/shared/models/YearWIseCalculatedData";

export const GetReconciliationDataByYear = async (year: number): Promise<YearWiseCalculatedData> => {
    const url = BACKEND_URL + "/api/Reconciliation/get-reconciliations-by-year?year=" + year;
    const res = await fetch(url);
    const data = await res.json();
    let output = new YearWiseCalculatedData(data);
    return output;
}
