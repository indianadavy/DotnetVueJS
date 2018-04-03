<template>
    <div id="new-Order">
        <div v-if="!submitted">
            <h2>Create a New Order</h2>
            <label>Selecte a User</label>
            <select v-model="selected">
                <option selected='' v-for="(user,index) in users" :key="index" v-bind:value="user.id">
                    {{ user.firstName + ' ' + user.lastName }}
                </option>
            </select>
        </div>

        <form v-if="!submitted && selected" @submit.prevent="checkForm">
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
            <button type="submit">Create Order</button>
        </form>
        <div v-if="submitted">
            <h3>Order #{{ order.trackingID }} created</h3>
            <button @click="resetForm">Add a new Order</button>
        </div>
    </div>
</template>

<script>
// Imports

export default {
    data () {
        return {
            users: [],
            order: {},
            selected: '',
            submitted: false,
            errors: []
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
                this.post();
            }
            else{
                console.log("there are errors");
                e.preventDefault();
            } 
        },
        post: function(){
            if (!this.order.trackingID == '')
            {
                this.order.userID = this.selected;
                this.$http.post('http://localhost:5000/api/order', this.order).then(function(data){
                    this.submitted = true;
                    this.selected = '';
                });
            }
            else {
                console.log('missing info');
            }
        },
        reload: function() {    
            this.$router.go(this.$router.currentRoute)
        },
        resetForm: function() {
            this.submitted = false;
            this.order = {};
        }
    },
    created() {
        this.$http.get('http://localhost:5000/api/user').then(function(data){
            return data.json();
        }).then(function(data){
            this.users = data;
        });  
    }
}
</script>

<style scoped>
#new-Order *{
    box-sizing: border-box;
}
#new-Order{ 
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
h2{
    margin-top: 10px;
}
</style>