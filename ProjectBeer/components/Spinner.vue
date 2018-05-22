
<template>
    <div class="media" v-if="isLoading">
        <div clas="media-content">
            <i class="fa fa-spinner fa-pulse fa-3x fa-fw"></i>
            <span class="sr-only">Loading...</span>            
        </div>
    </div>
</template>

<script>
    export default {
        name: 'Spinner',
        props: {
            beers: Array
        },
        computed: {
            isLoading: function() {
                return this.beers == null;
            }
        }
    }
</script>