<template>
    <div id="single-Order">
        <h2>Editing Order #{{ order.id }}</h2>
        <form @submit.prevent="checkForm">
            <label>Name:</label>
            <input type="text" v-model.lazy="order.name" required />
            <label>Street Address:</label>
            <input type="text" v-model.lazy="order.streetAddress" required />  
            <label>City:</label>
            <input type="text" v-model.lazy="order.city" required />  
            <label>State:</label>
            <input type="text" v-model.lazy="order.state" required />  
            <label>Zip Code</label>
            <input type="text" v-model.lazy="order.zipCode" required />  
            <label>Tracking ID</label>
            <input type="text" v-model.lazy="order.trackingID" required />   
            <button type="submit">Update Order</button>
        </form>
        <div v-if="submitted">
            <h3>Order #{{ order.trackingID }} upated</h3>
        </div>
    </div>
</template>

<script>
export default {
    data () {
        return {
            id: this.$route.params.id,
            order: {},
            submitted: false
        }
    },
    methods: {
        checkForm:function(e) {
            this.errors = [];
            if(!this.order.name) this.errors.push("Name required.");
            if(!this.order.streetAddress) this.errors.push("Street Address required.");
            if(!this.order.city) this.errors.push("City required.");
            if(!this.order.state) this.errors.push("State required.");
            if(!this.order.zipCode) this.errors.push("Zip Code required.");
            if(!this.order.trackingID) this.errors.push("Tracking ID required.");
            if(!this.errors.length){
                this.put();
            }
            else{
                console.log("there are errors");
                e.preventDefault();
            } 
        },
        put: function(){
            console.log(this.order);
            this.$http.put('http://localhost:5000/api/order', this.order).then(function(data){
                this.submitted = true;
            });
        }
    },
    created() {
        this.$http.get('api/order/' + this.id).then(function(data){
            console.log(data);
            this.order = data.body;
        });
    }
}
</script>

<style>
#single-Order *{
    box-sizing: border-box;
}
#single-Order{
    margin: 20px auto;
    max-width: 600px;
    padding: 20px;
}
label{
    display: block;
    margin: 20px 0 10px;
}
input[type="text"]{
    display: block;
    width: 100%;
    padding: 8px;
}
select{
    display: block;
    width: auto;
    padding: 8px;
}
h3{
    margin-top: 10px;
}
</style>
