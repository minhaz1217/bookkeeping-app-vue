import { BACKEND_URL } from "@/constants/appConfig";
import { YearWiseCalculatedData } from "@/shared/models/YearWIseCalculatedData";

export const GetReconciliationDataByYear = async (year: number): Promise<YearWiseCalculatedData> => {
    const url = BACKEND_URL + "/api/Reconciliation/get-reconciliations-by-year?year=" + year;

    let data: any = null;
    const res =
            (await fetch(url, {
                method: "GET"
            })
            .then(async response => {
                if (!response.ok) {
                    alert("Error: " + response.status);
                } else {
                    data = await response.json();
                }
            })
            .catch(error => {
                alert(error);
            }));
    let output = new YearWiseCalculatedData(data);
    return output;
}

export const SaveReconciliationData = async (data: YearWiseCalculatedData) => {
    const url = BACKEND_URL + "/api/Reconciliation/save-reconciliation-data";
    
    let output: any = null;
    const res = await fetch(url, {
            method: "POST",
            headers: {
                "Content-type": "application/json",
            },
            body: JSON.stringify(data)
        })
        .then(async response => {
            if (!response.ok) {
                alert("Error: " + response.status);
            } else {
                output = await response.json();
            }
        })
        .catch(error => {
        alert(error);
    });
    return output;
}