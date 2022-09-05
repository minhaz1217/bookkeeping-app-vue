import { BACKEND_URL } from "@/constants/appConfig";
import { YearWiseCalculatedData } from "@/shared/models/YearWIseCalculatedData";

export const GetReconciliationDataByYear = async (year: number): Promise<YearWiseCalculatedData> => {
    const url = BACKEND_URL + "/api/Reconciliation/get-reconciliations-by-year?year=" + year;
    const res = await fetch(url);
    const data = await res.json();
    let output = new YearWiseCalculatedData(data);
    return output;
}

export const SaveReconciliationData = async (data : YearWiseCalculatedData)=> {
    const url = BACKEND_URL + "/api/Reconciliation/save-reconciliation-data";
    const res = await fetch(url, {
        method : "POST",
        headers: {
            "Content-type": "application/json",
        },
        body: JSON.stringify(data)
    });
    return res;
}