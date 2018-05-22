<template>
    <ul class="beer-list">
        <li class="beer-list-item box" v-for="beer in beers" v-bind:key="beer.Id">
            <article class="media">
                <figure class="media-left">
                    <p class="image" v-if="beer.Labels != null">
                        <img v-bind:src="beer.Labels.Icon">
                    </p>
                </figure>
                <div class="media-content">
                    <div class="content">
                        <p>
                            <strong>{{beer.NameDisplay}}</strong>
                            <br>
                            <span class="tag is-danger is-rounded">{{beer.StatusDisplay}}</span>
                            &nbsp;&nbsp;
                            <span class="tag is-info is-rounded" v-if="beer.IsOrganic !== 'N'">Organic</span>
                        </p>
                    <div v-html="beer.Description"></div>
                    </div>
                    <nav class="level is-mobile">
                        <div class="level-left">
                            <div class="level-item">
                                <span class="icon has-text-info">
                                    <i class="fa fa-percent"></i>
                                </span>
                                <small v-if="beer.ABV != null"> {{beer.ABV}} alcohol by volume  </small>
                                <small v-else=""> 0 alcohol by volume  </small>
                                <span class="icon has-text-info">
                                    <i class="fa fa-clock-o"></i>
                                </span>
                                <small> Last updated on {{beer.UpdateDate}} </small>
                            </div>
                        </div>
                    </nav>
                </div>
                <div class="media-right">
                    <nuxt-link :to="{ name: 'Beer-id', params: {id: beer.Id}}">
                        <small>View detail </small>
                        <span class="icon">
                            <i class="fa fa-external-link"></i>
                        </span>
                    </nuxt-link>
                </div>
            </article>
        </li>
    </ul>
</template>

<script>
  export default{
    name: 'BeerList',
    props: {
        beers: Array
    }
  }
</script>