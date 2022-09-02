import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import Reconciliation from '../views/Reconciliation.vue'
import Income from '../views/Income.vue'
import Expense from '../views/Expense.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/reconciliation',
      name: 'reconciliation',
      component: Reconciliation
    },
    {
      path: '/income',
      name: 'income',
      component: Income
    },
    {
      path: '/expense',
      name: 'expense',
      component: Expense
    }
  ]
})

export default router
