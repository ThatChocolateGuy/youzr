import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

// import { OktaAuth } from '@okta/okta-auth-js'
// import OktaVue from '@okta/okta-vue'

// const oktaAuth = new OktaAuth({
//   // issuer: 'https://{yourOktaDomain}.com/oauth2/default',
//   issuer: 'https://dev-66817409.okta.com/oauth2/default',
//   // clientId: '{clientId}',
//   clientId: '0oa9mwq2lYbt5kssU5d6',
//   redirectUri: `${window.location.origin}/login/callback`,
//   scopes: ['openid', 'profile', 'email']
// })

createApp(App).use(router)
  // .use(OktaVue, { oktaAuth })
  .mount('#app')
