<script>
import { computed } from "@vue/runtime-core";
import { useRoute } from "vue-router";


const route = useRoute()

const currentRoute = computed( ()=>{
    switch(route.path){
        case "/" || "dashboard" : 
            return "dashboard";
        case "income":
            return "income"
        case "expense":
            return "expense";
        default:
            return "dashboard";
    }
});
</script>


<template>
    <nav id="sidebarMenu" class="col-md-3 col-lg-2 d-flex flex-column flex-shrink-0 p-3 bg-light collapse">
        <div class="position-sticky pt-3 sidebar-sticky">
            <ul class="nav flex-column">
                <li class="nav-item">
                    <RouterLink :class="'nav-link'" to="/dashboard" >Dashboard</RouterLink>
                    <RouterLink class="nav-link active" to="/income" >Income</RouterLink>
                    <RouterLink class="nav-link" to="/expense" >Expense</RouterLink>
                    <RouterLink class="nav-link" to="/reconciliation" >Reconciliation</RouterLink>
                </li>
            </ul>
        </div>
    </nav>
</template>