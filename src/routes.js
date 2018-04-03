import newUser from './components/newUser.vue';
import newOrder from './components/newOrder.vue';
import viewOrders from './components/viewOrders.vue';
import singleOrder from './components/singleOrder.vue';

export default [
    { path: '/', component: newUser},
    { path: '/newOrder', component: newOrder},
    { path: '/ViewOrders', component: viewOrders},
    { path: '/order/:id', component: singleOrder}
]
