<template>
  <div class="wrapper">
    <Login v-if="this.$route.path.includes(['/login'])" />

    <div class="main-app" v-if="!this.$route.path.includes(['/login'])">
      <Header />
      <SidebarMenu />

      <div class="content-wrapper">
        <router-view />
      </div>

      <Footer />

      <aside class="control-sidebar control-sidebar-dark"></aside>
      <div id="sidebar-overlay" v-on:click="toggleMenuSidebar"></div>
    </div>
  </div>
</template>

<script>
import Header from "./components/layout/Header";
import SidebarMenu from "./components/layout/SidebarMenu";
import Footer from "./components/layout/Footer";
import Login from "./components/login/Login";
import UserService from "././_services/users-service";

export default {
  name: "App",
  components: {
    Header,
    SidebarMenu,
    Footer,
    Login,
  },
  data() {
    return {
      user: null,
      users: [],
    };
  },
  methods: {
    toggleMenuSidebar() {
      if (document.body.classList.contains("sidebar-open")) {
        document.body.classList.remove("sidebar-open");
        document.body.classList.add("sidebar-collapse");
      } else if (document.body.classList.contains("sidebar-collapse")) {
        document.body.classList.remove("sidebar-collapse");
        document.body.classList.add("sidebar-open");
      }
    }
  },
  mounted() {
    UserService.seedUsers();
  },
};
</script>

<style>
@import url("https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css");
@import url("https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700");
@import url("../node_modules/bootstrap/dist/css/bootstrap.min.css");
@import url("../node_modules/admin-lte/dist/css/adminlte.min.css");
@import url("../node_modules/@fortawesome/fontawesome-free/css/all.min.css");
</style>
