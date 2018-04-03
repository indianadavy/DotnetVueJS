<template>
    <nav>
        <ul>
            <li><router-link to="/" exact>Add a new User</router-link></li>
            <li><router-link to="/newOrder" exact>Add a new Order</router-link></li>
            <li><router-link to="/viewOrders" exact>View Orders</router-link></li>       
        </ul>
    </nav>
</template>

<script>
export default {}
</script>

<style scoped>
ul{
    list-style-type: none;
    text-align: center;
    margin: 0;
}
li{
    display: inline-block;
    margin: 0 10px;
}
a{
    color: #fff;
    text-decoration: none;
    padding: 12px;
    border-radius: 5px;
}
nav{
    background:lightslategrey;
    padding: 30px 0;
    margin-bottom: 40px;
}
.router-link-active{
    background: rgba(255,255,255,0.8);
    color: #444;
}
</style>
