<template>
    <div>
        Sort by:
        <div class="select">
            <select v-bind:value="sortOption" v-on:change="$emit('sortOptionChanged', $event.target.value)">
                <option value='name'>Name</option>
                <option value='abv'>Alcohol by volume</option>
                <option value='isOrganic'>Is organic</option>
                <option value='status'>Status</option>
                <option value='updateDate'>Update date</option>
            </select>
        </div>
        <div class="select">
            <select v-bind:value="sortType" v-on:change="$emit('sortTypeChanged', $event.target.value)">
                <option value='asc'>Asc</option>
                <option value='desc'>Desc</option>
            </select>
        </div>
    </div>
</template>

<script>
export default {
    name: 'Sort',
    props:{
        sortOption: String,
        sortType: String
    }
}
</script>