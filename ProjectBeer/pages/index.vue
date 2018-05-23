<template>
    <div>
        <section class="hero is-bold">
            <div class="hero-body">
                <div class="container">
                    <h1 class="title">
                        Beers
                    </h1>
                    <h2 class="subtitle">
                        A lot of beers :)
                    </h2>
                </div>
            </div>
        </section>
        
        <Filters 
            :name="filter.name" v-on:filterByName="filter.name = $event"
            :abv="filter.abv" v-on:filterByAbv="filter.abv = $event"
            :status="filter.status" v-on:filterByStatus="filter.status = $event"
            :isOrganic="filter.isOrganic" v-on:filterIsOrganic="filter.isOrganic = $event ? 'Y' : 'N'">
        </Filters>

        <div class="media">
            <div class="media-content">
                Showing page {{currentPage}} of {{numberOfPages}} pages
            </div>
            <div class="media-right">
                <Sort 
                    :sortOption="selectedSortOption" v-on:sortOptionChanged="selectedSortOption = $event"
                    :sortType="selectedSortType" v-on:sortTypeChanged="selectedSortType = $event">
                </Sort>
            </div>
        </div>
        <br/>

        <Spinner :beers="beers"></Spinner>

        <div class="media" v-if="this.beers != null && this.beers.length == 0">
            <div clas="media-content">
                <span>No data available for the selected filters</span>            
            </div>
        </div>

        <BeerList :beers="beers"></BeerList>
        <br/>

        <div>
            <paginate
                :page-count="numberOfPages"
                :page-range="3"
                :click-handler="pageClicked"
                :prev-text="'Prev'"
                :next-text="'Next'"
                :page-class="'pagination-link'"
                :page-link-class="'pagination-link'"
                :prev-class="'pagination-previous'"
                :next-class="'pagination-next'"
                :active-class="'is-current'">
            </paginate>
        </div>
    </div>
</template>

<script>
    import axios from 'axios';
    import Spinner from '../components/Spinner.vue'
    import Filters from '../components/Filters.vue'
    import Sort from '../components/Sort.vue'
    import BeerList from '../components/BeerList.vue'

    export default {
        components: {
            Spinner,
            Filters,
            Sort,
            BeerList
        },
        head() {
            return {
                title: 'Project Beer'
            }
        },
        data() {
            return {
                beers: null,
                currentPage: 1,
                numberOfPages: 0,
                selectedSortOption: 'name',
                selectedSortType: 'asc',
                filter: {
                    name: '',
                    abv: 10,
                    isOrganic: 'Y',
                    status: 'verified'
                }
            }
        },
        watch: {
            'selectedSortOption': function(){
                this.refreshResult();
            },
            'selectedSortType': function(){
                this.refreshResult();
            },
            'filter.name': function(){
                this.refreshResult();
            },
            'filter.abv': function(){
                this.refreshResult();
            },
            'filter.isOrganic': function(){
                this.refreshResult();
            },
            'filter.status': function(){
                this.refreshResult();
            },
        },
        mounted() {
            this.getBeers();
        },
        methods: {
            getBeers: async function() {
                this.beers = null;
                var queryString = 'breweryDbApiKey=' + this.$root.ApiKey;
                queryString += '&pageNumber=' + this.currentPage;
                queryString += '&order=' + this.selectedSortOption;
                queryString+= '&sort=' + this.selectedSortType;
                queryString += '&name=' + this.filter.name;
                queryString += '&abv=-' + this.filter.abv;
                queryString += '&isOrganic=' + this.filter.isOrganic;
                queryString += '&status=' + this.filter.status;

                const res = await axios.get(`http://localhost:50630/api/beers?${queryString}`);
                
                this.beers = res.data.Data == null ? [] : res.data.Data;
                this.currentPage = res.data.CurrentPage;
                this.numberOfPages = res.data.NumberOfPages;
            },
            pageClicked: function(pageNumber){
                this.currentPage = pageNumber;
                this.getBeers();
            },
            refreshResult: function(){
                this.currentPage = 1;
                this.getBeers();
            }
        }
    }
</script>