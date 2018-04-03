<template>
    <div id="new-User">
        <form v-if="!submitted" @submit.prevent="checkForm">
            <h2>Create a New User</h2>
            <label>First Name:</label>
            <input type="text" v-model.lazy="user.firstName" required />
            <label>Last Name:</label>
            <input type="text" v-model.lazy="user.lastName" required />   
            <button type="submit">Create User</button>
        </form>
        <div v-if="submitted">
            <h3>User {{ user.firstName + ' ' + user.lastName}} created</h3>
            <button v-on:click="resetForm()">Add another User</button>
        </div>
    </div>
</template>

<script>
// Imports

export default {
    data () {
        return {
            user: {},
            submitted: ''
        }
    },
    methods: {
        checkForm:function(e) {
            this.errors = [];
            if(!this.user.firstName) this.errors.push("First Name required.");
            if(!this.user.lastName) this.errors.push("Last Name required.");
            if(!this.errors.length){
                this.post();
            }
            else{
                console.log("there are errors");
                e.preventDefault();
            } 
        },
        post: function(){
            this.$http.post('http://localhost:5000/api/user', this.user).then(function(data){
                console.log(data);
                this.submitted = true;
            });
        },
        resetForm: function() {
            this.submitted = false;
            this.user = {}
        }
    }
}
</script>

<style scoped>
#new-User *{
    box-sizing: border-box;
}
#new-User{
    margin: 20px auto;
    max-width: 600px;
    padding: 20px;
}
label{
    display: block;
    margin: 20px 0 10px;
}
input[type="text"], textarea, select{
    display: block;
    width: 100%;
    padding: 8px;
}
h3{
    margin-top: 10px;
}
</style>