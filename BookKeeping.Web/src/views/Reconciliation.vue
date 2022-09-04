<script setup lang="ts">
    import type { ReconciliationData } from "@/shared/models/ReconciliationData";
    import {YearWiseCalculatedData} from "../shared/models/YearWIseCalculatedData"
    import CustomInput from "../components/CustomInput.vue"
    import { ref } from "@vue/reactivity";

    const months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];

    var data :any = {
        Year : 2019,
        MonthlyDatas : []
    }
    data.MonthlyDatas = [];
    for(let i=1;i<=12;i++){
        let month :any = {
                Income: 100,
                Month: i,
                Cost: 100,
                Incomes: [
                    {
                        Id : 1,
                        Name : "Type 1",
                        Value : 100,
                        Type : 5
                    },
                    {
                        Id : 2,
                        Name : "Type 2",
                        Value : 100,
                        Type : 5
                    }
                ],
                Expenses:[
                    {
                        Id : 1,
                        Name : "Type 1",
                        Value : 100,
                        Type : 10
                    },
                    {
                        Id : 2,
                        Name : "Type 2",
                        Value : 100,
                        Type : 10
                    }                    
                ]
        };

        data.MonthlyDatas.push(month);
    }
    const yearData = ref(new YearWiseCalculatedData(data));

    // TODO: move this inside the constructor for year. because now it will do these loops every time the ui loads.
    const uniqueIncomeTypes = new Set<string>();    // this is so that we know dynamically how many row span to give in the table
    const uniqueExpenseTypes = new Set<string>();   // we had to use 2 separate variables because in SQL both of them can have same id for different types depending on DB structure. (1 table or 2 table structure).
    
    let incomeIdToName = new Map<string, string>(); // we map income type id => income type name. for showing in the UI more easily.
    let expenseIdToName = new Map<string, string>();

    let incomeIdMonthBasedMonthDatas = new Map<string, ReconciliationData >();  // we map income_type_id + month index => income data. for showing in the UI more easily.
    let expenseIdMonthBasedMonthDatas = new Map<string, ReconciliationData >();


    yearData.value.MonthlyDatas.forEach( (monthlyData) => {
        monthlyData.Incomes.forEach( (income) => {
            uniqueIncomeTypes.add( income.Id);
            incomeIdToName.set(income.Id, income.Name);

            let key = income.Id + "_" + monthlyData.Month;
            if(incomeIdMonthBasedMonthDatas.has(key)){
                incomeIdMonthBasedMonthDatas.set(key, income);
            }else{
                incomeIdMonthBasedMonthDatas.set(key, income);
            }
        } );
        monthlyData.Expenses.forEach( (expense) => {
            uniqueExpenseTypes.add( expense.Id);
            expenseIdToName.set(expense.Id, expense.Name);

            let key = expense.Id + "_" + monthlyData.Month;
            if(expenseIdMonthBasedMonthDatas.has(key)){
                expenseIdMonthBasedMonthDatas.set(key, expense);
            }else{
                expenseIdMonthBasedMonthDatas.set(key, expense);
            }
        });
    });

    // here we'll get key as incomeTypeId_MonthId
    function incomeChanged(value : string, key : string){
        let id = key.split("_")[0];
        let month = parseInt(key.split("_")[1]) ;
        let found = false;
        for(let i=0;i<yearData.value.MonthlyDatas.length && !found;i++){
            if(yearData.value.MonthlyDatas[i].Month == month){
                for(let j=0;j<yearData.value.MonthlyDatas[i].Incomes.length && !found;j++){
                    if(yearData.value.MonthlyDatas[i].Incomes[j].Id == id){
                        yearData.value.MonthlyDatas[i].Incomes[j].Value = parseInt(value);
                        yearData.value.MonthlyDatas[i].calculate();
                        found = true;
                    }
                }
            }
        }

        if(found){
            yearData.value.calculate();
        }
    }

    function expenseChanged(value : string, key : string){
        let id = key.split("_")[0];
        let month = parseInt(key.split("_")[1]) ;
        let found = false;
        for(let i=0;i<yearData.value.MonthlyDatas.length && !found;i++){
            if(yearData.value.MonthlyDatas[i].Month == month){
                for(let j=0;j<yearData.value.MonthlyDatas[i].Expenses.length && !found;j++){
                    if(yearData.value.MonthlyDatas[i].Expenses[j].Id == id){
                        yearData.value.MonthlyDatas[i].Expenses[j].Value = parseInt(value);
                        yearData.value.MonthlyDatas[i].calculate();
                        found = true;
                    }
                }
            }
        }

        if(found){
            yearData.value.calculate();
        }
    }
</script>


<template>
    <table class="table table-bordered">
        <tbody>
            <tr>
                <td colspan="14" class="text-center">Year {{yearData.Year}}</td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td v-for="month in months" :key="month">
                    {{month}}
                </td>
            </tr>
            <tr>
                <td></td>
                <td>Income</td>
                <td v-for="(monthData,index) in yearData.MonthlyDatas" :key="index">
                    {{monthData.Income}}
                </td>
            </tr>
            <tr>
                <td></td>
                <td>Cumulative Income</td>
                <td v-for="(cumulativeIncome,index) in yearData.CumulativeIncomes" :key="index">
                    {{cumulativeIncome}}
                </td>
            </tr>
            
            <tr>
                <td></td>
                <td>Cost</td>
                <td v-for="(monthData,index) in yearData.MonthlyDatas" :key="index">
                    {{monthData.Cost}}
                </td>
            </tr>
            <tr>
                <td></td>
                <td>Cumulative Cost</td>
                <td v-for="(cumulativeCost,index) in yearData.CumulativeCosts" :key="index">
                    {{cumulativeCost}}
                </td>
            </tr>
            
            <tr>
                <td></td>
                <td>Result</td>
                <td v-for="(monthData,index) in yearData.MonthlyDatas" :key="index">
                    {{monthData.Result}}
                </td>
            </tr>

            <tr>
                <td colspan="14" class="text-center">Reconciliation</td>
            </tr>
            <tr>
                <td class="text-center align-middle" :rowspan="uniqueIncomeTypes.size + 1">Income</td>
            </tr>
            <tr v-for="(incomeTypeId, index) in uniqueIncomeTypes" :key="index">
                <td> {{ incomeIdToName.get(incomeTypeId) }} </td>
                <td v-for="monthIndex in 12" :key="monthIndex" >
                    <CustomInput
                        class="col-12"
                        :value='incomeIdMonthBasedMonthDatas.get(incomeTypeId + "_" + monthIndex)?incomeIdMonthBasedMonthDatas.get(incomeTypeId + "_" + monthIndex)?.Value : 0'
                        @customInputChanged='(v)=>incomeChanged(v, incomeTypeId + "_" + monthIndex)'
                    />
                </td>
            </tr>

            <tr>
                <td class="text-center align-middle" :rowspan="uniqueExpenseTypes.size + 1">Expense</td>
            </tr>
            <tr v-for="(expenseTypeId, index) in uniqueExpenseTypes" :key="index">
                <td> {{ expenseIdToName.get(expenseTypeId) }} </td>
                <td v-for="monthIndex in 12" :key="monthIndex" >
                    
                    <CustomInput
                        class="col-12"
                        :value='expenseIdMonthBasedMonthDatas.get(expenseTypeId + "_" + monthIndex)?expenseIdMonthBasedMonthDatas.get(expenseTypeId + "_" + monthIndex)?.Value : 0'
                        @customInputChanged='(v)=>expenseChanged(v, expenseTypeId + "_" + monthIndex)'
                    />
                    <!-- {{ expenseIdMonthBasedMonthDatas.get(expenseTypeId + "_" + monthIndex)?expenseIdMonthBasedMonthDatas.get(expenseTypeId + "_" + monthIndex)?.Value : 0  }} -->
                </td>
            </tr>
            <tr>
                <td></td>
                <td>Reconciliation Result</td>
                <td v-for="(monthData,index) in yearData.MonthlyDatas" :key="index">
                    {{monthData.ReconciliationResult}}
                </td>
            </tr>
            <tr>
                <td></td>
                <td>Final Result</td>
                <td v-for="(monthData,index) in yearData.MonthlyDatas" :key="index">
                    {{monthData.FinalResult}}
                </td>
            </tr>
            <tr>
                <td></td>
                <td>Cumulative Final Result</td>
                <td v-for="(cumulativeFinalResult,index) in yearData.CumulativeFinalResults" :key="index">
                    {{cumulativeFinalResult}}
                </td>
            </tr>
        </tbody>
    </table>
</template>