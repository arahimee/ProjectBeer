<template>
  <div>
    <br/>
    <article class="media">
      <figure class="media-left">
        <p class="image">
          <img v-bind:src="beer.Labels.Medium" v-if="beer.Labels != null">
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
              <small v-else> 0 alcohol by volume  </small>
              <span class="icon has-text-info">
                <i class="fa fa-clock-o"></i>
              </span>
              <small> Last updated on {{beer.UpdateDate}} </small>
            </div>
          </div>
        </nav>
      </div>
    </article>
    <br/>

    <article class="box" v-if="beer.Style != null">
      <h4>
        <span class="icon is-medium has-text-primary">
          <i class="fa fa-info"></i>
        </span> Style
      </h4>
      <div class="media">
        <div class="media-content">
          <div class="content">
            <p>
              <strong>Name:</strong> {{beer.Style.Name}}
              <br/>
              <strong>Category:</strong> {{beer.Style.Category.Name}}
              <div>
                {{beer.Style.Description}}
              </div>
            </p>
          </div>
          <nav class="level is-mobile">
            <div class="level-left">
              <div class="level-item">
                <span class="icon has-text-info">
                  <i class="fa fa-percent"></i>
                </span>
                <small v-if="beer.Style.AbvMin != null"> {{beer.Style.AbvMin}} Min alcohol by volume  </small>
                <small v-else> 0 Min alcohol by volume  </small>
                <span class="icon has-text-info">
                  <i class="fa fa-percent"></i>
                </span>
                <small v-if="beer.Style.AbvMax != null"> {{beer.Style.AbvMax}} Max alcohol by volume  </small>
                <small v-else> 0 Max alcohol by volume  </small>

                <span class="icon has-text-info">
                  <i class="fa fa-clock-o"></i>
                </span>
                <small> Last updated on {{beer.Style.UpdateDate}} </small>
              </div>
            </div>
          </nav>
        </div>
      </div>
    </article>

    <article class="box" v-if="beer.Glass != null">
      <h4>
        <span class="icon is-medium has-text-primary">
          <i class="fa fa-beer"></i>
        </span> How beer is served
      </h4>
      <div class="media">
        <div class="media-content">
          <div class="content">
            <p>
              <strong>Glass:</strong> {{beer.Glass.Name}}
              <br/>
              <strong>Serving temperature:</strong> {{beer.ServingTemperatureDisplay}}
            </p>
          </div>
        </div>
      </div>
    </article>
  </div>
</template>

<script>
  import axios from "axios";

  export default {
    head() {
        return {
            title: this.beer != null ? this.beer.Name : ""
        };
    },
    data() {
        return {
            beer: {}
        };
    },
    mounted() {
        this.getBeer(this.$route.params.id);
    },
    methods: {
        getBeer: async function(id) {
            const res = await axios.get(
                `http://localhost:50630/api/beers/${id}?key=${this.$root.ApiKey}`
            );
            this.beer = res.data;
        }
    }
  }

</script>
