<template>
    <div class="box columns">
            <div class="column">
                Filter by name
                <input class="input" type="text" placeholder="Enter exact name of beer" v-bind:value="name" 
                    v-on:keyup="$emit('filterByName', $event.target.value)">
            </div>
            <div class="column">
                Alcohol by volume: up to {{abv}} %
                <div>
                    <input class="slider is-success" step="1" min="0" max="100" v-bind:value="abv" type="range" 
                        v-on:change="$emit('filterByAbv', parseInt($event.target.value))">
                </div>
            </div>
            <div class="column is-two-fifths">
                Status
                <div class="buttons has-addons">
                    <button class="button" v-bind:class="{ 'is-success': status == 'verified' }" 
                        @click="$emit('filterByStatus','verified')">
                        Verified
                    </button>
                    
                    <button class="button" v-bind:class="{ 'is-success': status == 'new_unverified' }" 
                        @click="$emit('filterByStatus','new_unverified')">
                        New, Unverified
                    </button>
                    
                    <button class="button" v-bind:class="{ 'is-success': status == 'update_pending' }" 
                        @click="$emit('filterByStatus','update_pending')">
                        Update Pending
                    </button>
                </div>
            </div>
            <div class="column">
                Is organic
                <div class="buttons has-addons">
                    <button class="button" v-bind:class="{ 'is-success': isOrganic == 'Y' }"  
                        @click="$emit('filterIsOrganic', true)">
                        Yes
                    </button>
                    
                    <button class="button" v-bind:class="{ 'is-success': isOrganic == 'N' }" 
                    @click="$emit('filterIsOrganic', false)">
                        No
                    </button>
                </div>
            </div>
    </div>
</template>

<script>
export default {
    name: 'Filters',
    props: {
        name: String,
        abv: Number,
        isOrganic: String,
        status: String
    }
}
</script>