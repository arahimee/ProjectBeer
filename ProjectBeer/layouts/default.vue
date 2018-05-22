<template>
    <div class="has-background-light">
        <nav class="navbar is-primary">
            <nuxt-link :to="{ name: 'index'}" class="navbar-brand ">
                    <div class='navbar-item'>
                        <span class="icon has-text-black is-medium">
                            <i class="fa fa-lg fa-beer"></i>
                        </span>
                    </div>
                    <div class='navbar-item title is-4'>
                        Project Beer
                    </div>
            </nuxt-link>
        </nav>
        <div class="container">
            <section v-if="!isApiKeyProvided" >
                <br/>
                <div class="field">
                    <label class="label">Please input your key to access the brewerydb API:</label>
                    <div class="control">
                        <input class="input" type="text" placeholder="Api Key" v-model="apiKey">
                    </div>
                    <br/>
                    <div class="control">
                        <button @click="saveApiKey" class="button is-primary">Enter web app</button>
                    </div>
                </div>
            </section>
            <nuxt v-else />
        </div>
    </div>
</template>

<style scoped>
    [v-cloak] {
        display: none;
    }
</style>

<script>
export default {
    head() {
        return {
            htmlAttrs: { lang: 'en' }
        }
    },
    data() {
        return {
            isApiKeyProvided: false,
            apiKey: ''
        }
    },
    methods: {
        saveApiKey: function(){
            this.$root['ApiKey'] = this.apiKey;
            this.isApiKeyProvided = true;
        }
    }
}
</script>
